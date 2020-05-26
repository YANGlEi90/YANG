using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace T6_2_1
{
    /// <summary>
    /// CarAjaxHttpHandler 的摘要说明
    /// </summary>
    public class CarAjaxHttpHandler : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            List<Car> list = new List<Car>()
           {
               new Car(){  CarID=1,Carmame="奥迪", Brand="奥迪A3",Picture="ada31.jpg"},
               new Car(){  CarID=2,Carmame="宝马", Brand="宝马M3",Picture="bmm31.jpg"}
           };
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("<table width='100%' cellpadding='0' cellspacing='1' border='0' bgcolor='#8C96B5'>");
            sb.AppendLine("<tr  bgcolor='#E1E4EC' align='center'><th>编号 </th><th> 汽车名称 </th><th> 品牌 </th><th> 图片 </th></tr> ");
            foreach (var item in list)
            {
                sb.AppendLine("<tr  bgcolor='#E1E4EC' align='center'><th>" + item.CarID + " </th><th> " + item.Carmame + " </th><th> " + item.Brand + " </th><th><img src='images/" + item.Picture + "' width='50' height='30'/> </th></tr> ");

            }
            sb.AppendLine("</table>");
            context.Response.ContentType = "text/plain";
            context.Response.Write(sb.ToString());
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