using System;

namespace ConsoleApp1
{
    class program
    {
        struct numbers
        {
            public int value { get; set; }
            public int count { get; set; }

            public numbers(int value)
            {
                this.value = value;
                count = 1;
            }

            public void getInfo()
            {
                Console.WriteLine($"{value} {count}");
            }
        }

        static void Main(string[] args)
        {
            numbers[] num = new numbers[0];
            Console.Write("Введите размерность массива: ");
            Random rnd = new Random();
            int n = Convert.ToInt32(Console.ReadLine());
            int[] arr = new int[n];
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = rnd.Next(0, 8);
            }
            Console.WriteLine("Массив:");
            for (int i = 0; i < n; i++)
            {
                Console.Write($"{arr[i]} ");
            }
            Console.WriteLine();
            Array.Resize(ref num, num.Length + 1);
            num[0] = new numbers(arr[0]);
            int j = 0;

            for (int i = 1; i < arr.Length; i++)
            {
                if (arr[i] == num[j].value)
                {
                    num[j].count++;
                }
                else
                {
                    j++;
                    Array.Resize(ref num, num.Length + 1);
                    num[j] = new numbers(arr[i]);
                }
            }

            foreach (var item in num)
            {
                item.getInfo();
            }

            int maxCount = int.MinValue;
            for (int i = 0; i < num.Length; i++)
            {
                if (num[i].count >= maxCount)
                {
                    maxCount = num[i].count;
                }
            }

            if(maxCount == 1)
            {
                Console.WriteLine("В массиве нет последовательностей из чисел");
            }
            else
            {
                for (int i = 0; i < num.Length; i++)
                {
                    if (num[i].count == maxCount)
                        Console.WriteLine($"Длина максимальной последовательности равна {num[i].count}, состоящая из чисел {num[i].value}");
                }
            }
        }
    }
}