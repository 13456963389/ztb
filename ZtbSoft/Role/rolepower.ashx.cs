using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.SessionState;

namespace ZtbSoft.Web.ajax.New
{
    /// <summary>
    /// rolepower 的摘要说明
    /// </summary>
    public class rolepower : IHttpHandler, IRequiresSessionState
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
            finally
            {

            }
        }
        public void Save(HttpContext context)
        {
            int count = 0;
            String json = context.Request["data"];
            int roleid = Convert.ToInt32(context.Request["RoleId"]);


            //删除当前角色所有权限
            new ZtbSoft.BLL.RolePowerBLL().DeleteByRoleId(roleid);

            //循环详细
            ArrayList rows = (ArrayList)JsonHelper.Decode(json);
            foreach (Hashtable row in rows)
            {
                count += execRow(row, roleid);
            }

            context.Response.ContentType = "text/plain";
            context.Response.Write(count);
        }

        public void GetList(HttpContext context)
        {
            //int roleid = Convert.ToInt32(context.Request["roleid"]);

            //ArrayList list = new ZtbSoft.BLL.RolePowerBLL().GetAll("roleid=" + roleid);

            //string json = JsonHelper.Encode(list);

            //context.Response.ContentType = "text/plain";
            //context.Response.Write(json);
        }

        private int execRow(Hashtable row, int roleid)
        {
            int count = 0;
            int PowerObjectId = Convert.ToInt32(row["Id"]);
            if (row["children"] != null)
            {

                if (row["checked"] != null && row["checked"].ToString().ToLower() == "true")
                {
                    ZtbSoft.Models.RolePower rp = new Models.RolePower();
                    rp.PowerId = PowerObjectId;
                    rp.RoleId = roleid;
                    count += new ZtbSoft.BLL.RolePowerBLL().Insert(rp);
                }

                ArrayList list = (ArrayList)row["children"];
                foreach (Hashtable item in list)
                {
                    count += execRow(item, roleid);
                }
            }
            else
            {

                if (row["functions"] != null)
                {
                    string detail = string.Empty;
                    ArrayList list = (ArrayList)row["functions"];
                    foreach (Hashtable item in list)
                    {
                        if (Convert.ToBoolean(item["checked"]))
                        {
                            detail += item["PowerDetailCode"] + ",";
                        }
                    }
                    if (!string.IsNullOrWhiteSpace(detail))
                    {
                        detail = detail.TrimEnd(',');
                        ZtbSoft.Models.RolePower rp = new Models.RolePower();
                        rp.PowerDetail = detail;
                        rp.PowerId = PowerObjectId;
                        rp.RoleId = roleid;
                        count += new ZtbSoft.BLL.RolePowerBLL().Insert(rp);
                    }
                }
            }

            return count;
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