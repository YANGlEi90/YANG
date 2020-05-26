using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace Web_MVC
{
    /// <summary>
    /// ȫ��Ӧ�ó����࣬����ȫ���¼�
    /// </summary>
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            //����--App_Start�����FilterConfig
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            //����·��--App_Start�����RouteConfig
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            //���ļ����󣬽��趨��ĳ���ļ�����һ����App_Start ��BundleConfig
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}
