using ZtbSoft.BLL;
using System;
using System.Collections;
using System.Data;
using System.Web;
using System.Web.SessionState;

namespace ZtbSoft.Web.ajax
{
    /// <summary>
    /// menuAjax 的摘要说明
    /// </summary>
    public class menuAjax : IHttpHandler, IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {

            try
            {
                DataTable dtPower;
                //判断是否登录
                string loginStr = new loginBLL().isLogin(context, out dtPower);
                if (!string.IsNullOrWhiteSpace(loginStr))
                {
                    context.Response.Clear();
                    context.Response.Write(loginStr);
                    return;
                }

                int roleid = new ZtbSoft.Components.SessionCommon().GetRoleId(context);
                ArrayList list = new ZtbSoft.BLL.RolePowerBLL().GetMenu(roleid);
                String json = JsonHelper.Encode(list);
                context.Response.Clear();
                context.Response.Write(json);

            }
            catch (Exception ex)
            {
                Hashtable result = new Hashtable();
                result["error"] = -1;
                result["message"] = ex.Message;
                result["stackTrace"] = ex.StackTrace;
                String json = JsonHelper.Encode(result);
                context.Response.Clear();
                context.Response.Write(json);
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