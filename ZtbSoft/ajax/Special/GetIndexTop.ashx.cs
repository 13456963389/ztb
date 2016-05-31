using ZtbSoft.BLL;
using ZtbSoft.Components;
using System;
using System.Collections;
using System.Data;
using System.Web;
using System.Web.SessionState;

namespace ZtbSoft.Web.ajax.Special
{
    /// <summary>
    /// GetIndexTop 的摘要说明
    /// </summary>
    public class GetIndexTop : IHttpHandler, IRequiresSessionState
    {
        private DataTable dtPower = null;   //当前用户权限

        public void ProcessRequest(HttpContext context)
        {
            //判断是否登录
            string loginStr = new loginBLL().isLogin(context, out dtPower);
            if (!string.IsNullOrWhiteSpace(loginStr))
            {
                context.Response.Clear();
                context.Response.Write(loginStr);
                return;
            }

            Hashtable result = new Hashtable();
            result["RoleName"] = new SessionCommon().GetRoleName(context);
            result["EmployeeName"] = new SessionCommon().GetEmployeeName(context);
            String json = JsonHelper.Encode(result);
            context.Response.Clear();
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