using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HttpTest
{
    public class TestHttpModule : IHttpModule
    {
        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public void Init(HttpApplication context)
        {
            //httpApplication请求，自定义生成两个事件
            //httpHandle对象请求之前得事件
            context.BeginRequest += context_BeginRequest;
            //httpHandler对象请求结束之后得事件
            context.EndRequest += Context_EndRequest;
        }

        private void Context_EndRequest(object sender, EventArgs e)
        {
            HttpApplication app = sender as HttpApplication;
            app.Response.Write("进去到了；httpHandler对象请求结束之后得事件");
        }

        private void context_BeginRequest(object sender, EventArgs e)
        {
            HttpApplication app = sender as HttpApplication;
            app.Response.Write("进去到了；httpHandle对象请求请求之前得事件");
        }
    }
}