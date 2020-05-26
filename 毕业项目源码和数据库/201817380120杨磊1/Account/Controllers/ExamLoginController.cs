using Account.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Account.Controllers
{
    public class ExamLoginController : Controller
    {

        AccountDBEntities db = new AccountDBEntities();

        // GET: ExamLogin
        public ActionResult Index()
        {
            return View();
        }
        /// <summary>
        /// 考试系统登录---老师
        /// </summary>
        /// <returns></returns>
        public ActionResult LoginTeacher()
        {
            return View();
        }
        [HttpPost]
        public ActionResult LoginTeacher(string TeacherLoginName,string TeacherLoginPwd)
        {
          Teacher teacher=db.Teacher.SingleOrDefault(p => p.TeacherLoginName == TeacherLoginName && p.TeacherLoginPwd == TeacherLoginPwd);

            if (teacher !=null)
            {
                Session["teacher"] = teacher;
                return RedirectToAction("Index");
            }
            else
            {
                return Content("<script>alert('账号或密码不正确');history.go(-1)</script>");
               
            }
        }

        /// <summary>
        /// 考试系统登录---学生
        /// </summary>
        /// <returns></returns>
        public ActionResult LoginStudent()
        {
            return View();
        }
        [HttpPost]
        public ActionResult LoginStudent(string StuLoginName, string StuLoginPwd)
        {
            Student stu = db.Student.SingleOrDefault(p => p.StuLoginName == StuLoginName && p.StuLoginPwd == StuLoginPwd);

            if (stu != null)
            {
                Session["stu"] = stu;
                return RedirectToAction("Index");
            }
            else
            {
                return Content("<script>alert('账号或密码不正确');history.go(-1)</script>");

            }
        }


        /// <summary>
        /// 注销按钮
        /// </summary>
        /// <returns></returns>
        public ActionResult Logout()
        {
            //点击注销按钮，清空 Session
            Session["teacher"] = null;
           Session["stu"] =null;
            //跳转到登录界面
            return RedirectToAction("Index");

        }

        public ActionResult AjaxLogin()
        {
            return View();
        }
        public string CheckLoginName(string LoginName)
        {
            Student stu= db.Student.FirstOrDefault(p => p.StuLoginName == LoginName);
            if (stu==null)
            {
                return "false";
            }
            else
            {
                return "true";
            }
            
        }
    }
}