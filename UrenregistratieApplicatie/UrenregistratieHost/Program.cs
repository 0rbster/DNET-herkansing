using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using UrenregistratieService;

namespace UrenregistratieHost
{
    class Program
    {
        static void Main(string[] args)
        {
            using (ServiceHost host = new ServiceHost(typeof(Urenregistratieservice)))
            {
                host.Open();
                Console.WriteLine("Service wordt gehost");
                Console.ReadKey();
            }
        }
    }
}
