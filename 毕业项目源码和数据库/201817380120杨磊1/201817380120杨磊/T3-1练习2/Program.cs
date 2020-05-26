using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace T3_1练习2
{
    delegate void lookDelegate();
    class Program
    {
        static void Main(string[] args)
        {
            for (int i = 0; i < 100; i++)
            {
                bool result = false;
                Random random = new Random();
                int num = random.Next();
                result = (num % 3 == 0);
                IsCarComeHere(result);
                if (result)
                {
                    break;
                }
            }
        }

        private static void IsCarComeHere(bool result)
        {
            if (result)
            {
                lookDelegate look = new lookDelegate(Call);
                look += new lookDelegate(Run);
                look.Invoke();
            }
            else
            {
                Console.WriteLine("猫没来，继续巡逻");
                
            }
        }

        private static void Run()
        {
            Console.WriteLine("Jerry向后方跑去");
        }

        private static void Call()
        {
            Console.WriteLine("猫来了，快点跑");
        }
    }
}
