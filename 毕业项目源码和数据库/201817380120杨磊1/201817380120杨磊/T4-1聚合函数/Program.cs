using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace T4_1聚合函数
{
    class Program
    {
        static void Main(string[] args)
        {
            var nba_stars = new List<NBA_Star> {
                new NBA_Star{ FirstName="迈克尔", LastName="乔丹", Champion=6},
                new NBA_Star{ FirstName="蒂姆", LastName="邓肯", Champion=5},
                new NBA_Star{ FirstName="勒布朗", LastName="詹姆斯", Champion=3},
                new NBA_Star{ FirstName="史蒂芬", LastName="库里", Champion=3},
                new NBA_Star{ FirstName="史蒂夫", LastName="纳什", Champion=0}
            };
            //Count
            var result = nba_stars.Count();
            Console.WriteLine("总行数：");
            Console.WriteLine(result);
            //LongCount
            var result1 = nba_stars.Where(s=>s.Champion>3).LongCount();
            Console.WriteLine("冠军大于3的行数：");
            Console.WriteLine(result1);
            //Max
            var result2 = nba_stars.Select(s => s.Champion).Max();
            Console.WriteLine("最大值");
            Console.WriteLine(result2);
            //Min
            var result3 = nba_stars.Select(s => s.Champion).Min();
            Console.WriteLine("最小值");
            Console.WriteLine(result3);
            //Sum
            var result4 = nba_stars.Select(s => s.Champion).Sum();
            Console.WriteLine("和");
            Console.WriteLine(result4);
            //Average
            var result5 = nba_stars.Select(s => s.Champion).Average();
            Console.WriteLine("平均值");
            Console.WriteLine(result5);

            var obj = nba_stars.GroupBy(s => s.FirstName);
            foreach (var item in obj)
            {
                Console.WriteLine("Key"+item.Key);
                foreach (var item1 in item)
                {
                    Console.WriteLine("\t{0},{1},{2}",item1.FirstName,item1.LastName,item1.Champion);
                }
            }
            //ElementAt
            var star = nba_stars.ElementAt(1);
            Console.WriteLine(star.FirstName);
            //ElementAtOrDefault
            var star1 = nba_stars.ElementAtOrDefault(1);
            Console.WriteLine(star1.FirstName);
            //First
            var star2 = nba_stars.First();
            Console.WriteLine(star2.FirstName);
            
           
            //Last
            var star5 = nba_stars.Last();
            Console.WriteLine(star5.FirstName);
            //LastOrDefault
            var star6 = nba_stars.LastOrDefault(p=>p.FirstName=="史蒂芬");
            Console.WriteLine(star6.FirstName);
            //Single
            //SingleOrDefault
            var star7 = nba_stars.Single(p => p.FirstName == "史蒂芬");
            Console.WriteLine(star7.FirstName);
            //1、当集合中只有一个元素时使用Single
            //2、当集合中不包含任何元素但需要返回默认值时，可以使用SingleORDefault
            //3、当集合中包含多个元素并想抛出异常时，可以使用Single或SingleOrDefault
            //4、无论集合中是否有元素，我们都想要返回一个记录时，可以使用以OeDefault结尾的方法
        }
    }
}
