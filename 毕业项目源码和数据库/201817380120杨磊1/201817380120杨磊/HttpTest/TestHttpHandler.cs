using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HttpTest
{
    public class TestHttpHandler : IHttpHandler
    {
        public bool IsReusable {

            get { return true; }
        }

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            context.Response.Write("哇，进入到了我们自己定义的handler里面");
        }
    }
}