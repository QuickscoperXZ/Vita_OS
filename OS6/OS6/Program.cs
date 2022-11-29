using System;
using System.IO;

namespace OS6
{
    class Program
    {
        static void Main(string[] args)
        {

        }
    }
    class Untitled
    {
        StreamReader sr;
        string line;
        
        public Untitled()
        {
            sr = new StreamReader(@"");
        }
        public void readLine()
        {
            sr.ReadLine();
        }
    }
}