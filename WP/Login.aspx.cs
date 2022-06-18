using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Food
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack) { }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            SqlParameter[] param = new SqlParameter[] {
                            new SqlParameter("@LoginName",SqlDbType.NVarChar),
                            new SqlParameter("@PassWord",SqlDbType.NVarChar)
                        };
            param[0].Value = username.Value;
            param[1].Value = password.Value;
            if (DBUtility.DbHelperSQL.Exists("select * from GZXX_U_UserTable where LoginName = @LoginName and PassWord = @PassWord ", param))
            {
                DataTable dt = DBUtility.DbHelperSQL.Query("select * from GZXX_U_UserTable where LoginName = @LoginName and PassWord = @PassWord ", param).Tables[0];
                Session["LoginLoginName"] = dt.Rows[0]["LoginName"].ToString();
                Session["LoginDepartID"] = dt.Rows[0]["DepartID"].ToString();
                Session["LoginInfoID"] = dt.Rows[0]["InfoID"].ToString();
                Session["LoginPic"] = dt.Rows[0]["Pic"].ToString();
                Session["UserLevel"] = dt.Rows[0]["UserLevel"].ToString();
                Session["LoginTitle"] = dt.Rows[0]["Title"].ToString();
                Response.Redirect("UserInfo.aspx");
            }
            else
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), System.DateTime.Now.Ticks.ToString(), "alert('用户名或密码错误！')", true);
            }
        }
    }
}