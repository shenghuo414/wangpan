using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Food
{
    public partial class UserInfo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                if (Session["LoginLoginName"] == null)
                {
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), System.DateTime.Now.Ticks.ToString(), "$(function(){layer.alert('登录超时！', {icon: 2,kin: 'layer-ext-moon',closeBtn: 0 }, function () {location.href='/Login.aspx';});});", true);
                }

                double templength = 0.00;
                object allcount = DBUtility.DbHelperSQL.GetSingle("select sum(cast(filelength as bigint)) from WP_File where UserInfoID = '" + Session["LoginInfoID"].ToString() + "'");
                if (allcount != null) { templength = double.Parse(allcount.ToString()); }
                double dsj = (double.Parse(templength.ToString()) / (double.Parse("1024") * double.Parse("1024") * double.Parse("1024")));
                int sj = int.Parse(Math.Ceiling(dsj).ToString());
                yyspan.InnerText = dsj.ToString("0.0") + "G";
                if (Session["UserLevel"].ToString() == "普通会员")
                {
                    sjdiv.Visible = true;
                    wyspan.InnerText = "100MB";
                    double bfb = (dsj * 1024);
                    yyspan.InnerText = (dsj * 1024).ToString("0.0") + "MB";
                    jdtspan.Attributes.Add("style", "background: rgb(255, 216, 33); transition-duration: 0.959255s;width:" + bfb.ToString("0.00") + "%");
                }
                else 
                {
                    yyspan.InnerText = dsj.ToString("0.0") + "G";
                    sjdiv.Visible = false;
                    wyspan.InnerText = "10G";
                    double bfb = (dsj / 10)* 100;
                    jdtspan.Attributes.Add("style", "background: rgb(255, 216, 33); transition-duration: 0.959255s;width:" + bfb.ToString("0.00") + "%");
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