using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace T3_2迭代器练习
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
            //var obj = GetLIst(nba_stars);
            var obj = nba_stars.Where(a=>a.FirstName.Length>=3&&a.Champion>0).ToList();
            Console.WriteLine("球员时代得到过总冠军，并且FirstName长度至少为3的NBA球星");
            foreach (var item in obj)
            {
                Console.WriteLine("姓名："+item.FirstName+"·"+item.LastName+"  总冠军数量："+item.Champion);
            }
        }

        /// <summary>
        /// 迭代器关键字用IEnumerable来接
        /// 通过循环遍历
        /// return 前面要加yield
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        //public static IEnumerable<NBA_Star> GetLIst(List<NBA_Star> list)
        //{
        //    foreach (var item in list)
        //    {
        //        if (item.FirstName.Length>=3&&item.Champion>0)
        //        {
        //            //将满足条件的球星放置到迭代器中
        //            yield return item;
        //        }
        //    }
        //}
    }
}
