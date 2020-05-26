using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3_2扩展方法
{
   static class StringExtensions
    {
        public static int WordCount(this string content)
        {
            return content.Split(new[] { '.', ',', ' ', '!', '?', ':' }, StringSplitOptions.RemoveEmptyEntries).Length;
        }
    }
}
