using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace WcfRotatePic
{
    // ПРИМЕЧАНИЕ. Команду "Переименовать" в меню "Рефакторинг" можно использовать для одновременного изменения имени класса "RotatePicService" в коде и файле конфигурации.
    public class RotatePicService : IRotatePicService
    {
        public string Path { get; set; }
        public string[] Pics { get; set; }
        public int Angle { get; set; }

        RotateFlipType[] angles = new RotateFlipType[3] { RotateFlipType.Rotate90FlipNone, RotateFlipType.Rotate180FlipNone, RotateFlipType.Rotate270FlipNone };

        public void RotatePic(int i)
        {
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            Console.WriteLine($"Image is rotating... Thread id: {Thread.CurrentThread.ManagedThreadId}");

            Image img = null;
            img = Image.FromFile(Pics[i]);

            if (img != null)
            {
                img.RotateFlip(angles[Angle]);
                img.Save(Pics[i]);
                Console.WriteLine($"Image rotated... Thread id: {Thread.CurrentThread.ManagedThreadId}");
            }
            stopWatch.Stop();
            TimeSpan ts = stopWatch.Elapsed;
            Console.WriteLine($"Image rotated for: {String.Format("{0:000}", ts.Milliseconds)} ms. Thread id: {Thread.CurrentThread.ManagedThreadId}");
        }

        public void StartRotatePic(string path, int angle)
        {
            Angle = angle;
            Pics = Directory.GetFiles(path).Where(s => s.ToLower().EndsWith(".bmp") || s.ToLower().EndsWith(".jpg") || s.ToLower().EndsWith(".png")).ToArray();

            Parallel.For(0, Pics.Length, RotatePic);
            Console.ReadKey();
        }
    }
}
