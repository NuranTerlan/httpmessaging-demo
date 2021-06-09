using System;

namespace RequestProducingService
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Request-Producer service is started..\n");
            while (true)
            {
                Console.Write("data: ");
                string postedData = Console.ReadLine().PadRight(50, ' ') + DateTime.UtcNow.ToLocalTime();
                HttpHelpers.SendPostRequest(postedData, "1155");
            }
        }
    }
}