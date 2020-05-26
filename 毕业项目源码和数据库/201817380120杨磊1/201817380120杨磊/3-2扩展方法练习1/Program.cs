using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3_2扩展方法练习1
{
    class Program
    {
        static void Main(string[] args)
        {
            int a= 11;
            if (a.Intfund1())
            {
                Console.WriteLine("{0}为偶数",a);
            }
            else
            {
                Console.WriteLine("{0}为基数", a);
            }
            
        }
    }
}
