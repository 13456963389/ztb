using System;
using System.Collections;
using System.Data;
using System.Reflection;
using System.Web;
using System.Web.SessionState;
using ZTB.Special.BLL;
using ZtbSoft.BLL;
using ZtbSoft.Components;

namespace ZtbSoft.ProjectInfo.ajax
{
    /// <summary>
    /// Zbwj 的摘要说明
    /// </summary>
    public class ZbggAjax : IHttpHandler, IRequiresSessionState
    {
        private DataTable dtPower = null;   //当前用户权限
        private string powerCode = enum_PowerObjectCode.Zbgg.ToString();
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
        }

        public void GetList(HttpContext context)
        {
            //判断查看权限
            string powerStr = PowerHelper.isView(powerCode, dtPower);
            if (!string.IsNullOrWhiteSpace(powerStr))
            {
                context.Response.Clear();
                context.Response.ContentType = "text/plain";
                context.Response.Write(powerStr);
                return;
            }

            
            Hashtable result = new Hashtable();
            string noticeType = enum_NoticeType.Zbgg.ToString();
            if (context.Request["pid"] != null)
            {
                string projectId = context.Request["pid"];
                result["data"] = new SNoticeInfoBLL().GetNoticeListByProjectInfoId(projectId, noticeType);
            }
            //JSON
            String json = JsonHelper.Encode(result);
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