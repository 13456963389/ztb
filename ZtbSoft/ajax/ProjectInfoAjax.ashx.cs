using System;
using System.Data;
using System.Web;
using System.Collections;
using System.Reflection;
using System.Web.SessionState;
using ZtbSoft.Components;
using ZtbSoft.BLL;
using ZtbSoft.Models;
using ZTB.Special.BLL;

namespace ZtbSoft.Web.Ajax
{
    /// <summary>
    /// ProjectInfo 项目基本信息
    /// </summary>
    public class ProjectInfoAjax : IHttpHandler, IRequiresSessionState
    {

        private DataTable dtPower = null;   //当前用户权限
        private string powerCode = enum_PowerObjectCode.ProjectInfo.ToString();
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
            string ProjectType = context.Request["ProjectType"];
            string TradeCode = context.Request["TradeCode"];
            string TendereeId = context.Request["TendereeId"];
            string AgencyId = context.Request["AgencyId"];
            string CheckStatu = context.Request["CheckStatu"];


            int count = 0;

            string sel_col = "*";
            string sel_whe = "";
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
            if (!string.IsNullOrWhiteSpace(ProjectType))
            { sel_whe += " and ProjectType = '" + ProjectType + "'"; }
            if (!string.IsNullOrWhiteSpace(TradeCode))
            { sel_whe += " and TradeCode = '" + TradeCode + "'"; }
            if (!string.IsNullOrWhiteSpace(TendereeId))
            { sel_whe += " and TendereeId = '" + TendereeId + "'"; }
            if (!string.IsNullOrWhiteSpace(AgencyId))
            { sel_whe += " and AgencyId = '" + AgencyId + "'"; }
            if (!string.IsNullOrWhiteSpace(CheckStatu))
            { sel_whe += " and CheckStatu = '" + CheckStatu + "'"; }


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
        public void Save(HttpContext context)
        {
            int count = 0;
            String json = context.Request["data"];
            string secJson = context.Request["secs"];

            ArrayList rows = (ArrayList)JsonHelper.Decode(json);

            foreach (Hashtable row in rows)
            {

                String id = row["ProjectId"] != null ? row["ProjectId"].ToString() : "";
                //根据记录状态，进行不同的增加、删除、修改操作
                String state = row["_state"] != null ? row["_state"].ToString() : "";
                //根据记录状态，进行不同的增加、修改操作

                if (state == "added" || id == "")           //新增：id为空，或_state为added
                {
                    //判断新增权限
                    string powerStr = PowerHelper.isAdd(powerCode, dtPower);
                    if (!string.IsNullOrWhiteSpace(powerStr))
                    {
                        context.Response.Clear();
                        context.Response.ContentType = "text/plain";
                        context.Response.Write(powerStr);
                        return;
                    }

                    row["ProjectId"] = -1;
                    row["CheckStatu"] = Convert.ToInt32(enum_ProjectStata.BZZ);
                    count += new ProjectInfoBLL().Insert(JsonHelper.Encode(row), new SessionCommon().GetEmployeeId(context));
                    new SSectionInfoBLL().AddSectionListForProjectInfoId(secJson, count, new SessionCommon().GetEmployeeId(context));
                }
                else if (state == "removed" || state == "deleted")  //删除
                {
                    //判断删除权限
                    string powerStr = PowerHelper.isDelete(powerCode, dtPower);
                    if (!string.IsNullOrWhiteSpace(powerStr))
                    {
                        context.Response.Clear();
                        context.Response.ContentType = "text/plain";
                        context.Response.Write(powerStr);
                        return;
                    }

                    count += new ProjectInfoBLL().DeleteByProjectId(Convert.ToInt32(id));
                    new SSectionInfoBLL().DeleteByProjectInfoId(Convert.ToInt32(id));
                }
                else if (state == "modified" || state == "") //更新：_state为空或modified
                {
                    //判断修改权限
                    string powerStr = PowerHelper.isEdit(powerCode, dtPower);
                    if (!string.IsNullOrWhiteSpace(powerStr))
                    {
                        context.Response.Clear();
                        context.Response.ContentType = "text/plain";
                        context.Response.Write(powerStr);
                        return;
                    }

                    count += new ProjectInfoBLL().Update(JsonHelper.Encode(row));
                    new SSectionInfoBLL().AddSectionListForProjectInfoId(secJson, Convert.ToInt32(id), new SessionCommon().GetEmployeeId(context));
                }
            }

            context.Response.ContentType = "text/plain";
            context.Response.Write(count);
        }

        /// <summary>
        /// 删除
        /// </summary>
        public void Remove(HttpContext context)
        {
            //判断删除权限
            string powerStr = PowerHelper.isDelete(powerCode, dtPower);
            if (!string.IsNullOrWhiteSpace(powerStr))
            {
                context.Response.Clear();
                context.Response.ContentType = "text/plain";
                context.Response.Write(powerStr);
                return;
            }

            String idStr = context.Request["id"];
            if (String.IsNullOrEmpty(idStr)) return;
            String[] ids = idStr.Split(',');
            for (int i = 0, l = ids.Length; i < l; i++)
            {
                string id = ids[i];
                new ProjectInfoBLL().DeleteByProjectId(Convert.ToInt32(id));
                new SSectionInfoBLL().DeleteByProjectInfoId(Convert.ToInt32(id));
            }
        }

        /// <summary>
        /// 获取实体
        /// </summary>
        public void GetModel(HttpContext context)
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

            string id = context.Request["id"];
            var projectInfo = new ProjectInfoBLL().GetByProjectId(Convert.ToInt32(id));
            String json = JsonHelper.Encode(projectInfo);
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