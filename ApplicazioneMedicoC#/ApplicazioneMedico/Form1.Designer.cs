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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ApplicazioneMedico));
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.picBox = new System.Windows.Forms.PictureBox();
            this.lblAggiornamento = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.picBox)).BeginInit();
            this.SuspendLayout();
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // picBox
            // 
            this.picBox.Image = ((System.Drawing.Image)(resources.GetObject("picBox.Image")));
            this.picBox.Location = new System.Drawing.Point(323, 151);
            this.picBox.Name = "picBox";
            this.picBox.Size = new System.Drawing.Size(196, 202);
            this.picBox.TabIndex = 1;
            this.picBox.TabStop = false;
            this.picBox.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // lblAggiornamento
            // 
            this.lblAggiornamento.AutoSize = true;
            this.lblAggiornamento.Font = new System.Drawing.Font("Georgia", 30.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAggiornamento.Location = new System.Drawing.Point(363, 388);
            this.lblAggiornamento.Name = "lblAggiornamento";
            this.lblAggiornamento.Size = new System.Drawing.Size(126, 47);
            this.lblAggiornamento.TabIndex = 2;
            this.lblAggiornamento.Text = "label1";
            this.lblAggiornamento.Click += new System.EventHandler(this.label1_Click);
            // 
            // ApplicazioneMedico
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(870, 626);
            this.Controls.Add(this.lblAggiornamento);
            this.Controls.Add(this.picBox);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Georgia", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "ApplicazioneMedico";
            this.Text = "i\'Medico";
            ((System.ComponentModel.ISupportInitialize)(this.picBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.PictureBox picBox;
        private System.Windows.Forms.Label lblAggiornamento;
    }
}

