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

namespace Serverless_Pattern.Functions
{
    public static class Registro
    {
        [FunctionName("Registro")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");

            string user_name = req.Query["user_name"];
            string email = req.Query["email"];
            string primer_nombre = req.Query["primer_nombre"];
            string segundo_nombre = req.Query["segundo_nombre"];
            string primer_apellido = req.Query["primer_apellido"];
            string segundo_apellido = req.Query["segundo_apellido"];
            string telefono = req.Query["telefono"];
            string fecha_nacimiento = req.Query["fecha_nacimiento"];
            string pais = req.Query["pais"];
            string ciudad = req.Query["ciudad"];
            string password = req.Query["pass"];
            string createdAt = DateTime.Now.ToString("dd/MM/yyyy");
            string updatedAt = DateTime.Now.ToString("dd/MM/yyyy");

            //string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            //dynamic data = JsonConvert.DeserializeObject(requestBody);
            //name = name ?? data?.name;

            Conexion conn = new Conexion();
            string responseMessage = "Conexion Fallida";

            if (conn.state() == true)
            {
                Registro_function registro = new Registro_function(conn);

                if (registro.valido(user_name, primer_nombre, primer_apellido, fecha_nacimiento, pais, ciudad, password, createdAt, updatedAt)) {
                    responseMessage = registro.insertar_registro(user_name, email, primer_nombre, segundo_nombre, primer_apellido, segundo_apellido, telefono, fecha_nacimiento, pais, ciudad,password, createdAt, updatedAt);
                    conn.close();
                    return new OkObjectResult(responseMessage);
                }
                
            }
            conn.close();
            return new OkObjectResult(responseMessage);



            //string responseMessage = string.IsNullOrEmpty(name)
            //    ? "This HTTP triggered function executed successfully. Pass a name in the query string or in the request body for a personalized response."
            //    : $"La conexion fue un: {conn}";

            //return new OkObjectResult(responseMessage);
          
        }
    }
}
