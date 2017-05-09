namespace ApplicazioneMedico
{
    partial class ApplicazioneMedico
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ApplicazioneMedico));
            this.mainNav = new System.Windows.Forms.MenuStrip();
            this.menuFile = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuPazienti = new System.Windows.Forms.ToolStripMenuItem();
            this.menuCertificati = new System.Windows.Forms.ToolStripMenuItem();
            this.menuPatologie = new System.Windows.Forms.ToolStripMenuItem();
            this.menuHelp = new System.Windows.Forms.ToolStripMenuItem();
            this.lblAggiornamento = new System.Windows.Forms.Label();
            this.picBox = new System.Windows.Forms.PictureBox();
            this.pnlAggiornamento = new System.Windows.Forms.Panel();
            this.pnlPazienti = new System.Windows.Forms.Panel();
            this.grdPazienti = new System.Windows.Forms.DataGridView();
            this.btnPazientiMostraFiltri = new System.Windows.Forms.Button();
            this.pnlCertificati = new System.Windows.Forms.Panel();
            this.grdCertificati = new System.Windows.Forms.DataGridView();
            this.btnCertificatiMostraFiltri = new System.Windows.Forms.Button();
            this.pnlPatologie = new System.Windows.Forms.Panel();
            this.grdPatologie = new System.Windows.Forms.DataGridView();
            this.btnPatologieMostraFiltri = new System.Windows.Forms.Button();
            this.mainNav.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picBox)).BeginInit();
            this.pnlAggiornamento.SuspendLayout();
            this.pnlPazienti.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdPazienti)).BeginInit();
            this.pnlCertificati.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdCertificati)).BeginInit();
            this.pnlPatologie.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdPatologie)).BeginInit();
            this.SuspendLayout();
            // 
            // mainNav
            // 
            this.mainNav.BackColor = System.Drawing.Color.Transparent;
            this.mainNav.Font = new System.Drawing.Font("Segoe UI", 25F);
            this.mainNav.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuFile,
            this.menuPazienti,
            this.menuCertificati,
            this.menuPatologie,
            this.menuHelp});
            this.mainNav.Location = new System.Drawing.Point(0, 0);
            this.mainNav.Name = "mainNav";
            this.mainNav.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.mainNav.Size = new System.Drawing.Size(1506, 33);
            this.mainNav.TabIndex = 5;
            this.mainNav.Text = "menuStrip1";
            // 
            // menuFile
            // 
            this.menuFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem});
            this.menuFile.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.menuFile.ForeColor = System.Drawing.SystemColors.Control;
            this.menuFile.Name = "menuFile";
            this.menuFile.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.menuFile.Size = new System.Drawing.Size(53, 29);
            this.menuFile.Text = "File";
            this.menuFile.DropDownClosed += new System.EventHandler(this.menuFile_DropDownClosed);
            this.menuFile.MouseEnter += new System.EventHandler(this.menuFile_MouseEnter);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.BackColor = System.Drawing.Color.White;
            this.exitToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(190, 26);
            this.exitToolStripMenuItem.Text = "Exit     (ALT+F4)";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // menuPazienti
            // 
            this.menuPazienti.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.menuPazienti.ForeColor = System.Drawing.SystemColors.Control;
            this.menuPazienti.Name = "menuPazienti";
            this.menuPazienti.Size = new System.Drawing.Size(91, 29);
            this.menuPazienti.Text = "Pazienti";
            this.menuPazienti.DropDownClosed += new System.EventHandler(this.menuPazienti_DropDownClosed);
            this.menuPazienti.Click += new System.EventHandler(this.menuPazienti_Click);
            this.menuPazienti.MouseEnter += new System.EventHandler(this.menuPazienti_MouseEnter);
            // 
            // menuCertificati
            // 
            this.menuCertificati.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.menuCertificati.ForeColor = System.Drawing.SystemColors.Control;
            this.menuCertificati.Name = "menuCertificati";
            this.menuCertificati.Size = new System.Drawing.Size(105, 29);
            this.menuCertificati.Text = "Certificati";
            this.menuCertificati.DropDownClosed += new System.EventHandler(this.menuCertificati_DropDownClosed);
            this.menuCertificati.Click += new System.EventHandler(this.menuCertificati_Click);
            this.menuCertificati.MouseEnter += new System.EventHandler(this.menuCertificati_MouseEnter);
            // 
            // menuPatologie
            // 
            this.menuPatologie.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.menuPatologie.ForeColor = System.Drawing.SystemColors.Control;
            this.menuPatologie.Name = "menuPatologie";
            this.menuPatologie.Size = new System.Drawing.Size(104, 29);
            this.menuPatologie.Text = "Patologie";
            this.menuPatologie.DropDownClosed += new System.EventHandler(this.menuPatologie_DropDownClosed);
            this.menuPatologie.Click += new System.EventHandler(this.menuPatologie_Click);
            this.menuPatologie.MouseEnter += new System.EventHandler(this.menuPatologie_MouseEnter);
            // 
            // menuHelp
            // 
            this.menuHelp.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.menuHelp.ForeColor = System.Drawing.SystemColors.Control;
            this.menuHelp.Name = "menuHelp";
            this.menuHelp.Size = new System.Drawing.Size(63, 29);
            this.menuHelp.Text = "Help";
            this.menuHelp.DropDownClosed += new System.EventHandler(this.menuHelp_DropDownClosed);
            this.menuHelp.MouseEnter += new System.EventHandler(this.menuHelp_MouseEnter);
            // 
            // lblAggiornamento
            // 
            this.lblAggiornamento.AutoSize = true;
            this.lblAggiornamento.Font = new System.Drawing.Font("Georgia", 30.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAggiornamento.Location = new System.Drawing.Point(364, 238);
            this.lblAggiornamento.Name = "lblAggiornamento";
            this.lblAggiornamento.Size = new System.Drawing.Size(126, 47);
            this.lblAggiornamento.TabIndex = 2;
            this.lblAggiornamento.Text = "label1";
            // 
            // picBox
            // 
            this.picBox.Image = ((System.Drawing.Image)(resources.GetObject("picBox.Image")));
            this.picBox.Location = new System.Drawing.Point(327, 20);
            this.picBox.Name = "picBox";
            this.picBox.Size = new System.Drawing.Size(196, 202);
            this.picBox.TabIndex = 1;
            this.picBox.TabStop = false;
            // 
            // pnlAggiornamento
            // 
            this.pnlAggiornamento.BackColor = System.Drawing.Color.Transparent;
            this.pnlAggiornamento.Controls.Add(this.picBox);
            this.pnlAggiornamento.Controls.Add(this.lblAggiornamento);
            this.pnlAggiornamento.Location = new System.Drawing.Point(0, 0);
            this.pnlAggiornamento.Name = "pnlAggiornamento";
            this.pnlAggiornamento.Size = new System.Drawing.Size(1506, 772);
            this.pnlAggiornamento.TabIndex = 6;
            // 
            // pnlPazienti
            // 
            this.pnlPazienti.BackColor = System.Drawing.Color.Transparent;
            this.pnlPazienti.Controls.Add(this.grdPazienti);
            this.pnlPazienti.Controls.Add(this.btnPazientiMostraFiltri);
            this.pnlPazienti.Location = new System.Drawing.Point(-1, 56);
            this.pnlPazienti.Name = "pnlPazienti";
            this.pnlPazienti.Size = new System.Drawing.Size(1495, 716);
            this.pnlPazienti.TabIndex = 8;
            // 
            // grdPazienti
            // 
            this.grdPazienti.AllowUserToAddRows = false;
            this.grdPazienti.AllowUserToDeleteRows = false;
            this.grdPazienti.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.grdPazienti.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdPazienti.Location = new System.Drawing.Point(13, 257);
            this.grdPazienti.Name = "grdPazienti";
            this.grdPazienti.ReadOnly = true;
            this.grdPazienti.Size = new System.Drawing.Size(1460, 428);
            this.grdPazienti.TabIndex = 1;
            // 
            // btnPazientiMostraFiltri
            // 
            this.btnPazientiMostraFiltri.Font = new System.Drawing.Font("Segoe UI", 20.25F);
            this.btnPazientiMostraFiltri.Location = new System.Drawing.Point(571, 20);
            this.btnPazientiMostraFiltri.Name = "btnPazientiMostraFiltri";
            this.btnPazientiMostraFiltri.Size = new System.Drawing.Size(345, 87);
            this.btnPazientiMostraFiltri.TabIndex = 0;
            this.btnPazientiMostraFiltri.Text = "Mostra Filtri";
            this.btnPazientiMostraFiltri.UseVisualStyleBackColor = true;
            // 
            // pnlCertificati
            // 
            this.pnlCertificati.BackColor = System.Drawing.Color.Transparent;
            this.pnlCertificati.Controls.Add(this.grdCertificati);
            this.pnlCertificati.Controls.Add(this.btnCertificatiMostraFiltri);
            this.pnlCertificati.Location = new System.Drawing.Point(6, 36);
            this.pnlCertificati.Name = "pnlCertificati";
            this.pnlCertificati.Size = new System.Drawing.Size(1495, 713);
            this.pnlCertificati.TabIndex = 9;
            // 
            // grdCertificati
            // 
            this.grdCertificati.AllowUserToAddRows = false;
            this.grdCertificati.AllowUserToDeleteRows = false;
            this.grdCertificati.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.grdCertificati.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdCertificati.Location = new System.Drawing.Point(13, 255);
            this.grdCertificati.Name = "grdCertificati";
            this.grdCertificati.ReadOnly = true;
            this.grdCertificati.Size = new System.Drawing.Size(1460, 428);
            this.grdCertificati.TabIndex = 1;
            // 
            // btnCertificatiMostraFiltri
            // 
            this.btnCertificatiMostraFiltri.Font = new System.Drawing.Font("Segoe UI", 20.25F);
            this.btnCertificatiMostraFiltri.Location = new System.Drawing.Point(571, 20);
            this.btnCertificatiMostraFiltri.Name = "btnCertificatiMostraFiltri";
            this.btnCertificatiMostraFiltri.Size = new System.Drawing.Size(345, 87);
            this.btnCertificatiMostraFiltri.TabIndex = 0;
            this.btnCertificatiMostraFiltri.Text = "Mostra Filtri";
            this.btnCertificatiMostraFiltri.UseVisualStyleBackColor = true;
            // 
            // pnlPatologie
            // 
            this.pnlPatologie.BackColor = System.Drawing.Color.Transparent;
            this.pnlPatologie.Controls.Add(this.grdPatologie);
            this.pnlPatologie.Controls.Add(this.btnPatologieMostraFiltri);
            this.pnlPatologie.Location = new System.Drawing.Point(6, 34);
            this.pnlPatologie.Name = "pnlPatologie";
            this.pnlPatologie.Size = new System.Drawing.Size(1495, 716);
            this.pnlPatologie.TabIndex = 10;
            // 
            // grdPatologie
            // 
            this.grdPatologie.AllowUserToAddRows = false;
            this.grdPatologie.AllowUserToDeleteRows = false;
            this.grdPatologie.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.grdPatologie.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdPatologie.Location = new System.Drawing.Point(13, 257);
            this.grdPatologie.Name = "grdPatologie";
            this.grdPatologie.ReadOnly = true;
            this.grdPatologie.Size = new System.Drawing.Size(1460, 428);
            this.grdPatologie.TabIndex = 1;
            // 
            // btnPatologieMostraFiltri
            // 
            this.btnPatologieMostraFiltri.Font = new System.Drawing.Font("Segoe UI", 20.25F);
            this.btnPatologieMostraFiltri.Location = new System.Drawing.Point(571, 20);
            this.btnPatologieMostraFiltri.Name = "btnPatologieMostraFiltri";
            this.btnPatologieMostraFiltri.Size = new System.Drawing.Size(345, 87);
            this.btnPatologieMostraFiltri.TabIndex = 0;
            this.btnPatologieMostraFiltri.Text = "Mostra Filtri";
            this.btnPatologieMostraFiltri.UseVisualStyleBackColor = true;
            // 
            // ApplicazioneMedico
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(154)))), ((int)(((byte)(222)))));
            this.BackgroundImage = global::ApplicazioneMedico.Properties.Resources.Background1;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1506, 784);
            this.Controls.Add(this.mainNav);
            this.Controls.Add(this.pnlPazienti);
            this.Controls.Add(this.pnlAggiornamento);
            this.Controls.Add(this.pnlCertificati);
            this.Controls.Add(this.pnlPatologie);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Georgia", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.mainNav;
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "ApplicazioneMedico";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Gestione Pazienti";
            this.SizeChanged += new System.EventHandler(this.ApplicazioneMedico_SizeChanged);
            this.mainNav.ResumeLayout(false);
            this.mainNav.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picBox)).EndInit();
            this.pnlAggiornamento.ResumeLayout(false);
            this.pnlAggiornamento.PerformLayout();
            this.pnlPazienti.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdPazienti)).EndInit();
            this.pnlCertificati.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdCertificati)).EndInit();
            this.pnlPatologie.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdPatologie)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip mainNav;
        private System.Windows.Forms.ToolStripMenuItem menuFile;
        private System.Windows.Forms.Label lblAggiornamento;
        private System.Windows.Forms.PictureBox picBox;
        private System.Windows.Forms.Panel pnlAggiornamento;
        private System.Windows.Forms.Panel pnlPazienti;
        private System.Windows.Forms.Button btnPazientiMostraFiltri;
        private System.Windows.Forms.DataGridView grdPazienti;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem menuPazienti;
        private System.Windows.Forms.ToolStripMenuItem menuCertificati;
        private System.Windows.Forms.ToolStripMenuItem menuPatologie;
        private System.Windows.Forms.ToolStripMenuItem menuHelp;
        private System.Windows.Forms.Panel pnlCertificati;
        private System.Windows.Forms.DataGridView grdCertificati;
        private System.Windows.Forms.Button btnCertificatiMostraFiltri;
        private System.Windows.Forms.Panel pnlPatologie;
        private System.Windows.Forms.DataGridView grdPatologie;
        private System.Windows.Forms.Button btnPatologieMostraFiltri;
    }
}

