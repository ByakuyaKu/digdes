using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using System.Drawing;
using System.Diagnostics;
using System.Linq;
using Microsoft.VisualBasic.FileIO;

namespace Task2
{
    class Program
    {
        private static string Path = Directory.GetCurrentDirectory() + "\\picsfolder";

        private static string[] Pics = Directory.GetFiles(Path).Where(s => s.EndsWith(".bmp") || s.EndsWith(".jpg") || s.EndsWith(".png")).ToArray();


        static void Main(string[] args)
        {
            Parallel.For(0, Pics.Length, RotatePic);
        }

        private static void RotatePic(int i)
        {
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            Console.WriteLine($"Image is rotating... Thread id: {Thread.CurrentThread.ManagedThreadId}");

            Image img = null;
            img = Image.FromFile(Pics[i]);

            if (img != null)
            {
                img.RotateFlip(RotateFlipType.Rotate90FlipNone);
                img.Save(Pics[i]);
                Console.WriteLine($"Image rotated... Thread id: {Thread.CurrentThread.ManagedThreadId}");
            }
            stopWatch.Stop();
            TimeSpan ts = stopWatch.Elapsed;
            Console.WriteLine($"Image rotated for: {String.Format("{0:000}", ts.Milliseconds)} ms. Thread id: {Thread.CurrentThread.ManagedThreadId}");
        }

    }
}