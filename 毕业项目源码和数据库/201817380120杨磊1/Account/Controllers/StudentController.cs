using Account.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Account.Controllers
{
    public class StudentController : Controller
    {

        AccountDBEntities db = new AccountDBEntities();

        // GET: Student
        public ActionResult Index()
        {
            List<Student> students = db.Student.ToList();
            ViewBag.list = students;
            return View();
        }

        /// <summary>
        /// 学生注册
        /// </summary>
        /// <returns></returns>
        public ActionResult Create()
        {
            return View();

        }

        [HttpPost]
        public ActionResult Create(Student student)
        {
            db.Student.Add(student);
            db.SaveChanges();
            return RedirectToAction("Index");

        }

        /// <summary>
        /// 学生信息的修改
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public ActionResult StuEdit(int ID)
        {
            Student students = db.Student.Find(ID);
            ViewBag.info = students;
            return View();
        }
        [HttpPost]
        public ActionResult StuEdit(Student student)
        {
            db.Entry(student).State= System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        /// <summary>
        /// 学生信息详情页
        /// </summary>
        /// <returns></returns>
        public ActionResult StuDetails(int ID)
        {
            Student student = db.Student.Find(ID);
            ViewBag.info = student;
            return View();
        }

        /// <summary>
        /// 学生信息的删除
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public ActionResult StuDelete(int ID) {
            Student student = db.Student.Find(ID);
            db.Student.Remove(student);
            db.SaveChanges();
            return RedirectToAction("Index");

        }
    }
}