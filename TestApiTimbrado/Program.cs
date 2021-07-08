using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.IO;
using System.Net;

namespace TestApiTimbrado
{
    class Program
    {
        static void Main(string[] args)
        {
            string token = ValidarAcceso();
            if (token != null)
            {
                var respuestaTimbrado = TimbrarComprobante(token);
                var respuestaPDF = ObtenerPDFComprobante(token);
            }
        }

        public static string ValidarAcceso()
        {
            var client = new RestClient("https://localhost:44373/api/Timbrado/ValidarAcceso");
            client.Timeout = -1;
            var request = new RestRequest(Method.POST);
            request.AlwaysMultipartFormData = true;
            request.AddParameter("usuario", "Demo1@mail.com");
            request.AddParameter("password", "Demo123#");
            IRestResponse response = client.Execute(request);

            if (response.StatusCode == HttpStatusCode.OK)
            {
                var Json = JObject.Parse(response.Content);
                string token = Json.GetValue("token").ToString();
                return token;
            }
            else
            {
                return null;
            }
        }

        public static IRestResponse  TimbrarComprobante(string token)
        {
            string texto =  File.ReadAllText("C:/Entrada/EjemploLayout.txt");
            var client = new RestClient("https://localhost:44373/api/Timbrado/TimbrarComprobante");
            client.Timeout = -1;
            var request = new RestRequest(Method.POST);
            request.AddHeader("Authorization", "Bearer " + token);
            request.AlwaysMultipartFormData = true;
            request.AddParameter("usuario", "Demo1@mail.com");
            request.AddParameter("password", "Demo123#");
            request.AddParameter("texto", texto);
            IRestResponse response = client.Execute(request);
            Console.WriteLine(response.Content);

            return response;
        }

        public static IRestResponse ObtenerPDFComprobante(string token)
        {
            var client = new RestClient("https://localhost:44373/api/Timbrado/ObtenerPDFComprobante");
            client.Timeout = -1;
            var request = new RestRequest(Method.POST);
            request.AddHeader("Authorization", "Bearer " + token);
            request.AlwaysMultipartFormData = true;
            request.AddParameter("usuario", "Demo1@mail.com");
            request.AddParameter("password", "Demo123#");
            request.AddParameter("uuid", "8A47479A-4C8C-492F-A5BE-3814C2131F5C");
            IRestResponse response = client.Execute(request);
            Console.WriteLine(response.Content);

            return response;
        }

    }
}
