using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using YANGBlog.Models;

namespace YANGBlog.Controllers
{
    public class UserController : Controller
    {
        YANGEntities db = new YANGEntities();
        // GET: User
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(string UserName,string PassWord)
        {
            //int count = db.UserInfo.Where(p => p.UserName == UserName && p.PassWord == PassWord).ToList().Count();
            List<UserInfo> list = db.UserInfo.Where(p => p.UserName == UserName && p.PassWord == PassWord).ToList();
            if (list.Count==1)
            {
                Session["UserID"] = list[0].UserId;
                return RedirectToAction("Index","Dynamic");
            }
            else
            {
                return Content("<script>alert('密码错误')</script>");
            }
        }
    }
}