using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exerciseNum14
{
    class Task4<gen>
    {
        public gen[] array;

        public static Task4<gen> operator+(Task4<gen> a, Task4<gen> b)
        {
            gen[] temp = new gen[0];
            for (int i = 0; i < a.array.Length; i++)
            {
                Array.Resize(ref temp, temp.Length + 1);
                temp[temp.Length - 1] = a.array[i];
            }
            for (int i = 0; i < b.array.Length; i++)
            {
                Array.Resize(ref temp, temp.Length + 1);
                temp[temp.Length - 1] = b.array[i];
            }
            Task4<gen> c = new Task4<gen>();
            c.array = temp;
            return c;
        }
    }
}
