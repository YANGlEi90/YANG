using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace T6_1_1
{
    public partial class ClassList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ClassManager cm = new ClassManager();
                this.ddClass.DataSource = cm.FindClass();
                this.ddClass.DataValueField = "classID";
                this.ddClass.DataTextField = "classNeme";
                this.ddClass.DataBind();
            }
        }
    }
}