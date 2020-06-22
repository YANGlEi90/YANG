using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace YANGBlog.Controllers
{
    public class MessageBoardController : Controller
    {
        // GET: MessageBoard
        public ActionResult Index()
        {
            return View();
        }
    }
}