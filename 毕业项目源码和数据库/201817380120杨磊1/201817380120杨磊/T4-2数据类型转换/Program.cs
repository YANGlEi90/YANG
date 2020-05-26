using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace T4_2数据类型转换
{
    class Program
    {
        static void Main(string[] args)
        {
            ArrayList list = new ArrayList();
            list.Add("1");
            list.Add("2");
            list.Add("123");
            list.Add("1234");
            list.Add("asd");
            var value = list.ToArray();
            foreach (var item in value)
            {
                Console.WriteLine(item);
            }
            //全部转—转换Cast<int>
            //var value2 = list.Cast<int>();
            //foreach (var item in value2)
            //{
            //    Console.WriteLine(item);
            //}
        }
    }
}
