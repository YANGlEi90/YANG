using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StuSystem.Controllers
{
    public class TestController : Controller
    {
        // GET: Test
        public ActionResult Index()
        {
            return View();
        }
        /// <summary>
        /// 引用分布页
        /// </summary>
        /// <returns></returns>
        public ActionResult Login()
        {
            return View();
        }
    }
}