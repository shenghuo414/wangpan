using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Food.Admin.Content
{
    public partial class UserManage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                bind();
            }
        }

        void bind()
        {
            AspNetPager1.RecordCount = int.Parse(DBUtility.DbHelperSQL.GetSingle("select count(*) from GZXX_U_UserTable where 1 = 1 "+HiddenField1.Value).ToString());
            rp_list.DataSource = DBUtility.DbHelperSQL.Query("select * from GZXX_U_UserTable where 1 = 1 "+HiddenField1.Value+" order by InfoID desc", AspNetPager1.PageSize * (AspNetPager1.CurrentPageIndex - 1), AspNetPager1.PageSize).Tables[0];
            rp_list.DataBind();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            HiddenField1.Value = "";
            if (TextBox2.Text.Trim() != "") 
            {
                HiddenField1.Value += " and LoginName like '%"+TextBox2.Text.Trim()+"%'";
            }
            if (TextBox1.Text.Trim() != "")
            {
                HiddenField1.Value += " and Title like '%" + TextBox1.Text.Trim() + "%'";
            }
            bind();
        }
        protected void Button2_Click(object sender, EventArgs e)
        {
            new BLL.GZXX_Model().DeleteContent("WP_File", int.Parse(HiddenField7.Value));
            bind();
        }

        protected void AspNetPager1_PageChanging(object src, Wuqi.Webdiyer.PageChangingEventArgs e)
        {

            AspNetPager1.CurrentPageIndex = e.NewPageIndex;
            bind();
        }
    }
}