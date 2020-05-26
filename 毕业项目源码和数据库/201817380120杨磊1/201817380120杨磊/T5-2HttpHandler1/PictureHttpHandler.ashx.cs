using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace T5_2HttpHandler1
{
    /// <summary>
    /// PictureHttpHandler 的摘要说明
    /// </summary>
    public class PictureHttpHandler : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            /*MIME类型是设定某种扩展名得文件用一种应用程序来打开的方式类型，
             *当扩展名文件被访问的时候，浏览器会自动指定应用程序来打开。
             * 多用于指定一些客户端自定义的文件名，以及一些媒体文件打开方式。
             * 
             * text/plain存文本，浏览器在获取这种文件时不会对其处理
             * text/html 浏览器再获取到这种文件时会自动对其进行解析
             */
            //context.Response.ContentType = "text/plain";
            //context.Response.Write("Hello World");
            string myDomain = "localhost";
            if (context.Request.UrlReferrer==null||context.Request.UrlReferrer.Host.ToLower().IndexOf(myDomain)<0)
            {
                //如果时通过浏览器直接访问或者是通过其他站点访问过来的，则显示“资源不存的图片”
                context.Response.ContentType = "image/jpeg";
                context.Response.WriteFile(context.Request.PhysicalApplicationPath+"/images/no.png");
            }
            else
            {
                context.Response.ContentType = "image/jpeg";
                context.Response.WriteFile(context.Request.PhysicalPath);
            }
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}