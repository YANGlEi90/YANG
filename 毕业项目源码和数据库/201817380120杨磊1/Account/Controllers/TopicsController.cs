using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Account.Models;

namespace Account.Controllers
{
    public class TopicsController : Controller
    {
        private AccountDBEntities db = new AccountDBEntities();

        // GET: Topics
        public ActionResult Index()
        {
            var topic = db.Topic.Include(t => t.Paper);
            return View(topic.ToList());
        }

        // GET: Topics/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Topic topic = db.Topic.Find(id);
            if (topic == null)
            {
                return HttpNotFound();
            }
            return View(topic);
        }

        // GET: Topics/Create
        public ActionResult Create(int id)
        {

            //根据试卷ID获得试卷
            Paper paper = db.Paper.Find(id);
            ViewBag.paper = paper;
            //编辑题目类型的下拉框数据

            List<SelectListItem> item = new List<SelectListItem>()
          {
              new SelectListItem(){ Value="1",Text="单选"},
               new SelectListItem(){ Value="2",Text="判断"},
                new SelectListItem(){ Value="3",Text="问答"}
          };
            ViewBag.type = new SelectList(item,"value","Text");
            return View();
        }

        // POST: Topics/Create
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TopicID,TopicExplain,TopicScore,TopicType,TopicA,TopicB,TopicC,TopicD,TopicSort,TopicAnswer,PaperID")] Topic topic)
        {
            if (ModelState.IsValid)
            {
                db.Topic.Add(topic);
                db.SaveChanges();
                return RedirectToAction("Details","Papers", new { id = topic.PaperID });
            }

           //跳转到get请求的创建方法中，并将试卷id带参过去
           //解决的视图上初始化Paper对象为空的报错，和题目类型下拉框初始化取值报错
            return RedirectToAction("Create",new { id= topic.PaperID});
        }

        // GET: Topics/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Topic topic = db.Topic.Find(id);
            if (topic == null)
            {
                return HttpNotFound();
            }

            //根据试卷ID获得试卷
            Paper paper = db.Paper.Find(topic.PaperID);
            ViewBag.paper = paper;
            //编辑题目类型的下拉框数据

            List<SelectListItem> item = new List<SelectListItem>()
          {
              new SelectListItem(){ Value="1",Text="单选"},
               new SelectListItem(){ Value="2",Text="判断"},
                new SelectListItem(){ Value="3",Text="问答"}
          };
            ViewBag.type = new SelectList(item, "value", "Text",topic.TopicType);
            return View(topic);
        }

        // POST: Topics/Edit/5
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TopicID,TopicExplain,TopicScore,TopicType,TopicA,TopicB,TopicC,TopicD,TopicSort,TopicAnswer,PaperID")] Topic topic)
        {
            if (ModelState.IsValid)
            {
                db.Entry(topic).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Details", "Papers", new { id = topic.PaperID });
            }
         
            return RedirectToAction("Edit",new { id=topic.TopicID});
        }

        // GET: Topics/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Topic topic = db.Topic.Find(id);
            if (topic == null)
            {
                return HttpNotFound();
            }
            return View(topic);
        }

        // POST: Topics/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            //通过题目ID查找是否有学生已经作答
            List<Detail> detail = db.Detail.Where(p => p.TopicID == id).ToList();
            //获得id对应的试题
            Topic topic = db.Topic.Find(id);
            //判断如果集合>0，说明该题目已被学生作答，不可删除
            if (detail.Count>0)
            {
                ModelState.AddModelError("errot","该题目正在作答，不可删除");
                return View(topic);
            }
          //否则删除，并跳转到详情页
            db.Topic.Remove(topic);
            db.SaveChanges();
            return RedirectToAction("Details", "Papers", new { id = topic.PaperID });
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
