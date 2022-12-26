using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exerciseNum14
{
    interface Base<gen>
    {
        public gen[] replaceElements(gen[] arr);
        

        public int getLengthOfArray
        {
            get;
        }
    }

    class Task3<gen>: Base<gen>
    {
        gen field;
        gen[] array;

        public Task3(gen a, gen[] b)
        {
            field = a;
            array = b;
        }

        public gen[] replaceElements(gen[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                 if(i % 2 == 0)
                {
                    arr[i] = field;
                }
            }
            return arr;
        }

        public int getLengthOfArray 
        {
            get
            {
                return array.Length;
            }
        }

        public override string ToString()
        {
            string temp = "";
            for (int i = 0; i < array.Length; i++)
            {
                temp += array[i] + " ";
            }

            return $"Первое поле: {field}\nВторое поле {temp}";
        }
    }
}
