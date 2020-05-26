using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace T3_1
{
    delegate string SayDelegate();
    class meeting
    {
        public static void SayHello(string name, SayDelegate sayDelegate)
        {
            Console.WriteLine(name + sayDelegate());
        }
    }
}
