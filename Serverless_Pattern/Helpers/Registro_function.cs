using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace Serverless_Pattern.Helpers
{
    public class Registro_function
    {
        Conexion conn;
        public Registro_function(Conexion con)
        {
            this.conn = con;
        }

        public bool valido(string username, string nombre, string apellido, string date, string pais, string ciudad, string pass, string ca, string ua)
        {
            if (string.IsNullOrEmpty(username)) return false;
            if (string.IsNullOrEmpty(nombre)) return false;
            if (string.IsNullOrEmpty(apellido)) return false;
            if (string.IsNullOrEmpty(date)) return false;
            if (string.IsNullOrEmpty(pais)) return false;
            if (string.IsNullOrEmpty(ciudad)) return false;
            if (string.IsNullOrEmpty(pass)) return false;
            if (string.IsNullOrEmpty(ca)) return false;
            if (string.IsNullOrEmpty(ua)) return false;
            return true;
        }

        public string insertar_registro(string username, string correo, string primer_nombre, string segundo_nombre, string primer_apellido,
            string segundo_apellido, string telefono, string fecha_nacimiento, string pais, string ciudad, string pass, string ca, string ua)
        {
            string query = @"insert into Usuarios(User_Name,Correo_Electronico, Primer_Nombre,Segundo_Nombre, Primer_Apellido, Segundo_Apellido, Telefono, Fecha_Nacimiento, Pais, Ciudad, Contrasena, createdAt, updatedAt) 
                            values(?p1,?p2,?p3,?p4,?p5,?p6,?p7,?p8,?p9,?p10,?p11,?p12,?p13)";
            MySqlCommand comando = new MySqlCommand(query, conn.conex);
            comando.Parameters.AddWithValue("?p1",username );
            comando.Parameters.AddWithValue("?p2", correo);
            comando.Parameters.AddWithValue("?p3", primer_nombre);
            comando.Parameters.AddWithValue("?p4",segundo_nombre );
            comando.Parameters.AddWithValue("?p5", primer_apellido);
            comando.Parameters.AddWithValue("?p6", segundo_apellido);
            comando.Parameters.AddWithValue("?p7", Convert.ToInt32(telefono));
            comando.Parameters.AddWithValue("?p8", Convert.ToDateTime(fecha_nacimiento));
            comando.Parameters.AddWithValue("?p9", pais);
            comando.Parameters.AddWithValue("?p10", ciudad);
            comando.Parameters.AddWithValue("?p11", pass);
            comando.Parameters.AddWithValue("?p12", Convert.ToDateTime(ca));
            comando.Parameters.AddWithValue("?p13", Convert.ToDateTime(ua));
            comando.ExecuteNonQuery();


            return "Registro Exitoso";
        }


    }
}
