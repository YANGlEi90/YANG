using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3_2扩展方法
{
    class Program
    {
        static void Main(string[] args)
        {
            //计算一段文字中有多少个单词
            string countent = "hello,How are you?";
            int count = countent.WordCount();
            Console.WriteLine("{0}中有{1}个单词",countent,count);
            //1、新建一个静态类
            //2、新建一个静态的方法
            //3、将类、方法添加统一访问修饰符，一般都是public
            //4、方法必须要有一个参数，第一个参数指明方法作用于哪种类型，必须添加，这个参数用this修饰，其他参数为形参
            //5、扩展方法的调用与调用类型的实列方法一样
            //6、如果引用的扩展方法所在的类的命名空间不一致，需要添加using指令，用于指定包含扩展方法类的命名空间
        }
    }
}
