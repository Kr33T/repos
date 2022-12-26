using System;
using System.Diagnostics;

namespace pyramid
{
    class program
    {
        static void Main(string[] args)
        {
            int[] arr = new int[15];

            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = i;
            }

            int a = 0, b = 1;
            for (int i = 0; i < arr.Length; i++)
            {
                Console.Write($"{arr[i]} ");
                if(i == a)
                {
                    Debug.WriteLine($"a - {a}; i - {i}");
                    Console.WriteLine();
                    b++;
                    a += b;
                }
            }
        }
    }
}