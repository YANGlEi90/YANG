using Account.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Account.Controllers
{
    public class HomeController : Controller
    {
        AccountDBEntities db = new AccountDBEntities();

       
        public ActionResult Index()
        {
            return View();
        }
        /// <summary>
        /// 权限管理系统的--【登录】
        /// </summary>
        /// <param name="Nmme"></param>
        /// <param name="pwd"></param>
        /// <returns></returns>
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(string Account, string Pwd)
        {
            //根据账号密码获取相应的对象
            var user = db.UserInfos.SingleOrDefault(p=>p.Account== Account && p.Pwd== Pwd);

            //判断账号密码存不存在
            if (user !=null)
            {
                //用Session存储
                Session["user"] = user;

                //查询该用户对应的菜单信息--【这里使用了视图】
                //v_user_menus---将视图作为查询对象，where---根据当前用户ID筛选，distinct---过滤重复项

                List<v_user_menus> list = db.v_user_menus.Where(p=>p.UserID== user.ID).Distinct().ToList();
               
                Session["v_user_menus"] = list;

                //跳转到主页
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
        public ActionResult Exit()
        {
            //点击注销按钮，清空 Session
            Session["user"] = null;
            //跳转到登录界面
           return RedirectToAction("Login");

        }

       
    }
}