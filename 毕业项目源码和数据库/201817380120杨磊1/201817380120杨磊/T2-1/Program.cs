using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using T2_1.Models;

namespace T2_1
{
    class Program
    {
        static void Main(string[] args)
        {
            //dbTeacher teacher = new dbTeacher()
            //{
                
            //    TeaName = "胡瑶"
            //};
            using(nCovDBContextL db= new nCovDBContextL())
            {
                var stu = db.dbStudent.Find("201817380120");
                Console.WriteLine("姓名：{0}，地址：{1}", stu.stuName, stu.stuAddress);
                //获得学生集合
                var stuList = db.dbStudent.Include("dbDetail"); //贪婪加载 不用virtur
                //var stuList = db.dbStudent.ToList();//显示加载 不用virtur
                //var stuList = db.dbStudent.ToList();//延迟加载 要用virtur

                foreach (var item in stuList)
                {
                    //db.Entry(item).Collection("dbDetail").Load();//配合显示加载
                    //item每一个学生
                    Console.WriteLine("学生的姓名：" + item.stuName);
                    //学生item填表的信息
                    foreach (var item1 in item.dbDetail)
                    {
                        Console.WriteLine("{0},{1},{2},{3}", item1.ID, item1.fillTime, item1.isFever, item1.isCough);
                    }
                }

                //var stu = db.dbStudent.Find("201817380120");
                //foreach (var item1 in stu.dbDetail)
                //{
                //    Console.WriteLine("{0},{1},{2},{3}", item1.ID, item1.fillTime, item1.isFever, item1.isCough);
                //}
            }
            Console.WriteLine("添加成功");
        }
    }
}
