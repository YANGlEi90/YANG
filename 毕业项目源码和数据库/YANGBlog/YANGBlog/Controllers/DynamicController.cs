using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using YANGBlog.Models;
using System.IO;
using System.Text.RegularExpressions;

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
        public ActionResult Write()
        {
            
            return View();
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult WriteAdd(string DynamicHead, string introduction, string content, HttpPostedFileBase Picture)
        {
            if (Picture!=null)
            {
                int userid = int.Parse(Session["UserID"].ToString());
                string PictureName = Path.GetFileName(Picture.FileName);
                if (PictureName.EndsWith("jpg") || PictureName.EndsWith("png") || PictureName.EndsWith("gif"))
                {
                    Picture.SaveAs(Server.MapPath("/res/Img/" + PictureName));
                    Dynamic dynamic = new Dynamic()
                    {
                        UserId = userid,
                        Releasetime = DateTime.Now,
                        Content = content,
                        Picture = PictureName,
                        DynamicType = "0",
                        DynamicHead = DynamicHead,
                        introduction = introduction
                    };
                    db.Dynamic.Add(dynamic);
                    db.SaveChanges();
                }
                else
                {
                    return Content("<script> alert('上传的图片格式不对')</script>");
                }
            }
            else
            {
                return Content("<script> alert('请上传图片');history.go(-1)</script>");

            }
            return RedirectToAction("Index");


        }
        public ActionResult Dynamics()
        {
            int userid = int.Parse(Session["UserID"].ToString());
            List<Dynamic> dynamic = db.Dynamic.Where(p => p.UserId == userid && p.DynamicType == "1").ToList();
            return View(dynamic);
        }
        public ActionResult DeleteDynamic(int DynamicId)
        {
           var dynamic= db.Dynamic.Find(DynamicId);
            if (dynamic.Comment.Count==0)
            {
                db.Dynamic.Remove(dynamic);
                db.SaveChanges();
            }
            else
            {
                var Commentlist = db.Comment.Where(p => p.DynamicId == DynamicId);
                foreach (var item in Commentlist)
                {
                    db.Comment.Remove(item);
                }
                db.Dynamic.Remove(dynamic);
                db.SaveChanges();
            }
            return RedirectToAction("Dynamics");
        }


        [HttpPost]
        public ActionResult Addshuoshuo(string dynamictextarea)
        {
            Dynamic dynamics = new Dynamic()
            {
                UserId = int.Parse(Session["UserID"].ToString()),
                Releasetime = DateTime.Now.ToLocalTime(),
                Content = dynamictextarea,
                DynamicType = "1",
                isPass = "1"
            };
            db.Dynamic.Add(dynamics);
            db.SaveChanges();
            return RedirectToAction("Dynamics");
        }
        //public ActionResult Dynamics(string Content ,string Picture )
        //{
        //    Dynamic dynamics = new Dynamic()
        //    {
        //        UserId = int.Parse(Session["UserID"].ToString()),
        //        Releasetime = DateTime.Now.ToLocalTime(),
        //        Content = Content,
        //        Picture = Picture,
        //        DynamicType = "1",
        //        isPass = "1"
        //    };
        //    db.Dynamic.Add(dynamics);
        //    db.SaveChanges();
        //    return View();
        //}
        public ActionResult details(int DynamicId)
        {
            ViewBag.list = db.Dynamic.Find(DynamicId);
            ViewBag.Clist = db.Comment.Where(p => p.DynamicId == DynamicId).OrderByDescending(p=>p.CommentTime);
            return View();
        }
        [HttpPost]
        public JsonResult Comment(int uId, int DynamicId, string textareacomment)
        {
            Comment comment = new Comment()
            {
                DynamicId = DynamicId,
                UserId = uId,
                CommentContent = textareacomment,
                CommentTime = DateTime.Now.ToLocalTime()
        };
            db.Comment.Add(comment);
            db.SaveChanges();
            return Json("评论成功");
        }
        
        //public ActionResult CommentReply()
        //{

        //}
    }
}