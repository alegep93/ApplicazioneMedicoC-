using ApplicazioneMedico.API;
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
        Timer t = new Timer();
        RootObject<Paziente> roPaz = null;
        RootObject<Patologia> roPat = null;
        RootObject<Certificato> roCert = null;
        bool response = false;

        public ApplicazioneMedico()
        {
            InitializeComponent();

            //GetOrSendData();
            SetFont();
            //Sync();

            //Mostro per 2 secondi il caricamento e poi passo al pannello dei pazienti
            Wait2Seconds();

            //Mostro il pannello dei pazienti
            BringPanelToFront(true, false, false, false, false);
            CreateInfoColumn();
            BindGridPazienti();
            FillComboBox();

            //Regolo la grandezza dei panel
            SetItemsWidthAndHeight();
            SetItemsPosition();
        }

        /* Eventi Click */
        private void menuPazienti_Click(object sender, EventArgs e)
        {
            BringPanelToFront(true, false, false, false, false);
            BindGridPazienti();
        }
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void menuCertificati_Click(object sender, EventArgs e)
        {
            BindGridCertificati();
            BringPanelToFront(false, true, false, false, false);
        }
        private void menuPatologie_Click(object sender, EventArgs e)
        {
            BindGridPatologie();
            BringPanelToFront(false, false, true, false, false);
        }
        private void btnPazientiSearch_Click(object sender, EventArgs e)
        {
            BindGridPazientiWithSearch();
        }
        private void btnNuovoCertificato_Click(object sender, EventArgs e)
        {
            BringPanelToFront(false, false, false, false, true);
            popolaCampiNuovoCertificato();
        }
        private void grdPazienti_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            Paziente p = new Paziente();

            if (e.ColumnIndex == 0)
            {
                BringPanelToFront(false, false, false, true, false);
                string codPaz = grdPazienti.Rows[e.RowIndex].Cells[15].Value.ToString();
                p = PazientiDAO.GetPaziente(codPaz);

                FillSchedaPaziente(p);
                BindGridCertificatiSingoloPaziente();
            }
        }
        private void subMenuSincronizza_Click(object sender, EventArgs e)
        {
            Sync();
        }
        private void btnInsNuovoCert_Click(object sender, EventArgs e)
        {
            Certificato c = new Certificato();
            popolaCertificato(c);
            CertificatiDAO.InsertCertificato(c);
        }
        private void btnAnnullaNuovoCert_Click(object sender, EventArgs e)
        {
            BringPanelToFront(false, false, false, true, false);
        }

        /* HELPERS */
        protected void BindGridPazienti()
        {
            BindingSource bs = new BindingSource();
            bs.DataSource = PazientiDAO.GetDataTablePazienti();
            grdPazienti.DataSource = bs;
            grdPazienti.Columns[1].Visible = false;
            grdPazienti.Columns[16].Visible = false;
            grdPazienti.Columns[17].Visible = false;
            grdPazienti.Columns[18].Visible = false;
            grdPazienti.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }
        protected void BindGridPazientiWithSearch()
        {
            BindingSource bs = new BindingSource();
            bs.DataSource = PazientiDAO.SearchPazienti(txtPazientiSearch.Text);
            grdPazienti.DataSource = bs;
            grdPazienti.Columns[1].Visible = false;
            grdPazienti.Columns[16].Visible = false;
            grdPazienti.Columns[17].Visible = false;
            grdPazienti.Columns[18].Visible = false;
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
        protected void BindGridCertificatiSingoloPaziente()
        {
            BindingSource bs = new BindingSource();
            bs.DataSource = CertificatiDAO.GetCertificatiSingoloPaziente(txtCodiceSanitarioPaziente.Text);
            grdCertificatiPaziente.DataSource = bs;
            grdCertificatiPaziente.Columns[0].Visible = false;
            grdCertificatiPaziente.Columns[2].Visible = false;
            grdCertificatiPaziente.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }
        protected void CreateInfoColumn()
        {
            Image myImage = Image.FromFile(@"C:\Git Repository\ApplicazioneMedicoC#\ApplicazioneMedicoC#\ApplicazioneMedico\Images\info.png");
            Bitmap imgResized = new Bitmap(myImage, new Size(20, 20));
            DataGridViewImageColumn iconColumn = new DataGridViewImageColumn();
            iconColumn.Image = imgResized;
            iconColumn.Name = "Info";
            iconColumn.HeaderText = "";
            grdPazienti.Columns.Insert(0, iconColumn);
        }
        protected void BringPanelToFront(bool bringPnlPazienti, bool bringPnlCertificati, bool bringPnlPatologie, bool bringPnlSingoloPaziente, bool bringPnlNuovoCertificato)
        {
            pnlPazienti.Visible = bringPnlPazienti;
            pnlCertificati.Visible = bringPnlCertificati;
            pnlPatologie.Visible = bringPnlPatologie;
            pnlSingoloPaziente.Visible = bringPnlSingoloPaziente;
            pnlNuovoCertificato.Visible = bringPnlNuovoCertificato;
        }
        protected void SetItemsWidthAndHeight()
        {
            //Larghezza Pannelli Container
            pnlAggiornamento.Width = pnlPazienti.Width = pnlCertificati.Width = pnlPatologie.Width =
                pnlSingoloPaziente.Width = pnlNuovoCertificato.Width = pnlAggiornamento.Parent.ClientSize.Width;

            //Altezza Pannelli Container
            pnlAggiornamento.Height = pnlAggiornamento.Parent.ClientSize.Height;
            pnlPazienti.Height = pnlCertificati.Height = pnlPatologie.Height =
                pnlSingoloPaziente.Height = pnlNuovoCertificato.Height = (pnlAggiornamento.Parent.ClientSize.Height - mainNav.Height);

            //Larghezza Pannelli Filtri
            pnlPazientiFiltri.Width = grdPazienti.Width;
            pnlCertificatiSearchContainer.Height = pnlPatologieSearchContainer.Height = pnlPazientiFiltri.Height;
            txtPazientiSearch.Height = txtCercaCertificati.Height = txtCercaPatologie.Height = 14;
            btnPazientiSearch.Height = btnCercaCertificati.Height = btnCercaPatologie.Height = txtPazientiSearch.Height;

            //Griglia Pazienti
            grdCertificati.Width = grdPazienti.Width;
            grdCertificati.Height = grdPazienti.Height;

            //Larghezza Main Navigation
            mainNav.Width = pnlAggiornamento.Parent.ClientSize.Width - 20;

            //ContenitoreSchedaPazienti
            pnlSchedaPazCont.Width = grdCertificatiPaziente.Width;

            //Tabella scheda paziente
            tblSchedaPaziente.Width = pnlSchedaPazCont.Width / 2;
            tblSchedaPaziente.Height = pnlSchedaPazCont.Height - 20;

            //Colonne Scheda paziente
            for (int i = 0; i < tblSchedaPaziente.RowCount; i++)
                tblSchedaPaziente.RowStyles[i].Height = tblSchedaPaziente.Height / tblSchedaPaziente.RowCount;

            //Righe Scheda paziente
            for (int i = 0; i < tblSchedaPaziente.ColumnCount; i++)
                tblSchedaPaziente.ColumnStyles[i].Width = tblSchedaPaziente.Width / tblSchedaPaziente.ColumnCount;

            //Larghezza campi di testo all'interno della scheda del singolo paziente
            foreach (Control c in tblSchedaPaziente.Controls)
                if (c.GetType().Equals(txtNomePaziente))
                    c.Width = 200;
        }
        protected void SetItemsPosition()
        {
            int rientroLeft = 20;

            //Immagine e label di caricamento
            picBox.Top = (pnlAggiornamento.Height - picBox.Height) / 3;
            picBox.Left = (pnlAggiornamento.Width - picBox.Width) / 2;
            picBox.Refresh();
            lblAggiornamento.Text = "Aggiornamento in corso...";
            lblAggiornamento.Top = (picBox.Top + 250);
            lblAggiornamento.Left = (picBox.Parent.ClientSize.Width - lblAggiornamento.Width) / 2;
            lblAggiornamento.Refresh();

            //Pannelli Container
            pnlAggiornamento.Left = pnlPazienti.Left = pnlCertificati.Left = pnlPatologie.Left = pnlSingoloPaziente.Left = pnlNuovoCertificato.Left = 0;
            pnlAggiornamento.Top = 0;
            pnlPazienti.Top = pnlCertificati.Top = pnlPatologie.Top = pnlSingoloPaziente.Top = pnlNuovoCertificato.Top = mainNav.Height;

            //Main Navigation
            mainNav.Left = rientroLeft;
            lblServerDate.Left = mainNav.Width - (lblServerDate.Width + rientroLeft);

            //Tabella scheda paziente
            tblSchedaPaziente.Left = (pnlSchedaPazCont.Width - tblSchedaPaziente.Width) / 2;

            //Titoli
            lblTitlePazienti.Left = (pnlPazienti.Width - lblTitlePazienti.Width) / 2;
            lblTitleCertificati.Left = (pnlCertificati.Width - lblTitleCertificati.Width) / 2;
            lblTitlePatologie.Left = (pnlPatologie.Width - lblTitlePatologie.Width) / 2;
            lblTitlePazienti.Top = lblTitleCertificati.Top = lblTitlePatologie.Top = mainNav.Bottom + 10;

            //Pannelli Filtri
            pnlPazientiFiltri.Top = pnlCertificatiSearchContainer.Top = pnlPatologieSearchContainer.Top = lblTitlePazienti.Bottom + 10;
            pnlPazientiFiltri.Left = pnlCertificatiSearchContainer.Left = pnlPatologieSearchContainer.Left = rientroLeft;

            //GridView
            grdPazienti.Top = grdCertificati.Top = grdPatologie.Top = pnlPazientiFiltri.Bottom + 5;
            grdPazienti.Left = grdCertificati.Left = grdPatologie.Left = rientroLeft;
            btnNuovoCertificato.Top = grdCertificatiPaziente.Bottom + 10;
        }
        protected void Wait2Seconds()
        {
            t.Interval = 2000;
            t.Tick += new EventHandler(Timer_Tick);
            t.Start();
        }
        protected void Timer_Tick(object sender, EventArgs e)
        {
            pnlAggiornamento.Visible = false;
        }
        protected void FillComboBox()
        {
            List<string> colList = new List<string>();
            foreach (DataGridViewColumn c in grdPazienti.Columns)
            {
                if (c.Visible == true)
                    colList.Add(c.HeaderText.ToString());
            }

            cmbPazientiColumns.Items.Clear();

            foreach (string colName in colList)
            {
                cmbPazientiColumns.Items.Add(colName);
            }
        }
        protected void FillSchedaPaziente(Paziente p)
        {
            txtNomePaziente.Text = p.nome;
            txtCognomePaziente.Text = p.cognome;
            txtSessoPaziente.Text = p.Sesso;
            txtDataNascitaPaziente.Text = p.data_nascita;
            txtLuogoNascitaPaziente.Text = p.luogo;
            txtCodiceFiscalePaziente.Text = p.cod_fis;
            txtComunePaziente.Text = p.residenza;
            txtProvinciaPaziente.Text = p.provincia;
            txtIndirizzoPaziente.Text = p.indirizzo;
            txtCapPaziente.Text = p.CAP;
            txtTelefonoPaziente.Text = p.telefono;
            txtCellularePaziente.Text = p.mobile;
            txtEmailPaziente.Text = p.email;
            txtCodiceSanitarioPaziente.Text = p.cod_sanitario;
        }
        protected void SetFont()
        {
            foreach (Control c in this.Controls)
            {
                c.Font = new Font("Segoe UI", 8, FontStyle.Regular);
            }

            //Titoli
            lblTitleCertificati.Font = lblTitlePazienti.Font = lblTitlePatologie.Font = new Font("Segoe UI", 40, FontStyle.Bold);
            lblTitleCertificati.ForeColor = lblTitlePazienti.ForeColor = lblTitlePatologie.ForeColor = Color.White;


        }
        protected void SetDate()
        {
            if (roPaz != null)
            {
                lblServerDate.Text = "Data ultimo aggiornamento: " + roPaz.datetime;
                lblServerDate.ForeColor = Color.White;
            }
            else
            {
                lblServerDate.Text = "Ora non disponibile. Server non raggiungibile.";
            }
        }
        protected void Sync()
        {
            bool isSynchronized = SyncDataFromServer.Synchronize(roPaz, roPat, roCert);

            if (!isSynchronized)
            {
                MessageBox.Show("Impossibile raggiungere l'host del servizio remoto. \r\nIl servizio di aggiornamento non sarà disponibile.");
                pnlAggiornamento.Visible = false;
            }
            else
            {
                //Aggiornamento iniziale
                pnlAggiornamento.Visible = true;
                pnlAggiornamento.BringToFront();
            }

            SetDate();
        }
        protected Certificato popolaCertificato(Certificato c)
        {
            c.cod_sanitario = txtCodSanNuovoCert.Text;
            c.data_emissione = DateTime.Now.ToString();
            c.cod_patologia = txtCodPatNuovoCert.Text;
            c.data_inizio = dtpDataInizioNuovoCert.Value.ToString();
            c.data_fine = dtpDataFineNuovoCert.Value.ToString();
            c.tipologia = cmbTipologia.Text;
            c.comune = txtComuneNuovoCert.Text;
            c.provincia = txtProvinciaNuovoCert.Text;
            c.CAP = txtCapNuovoCert.Text;
            c.note = txtNoteNuovoCert.Text;

            if (c.domicilio != "")
                c.domicilio = txtDomicilioNuovoCert.Text;
            else
                c.domicilio = txtIndirizzoNuovoCert.Text;

            return c;
        }
        protected void popolaCampiNuovoCertificato()
        {
            txtCodSanNuovoCert.Text = txtCodiceSanitarioPaziente.Text;
            txtComuneNuovoCert.Text = txtComunePaziente.Text;
            txtProvinciaNuovoCert.Text = txtProvinciaPaziente.Text;
            txtIndirizzoNuovoCert.Text = txtIndirizzoPaziente.Text;
            txtCapNuovoCert.Text = txtCapPaziente.Text;

            cmbTipologia.Items.Add("Inizio");
            cmbTipologia.Items.Add("Continuazione");
            cmbTipologia.Items.Add("Ricaduta");
        }        
        protected void GetOrSendData()
        {
            roPaz = ApiRestClient.GetPazientiDataFromServer();
            roPat = ApiRestClient.GetPatologieDataFromServer();
            roCert = ApiRestClient.GetCertificatiDataFromServer();
            response = ApiRestClient.SendCertificatiToServer(CertificatiDAO.GetListCertificatiAfterSyncDate());
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

        /* Azioni al resize della window */
        private void ApplicazioneMedico_SizeChanged(object sender, EventArgs e)
        {
            SetItemsWidthAndHeight();
            SetItemsPosition();
        }
    }
}
