using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace yhteystiedotProjekti
{
    public partial class Muokkaa_kontaktia_Form : Form
    {
        public Muokkaa_kontaktia_Form()
        {
            InitializeComponent();
        }

        private void Muokkaa_kontaktia_Form_Load(object sender, EventArgs e)
        {
            panel3.BackgroundImage = Image.FromFile("../../kuvat/minimoi.png");

            ryhma ryhma = new ryhma();
            comboBoxGroup.DataSource = ryhma.getGroups(Globals.GlobalkayttajaId);
            comboBoxGroup.DisplayMember = "nimi";
            comboBoxGroup.ValueMember = "id";
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void buttonSulje_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void buttonMinimoi_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void buttonSelectContact_Click(object sender, EventArgs e)
        {
            Valitse_kontakti_Form selectContactF = new Valitse_kontakti_Form();
            selectContactF.ShowDialog();

            try
            {
                int contactId = Convert.ToInt32(selectContactF.dataGridView1.CurrentRow.Cells[0].Value.ToString());

                KONTAKTI kontakti = new KONTAKTI();

                DataTable table = kontakti.getContactById(contactId);

                textBoxContactID.Text = table.Rows[0]["id"].ToString();
                tbEtunimi.Text = table.Rows[0]["etunimi"].ToString();
                tbSukunimi.Text = table.Rows[0]["sukunimi"].ToString();
                comboBoxGroup.SelectedValue = table.Rows[0]["ryhma id"];
                textBoxPhone.Text = table.Rows[0]["puhelin"].ToString();
                textBoxEmail.Text = table.Rows[0]["sahkoposti"].ToString();
                textBoxAddress.Text = table.Rows[0]["osoite"].ToString();

                Byte[] kuva = (byte[])table.Rows[0]["kuva"];
                MemoryStream picture = new MemoryStream(kuva);
                pbContactPic.Image = Image.FromStream(picture);
            }
            catch
            {

            }

            
        }

        private void buttonEditContact_Click(object sender, EventArgs e)
        {
            KONTAKTI kontakti = new KONTAKTI();
            string etunimi = tbEtunimi.Text;
            string sukunimi = tbSukunimi.Text;
            string puhelin = textBoxPhone.Text;
            string osoite = textBoxAddress.Text;
            string sahkoposti = textBoxEmail.Text;


            try
            {
                int kontaktiId = Convert.ToInt32(textBoxContactID.Text);

                int ryhma_id = (int)comboBoxGroup.SelectedValue;

                MemoryStream kuva = new MemoryStream();
                pbContactPic.Image.Save(kuva, pbContactPic.Image.RawFormat);

                if (kontakti.updateKontakti(kontaktiId,etunimi,sukunimi,ryhma_id,puhelin,sahkoposti,osoite,kuva))
                {
                    MessageBox.Show("Kontakti päivitetty", "Edit contact", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Error", "Edit contact", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Edit contact", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
