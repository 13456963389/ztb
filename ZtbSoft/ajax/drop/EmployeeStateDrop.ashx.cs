using System;
using System.Collections;
using System.Reflection;
using System.Web;
using ZtbSoft.BLL;
using System.Data;
using ZtbSoft.Components;
using System.Web.SessionState;

namespace ZtbSoft.WEB.ajax.drop
{
    /// <summary>
    /// EmployeeState 的摘要说明
    /// </summary>
    public class EmployeeStateDrop : IHttpHandler, IRequiresSessionState
    {
        
        private DataTable dtPower = null;   //当前用户权限

        public void ProcessRequest(HttpContext context)
        {
            try
            {
                //判断是否登录
                string loginStr = new loginBLL().isLogin(context,  out dtPower);
                if (!string.IsNullOrWhiteSpace(loginStr))
                {
                    context.Response.Clear();
                    context.Response.Write(loginStr);
                    return;
                }

                String methodName = context.Request["method"];
                Type type = this.GetType();
                MethodInfo method = type.GetMethod(methodName);
                if (method == null) throw new Exception("method is null");
                method.Invoke(this, new object[] { context });
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
            finally
            {

            }
        }

        public void GetList(HttpContext context)
        {

            ArrayList data = new clsEnmu().GetEnumObj(typeof(enum_EmployeeState));
            String json = JsonHelper.Encode(data);
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