using Account.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Account.Controllers
{
    public class UserRoleController : Controller
    {


        AccountDBEntities db = new AccountDBEntities();

        // GET: UserRole
        public ActionResult Index()
        {
            return View();
        }


        /// <summary>
        /// 删除【【---角色---】】
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public ActionResult Delete(int ID)
        {
            //根据获得的ID查找
            R_User_Roles kk = db.R_User_Roles.Find(ID);
            //删除
            db.R_User_Roles.Remove(kk);
            //操作数据库
            db.SaveChanges();
            //删除成功后，跳转到另一个控制器下的视图
            return RedirectToAction("Index", "UserInfo");
        }

        /// <summary>
        /// 添加角色 ---多表查询
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public ActionResult setRole(int UserID)
        {
            //通过用户id查到--用户信息，并存ViewBag中
            UserInfos user= db.UserInfos.Find(UserID);
            ViewBag.User = user;

            //通过用户id查到--对应的角色关系。并存ViewBag 中
            List<R_User_Roles>  UserRole = db.R_User_Roles.Where(p => p.UserID == UserID).ToList();
            ViewBag.UserRole = UserRole;

            //获得所有的角色，并存ViewBag中
           List< Roles>  Role = db.Roles.ToList();
            ViewBag.role = Role;

            return View();
        
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id">获得视图中的用户ID</param>
        /// <param name="roles">获的选中的角色</param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult setRole(int userid, List<int> roles)
        {
            //先通过用户ID清除与该用户id的相关角色关系
            List<R_User_Roles>  urInfo  = db.R_User_Roles.Where(p=>p.UserID== userid).ToList();

            foreach (var item in urInfo)
            {
                db.R_User_Roles.Remove(item);
            }
            db.SaveChanges();


            if (roles !=null)
            {
                //添加新的关系--遍历所选中的角色
                foreach (var item in roles)
                {
                    //new 一个新的 R_User_Roles对象，将角色ID 与 RoleID 组成一个新的对象添加
                    R_User_Roles r_User_Roles = new R_User_Roles()
                    {

                        UserID = userid,
                        RoleID = item
                    };
                    db.R_User_Roles.Add(r_User_Roles);
                }
                db.SaveChanges();
            }
            return RedirectToAction("Index","UserInfo");
        }
     }
}