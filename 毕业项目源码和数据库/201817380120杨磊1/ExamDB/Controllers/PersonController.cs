using ExamDB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ExamDB.Controllers
{
    public class PersonController : Controller
    {
        // GET: Person
        public ActionResult Index()
        {
            return View();
        }
        /// <summary>
        /// string userName ---------这种方式可以单独获取某元素的值，需要跟视图的name名字相对应
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="userPwd"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Index(string userName, string userPwd)
        {
            ViewBag.UN = userName;
            ViewBag.PW = userPwd;
            return View();
        }

        /// <summary>
        /// 【【---------选择爱好的显示页面-----】】---【集合】   ==入口
        /// </summary>
        /// <returns></returns>
        public ActionResult Islike()
        {
            return View();
        }
        /// <summary> 
        /// 【【---------真正添加的页面-----】】    ==出口
        /// </summary>
        /// <param name="love"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Islike(List<string> love)
        {

            ViewBag.GetLike = love;
            return View("Islike");
        }

        /// <summary>
        /// 【【---------一个人买多张票的显示页面-----】】  ==入口
        /// </summary>
        /// <returns></returns>
        public ActionResult Buy()
        {
            return View();
        }

        /// <summary>
        /// 【【---------真正添加的页面-----】】 ===出口
        /// </summary>
        /// <param name="Person"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Buy(List<Person> Person)
        {
            ViewBag.list = Person;
            return View();
        }





    }
}