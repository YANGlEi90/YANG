using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace T6_1_1
{
    public class ClassHttpModule : IHttpModule
    {
        /// <summary>
        /// 释放资源
        /// </summary>
        public void Dispose()
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// 初始化入口
        /// </summary>
        /// <param name="context"></param>
        public void Init(HttpApplication context)
        {
            context.BeginRequest += Context_BeginRequest;
        }

        private void Context_BeginRequest(object sender, EventArgs e)
        {
            //将请求的动作转化为应用请求
            HttpApplication app = sender as HttpApplication;
            //获取请求的原始地址
            string url = app.Request.RawUrl;
            //正则表达式，用来判断请求地址的规则
            Regex regex = new Regex(@"\w+_+\d\.html");
            if (regex.IsMatch(url))
            {
                int line = url.LastIndexOf("_");
                int dot = url.LastIndexOf(".");
                //获取id
                string id = url.Substring(line+1,dot-1-line);
                string directUrl = "~/ShowClass.aspx?ID=" + id;
                //跳转到真实的url
                app.Server.Transfer(directUrl);
            }
        }
    }
}