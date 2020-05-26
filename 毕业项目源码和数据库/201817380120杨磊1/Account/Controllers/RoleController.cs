using Account.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Account.Controllers
{
    public class RoleController : Controller
    {

        AccountDBEntities db = new AccountDBEntities();

        // GET: Role
        public ActionResult Index(string Name="")
        {
            List<Roles> list = db.Roles.Where(p => p.Name == "" || p.Name.Contains(Name)).ToList();
            ViewBag.name = Name;
            return View(list);
        }
        /// <summary>
        /// 菜单的添加
        /// </summary>
        /// <param name="roles"></param>
        /// <returns></returns>
        public ActionResult RoleInsert(Roles roles)
        {
            db.Roles.Add(roles);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        /// <summary>
        /// 菜单的删除
        /// </summary>
        /// <param name="roles"></param>
        /// <returns></returns>

        public ActionResult RoleDelete(int ID)
        {
            //获得菜单绑定信息
            var nk = db.R_User_Roles.Where(p => p.RoleID == ID).ToList();
            //获得用户绑定
            var RolseMenu = db.R_Role_Menus.Where(p => p.RoleID == ID).ToList();

            if (nk.Count>0)
            {
                return Content("<script>alert('该用户有菜单不能删除');history.go(-1)</script>");

            }else if (RolseMenu.Count > 0)
            {
                return Content("<script>alert('该用户有角色不能删除');history.go(-1)</script>");
            }
            else
            {
                Roles roles = db.Roles.Find(ID);
                db.Roles.Remove(roles);
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }

    }
}