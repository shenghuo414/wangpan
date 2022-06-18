using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Food.Admin.Depart
{
    public partial class AddGroup : System.Web.UI.Page
    {
        BLL.GZXX_Group bll = new BLL.GZXX_Group();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack) 
            {
                
                if (Request.QueryString["action"] == "edit")
                {
                    Model.GZXX_Group model = new Model.GZXX_Group();
                    model = bll.GetGroupInfo(int.Parse(Request.QueryString["groupid"]));
                    TextBox1.Text = model.groupname;
                    TextBox7.Text = model.intro;
                    foreach (Control ct in pl_main.Controls)
                    {
                        if (ct.GetType().ToString().Equals("System.Web.UI.WebControls.CheckBox"))
                        {
                            CheckBox cb = (CheckBox)ct;
                            string cbcs = "|"+cb.CssClass+"|";
                            string powerlist = "|" + model.powerlist + "|";
                            if (powerlist.Contains(cbcs)) 
                            {
                                cb.Checked = true;
                            }
                        }
                    }
                    //for (int i = 0; i < Repeater1.Items.Count; i++)
                    //{
                    //    CheckBox chk = (CheckBox)Repeater1.Items[i].FindControl("chk01_01_");
                    //    string cbcs = "|" + chk.CssClass + "|";
                    //    string powerlist = "|" + model.powerlist + "|";
                    //    if (powerlist.Contains(cbcs))
                    //    {
                    //        chk.Checked = true;
                    //    }
                    //}
                }
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string powerlist = string.Empty;
            foreach (Control ct in pl_main.Controls)
            {
                if (ct.GetType().ToString().Equals("System.Web.UI.WebControls.CheckBox"))
                {
                    CheckBox cb = (CheckBox)ct;
                    if (cb.Checked) 
                    {
                        powerlist += "|" + cb.CssClass;
                    }
                }
            }
            //for (int i = 0; i < Repeater1.Items.Count; i++)
            //{
            //    CheckBox chk = (CheckBox)Repeater1.Items[i].FindControl("chk01_01_");
            //    if (chk.Checked)
            //    {
            //        powerlist += "|" + chk.CssClass;
            //    }
            //}
            Model.GZXX_Group model = new Model.GZXX_Group();
            model.groupname = TextBox1.Text.Trim();
            model.intro = TextBox7.Text;
            if (powerlist != "")
            {
                model.powerlist = powerlist.Substring(1);
            }
            else {
                model.powerlist = "";
            }
            if (Request.QueryString["action"] == "add")
            {
                if (bll.Add(model))
                {
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), System.DateTime.Now.Ticks.ToString(), "layer.alert('操作成功！', {icon: 1,kin: 'layer-ext-moon',closeBtn: 0}, function () { location.href = 'ManageGroup.aspx';})", true);
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), System.DateTime.Now.Ticks.ToString(), "alert('操作失败！')", true);
                }
            }
            else 
            {
                model.groupid = int.Parse(Request.QueryString["groupid"]);
                if (bll.Update(model))
                {
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), System.DateTime.Now.Ticks.ToString(), "layer.alert('操作成功！', {icon: 1,kin: 'layer-ext-moon',closeBtn: 0}, function () { location.href = 'ManageGroup.aspx';})", true);
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), System.DateTime.Now.Ticks.ToString(), "alert('操作失败！')", true);
                }
            }
        }
    }
}