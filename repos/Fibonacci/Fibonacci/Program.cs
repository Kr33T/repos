using System;

namespace incomingInspection
{
    class program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.Clear();
                Console.Write("Введите номер задачи: ");
                int num = Convert.ToInt32(Console.ReadLine());
                switch (num)
                {
                    case 1:
                        task1();
                        break;
                    case 2:
                        task2();
                        break;
                    case 3:
                        task3();
                        break;
                    case 4:
                        task4();
                        break;
                    case 5:
                        task5();
                        break;
                    case 6:
                        task6();
                        break;
                    case 7:
                        task7();
                        break;
                    case 8:
                        task8();
                        break;
                }
                Console.WriteLine("Если хотите повторить выполнение программы, нажмите Y, если нет, то любую другую клавишу");
                if (Console.ReadKey().Key != ConsoleKey.Y)
                {
                    break;
                }
            }
        }

        static void task1()
        {
            Console.WriteLine();
            Console.Write("Введите первое вещественное число: ");
            double a = Convert.ToDouble(Console.ReadLine());
            Console.Write("Введите второе вещественное число: ");
            double b = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine($"Результат: {Math.Pow(a, b)}");
        }

        static void task2()
        {
            int x1, y1, x2, y2;
            Console.Write("Введите x1: ");
            x1 = Convert.ToInt32(Console.ReadLine());
            Console.Write("Введите y1: ");
            y1 = Convert.ToInt32(Console.ReadLine());
            Console.Write("Введите x2: ");
            x2 = Convert.ToInt32(Console.ReadLine());
            Console.Write("Введите y2: ");
            y2 = Convert.ToInt32(Console.ReadLine());
            int x3 = x1, y3 = y2;

            double a, b, c;
            a = dekart(x1, y1, x2, y2); //гипотенуза
            b = dekart(x1, y1, x3, y3);
            c = dekart(x2, y2, x3, y3);

            Console.WriteLine($"\nСтороны треугольника:\nгипотенуза - {a}\nпервый катет - {b}\nвторой катет - {c}\nПериметр треугольника: {a + b + c}\nПлощадь треугольника: {(b * c) / 2}");
        }

        static double dekart(int x1, int y1, int x2, int y2)
        {
            return Math.Sqrt(Math.Pow(x1 - x2, 2) + Math.Pow(y1 - y2, 2));
        }

        static void task3()
        {
            Console.WriteLine();
            Console.Write("Введите число: ");
            int n = Convert.ToInt32(Console.ReadLine());
            if (n % 3 == n % 2)
            {
                Console.WriteLine($"Число {n} дает одинаковый остаток как при делении на 3, так и при делении на 2 (остаток: {n % 2})");
            }
            else
            {
                Console.WriteLine($"Число {n} дает разный остаток при делении на 3 и на 2.\nОстаток при делении на 3 - {n % 3}\nОстаток при делении на 2 - {n % 2}, ");
            }
        }

        static void task4()
        {
            Console.WriteLine();
            ulong n;
            while (true)
            {
                Console.Write("Введите число в котором не более 10 разрядов: ");
                n = Convert.ToUInt64(Console.ReadLine());
                if (n.ToString().Length > 0 && n.ToString().Length <= 10 && n > 0)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Вы ввели слишком большое число!\nПовторите ввод");
                }
            }
            List<int> arr = new List<int>();
            while(n.ToString().Length != 1)
            {
                arr.Add(Convert.ToInt32(n) % 10);
                n /= 10;
            }
            arr.Add(Convert.ToInt32(n));
            foreach (var item in arr)
            {
                Console.Write($"{item} ");
            }
        }

        static void task5()
        {
            Console.WriteLine();
            Console.Write("Введите x: ");
            int x = Convert.ToInt32(Console.ReadLine());
            Console.Write("Введите y: ");
            int y = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine($"Значение выражения: {(1+Math.Sin(Math.Sqrt(x + 1)))/(Math.Cos(12 * y - 4))}");
        }

        static void task6()
        {
            Console.WriteLine();
            Console.Write("Введите количество чисел: ");
            int n = Convert.ToInt32(Console.ReadLine());
            ulong[] arr = new ulong[n * 2 + 2];
            arr[0] = 0;
            arr[1] = 1;
            for (int i = 2; i < arr.Length; i++)
            {
                arr[i] = arr[i - 1] + arr[i - 2];
            }
            for (int i = 0; i < arr.Length; i++)
            {
                if (i % 2 == 0 && i != 0)
                {
                    Console.WriteLine($"{i}) {arr[i]}");
                }
            }
        }

        static void task7()
        {
            Console.WriteLine();
            Console.Write("Введите n: ");
            int n = Convert.ToInt32(Console.ReadLine());
            double sum = 0;
            double temp;
            for (int i = 2; i <= n + 1; i++)
            {
                temp = i;
                sum += (temp - 1) / temp;
            }
            Console.WriteLine($"Сумма последовательности: {sum}");
        }

        static void task8()
        {
            Console.WriteLine();
            double[] results = new double[3];
            for (int i = 0; i < results.Length; i++)
            {
                Console.Write($"Введите результаты заплыва {i + 1} спортсмена: ");
                results[i] = Convert.ToDouble(Console.ReadLine());
            }
            int winnerIndex = 0;
            double winnerScore = double.MaxValue;
            for (int i = 0; i < results.Length; i++)
            {
                if(winnerScore > results[i])
                {
                    winnerIndex = i;
                    winnerScore = results[i];
                }
            }
            Console.WriteLine($"\nВыиграл спортсмен под номером {winnerIndex + 1} с временем {winnerScore}");
        }
    }
}