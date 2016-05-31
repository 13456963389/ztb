using ZtbSoft.BLL;
using ZtbSoft.Components;
using ZtbSoft.Models;
using System;
using System.Collections;
using System.Data;
using System.Reflection;
using System.Web;
using System.Web.SessionState;

namespace ZtbSoft.Web.ajax
{
    /// <summary>
    /// login 的摘要说明
    /// </summary>
    public class loginAjax : IHttpHandler, IRequiresSessionState
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

        public void Validate(HttpContext context)
        {
            try
            {
                string point = context.Request["point"];
                string username = context.Request["username"];
                string pwd = context.Request["pwd"];

                Hashtable result = new Hashtable();

                Hashtable hash = new Hashtable();
                if (new loginBLL().login(username, pwd, out hash))
                {
                    DataTable dtPower = new loginBLL().getPower((int)hash["RoleId"]);
                    context.Session["employee"] = hash;
                    context.Session["power"] = dtPower;
                    result["error"] = 0;
                }
                else
                {
                    result["error"] = 1;
                    result["message"] = "登录失败";
                }
                String json = JsonHelper.Encode(result);
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
        public void UpdatePassword(HttpContext context)
        {

            string oldpass = context.Request["oldpass"];
            string newpass = context.Request["newpass"];

            int EmployeeId = new SessionCommon().GetEmployeeId(context);

            Employee model = new EmployeeBLL().GetByEmployeeId(EmployeeId);
            if (model.EmployeeUserpass == oldpass)
            {
                Employee UpdateModel = new Employee();
                UpdateModel.EmployeeId = EmployeeId;
                UpdateModel.EmployeeUserpass = newpass;
                int count = new EmployeeBLL().Update_V(UpdateModel);
                if (count == 1)
                {
                    context.Response.Clear();
                    context.Response.Write("修改成功");

                }

            }
            else
            {
                context.Response.Clear();
                context.Response.Write("旧密码不正确");
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