using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Food
{
    public partial class LookFile : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                if (Request["InfoID"] != null&&Request["type"]==null)
                {
                    HiddenField1.Value = " and ParentInfoID = " + int.Parse(Request["InfoID"].ToString()) + " ";
                }
                else
                {
                    if (Request["type"] == null)
                    {
                        HiddenField1.Value = " and ParentInfoID = 0 ";
                    }
                }
                if (Request["type"] == null)
                {
                    Repeater1.DataSource = DBUtility.DbHelperSQL.Query("select * from WP_Class where UserInfoID = '" + Session["LoginInfoID"].ToString() + "' " + HiddenField1.Value).Tables[0];
                    Repeater1.DataBind();
                }
                else
                {
                    if (Request["type"].ToString() == "pic") 
                    {
                        HiddenField1.Value += " and (OldName like '%.png%' or OldName like '%.jpeg%' or OldName like '%.jpg%')";
                    }
                    if (Request["type"].ToString() == "video")
                    {
                        HiddenField1.Value += " and (OldName like '%.mp4%' or OldName like '%.flv%' or OldName like '%.mpeg%')";
                    }
                    if (Request["type"].ToString() == "music")
                    {
                        HiddenField1.Value += " and (OldName like '%.mp3%' )";
                    }
                    if (Request["type"].ToString() == "torrent")
                    {
                        HiddenField1.Value += " and (OldName like '%.torrent%' )";
                    }
                    if (Request["type"].ToString() == "word")
                    {
                        HiddenField1.Value += " and (OldName like '%.txt%' or OldName like '%.doc%' or OldName like '%.xls%' or OldName like '%.pdf%'  or OldName like '%.xlxs%')";
                    }
                    if (Request["type"].ToString() == "other")
                    {
                        HiddenField1.Value += " and OldName not like '%.jpeg%' and OldName not like '%.png%' and OldName not like '%.jpg%' and OldName not like '%.torrent%' and OldName not like '%.mp3%' and OldName not like '%.mp4%' and OldName not like '%.flv%' and OldName not like '%.mpeg%' and OldName not like '%.txt%' and OldName not like '%.doc%' and OldName not like '%.xls%' and OldName not like '%.pdf%' and OldName not like '%.xlxs%' ";
                    }
                }
                Repeater2.DataSource = DBUtility.DbHelperSQL.Query("select * from WP_File where UserInfoID = '" + Session["LoginInfoID"].ToString() + "' " + HiddenField1.Value).Tables[0];
                Repeater2.DataBind();
                Literal1.Text = (Repeater1.Items.Count + Repeater2.Items.Count).ToString();
                object allcount = DBUtility.DbHelperSQL.GetSingle("select sum(cast(filelength as bigint)) from WP_File where UserInfoID = '" + Session["LoginInfoID"].ToString() + "'");
                if (allcount == null) { HiddenField3.Value = "0"; }
                else { HiddenField3.Value = allcount.ToString(); }
                HiddenField4.Value = Session["UserLevel"].ToString();
            }
        }

        public string ShowClass(string filename)
        {
            if (filename.ToLower().IndexOf(".zip") > 0 || filename.ToLower().IndexOf(".rar") > 0 || filename.ToLower().IndexOf(".7z") > 0)
            {
                return "fileicon-small-zip";
            }
            else if (filename.ToLower().IndexOf(".jpeg") > 0 || filename.ToLower().IndexOf(".jpg") > 0 || filename.ToLower().IndexOf(".png") > 0)
            {
                return "fileicon-small-pic";
            }
            else 
            {
                return "default-small";
            }
        }

        public string JS(string filelength)
        {
            double dsj = (double.Parse(filelength) / double.Parse("1024"));
            int sj = int.Parse(Math.Ceiling(dsj).ToString());
            if (sj.ToString().Length <= 3) { return dsj.ToString("0.00") + "KB"; }
            else 
            {
                double dsj1=(double.Parse(sj.ToString()) / double.Parse("1024"));
                int sj1 = int.Parse(Math.Ceiling(dsj1).ToString());
                if (sj1.ToString().Length <= 3) { return dsj1.ToString("0.00") + "MB"; }
                else 
                {
                    double dsj2 = (double.Parse(sj.ToString()) / (double.Parse("1024") * double.Parse("1024")));
                    int sj2 = int.Parse(Math.Ceiling(dsj2).ToString());
                    return dsj2.ToString("0.00") + "G";
                }
            }
        }
        public int ShowID(object rid)
        {
            if (rid != null) { return int.Parse(rid.ToString()); }
            else { return 0; }
        }
        protected void Button2_Click(object sender, EventArgs e)
        {
            new BLL.GZXX_Model().DeleteContent("WP_File", int.Parse(HiddenField2.Value));
            if (Request["InfoID"] == null)
            {
                if (Request["type"] == null)
                {
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), System.DateTime.Now.Ticks.ToString(), "layer.alert('删除成功！', {icon: 1,kin: 'layer-ext-moon',closeBtn: 0 }, function () { location.href='LookFile.aspx';})", true);
                }
                else 
                {
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), System.DateTime.Now.Ticks.ToString(), "layer.alert('删除成功！', {icon: 1,kin: 'layer-ext-moon',closeBtn: 0 }, function () { location.href='LookFile.aspx?type="+Request["type"].ToString()+"';})", true);
                }
            }
            else
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), System.DateTime.Now.Ticks.ToString(), "layer.alert('删除成功！', {icon: 1,kin: 'layer-ext-moon',closeBtn: 0 }, function () { location.href='LookFile.aspx?InfoID=" + Request["InfoID"].ToString() + "';})", true);
            }
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            string sFileName = Server.MapPath(HiddenField2.Value);
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
    }
}