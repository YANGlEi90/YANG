using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using T1_1.Models;

namespace T1_1
{
    class Program
    {
        static void Main(string[] args)
        {

            using (ncovDBEntities db = new ncovDBEntities())
            {
                Console.WriteLine("-------TOdictionary--key value键值对----");
                var obj = db.tbStu.ToDictionary(p=>p.stuID);
                Console.WriteLine("-------直接循环");
                foreach (var item in obj)
                {
                    Console.WriteLine("{0},{1},{2}",item.Value.stuID,item.Value.stuName,item.Value.stuAddress);
                }
                Console.WriteLine("-------TolookUp()---key value键值对-1对多----");
                var obj2 = db.tbStu.ToLookup(p => p.stuID);
                foreach (var item in obj2)
                {
                    Console.WriteLine(item.Key);
                    foreach (var item1 in item)
                    {
                        Console.WriteLine("{0},{1},{2}", item1.stuID, item1.stuName, item1.stuAddress);
                    }
                }

                //Console.WriteLine("-------循环Values");
                //foreach (var item in obj.Values)
                //{
                //    Console.WriteLine("{0},{1},{2}", item.stuID, item.stuName, item.stuAddress);
                //}
                //Console.WriteLine("-------通过Keys循环");
                //foreach (var item in obj.Keys)
                //{
                //    Console.WriteLine("{0},{1},{2}", obj[item].stuID, obj[item].stuName, obj[item].stuAddress);
                //}
            }
            using (ncovDBEntities db = new ncovDBEntities())
            {
                Console.WriteLine("-------TOdictionary--key value键值对----");
                Console.WriteLine("-------将具体的某项值作为dictionary的value值----");
                //var obj = db.tbStu.ToDictionary(p => p.stuID, k => k.stuName);
                //foreach (var item in obj)
                //{
                //    Console.WriteLine(item);
                //}
                //Console.WriteLine("-------将自定义对象作为dictionary的value值----");
                //var obj = db.tbStu.ToDictionary(p => p.stuID, k => new { name = k, address = k.stuAddress });
                //foreach (var item in obj.Values)
                //{
                //    Console.WriteLine(item.name+item.address);
                //}
                
            }















            //添加
            //创建实体

            //tbTea tea = new tbTea()
            //{
            //    TeaName = "胡瑶",
            //};
            ////添加
            //using (ncovDBEntities db = new ncovDBEntities())
            //{
            //    tbStu stu = new tbStu()
            //    {
            //        stuID = "201817380120",
            //        stuName = "杨磊",
            //        stuAddress = "湖南常德"
            //    };
            //    //在上下文类学生实体集合中添加学生信息
            //    db.tbStu.Add(stu);
            //    //保存
            //    db.SaveChanges();
            //}
            //Console.WriteLine("添加成功");

            //Console.WriteLine();
            //Console.WriteLine("学生信息如下：");

            //using (ncovDBEntities db = new ncovDBEntities())
            //{
            //    List<tbStu> list = db.tbStu.ToList();
            //    foreach (var item in list)
            //    {
            //        Console.WriteLine("学生的ID是：{0},学生的姓名是：{1},学生的地址：{2}", item.stuID, item.stuName, item.stuAddress);
            //    }
            //}
            //Console.WriteLine();

            //根据主键去查询
            //using (ncovDBEntities db = new ncovDBEntities())
            //{
            //    var stu1 = db.tbStu.Find("201817380120");
            //    Console.WriteLine("学生的姓名是："+ stu1.stuName);
            //    Console.WriteLine("学生的ID是是：" + stu1.stuID);
            //    Console.WriteLine("学生的地址是：" + stu1.stuAddress);
            //}
            //修改方法一
            //using (ncovDBEntities db = new ncovDBEntities())
            //{
            //    var stu = db.tbStu.Find("201817380120");
            //    stu.stuAddress = "湖南长沙";
            //    db.SaveChanges();
            //}
            //修改方法二

            //var stu = db.tbStu.Find("201817380120");
            //stu.stuAddress = "湖南长沙";
            //db.Entry(stu).State = System.Data.Entity.EntityState.Modified;
            //db.SaveChanges();
            //Console.WriteLine("修改成功"); 
            //删除---
            //var stu = db.tbStu.Find("201817380120");
            //db.tbStu.Remove(stu);
            //db.SaveChanges();
            //Console.WriteLine("删除成功");

            //    var stu = db.tbStu.Find("201817380120");
            //    //db.tbStu.Remove(stu);
            //    db.Entry(stu).State = System.Data.Entity.EntityState.Deleted;
            //    db.SaveChanges();
            //    Console.WriteLine("删除成功");

        }
    }
}
