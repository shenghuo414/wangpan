using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Food.Admin.Depart
{
    public partial class AddDepart : System.Web.UI.Page
    {
        BLL.GZXX_UserDepartMent bll = new BLL.GZXX_UserDepartMent();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                if (Request["action"] == null) 
                {
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), System.DateTime.Now.Ticks.ToString(), "alert('参数错误！')", true);
                }
                else
                {
                    if (Request["action"].ToString() == "add" && Request["parentId"] != null)
                    {
                        DataTable dt = bll.getDepartMent(int.Parse(Session["DepartId"].ToString()));

                        drp_ParentID.Items.Clear();
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            ListItem li = new ListItem();
                            li.Value = dt.Rows[i]["DepartId"].ToString();
                            li.Text = bll.getLine(dt.Rows[i]["ParentIDPath"].ToString(), dt.Rows[i]["DepartMentName"].ToString(), dt.Rows[i]["Child"].ToString(), "no");
                            drp_ParentID.Items.Add(li);
                        }

                        string id = Request.QueryString["Parentid"];
                        if (id != null && id != "")
                        {
                            foreach (ListItem li in drp_ParentID.Items)
                            {
                                if (li.Value == id)
                                {
                                    li.Selected = true;
                                }
                            }
                        }
                        drp_ParentID.DataBind();
                        //AdminPurview.Items[0].Selected = true;
                    }
                    else if (Request["action"].ToString() == "edit" && Request["id"] != null)
                    {
                        Model.GZXX_UserDepartMent model = new Model.GZXX_UserDepartMent();
                        model = bll.getDepartMentInfo(int.Parse(Request["id"].ToString()));
                        txt_OrderID.Text = model.orderid.ToString();
                        txt_DepartMentName.Text = model.departmentname;
                        txt_DepartMentEname.Text = model.departmentename;
                        drp_ParentID.Items.Clear();
                        ListItem li = new ListItem();
                        if (model.partentid != 0)
                        {
                            model = bll.getDepartMentInfo(model.partentid);
                            li.Value = model.departid.ToString();
                            li.Text = bll.getLine(model.parentidpath, model.departmentname, model.child.ToString(), "no");
                        }
                        else 
                        {
                            li.Value = model.partentid.ToString();
                            li.Text = "根节点";
                        }
                        drp_ParentID.Items.Add(li);
                        drp_ParentID.DataBind();
                        drp_ParentID.Enabled = false;
                        
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), System.DateTime.Now.Ticks.ToString(), "alert('参数错误！')", true);
                    }
                }
            }
        }

        protected void txt_DepartMentName_TextChanged(object sender, EventArgs e)
        {
            txt_DepartMentEname.Text = DBUtility.Tools.GetSpellCode(txt_DepartMentName.Text);
        }

        protected void lk_sure_Click(object sender, EventArgs e)
        {
            Model.GZXX_UserDepartMent parentmodel = new Model.GZXX_UserDepartMent();
            parentmodel = bll.getDepartMentInfo(int.Parse(drp_ParentID.SelectedValue));
            Model.GZXX_UserDepartMent model = new Model.GZXX_UserDepartMent();
            model.adminpurview = "";// AdminPurview.SelectedValue;
            model.child = 0;
            model.classdir = string.Empty;
            model.departmentename = txt_DepartMentEname.Text;
            model.departmentname = txt_DepartMentName.Text;
            if (drp_ParentID.SelectedValue == "0") 
            {
                model.depth = 1;
                try
                {
                    model.orderid = int.Parse(txt_OrderID.Text);
                }
                catch (Exception)
                {
                    model.orderid = 0;
                }
                model.parentidpath = "0";
                model.partentid = 0;
            }
            else
            {
                model.depth = parentmodel.parentidpath.Split(',').Length + 1;
                try
                {
                    model.orderid = int.Parse(txt_OrderID.Text);
                }
                catch (Exception)
                {
                    model.orderid = parentmodel.parentidpath.Split(',').Length;
                }
                model.parentidpath = parentmodel.parentidpath + "," + parentmodel.departid;
                model.partentid = parentmodel.departid;
            }
            model.intro = string.Empty;
            model.nextid = 0;
            model.previd = 0;
            model.root = 0;
            model.username = string.Empty;

            model.photourl = "";// upfile.Value;
            if (Request["action"].ToString() == "add")
            {
                if (bll.Add(model))
                {
                    txt_DepartMentEname.Text = "";
                    txt_DepartMentName.Text = "";
                    txt_OrderID.Text = "";
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), System.DateTime.Now.Ticks.ToString(), "layer.alert('操作成功！', {icon: 1,kin: 'layer-ext-moon',closeBtn: 0 }, function () { parent.window.location.reload();})", true);
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), System.DateTime.Now.Ticks.ToString(), "alert('操作失败！')", true);
                }
            }
            else if (Request["action"].ToString() == "edit")
            {
                model.departid = int.Parse(Request["id"].ToString());
                if (bll.Update(model))
                {
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), System.DateTime.Now.Ticks.ToString(), "layer.alert('操作成功！', {icon: 1,kin: 'layer-ext-moon',closeBtn: 0 }, function () { parent.window.location.reload();})", true);
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), System.DateTime.Now.Ticks.ToString(), "alert('操作失败！')", true);
                }
            }
        }
    }
}