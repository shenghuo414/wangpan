using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Food.Admin
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                Session["LoginName"] = null;
                Session["DepartID"] = null;
                Session["GroupID"] = null;
                Session["RealName"] = null;
                Session["PowerList"] = null;
                Session["GroupName"] = null;
                Session["LastLoginTime"] = null;
                Button1.Attributes.Add("OnClick", "return CheckForm()");
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string vCode = string.Empty;
            try
            {
                vCode = Session["CheckCode"].ToString();
            }
            catch (Exception)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), System.DateTime.Now.Ticks.ToString(), "alert('验证码已过期！');document.getElementById('codeimage').click();", true);
                return;
            }
            if (ValidateCode.Text.Trim().ToUpper() != vCode.ToUpper())
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), System.DateTime.Now.Ticks.ToString(), "alert('验证码不正确！');", true);
                ValidateCode.Focus();
            }
            else
            {
                string LoginName = UserName.Text.Trim();
                string PassWord = UserPass.Text.Trim();
                BLL.GZXX_Admin bll = new BLL.GZXX_Admin();
                if (bll.CheckLogin(LoginName, PassWord))
                {
                    Model.GZXX_Admin model = new Model.GZXX_Admin();
                    try
                    {
                        model.LoginName = LoginName;
                        DBUtility.IPAddress ip = new DBUtility.IPAddress();
                        model.LastLoginIP = ip.IP_Address;
                        bll.UpdateLoginInfo(model);
                    }
                    catch (Exception) { }
                    model = bll.GetAdminInfo(LoginName);
                    if (model.Locked == 1)
                    {
                        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), System.DateTime.Now.Ticks.ToString(), "alert('账号已锁定！');", true);
                    }
                    else
                    {
                        Session["LoginName"] = Session["Username"] = model.LoginName;
                        Session["DepartID"] = model.DepartID;

                        Session["GroupID"] = model.GroupID;
                        Session["RealName"] = model.RealName;
                        Model.GZXX_Group gmodel = new Model.GZXX_Group();
                        BLL.GZXX_Group gbll = new BLL.GZXX_Group();
                        gmodel = gbll.GetGroupInfo(model.GroupID);
                        Session["PowerList"] = gmodel.powerlist;
                        Session["GroupName"] = gmodel.groupname;
                        Session["LastLoginTime"] = model.LastLoginTime;
                        Response.Redirect("Index.aspx");
                    }
                }
                else
                {
                    UserName.Focus();
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), System.DateTime.Now.Ticks.ToString(), "alert('账号或密码不正确！');", true);
                }
            }
        }
    }
}