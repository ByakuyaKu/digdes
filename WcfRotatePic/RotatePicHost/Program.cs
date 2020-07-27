using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;


namespace RotatePicHost
{
    class Program
    {
        static void Main(string[] args)
        {
           
            using (var host = new ServiceHost(typeof(WcfRotatePic.RotatePicService)))
            {
                host.Open();
                Console.WriteLine("Host started");
                Console.ReadKey();
            }
        }
    }
}
