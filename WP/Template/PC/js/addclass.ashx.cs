using System;
using System.Collections.Generic;
using System.Web.SessionState;
using System.Web;
using System.Collections;

namespace Food.Template.PC.js
{
    /// <summary>
    /// addclass 的摘要说明
    /// </summary>
    public class addclass : IHttpHandler,IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            //context.Response.Write("Hello World");
            Hashtable ht = new Hashtable();
            ht.Add("Title", context.Request["name"]);
            ht.Add("channelid", 0);
            ht.Add("ClassID", 0);
            ht.Add("UserInfoID", context.Session["LoginInfoID"].ToString());
            ht.Add("ParentInfoID", context.Request["pid"]);
            new BLL.GZXX_Model().AddContent("WP_Class", ht);
            context.Response.Write("OK");
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