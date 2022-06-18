using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Food.Admin.Depart
{
    public partial class ManageGroup : System.Web.UI.Page
    {
        BLL.GZXX_Group bll = new BLL.GZXX_Group();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack) 
            {
                bind(AspNetPager1.PageSize * (AspNetPager1.CurrentPageIndex - 1), AspNetPager1.PageSize, "");
            }
        }
        void bind(int currentSize, int pageSize, string where)
        {
            AspNetPager1.RecordCount = bll.GetCount(where, null);
            DataTable dt = bll.GetDataTable(where, currentSize, pageSize, null);
            rp_list.DataSource = dt;
            rp_list.DataBind();
        }
        protected void AspNetPager1_PageChanging(object src, Wuqi.Webdiyer.PageChangingEventArgs e)
        {
            AspNetPager1.CurrentPageIndex = e.NewPageIndex;
            bind(AspNetPager1.PageSize * (AspNetPager1.CurrentPageIndex - 1), AspNetPager1.PageSize, "");
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            BLL.GZXX_Group bll = new BLL.GZXX_Group();
            try
            {
                if (bll.GroupHasUser(int.Parse(HiddenField1.Value)))
                {
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), System.DateTime.Now.Ticks.ToString(), "alert('用户组下有用户不能删除！')", true);
                }
                else
                {
                    if (bll.Delete(int.Parse(HiddenField1.Value)))
                    {
                        Response.Redirect("ManageDepart.aspx");
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), System.DateTime.Now.Ticks.ToString(), "alert('操作失败！')", true);
                    }
                }
            }
            catch (Exception)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), System.DateTime.Now.Ticks.ToString(), "alert('操作失败！')", true);
            }

        }
    }
}