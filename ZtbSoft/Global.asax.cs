using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;

namespace ZtbSoft.Web
{
    public class Global : System.Web.HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {
            ZtbSoft.Components.LogHelper<Global>.SetConfig();
            ZtbSoft.Components.LogHelper<Global>.WriteLog("Server strating...");
        }

        protected void Session_Start(object sender, EventArgs e)
        {

        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {
            Exception objExp = HttpContext.Current.Server.GetLastError();
            ZtbSoft.Components.LogHelper<Global>.WriteLog("\r\n客户机IP:" + Request.UserHostAddress + "\r\n错误地址:" + Request.Url + "\r\n异常信息:" + Server.GetLastError().Message, objExp);
        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}