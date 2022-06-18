using DBUtility;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Food.Admin
{
    public partial class Index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                if (Session["LoginName"] == null)
                {
                    Response.Redirect("Login.aspx");
                    //ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), System.DateTime.Now.Ticks.ToString(), "layer.alert('登录超时！', {icon: 2,kin: 'layer-ext-moon' });", true);
                }
                //Response.Write(Session["PowerList"].ToString());
                try
                {
                    HiddenField1.Value = Session["PowerList"].ToString();
                }
                catch (Exception)
                {
                    //Response.Write("..........");
                }
            }
        }

        public string CheckSession(object obj)
        {
            if (obj != null) { return obj.ToString(); }
            else
            {
                return "";
            }
        }
    }
}