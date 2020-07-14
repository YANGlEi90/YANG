using System;
using System.Collections.Generic;
using System.IO;
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
            int id = int.Parse(Session["UserID"].ToString());
            ViewBag.UserInfo=db.UserInfo.Find(id);
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
                Session["User"] = list[0];
                return RedirectToAction("Index","Dynamic");
            }
            else
            {
                return Content("<script>alert('密码错误');history.go(-1)</script>");
            }
        }
        public ActionResult Out()
        {
            Session["UserID"] = null;
            Session["User"] = null;
            return RedirectToAction("Login", "User");
        }
        
        public ActionResult Register()
        {
            
            return View();
        }
        [HttpPost]
        public ActionResult Register(UserInfo user, HttpPostedFileBase HeadPortrait)
        {
            if (HeadPortrait != null)
            {
                
                string PictureName = Path.GetFileName(HeadPortrait.FileName);
                if (PictureName.EndsWith("jpg") || PictureName.EndsWith("png") || PictureName.EndsWith("gif"))
                {
                    HeadPortrait.SaveAs(Server.MapPath("/res/Img/" + PictureName));
                    user.HeadPortrait = PictureName;
                    db.UserInfo.Add(user);
                    db.SaveChanges(); 
                }
                else
                {
                    return Content("<script> alert('上传的图片格式不对');history.go(-1)</script>");
                }
            }
            else
            {
                return Content("<script> alert('请上传图片');history.go(-1)</script>");

            }
            return RedirectToAction("Login");
        }
    }
}