using System;
using System.Collections.Generic;
using System.Web.SessionState;
using System.Web;
using System.Collections;

namespace Food.Template.PC.js
{
    /// <summary>
    /// setfav 的摘要说明
    /// </summary>
    public class setfav : IHttpHandler,IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            if (context.Request["infoid"] != null && context.Request["title"] != null)
            {
                if (context.Session["LoginInfoID"] != null)
                {

                    BLL.GZXX_Model bll = new BLL.GZXX_Model();

                    Hashtable ht = new Hashtable();
                    ht.Add("Inputer", context.Session["LoginInfoID"]);
                    ht.Add("DepartID", 1);
                    ht.Add("UserInfoID", context.Session["LoginInfoID"]);
                    ht.Add("UserName", context.Session["LoginTitle"]);
                    ht.Add("Title", context.Request["title"]);
                    ht.Add("CPInfoID", context.Request["infoid"]);
                    ht.Add("ChannelID", 1000063);
                    ht.Add("ClassID", 136);
                    ht.Add("CreateDate", DateTime.Parse(DBUtility.DbHelperSQL.GetSingle("select getdate()").ToString()).ToString("yyyy-MM-dd HH:mm:ss"));

                    int infoid = bll.AddContent("GZXX_U_Favorite", ht);

                    if (infoid > 0)
                    {
                        context.Response.Write("OK");
                    }
                    else
                    {
                        context.Response.Write("ParamError");
                    }
                }
                else
                {
                    context.Response.Write("NoLogin");
                }
            }
            else
            {
                context.Response.Write("ParamError");
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