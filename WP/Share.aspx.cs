using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;
using System.Text;

namespace Food
{
    public partial class Share : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack) 
            {
                SqlParameter[] param = new SqlParameter[] {
                    new SqlParameter("@Share",SqlDbType.NVarChar)
                };
                param[0].Value = Request["code"].ToString();
                DataTable dt = DBUtility.DbHelperSQL.Query("select *,(select LoginName from GZXX_U_UserTable where GZXX_U_UserTable.InfoID = WP_File.UserInfoID) as LoginName from WP_File where ShareID = @Share", param).Tables[0];
                Literal1.Text = GetxxxString(dt.Rows[0]["LoginName"].ToString());
                HiddenField1.Value = DBUtility.DESEncrypt.Encrypt(dt.Rows[0]["ShareCode"].ToString());
                HiddenField2.Value = DBUtility.DESEncrypt.Encrypt(dt.Rows[0]["Title"].ToString());
            }
        }

        public static string GetxxxString(string Input)
 {
     string Output = "";
     switch (Input.Length)
     {
         case 1:
             Output = "*";
             break;
         case 2:
             Output = Input[0] + "*";
             break;
         case 0:
             Output = "";
             break;
         default:
             Output = Input.Substring(0, 1);
             for (int i = 0; i < Input.Length - 2; i++)
             {
                 Output += "*";
             }
             Output += Input.Substring(Input.Length - 1, 1);
             break;
     }
     return Output;
 }

        protected void Button2_Click(object sender, EventArgs e)
        {
            if(hvyVEbB.Value == DBUtility.DESEncrypt.Decrypt(HiddenField1.Value))
            {
                string sFileName = Server.MapPath(DBUtility.DESEncrypt.Decrypt(HiddenField2.Value));
                FileStream fileStream = new FileStream(sFileName, FileMode.Open);
                long fileSize = fileStream.Length;
                byte[] fileBuffer = new byte[fileSize];
                fileStream.Read(fileBuffer, 0, (int)fileSize);
                //如果不写fileStream.Close()语句，用户在下载过程中选择取消，将不能再次下载
                fileStream.Close();

                Context.Response.ContentType = "application/octet-stream";
                Context.Response.AppendHeader("Content-Disposition", "attachment;filename=" + HttpUtility.UrlEncode(sFileName, Encoding.UTF8));
                Context.Response.AddHeader("Content-Length", fileSize.ToString());

                Context.Response.BinaryWrite(fileBuffer);
                Context.Response.End();
                Context.Response.Close();
            }
            else
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), System.DateTime.Now.Ticks.ToString(), "layer.alert('提取码不正确！', {icon: 2,kin: 'layer-ext-moon',closeBtn: 0 })", true);
            }
        }
    }
}