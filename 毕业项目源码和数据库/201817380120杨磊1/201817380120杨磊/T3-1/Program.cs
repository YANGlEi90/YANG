using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace T3_1
{
    class Program
    {
        static void Main(string[] args)
        {
            string name = "杨磊";
            meeting.SayHello(name, ChineseSay);
            string name1 = "joy";
            meeting.SayHello(name1, AmericanSay);
            string name2 = "泰戈尔";
            meeting.SayHello(name2, TilandSay);
        }
        public static string ChineseSay()
        {
            return "吃了吗?";
        }
        public static string AmericanSay()
        {
            return "How are you?";
        }
        public static string TilandSay()
        {
            return "萨瓦迪卡";
        }
    }
}
