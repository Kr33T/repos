using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exerciseNum14
{
    class Task2<Gen>
    {
        Gen field;

        public Gen MyProp 
        { 
            get 
            {
                return field;
            } 
            set 
            {
                field = value;
            } 
        }
    }
}
