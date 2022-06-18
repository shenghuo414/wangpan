using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;

namespace Food
{
    public partial class UpdatePass : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack) { }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Hashtable ht = new Hashtable();
            ht.Add("InfoID", Session["LoginInfoID"]);
            ht.Add("PassWord", password.Value);
            new BLL.GZXX_Model().EditContent("GZXX_U_UserTable", ht);
            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), System.DateTime.Now.Ticks.ToString(), "layer.alert('密码修改成功！', {icon: 1,kin: 'layer-ext-moon',closeBtn: 0 })", true);
        }
    }
}