using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;
using System.Data;

namespace Food.Admin.Content
{
    public partial class ContactEidt : System.Web.UI.Page
    {
        public string FH(string str) 
        {
            return str.Substring(0, 4) + "-" + str.Substring(4, 4) + "-" + str.Substring(8, 4) + "-" + str.Substring(12, 4);
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                for (int i = 0; i < 10; i++)
                {

                    string code = DBUtility.Tools.GetRandomChar(16).ToUpper();
                    
                    while (HiddenField1.Value.IndexOf(code) >= 0) 
                    {
                        code = DBUtility.Tools.GetRandomChar(16).ToUpper();
                    }
                
                    HiddenField1.Value += "," + code;
                    Literal1.Text += FH(code) + "<br>";
                }
                for (int i = 0; i < 10; i++)
                {

                    string code = DBUtility.Tools.GetRandomChar(16).ToUpper();

                    while (HiddenField1.Value.IndexOf(code) >= 0)
                    {
                        code = DBUtility.Tools.GetRandomChar(16).ToUpper();
                    }
                    HiddenField1.Value += "," + code;
                    Literal2.Text += FH(code) + "<br>";
                }
                Literal2.Visible = false;
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            int flag = 0;
            string[] arr = HiddenField1.Value.Substring(1).Split(',');
            for (int i = 0; i < int.Parse(DropDownList1.SelectedValue.Replace("个", "")); i++)
            {
                flag++;
                Hashtable ht = new Hashtable();
                ht.Add("Flag", "未激活");
                ht.Add("Title", FH(arr[i]));
                ht.Add("channelid", 0);
                ht.Add("ClassID", 0);
                new BLL.GZXX_Model().AddContent("WP_Code", ht);
            }
            
            
            if (flag>0)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), System.DateTime.Now.Ticks.ToString(), "layer.alert('操作成功！', {icon: 1,kin: 'layer-ext-moon',closeBtn: 0 }, function () { location.href='ContactManage.aspx';})", true);
            }
            else
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), System.DateTime.Now.Ticks.ToString(), "alert('操作失败！')", true);
            }
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DropDownList1.SelectedValue == "10个")
            {
                Literal2.Visible = false;
            }
            else 
            {
                Literal2.Visible = true;
            }
        }


    }
}