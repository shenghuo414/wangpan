using System;
using System.Collections;
using System.Collections.Generic;
using System.Web.SessionState;
using System.Web;

namespace Food.Template.PC.js
{
    /// <summary>
    /// caipu 的摘要说明
    /// </summary>
    public class caipu : IHttpHandler,IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            if (context.Request["channelid"] != null && context.Request["classid"] != null)
            {
                
                    Hashtable ht = new Hashtable();
                    ht.Add("Inputer", context.Session["LoginInfoID"]);
                    ht.Add("DepartID", 1);
                    for (int i = 0; i < context.Request.Form.Count; i++)
                    {
                        ht.Add(context.Request.Form.Keys[i].ToString(), context.Request.Form[i].ToString());
                    }
                    ht.Add("UserInfoID", context.Session["LoginInfoID"]);
                    ht.Add("Flag", "已审核");
                    ht.Add("CreateDate", DateTime.Parse(DBUtility.DbHelperSQL.GetSingle("select getdate()").ToString()).ToString("yyyy-MM-dd HH:mm:ss"));
                    int infoid = new BLL.GZXX_Model().AddContent("GZXX_U_MeiShi", ht);

                    if (infoid > 0)
                    {
                        context.Response.Write("发布成功！");
                    }
                    else
                    {
                        context.Response.Write("发布失败，请稍后再试！");
                    }
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