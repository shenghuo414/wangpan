using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Food.Admin.User
{
    public partial class AddAdmin : System.Web.UI.Page
    {
        BLL.GZXX_Admin bll = new BLL.GZXX_Admin();
        BLL.GZXX_UserDepartMent ubll = new BLL.GZXX_UserDepartMent();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack) 
            {
                Button1.Attributes.Add("OnClick", "return CheckForm()");
                BLL.GZXX_Group gbll=new BLL.GZXX_Group();
                DropDownList1.DataSource = gbll.GetDataTable("", 0, 10000, null);
                DropDownList1.DataTextField = "GroupName";
                DropDownList1.DataValueField = "GroupID";
                DropDownList1.DataBind();
                ListItem item = new ListItem();
                item.Text = "--请选择用户组--";
                item.Value = "0";
                DropDownList1.Items.Insert(0, item);
               
                DataTable newdt = new DataTable();
                newdt.Columns.Add("DepartID");
                newdt.Columns.Add("DepartMentName");
                DataTable dt = ubll.getDepartMent(int.Parse(Session["DepartID"].ToString()));
                for (int i = 0; i < dt.Rows.Count; i++) 
                {
                    DataRow dr = newdt.NewRow();
                    dr[0] = dt.Rows[i]["DepartID"].ToString();
                    dr[1] = getLine(dt.Rows[i]["ParentIDPath"].ToString(), dt.Rows[i]["DepartMentName"].ToString(), dt.Rows[i]["child"].ToString()).Replace("<span onclick='jd(this)' style='cursor: pointer'>[-]</span>", "");
                    newdt.Rows.Add(dr);
                }
                DropDownList2.DataSource = newdt;
                DropDownList2.DataTextField = "DepartMentName";
                DropDownList2.DataValueField = "DepartID";
                DropDownList2.DataBind();
                ListItem item_1 = new ListItem();
                item_1.Text = "--请选择部门--";
                item_1.Value = "0";
                DropDownList2.Items.Insert(0, item_1);

                if (Request.QueryString["action"] == "edit") 
                {
                    if (Request["loginname"] != null) 
                    {
                        Model.GZXX_Admin model = new Model.GZXX_Admin();
                        model = bll.GetAdminInfo(Request.QueryString["loginname"]);
                        TextBox1.Text = model.LoginName;
                        TextBox1.Enabled = false;
                        TextBox2.Text = model.RealName;
                        TextBox3.Attributes.Add("value", model.PassWord);
                        if (model.Locked == 1) 
                        {
                            RadioButtonList1.Items[0].Selected = false;
                            RadioButtonList1.Items[1].Selected = true;
                        }
                        for (int i = 0; i < DropDownList1.Items.Count; i++) 
                        {
                            if (DropDownList1.Items[i].Value == model.GroupID.ToString()) 
                            {
                                DropDownList1.Items[i].Selected = true;
                            }
                        }

                        for (int i = 0; i < DropDownList2.Items.Count; i++)
                        {
                            if (DropDownList2.Items[i].Value == model.DepartID.ToString())
                            {
                                DropDownList2.Items[i].Selected = true;
                            }
                        }
                    }
                }
            }
        }

        public string getLine(string items, string dePartName, string child)
        {
            return ubll.getLine(items, dePartName, child, "yes");
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Model.GZXX_Admin model = new Model.GZXX_Admin();
            model.GroupID = int.Parse(DropDownList1.SelectedValue);
            model.DepartID = int.Parse(DropDownList2.SelectedValue);
            if (RadioButtonList1.Items[0].Selected == true)
            {
                model.Locked = 0;
            }
            else
            {
                model.Locked = 1;
            }
            model.LoginName = TextBox1.Text;
            model.PassWord = TextBox3.Text;
            model.PowerList = "";
            model.RealName = TextBox2.Text;
            model.UserFace = "";
            DBUtility.IPAddress ip = new DBUtility.IPAddress();
            model.LastLoginIP = ip.IP_Address;
            if (Request.QueryString["action"] == "add")
            {
                if (bll.HasAdmin(TextBox1.Text.Trim()))
                {
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), System.DateTime.Now.Ticks.ToString(), "alert('操作失败，管理员名称已存在！')", true);
                }
                else
                {
                    if (bll.Add(model))
                    {
                        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), System.DateTime.Now.Ticks.ToString(), "layer.alert('操作成功！', {icon: 1,kin: 'layer-ext-moon',closeBtn: 0}, function () { location.href = 'AdminManage.aspx';})", true);
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), System.DateTime.Now.Ticks.ToString(), "alert('操作失败！')", true);
                    }
                }
            }
            else 
            {
                model.LoginName = Request.QueryString["loginname"];
                if (bll.Update(model))
                {
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), System.DateTime.Now.Ticks.ToString(), "layer.alert('操作成功！', {icon: 1,kin: 'layer-ext-moon',closeBtn: 0}, function () { location.href = 'AdminManage.aspx';})", true);
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), System.DateTime.Now.Ticks.ToString(), "alert('操作失败！')", true);
                }
            }
        }
    }
}