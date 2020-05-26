using Account.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Account.Controllers
{
    public class MenuController : Controller
    {

        AccountDBEntities db = new AccountDBEntities();

        // GET: Menu
        public ActionResult Index(string Name="")
        {
            //获得Menus信息
            List<Menus> list = db.Menus.Where(p => p.Name == "" || p.Name.Contains(Name)).ToList();
            ViewBag.name = Name;
            return View(list);
        }

        /// <summary>
        /// 添加
        /// </summary>
        /// <returns></returns>
        public ActionResult MenuInsert()
        {
            return View();

        }
        [HttpPost]
        public ActionResult MenuInsert(Menus menus)
        {
            //添加菜单信息
            db.Menus.Add(menus);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <returns></returns>
        public ActionResult MenuUpdate(int ID)
        {
            //根据ID查询信息
            Menus  menu= db.Menus.Find(ID);
            ViewBag.menu = menu;
            return View();
        }

        [HttpPost]
        public ActionResult MenuUpdate(Menus menus)
        {
            //修改
            db.Entry(menus).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="MenuID"></param>
        /// <returns></returns>
        public ActionResult MenuDelete(int MenuID)
        {
            //根据MenuID查询出角色菜单关系表信息
            var RoleMenus = db.R_Role_Menus.Where(p => p.MenuID == MenuID).ToList();
            //若返回行数>0,则存在该数据
            if (RoleMenus.Count>0)
            {
                return Content("<script>alert('该菜单有角色不能删除');history.go(-1)</script>");
            }
            else
            {
                var menulist = db.Menus.Find(MenuID);
                db.Menus.Remove(menulist);
                db.SaveChanges();
            }
          
            return RedirectToAction("Index");
        }

    }
}