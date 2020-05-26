using Account.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Account.Controllers
{
    public class UserInfoController : Controller
    {

        AccountDBEntities db = new AccountDBEntities();

        // GET: UserInfo
        /// <summary>
        /// 
        /// </summary>
        /// <param name="departmentID">部门ID</param>
        /// <param name="Name">用户名</param>
        /// <param name="pageIndex">当前页</param>
        /// <param name="pageCount">每页显示的行数</param>
        /// <returns></returns>
        public ActionResult Index(int departmentID = 0,string Name="",int pageIndex=1,int pageCount=5)
        {
            //获得部门下拉框部门的值
            List<Departments> dlist=  db.Departments.ToList();
            //ViewBag传递数据
            ViewBag.dlist = dlist;


            //获得总行数
            int totalCount = db.UserInfos.OrderBy(p => p.ID)
                .Where(p => (departmentID == 0 || p.DepartmentID == departmentID) && (Name == "" || p.Name.Contains(Name)))
                .Count();


            //获得总页数=总行数/页面数       Ceiling--向上取整  
            double totalPage = Math.Ceiling(totalCount / (double)pageCount);

            //查询列表信息 ----可以用OrderBy主键正序排列，条件过滤，转成集合
            //where()---调价筛选，Tolist()---转成集合 
            //Skip()--跳过指定数量的元素，返回剩下的集合,Take() --从剩下的集合数中，从第一条开始获取指定数量的集合
            List<UserInfos> list = db.UserInfos.OrderBy(p=>p.ID)
                .Where(p=>(departmentID == 0||p.DepartmentID== departmentID) && (Name==""||p.Name.Contains(Name)))
                .Skip((pageIndex-1)*pageCount).Take(pageCount)
                .ToList();

            //数据加载的同时将条件存储并输出在对应控件显示
            ViewBag.departmentID = departmentID;
            ViewBag.name = Name;


            ViewBag.pageIndex = pageIndex;    //当前页
            ViewBag.pageCount = pageCount;    //每页行数
            ViewBag.totalCount = totalCount;  //总行数
            ViewBag.totalPage = totalPage;    //总页数

            return View(list);    //用过模型传递数据
        }

       /// <summary>
       /// 添加一个用户信息
       /// </summary>
       /// <returns></returns>
        public ActionResult Insert()
        {

            //动态获取下拉框部门的值
            List<SelectListItem> list = db.Departments.Select(p => new SelectListItem()
            {
                Text = p.Name,
                Value = p.ID.ToString()

            }).ToList() ;

            ViewBag.Department = list;

            //获取多选框角色的值
            List<Roles> roles = db.Roles.ToList();
            ViewBag.roles = roles;

            return View();
        }

        [HttpPost]
        public ActionResult Insert(HttpPostedFileBase Photo, UserInfos userInfo, List<int> roles)
        {
            //-----添加图片
            //判断图片是否为空
            if (Photo != null)
            {
                //判断图片大小
                if (Photo.ContentLength>0 && Photo.ContentLength<4194304)
                {
                    //获取上传路径
                    string FileName= Path.GetFileName(Photo.FileName);
                    //获取文件后缀名
                    string suff = FileName.Substring(FileName.IndexOf(".") + 1);

                    //判断格式
                    if (suff =="jpg" || suff=="png" || suff=="gif")
                    {
                        //图片存储位置
                        Photo.SaveAs(Server.MapPath("~/images/users/"+ Photo.FileName));
                        userInfo.Photo = Photo.FileName;
                    }
                  
                }

            }
            else
            {
                return Content("<script>alert('未获取到上传的文件')</script>");
            }
            //-----添加用户信息
            db.UserInfos.Add(userInfo);
            db.SaveChanges();

            //-----添加用户与角色的关系
            //遍历所选中的角色
            foreach (var item in roles)
            {
                //new 一个新的 R_User_Roles对象，将角色ID 与 RoleID 组成一个新的对象添加
                R_User_Roles UR = new R_User_Roles() {

                    UserID =userInfo.ID,
                    RoleID=item
                };
                db.R_User_Roles.Add(UR);
            }
          
            db.SaveChanges();
            return RedirectToAction("Index");
                
        }

        /// <summary>
        /// 修改用户信息
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public ActionResult Update(int ID)
        {

           //动态获取下拉框部门的值
            List<Departments> departmentlist = db.Departments.ToList();
            ViewBag.dptlist = departmentlist;

            //获取多选框角色的值
            List<Roles> Role = db.Roles.ToList();
            ViewBag.role = Role;


            //1、获得UseInfo信息
            UserInfos userInfo = db.UserInfos.Find(ID);
            ViewBag.userInfo = userInfo;

            //2、通过用户id查到--对应的角色关系。并存ViewBag 中
            List<R_User_Roles> UserRole = db.R_User_Roles.Where(p => p.UserID == ID).ToList();
            ViewBag.UserRole = UserRole;

            return View();
        }


        [HttpPost]
        public ActionResult Update(HttpPostedFileBase EPhoto, UserInfos userInfo, List<int> roles)
        {

            //------1、判断是否重新添加图片
            if (EPhoto !=null)
            {
                //判断图片大小
                if (EPhoto.ContentLength > 0 && EPhoto.ContentLength < 4194304)
                {
                    //获取上传路径
                    string FileName = Path.GetFileName(EPhoto.FileName);
                    //获取文件后缀名
                    string suff = FileName.Substring(FileName.IndexOf(".") + 1);

                    //判断格式
                    if (suff == "jpg" || suff == "png" || suff == "gif")
                    {
                        //图片存储位置
                        EPhoto.SaveAs(Server.MapPath("~/images/users/" + EPhoto.FileName));
                        userInfo.Photo = EPhoto.FileName;
                    }

                }
            }
            //----2、修改用户信息--Modified看你这条记录中是否有数据发生改变
            db.Entry(userInfo).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();

            //-----3、修改用户与角色的关系

            //先通过用户ID清除与该用户id的相关角色关系
            List<R_User_Roles> urInfo = db.R_User_Roles.Where(p => p.UserID == userInfo.ID).ToList();

            foreach (var item in urInfo)
            {
                db.R_User_Roles.Remove(item);
            }
            db.SaveChanges();


            //添加新的关系--遍历所选中的角色
            foreach (var item in roles)
            {
                //new 一个新的 R_User_Roles对象，将角色ID 与 RoleID 组成一个新的对象添加
                R_User_Roles r_User_Roles = new R_User_Roles()
                {

                    UserID = userInfo.ID,
                    RoleID = item
                };
                db.R_User_Roles.Add(r_User_Roles);
            }
            db.SaveChanges();

            return RedirectToAction("Index");
        }
         /// <summary>
         /// 删除
         /// </summary>
         /// <param name="UserID"></param>
         /// <returns></returns>
        public ActionResult Remove(int UserID)
        {
            //查出用户角色关系表
            var rURList = db.R_User_Roles.Where(p => p.UserID == UserID).ToList();
            if (rURList.Count > 0)
            {
                return Content("<script>alert('该用户有角色不能删除');history.go(-1)</script>");
            }
            else
            {
                UserInfos user = db.UserInfos.Find(UserID);
                db.UserInfos.Remove(user);
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}