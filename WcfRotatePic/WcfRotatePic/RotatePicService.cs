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
        private string Path { get; set; }
        private string[] Pics { get; set; }
        private int Angle { get; set; }
        private string Output = "";

        private RotateFlipType[] angles = new RotateFlipType[3] { RotateFlipType.Rotate90FlipNone, RotateFlipType.Rotate180FlipNone, RotateFlipType.Rotate270FlipNone };


        public void RotatePic(int i)
        {
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            //Console.WriteLine($"Image is rotating... Thread id: {Thread.CurrentThread.ManagedThreadId}");
            Output += $"Image is rotating... Thread id: {Thread.CurrentThread.ManagedThreadId}\n";

            Image img = null;
            img = Image.FromFile(Pics[i]);

            if (img != null)
            {
                img.RotateFlip(angles[Angle]);
                img.Save(Pics[i]);
                //Console.WriteLine($"Image rotated... Thread id: {Thread.CurrentThread.ManagedThreadId}");
                Output += $"Image rotated... Thread id: {Thread.CurrentThread.ManagedThreadId}\n";
            }
            stopWatch.Stop();
            TimeSpan ts = stopWatch.Elapsed;
            //Console.WriteLine($"Image rotated for: {String.Format("{0:000}", ts.Milliseconds)} ms. Thread id: {Thread.CurrentThread.ManagedThreadId}");
            Output += $"Image rotated for: {String.Format("{0:000}", ts.Milliseconds)} ms. Thread id: {Thread.CurrentThread.ManagedThreadId}\n";
        }

        public string StartRotatePic(string path, int angle)
        {
            Angle = angle;
            Pics = Directory.GetFiles(path).Where(s => s.ToLower().EndsWith(".bmp") || s.ToLower().EndsWith(".jpg") || s.ToLower().EndsWith(".png")).ToArray();

            Parallel.For(0, Pics.Length, RotatePic);
            return Output;
        }
    }
}
