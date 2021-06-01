using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace yhteystiedotProjekti
{
    public partial class Kontaktien_koko_lista_Form : Form
    {
        public Kontaktien_koko_lista_Form()
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Kontaktien_koko_lista_Form_Load(object sender, EventArgs e)
        {
            panel3.BackgroundImage = Image.FromFile("../../images/img4.png");

            DataGridViewImageColumn picCol = new DataGridViewImageColumn();

            dataGridView1.RowTemplate.Height = 80;

            KONTAKTI kontakti = new KONTAKTI();
            MySqlCommand command = new MySqlCommand("SELECT fname as 'etunimi', lname as 'sukunimi', minunryhmat.nimi as 'ryhma', puhelin, sahkoposti, osoite, kuva, INNER JOIN minunryhmat on minunkontaktit.ryhma_id = minunryhmat.id WHERE minunkontaktit.kayttajaid = @kayttajaid");
            command.Parameters.Add("@kayttajaid", MySqlDbType.Int32).Value = Globals.GlobalkayttajaId;
            dataGridView1.DataSource = kontakti.selectContactList(command);

            picCol = (DataGridViewImageColumn)dataGridView1.Columns[6];
            picCol.ImageLayout = DataGridViewImageCellLayout.Stretch;

            for(int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                if(IsOdd(i))
                {
                    dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.Green;
                }
            }

            ryhma ryhma = new ryhma();
            listBox1.DataSource = ryhma.getGroups(Globals.GlobalkayttajaId);
            listBox1.DisplayMember = "nimi";
            listBox1.ValueMember = "id";

            listBox1.SelectedItem = null;
            dataGridView1.ClearSelection();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void listBox1_Click(object sender, EventArgs e)
        {
            try
            {
                KONTAKTI kontakti = new KONTAKTI();
                int ryhmaid = (Int32)listBox1.SelectedValue;
                MySqlCommand command = new MySqlCommand("SELECT fname as 'etunimi', lname as 'sukunimi', minunryhmat.nimi as 'ryhma', puhelin, sahkoposti, osoite, kuva, INNER JOIN minunryhmat on minunkontaktit.ryhma_id = minunryhmat.id WHERE minunkontaktit.kayttajaid = @kayttajaid AND minunkontaktit.ryhma_id=@ryhmaid");
                command.Parameters.Add("@kayttajaid", MySqlDbType.Int32).Value = Globals.GlobalkayttajaId;
                command.Parameters.Add("@ryhmaid", MySqlDbType.Int32).Value = ryhmaid;
                dataGridView1.DataSource = kontakti.selectContactList(command);

                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    if (IsOdd(i))
                    {
                        dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.WhiteSmoke;
                    }
                }

                dataGridView1.ClearSelection();
            }
            catch
            {

            }
        }

        private void labelShowAll_Click(object sender, EventArgs e)
        {
            Kontaktien_koko_lista_Form_Load(null, null);
        }

        public bool IsOdd(int value)
        {
            return value % 2 != 0;
        }

        private void dataGridView1_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                if (IsOdd(i))
                {
                    dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.WhiteSmoke;
                }
            }

            dataGridView1.ClearSelection();
        }

        private void dataGridView1_Click(object sender, EventArgs e)
        {
            textBoxAddress.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
        }
    }
}
