using System;
using System.Collections;
using System.Data;
using System.Reflection;
using System.Web;
using System.Web.SessionState;
using ZtbSoft.BLL;
using ZtbSoft.Components;

namespace ZtbSoft.ProjectInfo.ajax
{
    /// <summary>
    /// Zbwj 的摘要说明
    /// </summary>
    public class TbwjAjax : IHttpHandler, IRequiresSessionState
    {
        private DataTable dtPower = null;   //当前用户权限
        private string powerCode = enum_PowerObjectCode.Tbwj.ToString();
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

            //分页
            int pageIndex = Convert.ToInt32(context.Request["pageIndex"]);
            int pageSize = Convert.ToInt32(context.Request["pageSize"]);
            //字段排序
            String sortField = context.Request["sortField"];
            String sortOrder = context.Request["sortOrder"];

            //查询字段
            string ProjectCode = context.Request["ProjectCode"];
            string ProjectName = context.Request["ProjectName"];

            int count = 0;

            string sel_col = "*";
            string sel_whe = " and NoticeType=" + enum_NoticeType.Zbgg.ToString();
            string ord = "";

            if (!String.IsNullOrWhiteSpace(sortField))
            {
                if (sortOrder != "desc") sortOrder = "asc";
                ord += " " + sortField + " " + sortOrder;
            }
            //查询条件
            if (!string.IsNullOrWhiteSpace(ProjectCode))
            { sel_whe += " and ProjectCode = '" + ProjectCode + "'"; }
            if (!string.IsNullOrWhiteSpace(ProjectName))
            { sel_whe += " and ProjectName like '%" + ProjectName + "%'"; }


            if (!string.IsNullOrWhiteSpace(sel_whe))
                sel_whe = sel_whe.Substring(4);

            Hashtable result = new Hashtable();

            result["data"] = new ProjectInfoBLL().GetPage(sel_col, sel_whe, ord, pageSize, pageIndex, out count);
            result["total"] = count;

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