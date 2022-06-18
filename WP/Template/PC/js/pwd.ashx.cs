using System;
using System.Collections.Generic;
using System.Web.SessionState;
using System.Web;
using System.Collections;

namespace Food.Template.PC.js
{
    /// <summary>
    /// pwd 的摘要说明
    /// </summary>
    public class pwd : IHttpHandler,IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            if (context.Session["LoginLoginName"] != null)
            {
                if (context.Request["channelid"] != null && context.Request["classid"] != null)
                {
                    BLL.GZXX_Model bll = new BLL.GZXX_Model();
                 
                        Hashtable ht = new Hashtable();
                        //ht["Title"] = context.Session["LoginTitle"].ToString();
                        //ht["infoid"] = context.Session["LoginInfoID"].ToString();
                        ht.Add("infoid", context.Session["LoginInfoID"].ToString());
               
                        for (int i = 0; i < context.Request.Form.Count; i++)
                        {
                            ht.Add(context.Request.Form.Keys[i].ToString(), context.Request.Form[i].ToString());
                        }
                        if (bll.EditContent("GZXX_U_UserTable", ht))
                        {
                            context.Session["LoginPic"] = ht["pic"];
                            context.Response.Write("密码修改成功！");
                        }
                        else
                        {
                            context.Response.Write("密码修改失败，请稍后再试！");
                        }
                    }
                }
                else
                {
                    context.Response.Write("参数错误！");
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