using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ExamDB.Controllers
{
    public class ResourceController : Controller
    {
        // GET: Resource
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(HttpPostedFileBase resourceFile)
        { 
            //判断上传文件是否为空
            if (resourceFile != null)
            {
                //判断文件大小
                if (resourceFile.ContentLength > 0 && resourceFile.ContentLength < 4194304)
                {
                    //获取上传文件路径
                    string fileName = Path.GetFileName(resourceFile.FileName);
                    //获取文件后缀名【两种方式-------截取==jpg，，，GetExtension== .jpg】
                    //string suff = fileName.Substring(fileName.LastIndexOf(".")+1);
                    string suff = Path.GetExtension(fileName);
                    //判断文件格式
                    if (suff == ".gif" || suff == ".jpg" || suff == ".png")
                    {
                        //保存上传文件的路径
                        resourceFile.SaveAs(Server.MapPath("~/UploadFile/" + resourceFile.FileName));
                        //获取上传文件名，用于后期拿图片
                        ViewBag.img = resourceFile.FileName;
                    }
                    else
                    {
                        ViewBag.Message = "文件格式不正确！";
                    }
                }
                else
                {
                    ViewBag.Message = "文件大小不符合要求！";
                }
            }
            else
            {
                ViewBag.Message = "请上传文件！";
            }
            return View();
        }
    }
}