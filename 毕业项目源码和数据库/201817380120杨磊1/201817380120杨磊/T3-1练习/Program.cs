using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace T3_1练习
{
    class Program
    {
        static void Main(string[] args)
        {
            //案例2：实现计算器Calculator的计算Calculate（加减乘除）功能
            //Plus：+
            //Minus：-
            //Multip：*
            //Division：/
            int a=3, b=2;
            Console.WriteLine(Fin.Find(a, b, Plus));
            Console.WriteLine(Fin.Find(a, b, Minus));
            Console.WriteLine(Fin.Find(a, b, Multip));
            Console.WriteLine(Fin.Find(a, b, Division));
            
        }
        public static int Plus(int a,int b)
        {
            return a + b;
        }
        public static int Minus(int a, int b)
        {
            return a - b;
        }
        public static int Multip(int a, int b)
        {
            return a * b;
        }
        public static int Division(int a, int b)
        {
            return a / b;
        }
    }
}
