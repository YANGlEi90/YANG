using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StuSystem.Models
{

    /// <summary>
    /// 自定义一个Html辅助标签
    /// </summary>
    public static class UIHtml
    {
        /*
         * <ul>
         * <li><a href="#">首页</a></li>
         * <li><a href="#">新闻</a></li>
         * <li><a href="#">热点</a></li>
         * <li><a href="#">时事</a></li>
         *  
         *  1、类静态 2、方法静态   3、this点   4、MvcHtmlString（注意引用命名空间）
         *  调用：@Html.SetUI(new [] {"首页","新闻","热点","时事"})
         */
            /// <summary>
            /// 生成无序列表
            /// </summary>
            /// <param name="htmlHelper"></param>
            /// <param name="itemValue"></param>
            /// <returns></returns>
        public static MvcHtmlString SetUI(this HtmlHelper htmlHelper,string [] itemValue)
        {
            TagBuilder tag = new TagBuilder("ul");                  //创建 ul 标签
            foreach (var item in itemValue)
            {
                TagBuilder li_Tag = new TagBuilder("li");        //创建 li 标签
                TagBuilder a_Tag = new TagBuilder("a");          //创建 a 标签

                a_Tag.MergeAttribute("href","#");                //在 a 标签上设置属性 href="#"
                a_Tag.SetInnerText(item);                       //设置 a 标签之间的文本
                li_Tag.InnerHtml = a_Tag.ToString();              //用过InnerHtml,给li标签添加创建的A标签内容（标签，文本）---【将 a 标签放到 li 标签里面 】
                tag.InnerHtml += li_Tag.ToString();               //用过InnerHtml,给ul标签累加创建a标签内容-----【将 li标签放到 ul 标签里面 】
            }
            return new MvcHtmlString(tag.ToString());             //new 一下输出
        }

        /// <summary>
        /// 方法的重载
        /// </summary>
        /// <param name="htmlHelper"></param>
        /// <param name="itemValue"></param>
        /// <param name="ClassName"></param>
        /// <returns></returns>

        public static MvcHtmlString SetUI(this HtmlHelper htmlHelper, string[] itemValue,string ClassName)
        {
            TagBuilder tag = new TagBuilder("ul");                  //创建 ul 标签
            tag.AddCssClass(ClassName);                       //添加样式名
            foreach (var item in itemValue)
            {
                TagBuilder li_Tag = new TagBuilder("li");        //创建 li 标签
                TagBuilder a_Tag = new TagBuilder("a");          //创建 a 标签

                a_Tag.MergeAttribute("href", "#");                //在 a 标签上设置属性 href="#"
                a_Tag.SetInnerText(item);                       //设置 a 标签之间的文本
                li_Tag.InnerHtml = a_Tag.ToString();              //用过InnerHtml,给li标签添加创建的A标签内容（标签，文本）---【将 a 标签放到 li 标签里面 】
                tag.InnerHtml += li_Tag.ToString();               //用过InnerHtml,给ul标签累加创建a标签内容-----【将 li标签放到 ul 标签里面 】
            }
            return new MvcHtmlString(tag.ToString());             //new 一下输出
        }
    }
}