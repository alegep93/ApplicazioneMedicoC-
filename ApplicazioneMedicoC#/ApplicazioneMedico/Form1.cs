using ApplicazioneMedico.DAO;
using ApplicazioneMedico.Data;
using ApplicazioneMedico.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ApplicazioneMedico
{
    public partial class ApplicazioneMedico : Form
    {
        Timer timer = new Timer();

        public ApplicazioneMedico()
        {
            InitializeComponent();

            //Regolo la grandezza dei panel
            setItemsWidthAndHeight();
            setItemsPosition();

            //Rimane 2 secondi e si chiude simulando l'aggiornamento dei dati
            pnlAggiornamento.Visible = true;
            pnlAggiornamento.BringToFront();
            timer.Interval = 2000;
            timer.Tick += new EventHandler(timer_Tick);
            timer.Start();

            //Mostro il pannello dei pazienti e compilo la griglia
            BringPanelToFront(true, false, false);
            CreateInfoColumn();
            BindGridPazienti();

            JSONReader.GetJsonString();
        }

        /* Metodo che viene richiamato alla fine del timer */
        void timer_Tick(object sender, EventArgs e)
        {
            pnlAggiornamento.Visible = false;
        }

        /* Eventi Click */
        private void menuPazienti_Click(object sender, EventArgs e)
        {
            BringPanelToFront(true, false, false);
            BindGridPazienti();
        }
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void menuCertificati_Click(object sender, EventArgs e)
        {
            BindGridCertificati();
            BringPanelToFront(false, true, false);
        }
        private void menuPatologie_Click(object sender, EventArgs e)
        {
            BindGridPatologie();
            BringPanelToFront(false, false, true);
        }

        /* HELPERS */
        protected void BindGridPazienti()
        {
            BindingSource bs = new BindingSource();
            bs.DataSource = PazientiDAO.GetDataTablePazienti();
            grdPazienti.DataSource = bs;
            grdPazienti.Columns[1].Visible = false;
            grdPazienti.Columns[14].Visible = false;
            grdPazienti.Columns[15].Visible = false;
            grdPazienti.Columns[16].Visible = false;
            grdPazienti.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }
        protected void BindGridCertificati()
        {
            BindingSource bs = new BindingSource();
            bs.DataSource = CertificatiDAO.GetDataTableCertificati();
            grdCertificati.DataSource = bs;
            grdCertificati.Columns[0].Visible = false;
            grdCertificati.Columns[2].Visible = false;
            grdCertificati.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }
        protected void BindGridPatologie()
        {
            BindingSource bs = new BindingSource();
            bs.DataSource = PatologieDAO.GetDataTablePatologie();
            grdPatologie.DataSource = bs;
            grdPatologie.Columns[0].Visible = false;
            grdPatologie.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }
        protected void CreateInfoColumn()
        {
            Image myImage = Image.FromFile(@"C:\Users\admin\Documents\Alessandro\ProjectWork\ApplicazioneMedicoC#\ApplicazioneMedico\Images\info.png");
            Bitmap imgResized = new Bitmap(myImage, new Size(20, 20));
            DataGridViewImageColumn iconColumn = new DataGridViewImageColumn();
            iconColumn.Image = imgResized;
            iconColumn.Name = "Info";
            iconColumn.HeaderText = "";
            grdPazienti.Columns.Insert(0, iconColumn);
        }
        protected void BringPanelToFront(bool bringPnlPazienti, bool bringPnlCertificati, bool bringPnlPatologie)
        {
            pnlPazienti.Visible = bringPnlPazienti;
            pnlCertificati.Visible = bringPnlCertificati;
            pnlPatologie.Visible = bringPnlPatologie;
        }
        protected void setItemsWidthAndHeight()
        {
            //Larghezza
            pnlAggiornamento.Width = pnlPazienti.Width = pnlCertificati.Width = pnlPatologie.Width = pnlAggiornamento.Parent.ClientSize.Width;

            //Altezza
            pnlAggiornamento.Height = pnlAggiornamento.Parent.ClientSize.Height;
            pnlPazienti.Height = pnlCertificati.Height = pnlPatologie.Height = (pnlAggiornamento.Parent.ClientSize.Height - mainNav.Height);

            //TopLeft
            pnlAggiornamento.Left = pnlPazienti.Left = pnlCertificati.Left = pnlPatologie.Left = 0;
            pnlAggiornamento.Top = 0;
            pnlPazienti.Top = pnlCertificati.Top = pnlPatologie.Top = mainNav.Height;
        }
        protected void setItemsPosition()
        {
            picBox.Left = (pnlAggiornamento.Width - picBox.Width) / 2;
            picBox.Top = (pnlAggiornamento.Height - picBox.Height) / 3;

            lblAggiornamento.Text = "Aggiornamento in corso...";
            lblAggiornamento.Left = (picBox.Parent.ClientSize.Width - lblAggiornamento.Width) / 2;
            lblAggiornamento.Top = (picBox.Top + 250);

            picBox.Refresh();
            lblAggiornamento.Refresh();

            //Centratura dei pulsanti mostra filtri
            btnPazientiMostraFiltri.Left = btnCertificatiMostraFiltri.Left = btnPatologieMostraFiltri.Left = (pnlPatologie.ClientSize.Width - btnPatologieMostraFiltri.Width) / 2;
            btnPazientiMostraFiltri.Top = btnCertificatiMostraFiltri.Top = btnPatologieMostraFiltri.Top = 50;
        }

        /* Metodi per il Menù */
        private void menuFile_MouseEnter(object sender, EventArgs e)
        {
            menuFile.ForeColor = Color.Black;
        }
        private void menuFile_DropDownClosed(object sender, EventArgs e)
        {
            menuFile.ForeColor = Color.White;
        }
        private void menuPazienti_MouseEnter(object sender, EventArgs e)
        {
            menuPazienti.ForeColor = Color.Black;
        }
        private void menuPazienti_DropDownClosed(object sender, EventArgs e)
        {
            menuPazienti.ForeColor = Color.White;
        }
        private void menuCertificati_MouseEnter(object sender, EventArgs e)
        {
            menuCertificati.ForeColor = Color.Black;
        }
        private void menuCertificati_DropDownClosed(object sender, EventArgs e)
        {
            menuCertificati.ForeColor = Color.White;
        }
        private void menuPatologie_MouseEnter(object sender, EventArgs e)
        {
            menuPatologie.ForeColor = Color.Black;
        }
        private void menuPatologie_DropDownClosed(object sender, EventArgs e)
        {
            menuPatologie.ForeColor = Color.White;
        }
        private void menuHelp_MouseEnter(object sender, EventArgs e)
        {
            menuHelp.ForeColor = Color.Black;
        }
        private void menuHelp_DropDownClosed(object sender, EventArgs e)
        {
            menuHelp.ForeColor = Color.White;
        }

        private void ApplicazioneMedico_SizeChanged(object sender, EventArgs e)
        {
            setItemsWidthAndHeight();
            setItemsPosition();
        }
    }
}
