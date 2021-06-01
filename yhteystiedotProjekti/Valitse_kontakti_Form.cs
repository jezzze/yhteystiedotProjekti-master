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
    public partial class Valitse_kontakti_Form : Form
    {
        public Valitse_kontakti_Form()
        {
            InitializeComponent();
        }

        private void Valitse_kontakti_Form_Load(object sender, EventArgs e)
        {
            panel3.BackgroundImage = Image.FromFile("../../kuvat/minimoi.png");

            MySqlCommand command = new MySqlCommand("SELECT `id`, `etunimi`, `sukunimi`, `ryhma_id` as 'ryhma id' FROM `minunkontaktit` WHERE `kayttajaid` =@uid");
            command.Parameters.Add("@uid", MySqlDbType.Int32).Value = Globals.GlobalkayttajaId;

            KONTAKTI kontakti = new KONTAKTI();

            dataGridView1.DataSource = kontakti.selectContactList(command);
        }

        private void buttonSulje_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void buttonMinimoi_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void dataGridView1_AutoSizeColumnsModeChanged(object sender, DataGridViewAutoSizeColumnsModeEventArgs e)
        {

        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
