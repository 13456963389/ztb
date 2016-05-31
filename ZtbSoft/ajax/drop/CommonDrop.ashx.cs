using System;
using System.Collections;
using System.Web.SessionState;
using System.Reflection;
using System.Web;
using System.Data;
using ZtbSoft.BLL;

namespace ZtbSoft.ajax.drop
{
    /// <summary>
    /// CommonDrop 的摘要说明
    /// </summary>
    public class CommonDrop : IHttpHandler
    {
        private DataTable dtPower = null;   //当前用户权限
        public void ProcessRequest(HttpContext context)
        {
            try
            {
                //判断是否登录
                string loginStr = new loginBLL().isLogin(context, out dtPower);
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

        /// <summary>
        /// 根据文件类型获取文件列表
        /// </summary>
        /// <param name="context"></param>
        public void GetFileListByfType(HttpContext context)
        {
            string fType = context.Request["fType"];
            ArrayList data = new FileInfoBLL().GetAll("FileType=" + fType);
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