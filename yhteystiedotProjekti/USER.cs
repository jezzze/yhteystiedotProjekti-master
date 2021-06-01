using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
namespace yhteystiedotProjekti
{
    class USER
    {

        MY_DB db = new MY_DB();

        public bool kayttajanimiExists(string kayttajanimi, string operation, int userid = 0)
        {
            string query = "";

            if(operation == "rekisteroidy")
            {
                //tarkistan jos uusi käyttäjä rekisteröityy ettei se käyttäjänimi ole jo olemassa
                 query = "SELECT * FROM `kayttaja` WHERE `kayttajanimi`=@un";

            }
            else if (operation == "muokkaa")
            {//tarkistan että onko käyttäjä nimi olemassa 
                query = "SELECT* FROM `kayttaja` WHERE `kayttajanimi`= @un And id <> @uid";
            }

            MySqlCommand command = new MySqlCommand(query, db.getConnection);

            command.Parameters.Add("@un", MySqlDbType.VarChar).Value = kayttajanimi;
            command.Parameters.Add("@uid", MySqlDbType.UInt32).Value = userid;


            MySqlDataAdapter adapter = new MySqlDataAdapter(command);

            DataTable table = new DataTable();

            adapter.Fill(table);
            // jos käittäjänimi on olemassa niin silloin return on true
            if(table.Rows.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        //sijoitan uuden käyttäjän
        public bool insertUser(string etunimi, string sukunimi, string kayttajanimi, string salasana, MemoryStream kuva)
        {
            MySqlCommand command = new MySqlCommand("INSERT INTO `kayttaja`(`etunimi`, `sukunimi`, `kayttajanimi`, `salasana`, `kuva`) VALUES (@fn,@ln,@un,@pass,@pic)", db.getConnection);

            command.Parameters.Add("@fn", MySqlDbType.VarChar).Value = etunimi;
            command.Parameters.Add("@ln", MySqlDbType.VarChar).Value = sukunimi;
            command.Parameters.Add("@un", MySqlDbType.VarChar).Value = kayttajanimi;
            command.Parameters.Add("@pass", MySqlDbType.VarChar).Value = salasana;
            command.Parameters.Add("@pic", MySqlDbType.Blob).Value = kuva.ToArray();


            db.avaaConnection();
            if(command.ExecuteNonQuery() == 1)
            {
                db.suljeConnection();
                return true;
            }
            else
            {
                db.suljeConnection();
                return false;
            }

        }

        //teen function joka palauttaa käyttäjän datan käyttämällä sen idtä
        public DataTable getUserById(Int32 userid)
        {
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            DataTable table = new DataTable();

            MySqlCommand command = new MySqlCommand("SELECT * FROM `kayttaja` WHERE `id` =@uid", db.getConnection);

            command.Parameters.Add("@uid", MySqlDbType.UInt32).Value = userid;

            adapter.SelectCommand = command;

            adapter.Fill(table);

            return table;
        }


        //Functio joka muokkaa käyttäjän tietoja
        public bool paivitakayttaja(int userid,string etunimi, string sukunimi, string kayttajanimi, string salasana, MemoryStream kuva)
        {
            MySqlCommand command = new MySqlCommand("UPDATE `kayttaja` SET `etunimi`=@fn,`sukunimi`=@ln,`kayttajanimi`=@un,`salasana`=@pass,`kuva`=@pic WHERE `id`=@uid", db.getConnection);

            command.Parameters.Add("@fn", MySqlDbType.VarChar).Value = etunimi;
            command.Parameters.Add("@ln", MySqlDbType.VarChar).Value = sukunimi;
            command.Parameters.Add("@un", MySqlDbType.VarChar).Value = kayttajanimi;
            command.Parameters.Add("@pass", MySqlDbType.VarChar).Value = salasana;
            command.Parameters.Add("@pic", MySqlDbType.Blob).Value = kuva.ToArray();
            command.Parameters.Add("@uid", MySqlDbType.Int32).Value = userid;



            db.avaaConnection();
            if (command.ExecuteNonQuery() == 1)
            {
                db.suljeConnection();
                return true;
            }
            else
            {
                db.suljeConnection();
                return false;
            }
        }


    }
}
