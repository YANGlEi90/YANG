using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace T3_2lambda表达式
{
    delegate double CalculateDelegate(double a, double b);
    class Program
    {
        static void Main(string[] args)
        {
            //lambda表达式；匿名函数；能够读取其他函数内部变量的函数
            double x = 10;
            double y = 5;
            //c#1.0
            //Show(x, y, Jia);

            //c#2.0
            //Show(x, y, delegate (double a, double b)
            //  {
            //      return a + b;
            //  });

            //c#3.0
            //  参数列表=>方法体  goes to 移入的意思
            //Show(x, y, (a, b) =>
            //{
            //    return a + b;
            //});
            //lambda表达式
            Show(x, y, (a, b) => a + b);
           
        }
        public static void Show(double a,double b,CalculateDelegate ca)
        {
            Console.WriteLine("运算的结果市："+ca(a,b));
        }
        public static double Jia(double a,double b)
        {
            return a + b;
        }
    }
}
