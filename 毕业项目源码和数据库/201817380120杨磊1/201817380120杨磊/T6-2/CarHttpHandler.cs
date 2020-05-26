using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace T6_2
{
    public class CarHttpHandler : IHttpHandler
    {
        public bool IsReusable => true;

        public void ProcessRequest(HttpContext context)
        {
            //获得请求的地址
            string url = context.Request.RawUrl;
            //处理获得id
            int line = url.LastIndexOf("_");
            int dot = url.LastIndexOf(".");
            int id = int.Parse(url.Substring(line + 1, dot - line - 1));
            
            string carPath = context.Server.MapPath("~/Car/car_" + id + ".html");
            if (!File.Exists(carPath))
            {
                CarManager cm = new CarManager();
                List<Car> list = cm.FindCar();
                //获得模板所在位置
                string templatePath = context.Server.MapPath("~/Car/Template.html");
                //获得模板中的内容
                string con = ReadTemlate(templatePath);
                //动态内容替换到静态的内容中
                con = con.Replace("{$Picture}",list[id-1].Picture);
                con = con.Replace("{$Carname}", list[id - 1].Carmame);
                con = con.Replace("{$Brand}", list[id - 1].Brand);
                //保存静态页面的方法
                ReWriteHtml(carPath, con);
            }
            context.Response.WriteFile(carPath);
        }
        /// <summary>
        /// path 生成的文件包含路径
        /// 
        /// </summary>
        /// <param name="path"></param>
        /// <param name="con"></param>
        private void ReWriteHtml(string path,string con)
        {
            FileStream fs = new FileStream(path, FileMode.Create);
            StreamWriter sw = new StreamWriter(fs);
            sw.Write(con);
            sw.Close();
            fs.Close();
        }
        /// <summary>
        /// 读取模板
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        private string ReadTemlate(string path)
        {
            if (!File.Exists(path))
            {
                //模板不存在抛出异常
                throw new Exception("您生成的静态页面的模板不存在！");
            }
            //定义文件流
            FileStream fs = new FileStream(path, FileMode.Open);
            StreamReader sr = new StreamReader(fs);
            string context = sr.ReadToEnd();
            sr.Close();
            fs.Close();
            return context;
        }
    }
}