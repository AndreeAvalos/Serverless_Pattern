using System;
using System.Collections.Generic;
using System.Text;

namespace Serverless_Pattern.Models
{
    class Login_model
    {
        string username;
        string password;

        public Login_model(string username, string password)
        {
            this.username = username;
            this.password = password;
        }

        public response validate(string password) {
            if (password.Equals(this.password))
            {
                return new response(true, "Bienvenido "+username);
            }
            else {
                return new response(false, "Contraseña incorrecta");
            }
        }

        
    }
}
