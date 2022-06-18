using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Web.SessionState;
using System.Web;
using System.Collections;

namespace Food
{
    /// <summary>
    /// Upload 的摘要说明
    /// </summary>
    public class Upload : IHttpHandler,IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            HttpPostedFile file = context.Request.Files[0];
            string uploadPath = context.Request.MapPath("~/UploadFiles/files/");
            if (file != null)
            {
                //新文件名

                string filename = DateTime.Now.ToString("yyyyMMddhhmmss") + Path.GetExtension(file.FileName);

                if (context.Request["pid"] != null)
                {
                    int i = file.ContentLength;
                    int num = 0;
                    object allcount = DBUtility.DbHelperSQL.GetSingle("select sum(cast(filelength as bigint)) from WP_File where UserInfoID = '" + context.Session["LoginInfoID"].ToString() + "'");
                    
                    if (allcount != null) { num = int.Parse(allcount.ToString()); }
                    if (context.Session["UserLevel"].ToString() == "普通会员") 
                    {
                        if (((i + num) / (1024 * 1024 )) > 100)
                        {
                            context.Response.Write("Error");
                            return;
                        }
                        else
                        {

                            file.SaveAs(uploadPath + filename);

                            Hashtable ht = new Hashtable();
                            ht.Add("channelid", 0);
                            ht.Add("ClassID", 0);
                            ht.Add("Title", "/UploadFiles/files/" + filename);
                            ht.Add("OldName", file.FileName);
                            ht.Add("FileLength", file.ContentLength);
                            ht.Add("UserInfoID", context.Session["LoginInfoID"]);
                            ht.Add("ParentInfoID", int.Parse(context.Request["pid"]));
                            ht.Add("ShareID", DBUtility.Tools.GetRandomChar(16));
                            ht.Add("ShareCode", DBUtility.Tools.GetRandomChar(4).ToLower());
                            new BLL.GZXX_Model().AddContent("WP_File", ht);
                        }
                    }
                    else
                    {
                        if (((i + num) / (1024 * 1024 * 1024)) > 10)
                        {
                            context.Response.Write("Error");
                            return;
                        }
                        else
                        {

                            file.SaveAs(uploadPath + filename);

                            Hashtable ht = new Hashtable();
                            ht.Add("channelid", 0);
                            ht.Add("ClassID", 0);
                            ht.Add("Title", "/UploadFiles/files/" + filename);
                            ht.Add("OldName", file.FileName);
                            ht.Add("FileLength", file.ContentLength);
                            ht.Add("UserInfoID", context.Session["LoginInfoID"]);
                            ht.Add("ParentInfoID", int.Parse(context.Request["pid"]));
                            string shareid = DBUtility.Tools.GetRandomChar(16);
                            ht.Add("ShareID", shareid);
                            string code = DBUtility.Tools.GetRandomChar(4);
                            while (code.ToLower() == shareid.ToLower().Substring(0, 4)) 
                            {
                                code = DBUtility.Tools.GetRandomChar(4);
                            }
                            ht.Add("ShareCode", code.ToLower());
                            new BLL.GZXX_Model().AddContent("WP_File", ht);
                        }
                    }
                }
                else { file.SaveAs(uploadPath + filename); }
                
                ReturnList.ResultInfo info = new ReturnList.ResultInfo();
                info.errorcode = 0;
                info.msg = "OK";
                info.url = "/UploadFiles/files/" + filename;
                string str = JsonConvert.SerializeObject(info);
                context.Response.Write(str);

                //context.Response.Write();
            }
            else
            {
                ReturnList.ResultInfo info = new ReturnList.ResultInfo();
                info.errorcode = 1;
                info.msg = "Error";
                info.url = "";
                string str = JsonConvert.SerializeObject(info);
                context.Response.Write(str);
            }
        }

        public class ReturnList
        {
            public class ResultInfo
            {
                public int errorcode { get; set; }
                public string msg { get; set; }
                public string url { get; set; }
            }
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}