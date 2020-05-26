using Account.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Account.Controllers
{
    public class PaperController : Controller
    {

        AccountDBEntities db = new AccountDBEntities();

        // GET: Paper
        public ActionResult Index()
        {
            List<Paper> paper = db.Paper.ToList();
            ViewBag.paper = paper;
            return View();
        }

        /// <summary>
        /// 新增试卷
        /// </summary>
        /// <returns></returns>
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Paper paper)
        {
            db.Paper.Add(paper);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        /// <summary>
        /// 试卷的修改
        /// </summary>
        /// <returns></returns>
        public ActionResult PaperEdit(int ID)
        {
            Paper paper=db.Paper.Find(ID);
            ViewBag.paper = paper;
            return View();
        }
        [HttpPost]
        public ActionResult PaperEdit(Paper paper)
        {
            db.Entry(paper).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        /// <summary>
        /// 试卷的详情页
        /// </summary>
        /// <returns></returns>
        public ActionResult PaperDetails(int ? ID)
        {
            //获得该编号试卷
            Paper paper = db.Paper.Find(ID);
            ViewBag.paper = paper;
            //获得该编号试卷对应的题目
            List<Topic> topic = db.Topic.Where(p => p.PaperID == ID).ToList();
            ViewBag.topic = topic;

            return View();
        }

   
        /// <summary>
        /// 试卷的删除的详情页
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public ActionResult PaperDelete(int ID)
        {
             Paper paper = db.Paper.Find(ID);
             ViewBag.paper = paper;
            return View();
        }
        /// <summary>
        /// 试卷的删除
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Delete(int ID)
        {
            Paper paper = db.Paper.Find(ID);
            db.Paper.Remove(paper);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        /// <summary>
        /// 试题的详情页
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public ActionResult TopicDelete(int ID)
        {
            //获得该试题的信息
            Topic topic = db.Topic.Find(ID);
            ViewBag.topic = topic;
           List<Paper> paper = db.Paper.Where(p=>p.PaperID == ID).ToList();
            ViewBag.paper = paper;
            return View();

        }
            /// <summary>
            /// 试题的删除
            /// </summary>
            /// <returns></returns>
        public ActionResult Delete2(int ID)
        {
           
                Topic topic = db.Topic.Find(ID);
                db.Topic.Remove(topic);
                db.SaveChanges();
                return RedirectToAction("Index");
         
        }
        /// <summary>
        /// 试题的修改
        /// </summary>
        /// <returns></returns>
        public ActionResult TopicEdit(int ID)
        {
            Topic topic = db.Topic.Find(ID);
            //动态获取下拉框的值
            List<Paper> paper = db.Paper.ToList();

            ViewBag.paper = paper;
            ViewBag.topic = topic;
            return View();
        }

        [HttpPost]
        public ActionResult TopicEdit(Topic topic) {

            db.Entry(topic).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        /// <summary>
        /// 试卷的添加
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public ActionResult PaperCreate(int ID) {
            Paper paper = db.Paper.Find(ID);
            ViewBag.paper = paper;
            return View();
        }
        [HttpPost]
        public ActionResult PaperCreate(Topic topic)
        {
            db.Topic.Add(topic);
            db.SaveChanges();
            return RedirectToAction("Index");

        }

        /// <summary>
        /// 在线考试
        /// </summary>
        /// <returns></returns>
        public ActionResult IndexStu()
        {
           List< Paper> paper= db.Paper.ToList();
            ViewBag.paper = paper;
            return View();
        }
     }
}