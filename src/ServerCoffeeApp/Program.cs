using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerCoffeeApp
{
    internal class Program
    {
        static void Main(string[] args)
        {

            UdpServer server = new UdpServer();
            server.Start();
        }
    }
}
