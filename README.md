# printservice35
 Print Service Windows Application for ZPL and A4 Printers

Nugets Package:

Microsoft.Bcl.AsyncInterfaces

Microsoft.Extensions.Configuration

Microsoft.Net.Http.Headers

Newtonsoft.Json

Pdfium_x86Dll

PdfiumViewer

PDFsharp

RestSharp

websocket-sharp.clone

System.Text.Encodings.Web

System.Threading.Tasks.Extensions

System.ValueTuple

System.Memory

===================================================================================================================================

Manual de Instruções para o Programa PrintService35
Introdução

O PrintService35 é um programa que atua como um WebSocket com interface gráfica, projetado para receber comandos e imprimir etiquetas ZPL em uma impressora Zebra ou arquivos PDF em uma impressora A4. Este manual fornecerá orientações detalhadas sobre como configurar e utilizar o programa.

Configuração Inicial

Passo 1: Escolher a Impressora A4

1. Abra o programa PrintService35.
2. Na interface gráfica, localize o dropdown list (lista suspensa) rotulado como "Impressora A4".
3. Clique na lista suspensa e selecione a impressora A4 desejada.

Passo 2: Escolher a Impressora Zebra

1. Na mesma interface gráfica, localize o dropdown list (lista suspensa) rotulado como "Impressora Zebra".
2. Clique na lista suspensa e selecione a impressora Zebra desejada.

Passo 3: Informar a Porta do WebSocket

1. Na interface gráfica, localize o campo de texto rotulado como "Porta do WebSocket".
2. Digite o número da porta desejada (por exemplo, 9344).

Passo 4: Reiniciar a Aplicação para Aplicar as Configurações

1. Após configurar as impressoras e a porta do WebSocket, localize o botão "Reiniciar" na interface gráfica.
2. Clique no botão "Reiniciar" para aplicar as configurações e reiniciar a aplicação.

Funcionalidades

Imprimir A4

Para imprimir um arquivo PDF em uma impressora A4, envie o comando no seguinte formato:

<pdf>{nome_do_arquivo.pdf}

Substitua {nome_do_arquivo.pdf} pelo nome do arquivo PDF que deseja imprimir.
O arquivo será enviado para a impressora A4 selecionada.

Imprimir Arquivo
Para imprimir um arquivo de texto ou outro tipo de arquivo suportado, envie o comando no seguinte formato:

<file>{nome_do_arquivo.txt}

Substitua {nome_do_arquivo.txt} pelo nome do arquivo que deseja imprimir.
O arquivo será enviado para a impressora A4 selecionada.

Imprimir Etiqueta ZPL
Se o comando enviado não contiver a TAG <pdf> ou <file>, o programa assumirá que o conteúdo é um código ZPL e o enviará para a impressora Zebra. Exemplo de comando:

^XA^FO50,50^ADN,36,20^FDHello, World!^FS^XZ

Exemplo de Uso

Configuração
1. Selecione "HP LaserJet 1020" no dropdown list "Impressora A4".
2. Selecione "Zebra ZP 450" no dropdown list "Impressora Zebra".
3. Digite 9344 no campo de texto da porta do WebSocket.
4. Clique no botão "Reiniciar" para aplicar as configurações.

Comandos de Impressão

1. Para imprimir um arquivo PDF:
<pdf>{documento.pdf}

2. Para imprimir um arquivo de texto:
<file>{documento.txt}

3. Para imprimir um código ZPL:
^XA^FO50,50^ADN,36,20^FDHello, World!^FS^XZ

Com estas instruções, você estará apto a configurar e utilizar o PrintService35 para gerenciar suas impressões de maneira eficiente e eficaz.



