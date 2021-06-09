using System;

namespace HttpListeningService
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Http-Listener service is started..\n");

            ListenerHelpers.ListenPorts(new string[] {"1155"});
            Console.ReadLine();
        }
    }
}