using System;
using System.IO;
using System.Net;
using System.Text;

namespace HttpListeningService
{
    public static class ListenerHelpers
    {
        public static void ListenPorts(string[] ports)
        {
            if (!HttpListener.IsSupported)
            {
                Console.WriteLine("Windows XP SP2 or Server 2003 is required to use the HttpListener class.");
                return;
            }

            if (ports is null || ports.Length == 0)
            {
                throw new ArgumentException("At least one port required to start listening!");
            }

            try
            {
                HttpListener listener = new HttpListener();
                foreach (string port in ports)
                {
                    listener.Prefixes.Add("http://localhost:" + port + '/');
                }
                
                listener.Start();
                Console.WriteLine($"Listening started for {string.Join(", ", listener.Prefixes)}\n");
                while (true)
                {
                    HttpListenerContext context = listener.GetContext();
                    HttpListenerRequest request = context.Request;

                    using (StreamReader reader = new StreamReader(request.InputStream, request.ContentEncoding))
                    {
                        Console.WriteLine(reader.ReadToEnd());
                    }

                    context.Response.Close();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Something went wrong while listening process!\nError content: " + e.Message);
                throw;
            }
        }
    }
}