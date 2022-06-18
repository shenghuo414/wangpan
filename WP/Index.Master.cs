using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Food
{
    public partial class Index : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                if (Request["action"] != null) 
                {
                    Session["LoginLoginName"] = null;
                    Session["LoginDepartID"] = null;
                    Session["LoginInfoID"] = null;
                    Session["LoginPic"] = null;
                    Session["LoginTitle"] = null;
                }
              
            }
        }
    }
}