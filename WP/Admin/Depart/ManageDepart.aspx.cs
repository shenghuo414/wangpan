using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Food.Admin.Depart
{
    public partial class ManageDepart : System.Web.UI.Page
    {
        BLL.GZXX_UserDepartMent bll = new BLL.GZXX_UserDepartMent();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack) 
            {
                bind();
            }
        }

        void bind() 
        {
            DataTable dt = bll.getDepartMent(int.Parse(Session["DepartID"].ToString()));
            list.DataSource = dt;
            list.DataBind();
        }

        public string getLine(string items, string dePartName, string child)
        {
            return bll.getLine(items, dePartName, child, "yes");
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            BLL.GZXX_UserDepartMent bll = new BLL.GZXX_UserDepartMent();
            bll.Delete(int.Parse(HiddenField1.Value));
            Response.Redirect("ManageDepart.aspx");
        }

       
    }
}