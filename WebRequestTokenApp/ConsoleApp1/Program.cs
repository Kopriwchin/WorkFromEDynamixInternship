using System;
using System.IO;
using System.Net;
using System.Text;

namespace ConsoleApp1
{
    public class Program
    {
        static void Main(string[] args)
        {
            ServicePointManager.ServerCertificateValidationCallback += (sender, certificate, chain, sslPolicyErrors) => true;
            ServicePointManager.Expect100Continue = true;

            const string URL = DataKeeper.URL;
            const string OTHER_URL = DataKeeper.OTHER_URL;

            string response = WebRequestResponse(URL);
            string initString = response.Remove(0, 10);
            int initIndex = initString.IndexOf('"');

            string token = initString.Remove(initIndex);
            Console.WriteLine(token);

            string secondtoken = SecondWebRequest(OTHER_URL, token);
        }

        public static string WebRequestResponse(string URL)
        {
            WebRequest request = WebRequest.Create(URL);

            request.Method = "POST";
            request.ContentType = "application/json";

            var loginDataJson = File.ReadAllText("../../../InputJson/input.json");
            byte[] byteArray = Encoding.UTF8.GetBytes(loginDataJson);

            request.ContentLength = byteArray.Length;

            var reqStream = request.GetRequestStream();
            reqStream.Write(byteArray, 0, byteArray.Length);

            var response = request.GetResponse();
            //Console.WriteLine(((HttpWebResponse)response).StatusDescription);

            var respStream = response.GetResponseStream();

            var reader = new StreamReader(respStream);
            string data = reader.ReadToEnd();
            //Console.WriteLine(data);

            reader.Close();
            response.Close();
            reqStream.Close();
            respStream.Close();

            return data;
        }
        public static string SecondWebRequest(string URL, string token)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(URL);

            var loginDataJson = File.ReadAllText("../../../InputJson/secondInput.json");
            byte[] byteArray = Encoding.UTF8.GetBytes(loginDataJson);

            request.Method = "POST";
            request.ContentType = "application/json";
            request.ContentLength = byteArray.Length;
            request.Accept = "*/*";
            request.Headers["Accept-Encoding"] = "gzip, deflate, br";
            request.Headers["Authorization"] = $"Bearer {token}";
            request.Headers["Referer"] = "internalapi.dealerdynamix.co.uk";
            request.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/91.0.4472.124 Safari/537.36";
            Console.WriteLine(new string('-', 50));
            Console.WriteLine(request.Headers["Authorization"]);
            Console.WriteLine();

            Stream reqStream = request.GetRequestStream();
            reqStream.Write(byteArray, 0, byteArray.Length);
            
            WebResponse response = request.GetResponse();
            Console.WriteLine(((HttpWebResponse)response).StatusDescription);

            var respStream = response.GetResponseStream();

            var reader = new StreamReader(respStream);
            string data = reader.ReadToEnd();

            Console.WriteLine(data);

            reader.Close();
            response.Close();
            reqStream.Close();
            respStream.Close();

            return data;
        }
    }
}
