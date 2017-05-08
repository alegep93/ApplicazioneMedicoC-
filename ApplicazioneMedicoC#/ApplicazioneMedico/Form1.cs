using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ApplicazioneMedico
{
    public partial class ApplicazioneMedico : Form
    {
        public ApplicazioneMedico()
        {
            InitializeComponent();
            lblAggiornamento.Text = "Aggiornamento in corso...";
            CenterPictureBox(picBox,lblAggiornamento);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void CenterPictureBox(PictureBox picBox, Label lbl)
        {
            picBox.Location = new Point((picBox.Parent.ClientSize.Width / 2) - (picBox.Image.Width / 2),
                                        (picBox.Parent.ClientSize.Height / 2) - ((picBox.Image.Height / 2) + (lblAggiornamento.Height/2) + 50));
            lblAggiornamento.Location = new Point((picBox.Parent.ClientSize.Width / 2) - (lblAggiornamento.Width / 2), 
                                                    picBox.Location.Y + 250);
            picBox.Refresh();
            lblAggiornamento.Refresh();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
