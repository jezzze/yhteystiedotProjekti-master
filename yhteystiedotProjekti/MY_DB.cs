using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
//lisään mysql connectorin
using MySql.Data.MySqlClient; 

namespace yhteystiedotProjekti
{
    class MY_DB
    {
        //Yhteys
        MySqlConnection con = new MySqlConnection("datasource=localhost;port=3306;username=root;password=;database=csharp_yhteystiedot_db");

        //palauta yhteys
        public MySqlConnection getConnection
        {
            get
            {
                return con;
            }
        }
        //avaa yhteys
        public void avaaConnection()
        {
            if(con.State == System.Data.ConnectionState.Closed)
            {
                con.Open();
            }
        }
        //sulje yhteys
        public void suljeConnection()
        {
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
        }
            


    }
}
