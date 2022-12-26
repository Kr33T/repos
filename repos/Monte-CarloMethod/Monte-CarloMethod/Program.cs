using System;

namespace Monte_CarloMethod
{
    class program
    {
        public struct Borders
        {
            public int x, y;
        }

        public struct RandomDots
        {
            public int x, y;
        }

        static void Main(string[] args)
        {
            List<Borders> coordinates = new List<Borders>();
            coordinates.Add(new Borders { x = 3, y = 2 });
            coordinates.Add(new Borders { x = 3, y = 12 });
            coordinates.Add(new Borders { x = 13, y = 2 });
            coordinates.Add(new Borders { x = 13, y = 12 });

            int xMax = int.MinValue, yMax = int.MinValue;
            int xMin = int.MaxValue, yMin = int.MaxValue;

            for (int i = 0; i < coordinates.Count; i++)
            {
                if (coordinates[i].x >= xMax)
                {
                    xMax = coordinates[i].x;
                }
                if (coordinates[i].y >= yMax)
                {
                    yMax = coordinates[i].y;
                }
                if (coordinates[i].x <= xMin)
                {
                    xMin = coordinates[i].x;
                }
                if (coordinates[i].y <= yMin)
                {
                    yMin = coordinates[i].y;
                }
            }
            Console.WriteLine($"{xMax} {yMax} {xMin} {yMin}");
            for (int i = xMin; i <= xMax; i++)
            {
                for (int j = yMin; j <= yMax; j++)
                {
                    coordinates.Add(new Borders { x = i, y = j });
                }
            }

            Random rnd = new Random();
            List<RandomDots> randoms = new List<RandomDots>();

            for (int i = 0; i <= 1000; i++)
            {
                randoms.Add(new RandomDots { x = rnd.Next(0, 100), y = rnd.Next(0, 100) });
            }

            int kolInside = 0, kolOutside = 0;

            //for (int i = 0; i < coordinates.Count; i++)
            //{
            //    yMin = int.MaxValue;
            //    yMax = int.MinValue;
            //    if(randoms.Where(x => x.x == coordinates[i].x).Count() > 0)
            //    {
            //        if(yMax <= coordinates[i].y)
            //        {
            //            yMax = coordinates[i].y;
            //        }
            //        if(yMin >= coordinates[i].y)
            //        {
            //            yMin = coordinates[i].y;
            //        }
            //    }
            //    Console.WriteLine(yMin + " " + yMax);
            //    if (randoms.Where(x => yMin <= x.y && x.y <= yMax).Count() == 1) kolInside++;
            //    else kolOutside++;
            //}

            bool check1 = false, check2 = false;

            for (int i = 0; i < coordinates.Count; i++)
            {
                yMin = int.MaxValue;
                yMax = int.MinValue;
                for (int j = 0; j < randoms.Count; j++)
                {
                    check1 = false;
                    check2 = false;
                    if (randoms[j].x == coordinates[i].x)
                    {
                        if (coordinates[i].y >= yMax)
                        {
                            yMax = coordinates[i].y;
                            check1 = true;
                        }
                        if (coordinates[i].y <= yMin)
                        {
                            yMin = coordinates[i].y;
                            check2 = true;
                        }
                        if(check1 && check2)
                        {
                            if (yMin <= randoms[i].y && randoms[i].y <= yMax) kolInside++;
                            else kolOutside++;
                        }
                    }
                    //Console.WriteLine(yMin + " " + yMax);
                    
                }
            }

            //foreach (var item in randoms)
            //{
            //    Console.WriteLine(item.x + " " + item.y);
            //}

            Console.WriteLine(kolInside + " " + kolOutside);
        }
    }
}