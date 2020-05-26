using Account.Models;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Account.Controllers
{
    public class TeacherController : Controller
    {
        AccountDBEntities db = new AccountDBEntities();
        // GET: Teacher
        public ActionResult Index(int ? page)
        {
            //数据源：
            List<Teacher> teacher = db.Teacher.ToList();

            //第几页  
            int pageNumber = page ?? 1;

            //每页显示多少条  
            int pageSize = 3;

            //根据ID升序排序  
            teacher = teacher.OrderBy(x => x.TeacherID).ToList();

            //通过ToPagedList扩展方法进行分页  
            IPagedList<Teacher> userPagedList = teacher.ToPagedList(pageNumber, pageSize);

            ViewBag.list = userPagedList;
            //将分页处理后的列表传给View 
            return View(userPagedList);
        }

        /// <summary>
        /// 老师新增
        /// </summary>
        /// <returns></returns>
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Teacher teacher)
        {
            db.Teacher.Add(teacher);
            db.SaveChanges();

            return RedirectToAction("Index");
        }

        /// <summary>
        /// 老师修改
        /// </summary>
        /// <param name="teacher"></param>
        /// <returns></returns>
        public ActionResult TeaEdit(int ID)
        {
           Teacher teacher = db.Teacher.Find(ID);
            ViewBag.list = teacher;
            return View();
        }

        [HttpPost]
        public ActionResult TeaEdit(Teacher teacher)
        {
            db.Entry(teacher).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
            
        }
        /// <summary>
        /// 老师详情页
        /// </summary>
        /// <param name="teacher"></param>
        /// <returns></returns>
        public ActionResult TeaDetails(int ID)
        {
            Teacher teacher = db.Teacher.Find(ID);
            ViewBag.list = teacher;
            return View();
        }

        public ActionResult TeaDelete(int ID)
        {

            Teacher teacher = db.Teacher.Find(ID);
            db.Teacher.Remove(teacher);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public JsonResult Remove(string ids)
        {
            ids = ids.Substring(0, ids.Length - 1); //删除字符串最后一个字符
            string[] datalist = ids.Split(',');
            foreach (var item in datalist)
            {
                int daa = int.Parse(item);
                var da = db.Teacher.FirstOrDefault(c => c.TeacherID == daa);
                db.Teacher.Remove(da);
            }
            db.SaveChanges();
            return Json(new { state = "10000" });
        }



    }
}