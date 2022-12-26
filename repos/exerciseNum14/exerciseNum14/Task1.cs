using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exerciseNum14
{
    internal class Task1
    {
        public static void replaceElements<T>(ref T[] arr)
        {
            T temp;

            for (int i = arr.Length - 1; i >= 1; i--)
            {
                temp = arr[i];
                arr[i] = arr[i - 1];
                arr[i - 1] = temp;
            }
        }
    }
}
