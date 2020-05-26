using MVC_T2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_T2.Controllers
{
    public class UsersController : Controller
    {
        // GET: Users
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult userMessage()
        {
            //ViewData和ViewBag是同一集合，可以互换但不能夸动作读取
            ViewData["Date"] = "ViewData";
            //ViewBag存储的数据类型为dynamic类型
            ViewBag.time = "ViewBag";
            //TempData【临时存储】：1、可以夸动作读取（夸视图）2、只能读取一次，用完就销毁
            TempData["content"] = "TempData";



        
            return View();
        }

    }
}