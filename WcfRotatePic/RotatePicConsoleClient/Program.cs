using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using RotatePicConsoleClient.RotatePicService;

namespace RotatePicConsoleClient
{
    public class Program
    {
        static void Main(string[] args)
        {
            RotatePicService.RotatePicServiceClient client = new RotatePicServiceClient();

            Console.WriteLine("Enter path to folder: ");
            string Path = Console.ReadLine();


            string Angle = InputAngle();
            int angleindex;

            while ((Int32.TryParse(Angle, out angleindex) && (angleindex == 0 || angleindex == 1 || angleindex == 2)) == false)
            {
                Console.WriteLine("Error! Wrong key!");
                Angle = InputAngle();
            }
            client.StartRotatePic(Path, angleindex);
        }

        private static string InputAngle()
        {
            Console.WriteLine("Choose angle for rotate ");
            Console.WriteLine("Press key: ");
            Console.WriteLine("______________________");
            Console.WriteLine("0: 90");
            Console.WriteLine("1: 180");
            Console.WriteLine("2: 270");
            Console.WriteLine("______________________");
            return Console.ReadLine();
        }
    }
}
