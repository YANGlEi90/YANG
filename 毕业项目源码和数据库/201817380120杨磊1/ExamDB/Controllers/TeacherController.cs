using ExamDB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ExamDB.Controllers
{

    public class TeacherController : Controller
    {
        // GET: Teacher

        //连接数据库
        ExamDBEntities db = new ExamDBEntities();

        /// <summary>
        /// 【【【输出显示老师信息】】】
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            //【【用view()传参】】
            List<Teacher> list = db.Teacher.ToList();  //获取数据库数据
            ViewBag.count = list.Count;
            ViewData["List"] = list;
            return View();
        }

        [HttpPost]
        public ActionResult Index(string teaName)
        {
            List<Teacher> list = db.Teacher.Where(p => p.TeacherName.Contains(teaName)).ToList();
            ViewBag.list = list;
            return View();
        }
        /// <summary>
        /// 【【【输出字符串model:"查询数据成功"，其他类型则直接输出】】】
        /// </summary>
        /// <returns></returns>
        //public ActionResult Show()
        //{
        //    return View(model:"查询数据成功");
        //}


        //【---------查询老师信息-------】                 =======查询一个即可
        public ActionResult ShowMessage()
        {
             //获得请求地址参数
            string id = Request["id"];
            //根据id查数据库存储对象
            var teacher=  db.Teacher.Find(int.Parse(id));
           
            ViewBag.teacher = teacher;
            return View();
        }

        /// <summary>
        /// 【【---------删除--------】】                     =======删除一个即可
        /// </summary>
        /// <returns></returns>
        public ActionResult deletes(string id)
        {
            //获取对象
            Teacher teacher = db.Teacher.Find(int.Parse(id));
            //移除
            db.Teacher.Remove(teacher);
            //执行数据库
            db.SaveChanges();

            //重新指向地址
            return RedirectToAction("Index");
        }

        /// <summary>
        /// 【【---添加的显示页面------】】           =======添加入口
        /// </summary>
        /// <returns></returns>
        public ActionResult Add()
        {
            return View();
        }

        /// <summary>
        /// 在asp.net.mvc框架中，为了限制某个action(动作=方法)只能接收httpPost的请求，httpGet的请求
        /// [httpPost]限制action值接受httpPost的请求，对于httpGet的请求，则提示404找不到页面
        /// 如果action钱没有[httpPost]，也每天[httpGet],则两种请求都接收
        /// 
        /// ---------【真正实现添加的功能】             =======添加出口
        /// </summary>
        /// <param name="teacher"></param>
        /// <returns></returns>
        /// 

        [HttpPost]
        public ActionResult AddShow(Teacher teacher)
        {
            db.Teacher.Add(teacher);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        /// <summary>
        /// 【【---修改的显示页面------】】               =======修改入口
        /// </summary>
        /// <returns></returns>
        public ActionResult Edit(int id)
        {
            Teacher tea = db.Teacher.Find(id);         //传递对象
            return View(tea);
        }

        /// <summary>
        /// DefaultModelBinder 类，自动实现默认模型绑定器
        /// 通过四种途径获得绑定值：
        /// request.Form-----获得表单提交
        /// RouteData.values----------获得路由值
        /// Request.QueryString ----获得URL值
        /// Request.Files ----------获得上传文件值
        /// 
        ///  ---------【真正实现添加的功能】        =======修改出口
        /// </summary>
        /// <returns></returns>
        /// 

        [HttpPost]
        public ActionResult Edit(Teacher oldtea)
        {
            Teacher Newtea = db.Teacher.Find(oldtea.TeacherID);

            Newtea.TeacherName = oldtea.TeacherName;
            Newtea.TeacherLoginName = oldtea.TeacherLoginName;
            Newtea.TeacherLoginPwd = oldtea.TeacherLoginPwd;
            Newtea.TeacherPhone = oldtea.TeacherPhone;
            Newtea.TeacherEmail = oldtea.TeacherEmail;
            //存储数据库
            db.SaveChanges();
            return RedirectToAction("Index");
        }

   
    }
}