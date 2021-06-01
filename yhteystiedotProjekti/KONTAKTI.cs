using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Data;
using MySql.Data.MySqlClient;

namespace yhteystiedotProjekti
{
    class KONTAKTI
    {

        MY_DB db = new MY_DB();


        public bool insertKontakti(string etunimi, string sukunimi, int kayttajaid, int ryhma_id, string puhelin, string sahkoposti, string osoite, MemoryStream kuva)
        {
            MySqlCommand command = new MySqlCommand("INSERT INTO `minunkontaktit`(`id`, `etunimi`, `sukunimi`, `ryhma_id`, `puhelin`, `sahkoposti`, `osoite`, `kuva`, `kayttajaid`) VALUES (@fn,@ln,@gid,@phn,@mail,@adrs@picture,@uid)", db.getConnection);

            command.Parameters.Add("@fn", MySqlDbType.VarChar).Value = etunimi;
            command.Parameters.Add("@ln", MySqlDbType.VarChar).Value = sukunimi;
            command.Parameters.Add("@gid", MySqlDbType.Int32).Value = ryhma_id;
            command.Parameters.Add("@phn", MySqlDbType.VarChar).Value = puhelin;
            command.Parameters.Add("@mail", MySqlDbType.VarChar).Value = sahkoposti;
            command.Parameters.Add("@adrs", MySqlDbType.VarChar).Value = osoite;
            command.Parameters.Add("@kuva", MySqlDbType.Blob).Value = kuva.ToArray();
            command.Parameters.Add("@uid", MySqlDbType.Int32).Value = kayttajaid;

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


        public bool updateKontakti(int id, string etunimi, string sukunimi, int ryhma_id, string puhelin, string sahkoposti, string osoite, MemoryStream kuva)
        {
            MySqlCommand command = new MySqlCommand("UPDATE `minunkontaktit` SET`etunimi`=@fn,`sukunimi`=@ln,`ryhma_id`=@gid,`puhelin`=@phn,`sahkoposti`=@mail,`osoite`=@adrs,`kuva`=@kuva,`kayttajaid`=@uid WHERE `id` =@id", db.getConnection);

            command.Parameters.Add("@fn", MySqlDbType.VarChar).Value = etunimi;
            command.Parameters.Add("@ln", MySqlDbType.VarChar).Value = sukunimi;
            command.Parameters.Add("@gid", MySqlDbType.Int32).Value = ryhma_id;
            command.Parameters.Add("@phn", MySqlDbType.VarChar).Value = puhelin;
            command.Parameters.Add("@mail", MySqlDbType.VarChar).Value = sahkoposti;
            command.Parameters.Add("@adrs", MySqlDbType.VarChar).Value = osoite;
            command.Parameters.Add("@kuva", MySqlDbType.Blob).Value = kuva.ToArray();
            command.Parameters.Add("@id", MySqlDbType.Int32).Value = id;

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

        public DataTable selectContactList(MySqlCommand command)
        {
            command.Connection = db.getConnection;
            MySqlDataAdapter adapter = new MySqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            return table;

        }

        public DataTable getContactById(int contactId)
        {
            MySqlCommand command = new MySqlCommand("SELECT `id`, `etunimi`, `sukunimi`, `ryhma_id`, `puhelin`, `sahkoposti`, `osoite`, `kuva`, `kayttajaid` FROM `minunkontaktit` WHERE `id` =@id", db.getConnection);
            command.Parameters.Add("@id", MySqlDbType.Int32).Value = contactId;
            MySqlDataAdapter adapter = new MySqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            return table;

        }

        public bool deleteGroup(int kontaktiId)
        {
            MySqlCommand command = new MySqlCommand("DELETE FROM `minunkontaktit` WHERE `id`=@id", db.getConnection);

            command.Parameters.Add("@id", MySqlDbType.Int32).Value = kontaktiId;

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
