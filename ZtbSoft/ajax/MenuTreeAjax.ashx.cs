using System;
using System.Collections;
using System.Reflection;
using System.Web;
using System.Web.SessionState;
using ZTB.Special.BLL;

namespace ZtbSoft.ajax
{
    /// <summary>
    /// MenuTreeAjax 的摘要说明
    /// </summary>
    public class MenuTreeAjax : IHttpHandler, IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            try
            {
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
        }

        /// <summary>
        /// 获取树节点
        /// </summary>
        /// <param name="context"></param>
        public void GetList(HttpContext context)
        {
            string treeType = context.Request["treeType"];
            string pid = context.Request["pid"] ?? "0";
            Hashtable result = new Hashtable();
                        
            string json = JsonHelper.Encode(new MenuTreeBLL().GetList(treeType, pid));
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