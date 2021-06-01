using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace yhteystiedotProjekti
{
    class ryhma
    {
        MY_DB mydb = new MY_DB();

        // funktio lisätä kirjautunut käyttäjä ryhmään
        public bool InsertGroup(string nimi, int kayttajaid)
        {

            MySqlCommand command = new MySqlCommand("INSERT INTO `minunryhmat`(`id`, `nimi`, `kayttajaid`) VALUES (@gn,@uid)", mydb.getConnection);

            command.Parameters.Add("@gn", MySqlDbType.VarChar).Value = nimi;
            command.Parameters.Add("@uid", MySqlDbType.Int32).Value = kayttajaid;

            mydb.avaaConnection();
            if (command.ExecuteNonQuery() == 1)
            {
                mydb.suljeConnection();
                return true;
            }
            else
            {
                mydb.suljeConnection();
                return false;
            }
        }

        // katso onko ryhmän nimi jo olemassa
        public bool geroupExists(string nimi, string operation, int kayttajaid = 0, int id = 0)
        {
            string query = "";

            MySqlCommand command = new MySqlCommand();

            if (operation == "Lisaa")
            {
                //tarkistan jos uusi ryhmä rekisteröityy ettei se käyttäjänimi ole jo olemassa
                query = "SELECT * FROM `minunryhmat` WHERE `nimi` =@gn AND `kayttajaid` =@uid";
                command.Parameters.Add("@gn", MySqlDbType.VarChar).Value = nimi;
                command.Parameters.Add("@uid", MySqlDbType.Int32).Value = kayttajaid;

            }
            else if (operation == "muokkaa")
            {//tarkistan että onko ryhmän nimi olemassa 
                query = "SELECT * FROM `minunryhmat` WHERE `nimi` =@gn AND `kayttajaid` =@uid AND `id` <>@gid";
                command.Parameters.Add("@gn", MySqlDbType.VarChar).Value = nimi;
                command.Parameters.Add("@uid", MySqlDbType.Int32).Value = kayttajaid;
                command.Parameters.Add("@gid", MySqlDbType.Int32).Value = id;
            }

            command.Connection = mydb.getConnection;
            command.CommandText = query;

            MySqlDataAdapter adapter = new MySqlDataAdapter(command);

            DataTable table = new DataTable();

            adapter.Fill(table);
            
            // jos ryhmä on olemassa niin silloin return on true
            if (table.Rows.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        // luo funktio saadaksesi kaikki ryhmät
        public DataTable getGroups(int kayttajaid)
        {
            MySqlCommand command = new MySqlCommand("SELECT * FROM `minunryhmat` WHERE `kayttajaid` =@uid",mydb.getConnection);

            command.Parameters.Add("@uid", MySqlDbType.Int32).Value = kayttajaid;

            MySqlDataAdapter adapter = new MySqlDataAdapter(command);

            DataTable table = new DataTable();

            adapter.Fill(table);

            return table;

        }

        internal bool groupExists(string ryhmannimi, string v, int globalkayttajaId)
        {
            throw new NotImplementedException();
        }

        internal bool groupExists(string ryhmannimi, string v, int globalkayttajaId, int groupId)
        {
            throw new NotImplementedException();
        }

        //luo funtio muokataksesi ryhmän nimeä
        public bool updateGroup(int id, string nimi)
        {
            MySqlCommand command = new MySqlCommand("UPDATE ``minunryhmat` set `nimi`=@nimi WHERE `id`=@id", mydb.getConnection);

            command.Parameters.Add("@nimi", MySqlDbType.VarChar).Value = nimi;
            command.Parameters.Add("@id", MySqlDbType.Int32).Value = id;

            mydb.avaaConnection();
            if (command.ExecuteNonQuery() == 1)
            {
                mydb.suljeConnection();
                return true;
            }
            else
            {
                mydb.suljeConnection();
                return false;
            }
        }

        // funktio joka poistaa ryhmän
        public bool deleteGroup(int ryhmaid)
        {
            MySqlCommand command = new MySqlCommand("DELETE FROM `minunryhmat` WHERE `id`=@id",mydb.getConnection);

            command.Parameters.Add("@id", MySqlDbType.Int32).Value = ryhmaid;

            mydb.avaaConnection();
            if (command.ExecuteNonQuery() == 1)
            {
                mydb.suljeConnection();
                return true;
            }
            else
            {
                mydb.suljeConnection();
                return false;
            }
        }
    }
}
