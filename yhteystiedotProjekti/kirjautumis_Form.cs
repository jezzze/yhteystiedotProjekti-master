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
using MySql.Data.MySqlClient;

namespace yhteystiedotProjekti
{
    public partial class kirjautumis_Form : Form
    {
        public kirjautumis_Form()
        {
            InitializeComponent();
        }

        private void kirjautumis_Form_Load(object sender, EventArgs e)
        {
            //lisään tässä kaksi kuvaa panel3een ja panel4jään
            panel3.BackgroundImage = Image.FromFile("../../kuvat/minimoi.png");
            panel4.BackgroundImage = Image.FromFile("../../kuvat/sulje.png"); // Korjattu
        }

        //registeröinti nappi
        private void button_registeroidy_Click(object sender, EventArgs e)
        {
            string etunimi = tbEnimi.Text;
            string sukunimi = tbSnimi.Text;
            string kayttajanimi = tbKäyttäjänimiRek.Text;
            string salasana = tbSalasanaRek.Text;

            USER user = new USER();


            if(tarkistafields("rekisteroidy"))
            {
                MemoryStream pic = new MemoryStream();
                pbProfiilikuva.Image.Save(pic, pbProfiilikuva.Image.RawFormat);

                //pitää tarkistaa jos käyttäjänimi on jo olemassa
                //pitää sijoittaa uusi käyttäjä tietokantaan
                if (!user.kayttajanimiExists(kayttajanimi,"rekisteroi" )) //tarkistan että onko kääyttäjänimi olemassa
                {
                    if(user.insertUser(etunimi,sukunimi,kayttajanimi,salasana,pic))
                    {
                        MessageBox.Show("Rekisteröinti onnistui", "Rekisteröinti", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Jotain meni väärin", "Rekisteröinti", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    MessageBox.Show("Tämä käytäjänimi on jo olemassa Kokeile uutta ", "Väärä Käyttäjänimi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }


            }
            else
            {
                MessageBox.Show("* Pakolliset kohdat - Käyttäjänimi / salasana / kuva *", "Rekisteröinti", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }


        // luon function joka tarkistaa tyhjät kohdat
        public bool tarkistafields(string operation)
        {
            bool check = false;

            if(operation == "rekisteroidy")
            {
                if(tbKäyttäjänimiRek.Text.Trim().Equals("") || tbSalasanaRek.Text.Trim().Equals("") || pbProfiilikuva.Image == null)
                {
                    check = false;
                }
                else
                {
                    check = true;
                }
            }
            else if(operation == "login")
            {
                if(tbKayttajanimi.Text.Trim().Trim().Equals("") || tbSalasana.Text.Trim().Equals(""))
                {
                    check = false;
                }
                else
                {
                    check = true;
                }
            }
            return check;

        }




        //selaa nappi
        private void button_selaa_Click(object sender, EventArgs e)
        {
            //paina ja valitse kuva 
            OpenFileDialog opf = new OpenFileDialog();
            opf.Filter = "Valitse Kuva(*.jpg;*.png;*.gif)|*.jpg;*.png;*.gif";

            if(opf.ShowDialog() == DialogResult.OK)
            {
                pbProfiilikuva.Image = Image.FromFile(opf.FileName);
            }
        }

        //label mene rekisteröinti kohtaan
        private void labelMeneRek_Click(object sender, EventArgs e)
        {
            timer1.Start();
            labelMeneRek.Enabled = false;
            labelMeneKirjaut.Enabled = false;
        }

        //label mene kirjautumis kohtaan
        private void labelMeneKirjaut_Click(object sender, EventArgs e)
        {
            timer2.Start();
            labelMeneKirjaut.Enabled = false;
            labelMeneRek.Enabled = false;
        }

        //nappi joka sulkee
        private void buttonSulje_Click(object sender, EventArgs e)
        {
            Close();
        }

        //nappi joka minimoi
        private void buttonMinimoi_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        //kun tämä timer alkaa niin näytämme vain rekisteröinti kohdan
        private void timer1_Tick(object sender, EventArgs e)
        {
            // kun laitat -289 niin näät vain rekisteröinti kohdan
            // se eka 289 on se että näät vain kirjautumis kohdan
            // tätä ei kannata muuttaa muuten se ei näytä hyvältä
            if(panel2.Location.X > -289)
            {
                panel2.Location = new Point(panel2.Location.X - 10, panel2.Location.Y);
            }
            else
            {
                timer1.Stop();
                labelMeneKirjaut.Enabled = true;
                labelMeneRek.Enabled = true;
            }
        }

        //kun tämä timer vie kirjautumis kohtaan
        private void timer2_Tick(object sender, EventArgs e)
        {
            if (panel2.Location.X < 0)
            {
                panel2.Location = new Point(panel2.Location.X + 10, panel2.Location.Y);
            }
            else
            {
                timer2.Stop();
                labelMeneKirjaut.Enabled = true;
                labelMeneRek.Enabled = true;
            }
        }
        //kirjautumis nappi
        private void button_kirjautumis_Click(object sender, EventArgs e)
        {
            MY_DB db = new MY_DB();

            MySqlDataAdapter adapter = new MySqlDataAdapter();

            DataTable table = new DataTable();

            MySqlCommand command = new MySqlCommand("SELECT * FROM `kayttaja` WHERE `kayttajanimi`= @un AND `salasana`= @pass", db.getConnection);

            command.Parameters.Add("@un", MySqlDbType.VarChar).Value = tbKayttajanimi.Text;
            command.Parameters.Add("@pass", MySqlDbType.VarChar).Value = tbSalasana.Text;

            adapter.SelectCommand = command;

            adapter.Fill(table); 

            if(tarkistafields("login")) // Tarkistan että onko tyhjiä kohtia
            {
                if (table.Rows.Count > 0) // Tarkistan että onko tämä käyttäjä olemassa
                {
                    int kayttajaId = Convert.ToInt32(table.Rows[0][0].ToString());
                    Globals.setGlobalkayttajaId(kayttajaId);

                    // näyttää pää formin 
                    this.DialogResult = DialogResult.OK;
                }
                else
                {
                    MessageBox.Show("Väärä käyttäjänimi tai salasana", "Kirjautumisen Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Tyhjä käyttäjänimi tai salasana", "Kirjautumisen Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }



        }

        private void tbKayttajanimi_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
