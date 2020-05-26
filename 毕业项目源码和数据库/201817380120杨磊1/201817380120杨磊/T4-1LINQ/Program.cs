using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using T4_1LINQ.Models;

namespace T4_1LINQ
{
    class Program
    {
        static void Main(string[] args)
        {
            ////获取数据源
            //int[] numbers = new int[]{ 1, 2, 5, 7, 9, 11, 12, 14 };
            ////写LINQ语句
            //var obj = from a in numbers where a % 2 == 0 select a;
            //foreach (var item in obj)
            //{
            //    Console.WriteLine(item);
            //}

            using (ncovDBEntities db = new ncovDBEntities())
            {
                //1、查询学生信息
                Console.WriteLine("---------第一题------");
                var obj1 = from stu in db.tbStu select stu;
                foreach (var item in obj1)Console.WriteLine("编号:{0},姓名:{1},地址：{2}",item.stuID,item.stuName,item.stuAddress);
                
                //2、查询在湖南长沙的学生信息
                Console.WriteLine("---------第二题------");
                var obj2 = db.tbStu.Where(p => p.stuAddress == "湖南长沙");
                //var obj2 = from stu in db.tbStu where stu.stuAddress=="湖南常德" select stu;
                foreach (var item in obj2)
                {
                    Console.WriteLine("编号:{0},姓名:{1},地址：{2}", item.stuID, item.stuName, item.stuAddress);
                }
                //3、按学生所在地址分组查询学生信息
                Console.WriteLine("---------第三题------");
                var obj3 = from stu in db.tbStu group stu by stu.stuAddress ;
                foreach (var item in obj3)
                {
                    Console.WriteLine("学生所在地区：{0}",item.Key);
                    var m = from stu in db.tbStu where item.Key==stu.stuAddress select stu;
                    foreach (var b in m)
                    {
                        Console.WriteLine("编号:{0},姓名:{1}", b.stuID, b.stuName);
                    }
                    //Console.WriteLine("地址：{0}，人数；{1}",item.Key,item.Count());
                }
                //4、查询不同所在地的学生数量
                Console.WriteLine("---------第四题------");
                var obj4 = from stu in db.tbStu group stu by stu.stuAddress into g select new { GroupKey = g.Key, Person = g.Count() };
                foreach (var item in obj4)
                {
                    Console.WriteLine("地址：{0}，人数；{1}", item.GroupKey, item.Person);
                }
                //5、查询学生姓名、学生所在地址，并通过姓名降序排列
                Console.WriteLine("---------第五题------");
                var obj5 = from stu in db.tbStu orderby stu.stuName ascending select stu;
                foreach (var item in obj5)
                {
                    Console.WriteLine("编号:{0},姓名:{1},地址：{2}", item.stuID, item.stuName, item.stuAddress);
                }
                //6、联合表查询，学生的上报填表信息
                var obj6 = from a in db.tbStu join b in db.tbDetail on a.stuID equals b.stuID  select new { value1=a,value2=b};
                foreach (var item in obj6)
                {
                    Console.WriteLine("姓名：{0}，上报时间：{1}，是否咳嗽：{2}，是否发烧：{3}",item.value1.stuName,item.value2.fillTime,item.value2.isCough,item.value2.isFever);
                }
            }
        }
    }
}
