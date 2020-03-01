using MySql.Data.MySqlClient;
using Serverless_Pattern.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Serverless_Pattern.Helpers
{
    public class Login_function
    {
        Conexion conn;

        public Login_function(Conexion conn)
        {
            this.conn = conn;
        }

        public bool valido(string email, string password) {
            if (String.IsNullOrEmpty(email)) return false;
            if (String.IsNullOrEmpty(password)) return false;
            return true;
        }

        public response validar_credenciales(string user_name, string password) {
            string query = "select contrasena from Usuarios where correo_electronico = '" + user_name + "'";
            MySqlCommand comando = conn.conex.CreateCommand();
            comando.CommandText = query;
            MySqlDataReader reader = comando.ExecuteReader();
            Login_model model = null;
            while (reader.Read()) {
                model = new Login_model(user_name, reader["contrasena"].ToString());
                break;
            }
            if (model != null) return model.validate(password);
            return new response(false,"No existe usuario");
        }
    }
}
