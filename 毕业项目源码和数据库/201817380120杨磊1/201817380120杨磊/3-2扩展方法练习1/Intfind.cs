using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3_2扩展方法练习1
{
    static class Intfind
    {
        public static bool Intfund1(this int a) {

            if (a%2==0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
