using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Dynamic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace TestWebApiREST
{
    class Program
    {
        static void Main(string[] args)
        {

            string UrlEntrada = ConfigurationManager.AppSettings["Entrada"];
            string Usuario = ConfigurationManager.AppSettings["Usuario"];
            string Password = ConfigurationManager.AppSettings["Password"];

            //string Token = ValidarAcceso(Usuario, Password);

            //if (Token != null)
            //{
            //Timbrar Documentos
            string[] ListaArchivos = Directory.GetFiles(UrlEntrada, "*.*", SearchOption.AllDirectories);

            foreach (var archivo in ListaArchivos)
            {
                string UrlCarpetaSalida = archivo.Replace("Entrada", "Salida");
                string UrlXML = UrlCarpetaSalida + "/Comprobante.xml";
                string UrlLog = UrlCarpetaSalida + "/Log.txt";
                Directory.CreateDirectory(UrlCarpetaSalida);
                File.WriteAllText(UrlLog, ".- Inicia timbrado");

                try
                {
                    string Layout = File.ReadAllText(archivo);

                    //Timbrar Archivo
                    //var respuestaTimbrado = TimbrarComprobante(Layout, Usuario, Password, Token);

                    ////Timbrar comprobante KAVAK
                    var respuestaTimbrado = TimbrarComprobanteKAVAK(Utilerias.AESEncrypt(Layout), Utilerias.AESEncrypt(Usuario), Utilerias.AESEncrypt(Password));

                    if (respuestaTimbrado.GetValue("exitoso").ToString() == "true")
                    {
                        using (StreamWriter Log = new StreamWriter(UrlLog, true))
                        {
                            Log.WriteLine(".- Timbrado con exito");
                            Log.Close();
                        }

                        string XMLTimbrado = respuestaTimbrado.GetValue("XmlTimbrado").ToString();

                        //KAVAK
                        XMLTimbrado = Utilerias.AESDecrypt(XMLTimbrado);

                        File.WriteAllText(UrlXML, XMLTimbrado);
                        using (StreamWriter Log = new StreamWriter(UrlLog, true))
                        {
                            Log.WriteLine(".- Se crea xml en la carpeta");
                            Log.Close();
                        }
                    }
                    else
                    {
                        using (StreamWriter Log = new StreamWriter(UrlLog, true))
                        {
                            Log.WriteLine(".- Error al timbrar");
                            Log.WriteLine(".- Mensaje: " + respuestaTimbrado.GetValue("mensajeError").ToString());
                            Log.WriteLine(".- Codigo Error: " + respuestaTimbrado.GetValue("codigoError").ToString());
                            Log.Close();
                        }
                    }
                }
                catch (Exception e)
                {
                    using (StreamWriter Log = new StreamWriter(UrlLog, true))
                    {
                        Log.WriteLine(".- Se produjo una Exception");
                        Log.WriteLine(".- Mensaje: " + e.Message);
                        Log.Close();
                    }
                }

            }

            //Obtener PDF
            //ObtenerPDFComprobante()

            //Cancelar Comprobante
            //CancelarComprobante()
        }




        public static string ValidarAcceso(string Usuario, string Password)
        {
            var client = new RestClient(ConfigurationManager.AppSettings["UrlValidarAcceso"]);
            client.Timeout = -1;
            var request = new RestRequest(Method.POST);
            request.AlwaysMultipartFormData = true;
            request.AddParameter("Usuario", Usuario);
            request.AddParameter("Password", Password);
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

        public static JObject TimbrarComprobante(string Layout, string Usuario, string Password, string Token)
        {
            var client = new RestClient(ConfigurationManager.AppSettings["UrlTimbrarComprobante"]);
            client.Timeout = -1;
            var request = new RestRequest(Method.POST);
            request.AddHeader("Authorization", "Bearer " + Token);
            request.AlwaysMultipartFormData = true;
            request.AddParameter("Usuario", Usuario);
            request.AddParameter("Password", Password);
            request.AddParameter("Lineas", Layout);
            IRestResponse response = client.Execute(request);
            Console.WriteLine(response.Content);

            return JObject.Parse(response.Content);
        }

        //Metodo para enviar los parametros por el header de la solicitud
        //public static JObject TimbrarComprobanteKAVAK(string Layout, string Usuario, string Password, string Token)
        //{
        //    var client = new RestClient(ConfigurationManager.AppSettings["UrlTimbrarComprobanteKAVAK"]);
        //    client.Timeout = -1;
        //    var request = new RestRequest(Method.POST);
        //    request.AddHeader("Authorization", "Bearer " + Token);
        //    request.AlwaysMultipartFormData = true;
        //    request.AddParameter("Usuario", Usuario);
        //    request.AddParameter("Password", Password);
        //    request.AddParameter("Lineas", Layout);
        //    IRestResponse response = client.Execute(request);
        //    Console.WriteLine(response.Content);

        //    return JObject.Parse(response.Content);

        //}

        //Metodo para enviar los parametros por el cuerpo de la solicitud
        public static JObject TimbrarComprobanteKAVAK(string Layout, string Usuario, string Password/*, string Token*/)
        {
            dynamic clase = new ExpandoObject();
            clase.Usuario = Usuario;
            clase.Password = Password;
            clase.Lineas = Layout;

            var body = JsonConvert.SerializeObject(clase);

            var client = new RestClient(ConfigurationManager.AppSettings["UrlTimbrarComprobanteKAVAK"]);
            client.Timeout = -1;
            var request = new RestRequest(Method.POST);
            //request.AddHeader("Authorization", "Bearer " + Token);
            request.AddHeader("Content-Type", "application/json");
            request.AddParameter("application/json", body, ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);
            Console.WriteLine(response.Content);

            return JObject.Parse(response.Content);

        }

        public static JObject ObtenerPDFComprobante(string UUID, string Usuario, string Password, string Token)
        {
            dynamic clase = new ExpandoObject();
            clase.Usuario = Usuario;
            clase.Password = Password;
            clase.UUID = UUID;

            var body = JsonConvert.SerializeObject(clase);

            var client = new RestClient(ConfigurationManager.AppSettings["UrlObtenerPDFComprobante"]);
            client.Timeout = -1;
            var request = new RestRequest(Method.POST);
            request.AddHeader("Content-Type", "application/json");
            request.AddParameter("application/json", body, ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);
            Console.WriteLine(response.Content);

            return JObject.Parse(response.Content);
        }

        public static JObject CancelarComprobante(string Usuario, string Password, string RFCEmisor, string RFCReceptor, string Total, string UUID, string Token)
        {
            var client = new RestClient(ConfigurationManager.AppSettings["UrlObtenerPDFComprobante"]);
            client.Timeout = -1;
            var request = new RestRequest(Method.POST);
            request.AddHeader("Authorization", "Bearer " + Token);
            request.AlwaysMultipartFormData = true;
            request.AddParameter("Usuario", Usuario);
            request.AddParameter("Password", Password);
            request.AddParameter("RFCEmisor", RFCEmisor);
            request.AddParameter("RFCReceptor", RFCReceptor);
            request.AddParameter("Total", Total);
            request.AddParameter("UUID", UUID);
            IRestResponse response = client.Execute(request);
            Console.WriteLine(response.Content);

            return JObject.Parse(response.Content);
        }
    }
}
