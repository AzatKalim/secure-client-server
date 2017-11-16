using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SecureClient
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "CLIENT";
            var client = new Client();
            string message=Console.ReadLine();
            client.SendMessage(message);
        }
    }
}
