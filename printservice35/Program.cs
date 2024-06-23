
using PdfiumViewer;
using PdfSharp.Drawing;
using PdfSharp.Pdf.IO;
using PdfSharp.Pdf;
using System;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using WebSocketSharp;
using WebSocketSharp.Server;
using File = System.IO.File;

namespace printservice35
{
    internal static class NativeMethods
    {
        [DllImport("kernel32.dll")]
        internal static extern Boolean AllocConsole();
    }

    internal static class Program
    {

        /// <summary>
        /// Ponto de entrada principal para o aplicativo.
        /// </summary>
        [STAThread]
        static void Main()
        {
            string nomeZebra = Properties.Settings.Default.printZebra;
            string printA4 = Properties.Settings.Default.printA4;
            string port = Properties.Settings.Default.port.ToString();

            if (port.Trim() != "0")
            {
                Task.Run(() => Imprimir(nomeZebra));
            }

            // Configure e inicie a aplicação Windows Forms na thread principal
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Crie e inicie uma nova thread para o formulário
            Thread thread = new Thread(new ThreadStart(StartForm));
            thread.SetApartmentState(ApartmentState.STA);
            thread.Start();
        }

        static void StartForm()
        {
            frmPrograma frm = new frmPrograma();
            Application.Run(frm);
        }

        static void write(string texto)
        {
            // Verificar se o formulário está aberto e ativo
            frmPrograma myForm = Application.OpenForms.OfType<frmPrograma>().FirstOrDefault();

            if (myForm != null && myForm.Visible)
            {
                // Chamar o método no formulário encontrado
                myForm.Invoke(new Action(() => myForm.write(texto)));
            }
        }

        private static void Imprimir(String printer)
        {
            int port = Properties.Settings.Default.port;

            var server = new WebSocketServer(IPAddress.Parse("127.0.0.1"), port);
            server.Start();
            server.AddWebSocketService<EtiquetaService>("/");

            if (server.IsListening)
            {
                Console.WriteLine("Servidor iniciado: " + server.Realm + ":" + server.Port);
            }

            string teste = string.Empty;
            while (!"sair".Equals(teste))
            {
                teste = Console.ReadLine();
                server.WebSocketServices.Broadcast(teste);
            }
            server.Stop();
        }

        class EtiquetaService : WebSocketBehavior
        {
            private static string BytesToStringConverted(byte[] bytes)
            {
                using (var stream = new MemoryStream(bytes))
                {
                    using (var streamReader = new StreamReader(stream))
                    {
                        return streamReader.ReadToEnd();
                    }
                }
            }

            [Obsolete]
            protected override Task OnMessage(MessageEventArgs e)
            {
                string nomeZebra = Properties.Settings.Default.printZebra;
                string printA4 = Properties.Settings.Default.port.ToString();

                Etiqueta et = new Etiqueta();
                Byte[] b = new Byte[1024000];
                e.Data.Read(b, 0, b.Length);

                bool data_found = false;
                byte[] new_data = b.Reverse().SkipWhile(point =>
                {
                    if (data_found) return false;
                    if (point == 0x00) return true; else { data_found = true; return false; }
                }).Reverse().ToArray();

                String data = BytesToStringConverted(new_data);

                if (data.IndexOf("<pdf>") > -1)
                {
                    string impressora = printA4;
                    string pdf_file = data.Trim().Replace("<pdf>", "");

                    write("Solicitação de Impressao de PDF: " + DateTime.Now);
                    write("=====================================================================");
                    write("Arquivo:\n" + pdf_file);
                    write("=====================================================================");

                    scanFile(pdf_file);
                }
                else if (data.IndexOf("<file>") > -1)
                {
                    string impressora = printA4;
                    string file_toprint = data.Trim().Replace("<file>", "");

                    write("Solicitação de Impressao de Arquivo: " + DateTime.Now);
                    write("=====================================================================");

                    RawPrinterHelper.SendFileToPrinter(impressora, file_toprint);
                }
                else
                {
                    write("Solicitação de Impressao de Etiqueta: " + DateTime.Now);
                    write("=====================================================================");
                    write("ZPL:\n" + data);
                    write("=====================================================================");

                    et.print(nomeZebra, data.Trim());
                }

                return new Task(() =>
                {
                    Console.WriteLine("Imprimindo: " + data);
                });
            }

            [Obsolete]
            static void scanFile(string pdf)
            {
                // Obtém o caminho da pasta do usuário
                string userFolder = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);

                // Concatena o caminho da pasta com o nome da pasta desejada (por exemplo, Desktop)
                string targetFolder = Path.Combine(userFolder, "Downloads");

                bool encontrado = false;

                // Verifica se a pasta existe
                if (Directory.Exists(targetFolder))
                {
                    // Lista todos os arquivos na pasta
                    string[] files = Directory.GetFiles(targetFolder);

                    // Exibe os arquivos encontrados
                    foreach (string file in files)
                    {
                        if (file.Contains(pdf))
                        {
                            write("Arquivo encontrado: "+file + " " + DateTime.Now);
                            PrintPdf(file);
                            encontrado = true;
                        }
                    }
                }

