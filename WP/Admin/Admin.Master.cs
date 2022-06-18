using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Food.Admin
{
    public partial class Admin : System.Web.UI.MasterPage
    {
        protected override void OnInit(EventArgs e)
        {
            if (Session["LoginName"] == null)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), System.DateTime.Now.Ticks.ToString(), "layer.alert('登录超时！', {icon: 2,kin: 'layer-ext-moon',closeBtn: 0 }, function () {parent.window.location.href='/Admin/Login.aspx';});", true);
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["LoginName"] == null)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), System.DateTime.Now.Ticks.ToString(), "layer.alert('登录超时！', {icon: 2,kin: 'layer-ext-moon',closeBtn: 0 }, function () {parent.window.location.href='/Admin/Login.aspx';});", true);
            }
        }
    }
}