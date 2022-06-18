using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;
using BLL;
using System.Data.SqlClient;
using System.Data;

namespace Food
{
    public partial class Register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack) { }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            SqlParameter[] param = new SqlParameter[] {
                            new SqlParameter("@LoginName",SqlDbType.NVarChar),
                            new SqlParameter("@Title",SqlDbType.NVarChar)
                        };
            param[0].Value = username.Value;
            param[1].Value = nickname.Value;
            if (DBUtility.DbHelperSQL.Exists("select * from GZXX_U_UserTable where LoginName = @LoginName", param))
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), System.DateTime.Now.Ticks.ToString(), "alert('账号已存在！')", true);
            }
            else if (DBUtility.DbHelperSQL.Exists("select * from GZXX_U_UserTable where Title = @Title", param))
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), System.DateTime.Now.Ticks.ToString(), "alert('昵称已存在！')", true);
            }
            else
            {
                Hashtable ht = new Hashtable();
                ht.Add("password", password.Value);
                ht.Add("loginname", username.Value);
                ht.Add("title", nickname.Value);
                ht.Add("pic", HiddenField1.Value);
                ht.Add("UserLevel", "普通会员");
                ht.Add("departid", 1);
                ht.Add("channelid", 1000054);
                ht.Add("ClassID", 96);
                ht.Add("inputer", username.Value);
                GZXX_Model bll = new GZXX_Model();
                int infoid = bll.AddContent("GZXX_U_UserTable", ht);
                if (infoid > 0)
                {
                    Session["UserLevel"] = "普通会员";
                    Session["LoginLoginName"] = username.Value;
                    Session["LoginDepartID"] = 1;
                    Session["LoginInfoID"] = infoid;
                    Session["LoginPic"] = HiddenField1.Value;
                    Session["LoginTitle"] = nickname.Value;
                    Response.Redirect("UserInfo.aspx");
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), System.DateTime.Now.Ticks.ToString(), "alert('注册失败！')", true);
                }
            }
        }
    }
}