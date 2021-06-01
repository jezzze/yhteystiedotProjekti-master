using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;


namespace yhteystiedotProjekti
{
    public partial class lisaa_Kontakti_Form : Form
    {
        public lisaa_Kontakti_Form()
        {
            InitializeComponent();
        }

        private void lisaa_Kontakti_Form_Load(object sender, EventArgs e)
        {
            panel3.BackgroundImage = Image.FromFile("../../kuvat/minimoi.png");

            ryhma ryhma = new ryhma();
            comboBoxGroup.DataSource = ryhma.getGroups(Globals.GlobalkayttajaId);
            comboBoxGroup.DisplayMember = "nimi";
            comboBoxGroup.ValueMember = "id";
        }

        private void buttonSulje_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void buttonMinimoi_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void buttonAddContact_Click(object sender, EventArgs e)
        {
            KONTAKTI kontakti = new KONTAKTI();
            string etunimi = tbEtunimi.Text;
            string sukunimi = tbSukunimi.Text;
            string puhelin = textBoxPhone.Text;
            string osoite = textBoxAddress.Text;
            string sahkoposti = textBoxEmail.Text;
            int kayttajaid = Globals.GlobalkayttajaId;


            try
            {
                int ryhma_id = (int)comboBoxGroup.SelectedValue;

                MemoryStream kuva = new MemoryStream();
                pbContactPic.Image.Save(kuva, pbContactPic.Image.RawFormat);

                if(kontakti.insertKontakti(etunimi,sukunimi,kayttajaid,ryhma_id,puhelin,sahkoposti,osoite,kuva))
                {
                    MessageBox.Show("Uusi kontakti lisätty", "Add contact", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Error", "Add contact", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Add contact", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button_Browse_Click(object sender, EventArgs e)
        {
            OpenFileDialog opf = new OpenFileDialog();
            opf.Filter = "Valitse Kuva(*.jpg;*.png;*.gif)|*.jpg;*.png;*.gif";

            if (opf.ShowDialog() == DialogResult.OK)
            {
                pbContactPic.Image = Image.FromFile(opf.FileName);
            }
        }
    }
}
