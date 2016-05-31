using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.SessionState;

namespace ZtbSoft.Web.ajax
{
    /// <summary>
    /// loginOut 的摘要说明
    /// </summary>
    public class loginOut : IHttpHandler, IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            new ZtbSoft.BLL.loginBLL().logingOut(context);

            Hashtable result = new Hashtable();
            result["error"] = -2;
            result["message"] = "登出成功";
            string json = JsonHelper.Encode(result);

            context.Response.ContentType = "text/plain";
            context.Response.Write(json);
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