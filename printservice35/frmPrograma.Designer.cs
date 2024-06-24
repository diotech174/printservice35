namespace printservice35
{
    partial class frmPrograma
    {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPrograma));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cbxZebra = new System.Windows.Forms.ComboBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cbxA4 = new System.Windows.Forms.ComboBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.txtPort = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtHost = new System.Windows.Forms.TextBox();
            this.console = new System.Windows.Forms.RichTextBox();
            this.btnEncerrar = new System.Windows.Forms.Button();
            this.btnReiniciar = new System.Windows.Forms.Button();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnInfo = new System.Windows.Forms.ToolStripButton();
            this.btnManual = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cbxZebra);
            this.groupBox1.Location = new System.Drawing.Point(13, 52);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(270, 82);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Zebra";
            // 
            // cbxZebra
            // 
            this.cbxZebra.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxZebra.FormattingEnabled = true;
            this.cbxZebra.Location = new System.Drawing.Point(19, 35);
            this.cbxZebra.Name = "cbxZebra";
            this.cbxZebra.Size = new System.Drawing.Size(235, 26);
            this.cbxZebra.TabIndex = 0;
            this.cbxZebra.SelectedIndexChanged += new System.EventHandler(this.cbxZebra_SelectedIndexChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.cbxA4);
            this.groupBox2.Location = new System.Drawing.Point(289, 52);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(270, 82);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Printer A4";
            // 
            // cbxA4
            // 
            this.cbxA4.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxA4.FormattingEnabled = true;
            this.cbxA4.Location = new System.Drawing.Point(18, 35);
            this.cbxA4.Name = "cbxA4";
            this.cbxA4.Size = new System.Drawing.Size(235, 26);
            this.cbxA4.TabIndex = 1;
            this.cbxA4.SelectedIndexChanged += new System.EventHandler(this.cbxA4_SelectedIndexChanged);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.txtPort);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.txtHost);
            this.groupBox3.Location = new System.Drawing.Point(13, 140);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(546, 69);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "WebSocket";
            // 
            // txtPort
            // 
            this.txtPort.Location = new System.Drawing.Point(442, 27);
            this.txtPort.Name = "txtPort";
            this.txtPort.Size = new System.Drawing.Size(87, 24);
            this.txtPort.TabIndex = 3;
            this.txtPort.TextChanged += new System.EventHandler(this.txtPort_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(400, 30);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(36, 18);
            this.label2.TabIndex = 2;
            this.label2.Text = "Port";
            // 
            // txtHost
            // 
            this.txtHost.Enabled = false;
            this.txtHost.Location = new System.Drawing.Point(19, 27);
            this.txtHost.Name = "txtHost";
            this.txtHost.Size = new System.Drawing.Size(235, 24);
            this.txtHost.TabIndex = 1;
            this.txtHost.Text = "localhost";
            // 
            // console
            // 
            this.console.BackColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.console.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.console.ForeColor = System.Drawing.SystemColors.Window;
            this.console.Location = new System.Drawing.Point(13, 215);
            this.console.Name = "console";
            this.console.ReadOnly = true;
            this.console.Size = new System.Drawing.Size(546, 190);
            this.console.TabIndex = 3;
            this.console.Text = "";
            // 
            // btnEncerrar
            // 
            this.btnEncerrar.Image = ((System.Drawing.Image)(resources.GetObject("btnEncerrar.Image")));
            this.btnEncerrar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnEncerrar.Location = new System.Drawing.Point(455, 412);
            this.btnEncerrar.Name = "btnEncerrar";
            this.btnEncerrar.Size = new System.Drawing.Size(104, 34);
            this.btnEncerrar.TabIndex = 5;
            this.btnEncerrar.Text = "Encerrar";
            this.btnEncerrar.UseVisualStyleBackColor = true;
            this.btnEncerrar.Click += new System.EventHandler(this.btnEncerrar_Click);
            // 
            // btnReiniciar
            // 
            this.btnReiniciar.Enabled = false;
            this.btnReiniciar.Image = ((System.Drawing.Image)(resources.GetObject("btnReiniciar.Image")));
            this.btnReiniciar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnReiniciar.Location = new System.Drawing.Point(345, 412);
            this.btnReiniciar.Name = "btnReiniciar";
            this.btnReiniciar.Size = new System.Drawing.Size(104, 34);
            this.btnReiniciar.TabIndex = 4;
            this.btnReiniciar.Text = "Reiniciar";
            this.btnReiniciar.UseVisualStyleBackColor = true;
            this.btnReiniciar.Click += new System.EventHandler(this.btnReiniciar_Click);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnManual,
            this.btnInfo,
            this.toolStripSeparator1});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(571, 38);
            this.toolStrip1.TabIndex = 6;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btnInfo
            // 
            this.btnInfo.Image = ((System.Drawing.Image)(resources.GetObject("btnInfo.Image")));
            this.btnInfo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnInfo.Name = "btnInfo";
            this.btnInfo.Size = new System.Drawing.Size(41, 35);
            this.btnInfo.Text = "Sobre";
            this.btnInfo.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnInfo.Click += new System.EventHandler(this.btnInfo_Click);
            // 
            // btnManual
            // 
            this.btnManual.Image = ((System.Drawing.Image)(resources.GetObject("btnManual.Image")));
            this.btnManual.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnManual.Name = "btnManual";
            this.btnManual.Size = new System.Drawing.Size(51, 35);
            this.btnManual.Text = "Manual";
            this.btnManual.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnManual.Click += new System.EventHandler(this.btnManual_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 38);
            // 
            // frmPrograma
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(571, 460);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.btnReiniciar);
            this.Controls.Add(this.btnEncerrar);
            this.Controls.Add(this.console);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "frmPrograma";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Print Service 35";
            this.Load += new System.EventHandler(this.frmPrograma_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cbxZebra;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox cbxA4;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox txtPort;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtHost;
        private System.Windows.Forms.RichTextBox console;
        private System.Windows.Forms.Button btnEncerrar;
        private System.Windows.Forms.Button btnReiniciar;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnInfo;
        private System.Windows.Forms.ToolStripButton btnManual;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
    }
}

