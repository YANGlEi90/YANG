using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace T3_1练习
{
    delegate int FinDelegate(int a,int b);
    class Fin
    {
        public static int Find(int a,int b, FinDelegate finDelegate) {
           return finDelegate(a, b);
        }
    }
}
