using System;
using System.Diagnostics;
using System.Drawing.Printing;
using System.Threading;
using System.Windows.Forms;

namespace printservice35
{
    public partial class frmPrograma : Form
    {
        public frmPrograma()
        {
            InitializeComponent();
        }

        private void frmPrograma_Load(object sender, EventArgs e)
        {
            string pkInstalledPrinters;
            for (int i = 0; i < PrinterSettings.InstalledPrinters.Count; i++)
            {
                pkInstalledPrinters = PrinterSettings.InstalledPrinters[i];
                cbxZebra.Items.Add(pkInstalledPrinters);
                cbxA4.Items.Add(pkInstalledPrinters);
            }

            cbxZebra.SelectedItem = Properties.Settings.Default.printZebra;
            cbxA4.SelectedItem = Properties.Settings.Default.printA4;

            if (Properties.Settings.Default.port.ToString() != "0")
            {
                txtPort.Text = Properties.Settings.Default.port.ToString();
            }

            write("Server started at ws://localhost:" + txtPort.Text+ " " + DateTime.Now);
            btnReiniciar.Enabled = false;
        }

        public void write(string texto)
        {
            console.Text = console.Text + texto +"\n";
            console.SelectionStart = console.Text.Length;

            // Move o cursor para o final do texto
            console.ScrollToCaret();
        }

        private void cbxZebra_SelectedIndexChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.printZebra = cbxZebra.Text;
            Properties.Settings.Default.Save();

            btnReiniciar.Enabled = true;
        }

        private void cbxA4_SelectedIndexChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.printA4 = cbxA4.Text;
            Properties.Settings.Default.Save();
            btnReiniciar.Enabled = true;
            
        }

        private void txtPort_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Properties.Settings.Default.port = Convert.ToInt32(txtPort.Text);
                Properties.Settings.Default.Save();
                btnReiniciar.Enabled = true;
            } catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                write("Por favor digite um número válido!");
                btnReiniciar.Enabled = false;
            }
        }

        private void btnEncerrar_Click(object sender, EventArgs e)
        {
            string processName = "printservice35";

            foreach (Process process in Process.GetProcessesByName(processName))
            {
                process.Kill();
            }
        }

        private void btnReiniciar_Click(object sender, EventArgs e)
        {
            if (txtPort.Text.Trim() == "")
            {
                MessageBox.Show("Informe a porta do Websocket!", "Aviso!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPort.Focus();
            }
            else
            {
                Application.Restart();
            }
        }
    }
}
