using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Account.Filter
{
    public class LoginModuleFilter : IHttpModule
    {
        /// <summary>
        /// 释放，结束之后
        /// </summary>
        public void Dispose()
        {
            //throw new NotImplementedException();
        }

        /// <summary>
        /// 初始化的入口
        /// </summary>
        /// <param name="context"></param>
        public void Init(HttpApplication context)
        {
            //原因：AcquireRequestState它可以获取Session
            context.AcquireRequestState += Context_AcquireRequestState;
        }
        /// <summary>
        /// 处理事件【拦截登录的过滤器】
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Context_AcquireRequestState(object sender, EventArgs e)
        {
            //获得应用请求
            HttpApplication app = sender as HttpApplication;
            //可以点到4个内置对象，获取有关当前请求的http特定信息
            HttpContext context = app.Context;
            //获得浏览器端请求的Url路径
            string Url = context.Request.Url.ToString();
           
            //不过滤 css/js/jpg/png/fonts
            if (Url.ToLower().Contains("css") || Url.ToLower().Contains("js") || Url.ToLower().Contains("jpg") ||Url.ToLower().Contains("png") || Url.ToLower().Contains("fonts"))
            {
                return;
            }else
            {
                //判断该地址是否包含----/home/login一段路径
                if (!Url.ToLower().Contains("/home/login"))
                {
                    //判断是否登录
                    if (context.Session["user"] == null)
                    {
                        //没登录则跳到登录
                        context.Response.Redirect("/Home/Login");
                    }
                }
            }
               
            



           
        }
    }
}