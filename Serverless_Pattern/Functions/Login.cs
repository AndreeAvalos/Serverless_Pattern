using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Serverless_Pattern.Helpers;
using Serverless_Pattern.Models;

namespace Serverless_Pattern.Functions
{
    public static class Login
    {
        [FunctionName("Login")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");

            string email = req.Query["email"];
            string password = req.Query["password"];

            Conexion conn = new Conexion();
            string responseMessage = "Conexion Fallida";


            if (conn.state())
            {
                Login_function login = new Login_function(conn);
                if (login.valido(email, password)) {
                    response respuesta = login.validar_credenciales(email, password);
                    conn.close();
                    return new OkObjectResult(JsonConvert.SerializeObject(respuesta));
                }
            }

            conn.close();
            return new OkObjectResult(JsonConvert.SerializeObject(new response(false, responseMessage)));
        }
    }
}
