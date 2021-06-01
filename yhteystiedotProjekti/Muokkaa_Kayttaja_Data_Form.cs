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

namespace yhteystiedotProjekti
{
    public partial class Muokkaa_Kayttaja_Data_Form : Form
    {
        public Muokkaa_Kayttaja_Data_Form()
        {
            InitializeComponent();
        }

        USER user = new USER();

        private void Muokkaa_Kayttaja_Data_Form_Load(object sender, EventArgs e)
        {
            //laitan sulje ja minimoi kuvat
            panel4.BackgroundImage = Image.FromFile("../../kuvat/minimoi.png");
            panel5.BackgroundImage = Image.FromFile("../../kuvat/sulje.png");

            //näyttää käyttäjän tiedot
            DataTable table = user.getUserById(Globals.GlobalkayttajaId);
            tbEtunimi.Text = table.Rows[0][1].ToString();
            tbSukunimi.Text = table.Rows[0][2].ToString();
            tbkayttajanimi.Text = table.Rows[0][3].ToString();
            tbsalasana.Text = table.Rows[0][4].ToString();

            byte[] pic = (byte[])table.Rows[0]["kuva"];
            MemoryStream kuva = new MemoryStream(pic);
            pbProfiilikuva.Image = Image.FromStream(kuva);
        }

        private void buttonSulje_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void buttonMinimoi_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void button_selaa_Click(object sender, EventArgs e)
        {
            //paina ja valitse kuva 
            OpenFileDialog opf = new OpenFileDialog();
            opf.Filter = "Valitse Kuva(*.jpg;*.png;*.gif)|*.jpg;*.png;*.gif";

            if (opf.ShowDialog() == DialogResult.OK)
            {
                pbProfiilikuva.Image = Image.FromFile(opf.FileName);
            }
        }
        //Muokkaa käyttäjän tietoja
        private void buttonMuokkaa_Click(object sender, EventArgs e)
        {
            MY_DB db = new MY_DB();

            int userid = Globals.GlobalkayttajaId;
            string etunimi = tbEtunimi.Text;
            string sukunimi = tbSukunimi.Text;
            string kaytnimi = tbkayttajanimi.Text;
            string salasana = tbsalasana.Text;

            MemoryStream pic = new MemoryStream();
            pbProfiilikuva.Image.Save(pic,pbProfiilikuva.Image.RawFormat);


            if(etunimi.Trim().Equals("") || salasana.Trim().Equals(""))
            {
                MessageBox.Show("Tarvittavat kohdat: Käyttäjänimi ja salasana", "muokkaa tiedot", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (user.kayttajanimiExists(kaytnimi,"muokkaa",userid)) //tarkistan että onko kääyttäjänimi olemassa
                {
                    MessageBox.Show("Tämä käytäjänimi on jo olemassa Kokeile toista ", "Väärä Käyttäjänimi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                   
                else if (user.paivitakayttaja(userid, etunimi, sukunimi, kaytnimi, salasana, pic))
                {
                    MessageBox.Show("Tietosi päivitetty", "muokkaa tiedot", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                
                else
                {
                    MessageBox.Show("error", "muokkaa tiedot", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                

            }

        }
    }
}
