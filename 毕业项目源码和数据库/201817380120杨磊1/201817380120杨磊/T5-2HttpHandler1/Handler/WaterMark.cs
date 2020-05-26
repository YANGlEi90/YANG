using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Drawing;
using System.Drawing.Imaging;

namespace T5_2HttpHandler1.Handler
{
    public class WaterMark : IHttpHandler

    {
        public bool IsReusable => false;

        public void ProcessRequest(HttpContext context)
        {
            //获得请求图片的全路径
            var path = context.Request.PhysicalPath;
            //根据路径生成图片
            var image = Image.FromFile(path);
            //创建一个Graphics类型的可编辑图层
            var g= Graphics.FromImage(image);
            Font font = new Font("微软雅黑",18);
            int width = image.Width;
            int height = image.Height;
            g.DrawString("@杨磊", font, Brushes.White ,width - 72, height - 36);
            context.Response.ContentType = "image/jpeg";
            //保存包含水印的图片，转为图片六数据
            image.Save(context.Response.OutputStream, ImageFormat.Jpeg);
        }
    }
}