using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Web_MVC.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        //【【控制器】】】


        /// <summary>
        /// 页面
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            return View();
        }


        /// <summary>
        /// 登录页面
        /// </summary>
        /// <returns></returns>
        public ActionResult Register()
        {
            return View();
        }
    }
}