using System;
using System.IO;
using System.Net;
using System.Text;

namespace RequestProducingService
{
    public static class HttpHelpers
    {
        private static readonly string HostName;

        static HttpHelpers()
        {
            HostName = "http://localhost:";
        }
        
        public static void SendPostRequest(string data, string port)
        {
            string requestedUri = HostName + port + '/';
            try
            {
                byte[] sentData = Encoding.UTF8.GetBytes(data);
                WebRequest request = WebRequest.Create(requestedUri);
                request.Method = "POST";
                request.ContentLength = sentData.Length;
                request.ContentType = "text/plain";

                using (BinaryWriter binaryWriter = new BinaryWriter(request.GetRequestStream()))
                {
                    binaryWriter.Write(sentData, 0, sentData.Length);
                }

                using (WebResponse response = request.GetResponse())
                {
                    Console.WriteLine(((HttpWebResponse) response).StatusDescription);
                    Console.WriteLine($"Data is successfully sent to {requestedUri}\n");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"Something went wrong, while sending post request to {requestedUri}!\n" +
                                  $"Error content: {e.Message}");
            }
        }
    }
}