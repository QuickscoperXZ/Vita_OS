using System;

namespace OS5
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.SetCursorPosition(0, 0);
            Console.WriteLine("Y:");
            Console.SetCursorPosition(20, 0);
            Console.WriteLine("X:");
            UntitledClass cls = new UntitledClass();
            Thread ft = new Thread(delegate () { cls.firstThread(); });
            Thread st = new Thread(delegate () { cls.secondThread(); });
            ft.Start();
            st.Start();
        }
    }

    class UntitledClass
    {
        Mutex mut = new Mutex();
        double x = 0, y = 0;

        public void firstThread()
        {
            for (int i = 1; i <= 100; i++)
            {
                mut.WaitOne();
                Thread.Sleep(40);
                y = Math.Sin(x);
                Console.SetCursorPosition(0, i);
                Console.WriteLine(y);
                mut.ReleaseMutex();
            }
        }
        public void secondThread()
        {
            for (int i = 1; i <= 100; i++)
            {
                mut.WaitOne();
                Thread.Sleep(40);
                x = Math.Cos(y);
                Console.SetCursorPosition(20, i);
                Console.WriteLine(x);
                mut.ReleaseMutex();
            }
        }
    }
}