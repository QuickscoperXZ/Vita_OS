using System;
using System.IO;

namespace OS4
{
    class Program
    {
        static void Main(string[] args)
        {
            threads th = new threads();
            Thread st = new Thread(delegate () { th.secondThread(-10, 1, 1000, 15); });
            Thread ft = new Thread(delegate () { threads.firstThread(15, -10, 1, 1000); });
            ft.Start();
            st.Start();

        }
    }

    class threads
    {
        public static void firstThread(int iterationsCount, double startingPoint, double step, int delay) // n,x,s,d соответственно
        {
            for (int i = 1; i <= iterationsCount; i++)
            {
                StreamWriter writer = new StreamWriter(@"C:\Users\Quickscoper\Documents\Vita_OS\OS4\OS4\results\thread1.dat", true);
                writer.WriteLine($"{DateTime.Now}|{Math.Sin(startingPoint + (step * i))}");
                writer.Close();
                Thread.Sleep(delay);
            }
        }

        public void secondThread(double startingPoint, double step, int delay, int time) //x, s, d, t соответственно
        {
            bool timeIsOver = false;
            DateTime startTime = DateTime.Now;
            DateTime endTime = DateTime.Now.AddSeconds(time);
            int iterationsCount = 1;
            while (!timeIsOver)
            {
                StreamWriter writer = new StreamWriter(@"C:\Users\Quickscoper\Documents\Vita_OS\OS4\OS4\results\thread2.dat", true);
                if (DateTime.Now >= endTime)
                { timeIsOver = true; }
                else
                {
                    writer.WriteLine($"{DateTime.Now}|{Math.Cos(startingPoint + (step * iterationsCount))}");
                    writer.Close();
                    Thread.Sleep(delay);
                }
                iterationsCount++;
            }
        }
    }
}