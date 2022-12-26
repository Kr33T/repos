using System;
using System.IO;

namespace writeInFile
{
    class program
    {
        public int sum (int a, int b)
        {
            return a + b;
        }

        static void Main(string[] args)
        {
            StreamWriter sw = new StreamWriter("outPut.txt");
            sw.WriteLine("Hello world!");
            sw.WriteLine("aboba");
            sw.WriteLine("cringe");
            sw.WriteLine("kekw");
            sw.Write("apcchigma");
            sw.Write("CPU");

            Random rnd = new Random();

            for (int i = 0; i < rnd.Next(0, 20); i++)
            {
                debugAndTrace.debuging($"{i}");
            }

            sw.Close();
        }
    }
}