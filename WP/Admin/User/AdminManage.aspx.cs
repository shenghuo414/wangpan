using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Food.Admin.User
{
    public partial class AdminManage : System.Web.UI.Page
    {
        BLL.GZXX_Admin bll = new BLL.GZXX_Admin();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack) 
            {
                bind("", AspNetPager1.PageSize * (AspNetPager1.CurrentPageIndex - 1), AspNetPager1.PageSize);
            }
        }

        void bind(string where,int currentSize,int pageSize) 
        {
            AspNetPager1.RecordCount = bll.GetCount(where);
            rp_list.DataSource = bll.GetDataTable(where, currentSize, pageSize);
            rp_list.DataBind();
        }

        protected void AspNetPager1_PageChanging(object src, Wuqi.Webdiyer.PageChangingEventArgs e)
        {
            AspNetPager1.CurrentPageIndex = e.NewPageIndex;
            bind("",AspNetPager1.PageSize * (AspNetPager1.CurrentPageIndex - 1), AspNetPager1.PageSize);
        }
    }
}