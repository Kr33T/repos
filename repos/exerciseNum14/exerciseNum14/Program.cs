using System;

namespace exerciseNum14
{
    class program
    {
        static void Main(string[] args)
        {
            Console.Write("Введите номер задачи: ");
            int num = Convert.ToInt32(Console.ReadLine());
            switch (num)
            {
                case 1:
                    Random rnd = new Random();
                    int[] ints = new int[rnd.Next(4, 10)];
                    for (int i = 0; i < ints.Length; i++)
                    {
                        ints[i] = rnd.Next(0, 10);
                    }
                    Console.WriteLine("Исходный массив:");
                    foreach (var item in ints)
                    {
                        Console.Write($"{item} ");
                    }
                    Console.WriteLine();
                    Task1.replaceElements(ref ints);
                    Console.WriteLine("Полученный массив:");
                    foreach (var item in ints)
                    {
                        Console.Write($"{item} ");
                    }
                    break;
                case 2:
                    Task2<string> obj = new Task2<string>();
                    Console.Write("Введите строку, которую хотите присвоить закрытому полю обобщенного класса: ");
                    obj.MyProp = Console.ReadLine();
                    Console.Write("Значение закрытого поля обобщенного класса: ");
                    Console.WriteLine(obj.MyProp);
                    break;
                case 3:
                    int[] arr = new int[10];
                    for (int i = 0; i < arr.Length; i++)
                    {
                        arr[i] = i + 1;
                    }
                    Task3<int> obj1 = new Task3<int>(5, arr);

                    Console.WriteLine("Размерность массива: " + obj1.getLengthOfArray);

                    arr = obj1.replaceElements(arr);

                    Console.WriteLine("Измененный массив: ");

                    for (int i = 0; i < arr.Length; i++)
                    {
                        Console.Write($"{arr[i]} ");
                    }

                    Console.WriteLine("\n" + obj1.ToString());
                    break;
                case 4:
                    Task4<int> a = new Task4<int>();
                    a.array = new int[10];
                    for (int i = 0; i < a.array.Length; i++)
                    {
                        a.array[i] = i + 1;
                    }
                    Task4<int> b = new Task4<int>();
                    b.array = new int[5];
                    for (int i = b.array.Length - 1; i >= 0; i--)
                    {
                        b.array[i] = i;
                    }

                    foreach (var item in a.array)
                    {
                        Console.Write($"{item} ");
                    }
                    Console.WriteLine();
                    foreach (var item in b.array)
                    {
                        Console.Write($"{item} ");
                    }
                    Console.WriteLine();
                    Task4<int> c = a + b;
                    for (int i = 0; i < c.array.Length; i++)
                    {
                        Console.Write(c.array[i] + " ");
                    }
                    break;
            }
        }
    }
}