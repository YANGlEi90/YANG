using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Account.Filter
{
    /// <summary>
    /// 过滤器 类命名规则  名+Attribute
    /// 需要引用using System.Web.Mvc;
    /// 需要继承ActionFilterAttribute
    /// </summary>
    public class LoginAttribute:ActionFilterAttribute
    {
        /// <summary>
        /// 正在发送请求时，进行相应
        /// </summary>
        /// <param name="filterContext"></param>
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            //如果获得请求中Session["user"]里的值为空
            if (HttpContext.Current.Session["user"]==null)
            {
                //筛选器捕获请求的结果，地址转向
                filterContext.Result = new RedirectResult("/Home/Login");
            }
        }
    }
}