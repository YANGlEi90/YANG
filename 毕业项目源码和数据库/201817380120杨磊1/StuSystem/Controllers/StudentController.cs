using StuSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StuSystem.Controllers
{
    public class StudentController : Controller
    {

        StuSystemEntities db = new StuSystemEntities();
        // GET: Student
        public ActionResult Index()
        {
           List<Student> list= db.Student.Include("Grades1").ToList(); //贪婪加载
            return View(list);     //return View(list); 对象传递
        }
      
        public ActionResult Register()
        {

            //动态获取下拉框的值
           List<SelectListItem> list=  db.Grades.Select(p => new SelectListItem()
            {
                Text = p.GradesName,
                Value = p.GradesID.ToString()

            }).ToList(); 
            ViewBag.GradeItem = list;
            return View();
        }
        [HttpPost]
        public ActionResult Register(Student stu)                   //----添加学生信息
        {
            //判断是否通过模型验证
            if (ModelState.IsValid)
            {
                db.Student.Add(stu);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                //动态获取下拉框的值
                List<SelectListItem> list = db.Grades.Select(p => new SelectListItem()
                {
                    Text = p.GradesName,
                    Value = p.GradesID.ToString()

                }).ToList();
                ViewBag.GradeItem = list;
                return View();

            }
          
        }


        }
}