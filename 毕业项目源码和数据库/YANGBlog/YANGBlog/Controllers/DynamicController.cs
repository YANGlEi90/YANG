using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using YANGBlog.Models;

namespace YANGBlog.Controllers
{
    public class DynamicController : Controller
    {
        YANGEntities db = new YANGEntities();
        // GET: Dynamic
        public ActionResult Index()
        {
            int userid = int.Parse(Session["UserID"].ToString());
            List <Dynamic> dynamic = db.Dynamic.Where(p =>p.UserId== userid&& p.DynamicType == "0").ToList();
            return View(dynamic);
        }
        public ActionResult Dynamics()
        {
            int userid = int.Parse(Session["UserID"].ToString());
            List<Dynamic> dynamic = db.Dynamic.Where(p => p.UserId == userid && p.DynamicType == "1").ToList();
            return View(dynamic);
        }
        public ActionResult details(int DynamicId)
        {
            ViewBag.list = db.Dynamic.Find(DynamicId);
            ViewBag.Clist = db.Comment.Where(p => p.DynamicId == DynamicId);
            return View();
        }
        [HttpPost]
        public void Comment(int userToId, int DynamicId, string CommentContent)
        {
            Comment comment = new Comment();
            comment.DynamicId = DynamicId;
            comment.UserId = userToId;
            comment.CommentContent = CommentContent;
            comment.CommentTime = DateTime.Now;
            db.Comment.Add(comment);
            db.SaveChanges();
        }
        //public ActionResult CommentReply()
        //{

        //}
    }
}