                if (!encontrado)
                {
                    targetFolder = Path.Combine(userFolder, "Documentos");

                    // Verifica se a pasta existe
                    if (Directory.Exists(targetFolder))
                    {
                        // Lista todos os arquivos na pasta
                        string[] files = Directory.GetFiles(targetFolder);

                        // Exibe os arquivos encontrados
                        foreach (string file in files)
                        {
                            if (file.Contains(pdf))
                            {
                                write("Arquivo encontrado: " + file + " " + DateTime.Now);
                                PrintPdf(file);
                                encontrado = true;
                            }
                        }
                    }
                    if (!encontrado)
                    {
                        targetFolder = Path.Combine(userFolder, "Desktop");

                        // Verifica se a pasta existe
                        if (Directory.Exists(targetFolder))
                        {
                            // Lista todos os arquivos na pasta
                            string[] files = Directory.GetFiles(targetFolder);

                            // Exibe os arquivos encontrados
                            foreach (string file in files)
                            {
                                if (file.Contains(pdf))
                                {
                                    write("Arquivo encontrado: " + file + " " + DateTime.Now);
                                    PrintPdf(file);
                                    encontrado = true;
                                }
                            }
                        }
                    }

                    if (!encontrado)
                    {
                        write("Arquivo \"" + pdf + "\" não foi encontrado!" + " " + DateTime.Now);
                    }
                }
            }

            [Obsolete]
            static void AlterarMargensPdf(string inputFilePath, string outputFilePath, float margemEsquerda, float margemDireita, float margemSuperior, float margemInferior)
            {
                // Carrega o documento PDF existente
                PdfSharp.Pdf.PdfDocument document = PdfReader.Open(inputFilePath, PdfDocumentOpenMode.Import);

                // Cria um novo documento PDF para o output
                PdfSharp.Pdf.PdfDocument outputDocument = new PdfSharp.Pdf.PdfDocument();

                foreach (PdfPage page in document.Pages)
                {
                    // Calcula o novo tamanho da página
                    double newWidth = page.Width + margemEsquerda + margemDireita;
                    double newHeight = page.Height + margemSuperior + margemInferior;

                    // Cria uma nova página com o novo tamanho
                    PdfPage newPage = outputDocument.AddPage();
                    newPage.Width = newWidth;
                    newPage.Height = newHeight;

                    // Obtém os gráficos da nova página
                    XGraphics gfx = XGraphics.FromPdfPage(newPage);

                    // Desenha o conteúdo da página original na nova página com as novas margens
                    XGraphicsState state = gfx.Save();
                    gfx.TranslateTransform(margemEsquerda, margemSuperior);
                    gfx.DrawImage(XImage.FromFile(inputFilePath), 0, 0, page.Width, page.Height);
                    gfx.Restore(state);
                }

                // Salva o documento modificado
                outputDocument.Save(outputFilePath);
            }

            [Obsolete]
            static void PrintPdf(string pdfFilePath)
            {
                string targetFolder = System.IO.Path.GetTempPath();

                string timestamp = DateTime.Now.Year.ToString() 
                    + DateTime.Now.Month.ToString() 
                    + DateTime.Now.Day.ToString() 
                    + DateTime.Now.Hour.ToString() 
                    + DateTime.Now.Minute.ToString()
                    + DateTime.Now.Second.ToString()
                    + DateTime.Now.Millisecond.ToString();

                string outPutFile = targetFolder+"temp_"+timestamp+".pdf";

                AlterarMargensPdf(pdfFilePath, outPutFile, 10, 10, 10, 10);

                Task.Run(() => DeleteFile(pdfFilePath, 10)); //  apaga arquivo baixado após 10 segundos
                Task.Run(() => DeleteFile(outPutFile, 180)); //  apaga arquivo temporário após 3 minutos

                using (var document = PdfiumViewer.PdfDocument.Load(outPutFile))
                using (var printDocument = document.CreatePrintDocument())
                {
                    printDocument.PrinterSettings = new PrinterSettings
                    {
                        PrinterName = Properties.Settings.Default.printA4,

                    };

                    //printDocument.PrintController = new StandardPrintController(); // Ocultar diálogo de impressão
                    printDocument.Print();
                }
            }

            static async Task DeleteFile(string filePath, int secounds)
            {
                // Aguarda 5 minutos
                await Task.Delay(TimeSpan.FromSeconds(secounds));

                // Verifica se o arquivo ainda existe antes de tentar deletar
                if (File.Exists(filePath))
                {
                    try
                    {
                        // Deleta o arquivo
                        File.Delete(filePath);
                        write("Arquivo \""+filePath+"\" deletado com sucesso." + " " + DateTime.Now);
                    }
                    catch (Exception ex)
                    {
                        write("Ocorreu um erro ao deletar o arquivo \""+filePath+"\": "+ ex.Message + " " + DateTime.Now);
                    }
                }
                else
                {
                    write("O arquivo \""+filePath+"\" não existe mais ou já foi deletado." + " " + DateTime.Now);
                }
            }
        }
    }
}
