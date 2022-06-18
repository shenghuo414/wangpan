using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;

namespace Food
{
    public partial class ActiveVIP : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                if (Session["UserLevel"].ToString() == "VIP超级会员") 
                {
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), System.DateTime.Now.Ticks.ToString(), "layer.alert('已经是VIP超级会员啦！', {icon: 1,kin: 'layer-ext-moon',closeBtn: 0 }, function () { location.href='LookFile.aspx';})", true);
                }
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string code = UserName.Value+"-"+Text1.Value+"-"+Text2.Value+"-"+Text3.Value;
            DataTable dt = DBUtility.DbHelperSQL.Query("select * from WP_Code where Title = '"+code+"'").Tables[0];
            if (dt.Rows.Count > 0) 
            {
                if (dt.Rows[0]["Flag"].ToString() != "未激活")
                {
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), System.DateTime.Now.Ticks.ToString(), "layer.alert('激活码已被使用！', {icon: 2,kin: 'layer-ext-moon',closeBtn: 0 })", true);
                }
                else 
                {
                    Hashtable ht = new Hashtable();
                    ht.Add("InfoID", Session["LoginInfoID"].ToString());
                    ht.Add("UserLevel", "VIP超级会员");
                    ht.Add("Code", code);
                    new BLL.GZXX_Model().EditContent("GZXX_U_UserTable", ht);
                    DBUtility.DbHelperSQL.ExecuteSql("update WP_Code set UserInfoID = '" + Session["LoginInfoID"].ToString() + "',ActiveDate=getdate(),Flag='已激活' where Title = '" + code + "'");
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), System.DateTime.Now.Ticks.ToString(), "layer.alert('激活VIP超级会员成功，请重新登录！', {icon: 1,kin: 'layer-ext-moon',closeBtn: 0 }, function () { parent.location.href='Login.aspx';})", true);
                }
            }
            else 
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), System.DateTime.Now.Ticks.ToString(), "layer.alert('激活码不存在！', {icon: 2,kin: 'layer-ext-moon',closeBtn: 0 })", true);
            }
        }
    }
}