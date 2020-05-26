using Account.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Account.Controllers
{
    public class RoleMenuController : Controller
    {

        AccountDBEntities db = new AccountDBEntities();

        // GET: RoleMenu
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// 删除操作的菜单
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public ActionResult RoleDelete(int ID)
        {
            //获得角色菜单表信息
            R_Role_Menus RoleMenus = db.R_Role_Menus.Find(ID);
            db.R_Role_Menus.Remove(RoleMenus);
            db.SaveChanges();
            return RedirectToAction("Index","Role");
        }

        /// <summary>
        /// 设置操作菜单
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public ActionResult RoleSet(int ID)
        {
            //获得角色信息
            Roles role = db.Roles.Find(ID);
            ViewBag.role = role;

            //获得角色菜单信息
           List< R_Role_Menus> roleMenus = db.R_Role_Menus.Where(p=>p.RoleID== ID).ToList();
            ViewBag.roleMenus = roleMenus;

            //获得所有菜单
            List<Menus> menu = db.Menus.ToList();
            ViewBag.menu = menu;
            return View();
        }

        [HttpPost]
        public ActionResult RoleSet(int menuid, int[] menu)
        {

            //将跟menuid有关的菜单删除
            List<R_Role_Menus> roleMenus = db.R_Role_Menus.Where(p => p.MenuID == menuid).ToList();
            foreach (var item in roleMenus)
            {
                db.R_Role_Menus.Remove(item);
            }
            db.SaveChanges();

            //添加新的菜单角色关系
            if (menu != null)
            {
                foreach (var item in menu)
                {
                        R_Role_Menus r_Role_Menus = new R_Role_Menus()
                        {
                            MenuID = item,
                            RoleID = menuid
                        };

                    db.R_Role_Menus.Add(r_Role_Menus);
                }
                db.SaveChanges();
            }
            return RedirectToAction("Index", "Role");
        }

    }
}