using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Food.Admin.User
{
    public partial class UpdatePass : System.Web.UI.Page
    {
        BLL.GZXX_Admin bll = new BLL.GZXX_Admin();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack) 
            {
                Button1.Attributes.Add("OnClick", "return CheckForm()");
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Model.GZXX_Admin model = new Model.GZXX_Admin();
            model.LoginName = Session["LoginName"].ToString();
            model.PassWord = TextBox3.Text.Trim();
            if (bll.UpdatePassWord(model)) 
            {
                TextBox3.Attributes.Add("value", model.PassWord);
                TextBox1.Attributes.Add("value", model.PassWord);
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), System.DateTime.Now.Ticks.ToString(), "alert('操作成功！')", true);
            }
            else {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), System.DateTime.Now.Ticks.ToString(), "alert('操作失败！')", true);
            }
        }
    }
}