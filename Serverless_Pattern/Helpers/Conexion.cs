using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace Serverless_Pattern.Helpers
{
    class Conexion
    {
        MySqlConnection conex = new MySqlConnection();

        static string server = "Server=35.188.13.111:3306;";
        static string db = "Database=DB_PazHUB;";
        static string usuario = "Uid=root;";
        static string password = "pwd=root;";
        public string result = "";
        string CadenaDeConexion = server + db + usuario + password;

        public Conexion() {
            try
            {
                conex.ConnectionString = CadenaDeConexion;
                conex.Open();
                result = "Exito";
            }
            catch (MySqlException)
            {

                result = "Fracaso";
            }
        }


    }
}
