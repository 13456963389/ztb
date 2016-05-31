using ZtbSoft.Components;
using ZtbSoft.DAL;
using ZtbSoft.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;

using System.Data.SqlClient;
namespace ZtbSoft.BLL
{
    public class loginBLL
    {

        /// <summary>
        /// 判断 返回用户
        /// </summary>
        /// <param name="point"></param>
        /// <param name="user"></param>
        /// <param name="pwd"></param>
        /// <param name="employee">员工 只有 EmployeeName,EmployeeUsername,PointId,RoleId</param>
        /// <returns></returns>
        public bool login(string user, string pwd, out Hashtable hash)
        {
            string sql = @"select a.EmployeeId,a.EmployeeName,a.EmployeeUsername,a.EmployeeUserpass,a.RoleId,a.State,
                           c.RoleName
                           from [Employee] as a
						   left join Role as c on a.RoleId=c.RoleId
                           where (a.EmployeeUsername=@EmployeeUsername or a.EmployeeCode=@EmployeeUsername OR a.EmployeeName=@EmployeeUsername)
                           and a.EmployeeUserpass=@EmployeeUserpass and a.State=@State";
            SqlParameter[] paras = {
                                    new SqlParameter("@EmployeeUsername",user),
                                    new SqlParameter("@EmployeeUserpass",pwd),
                                    new SqlParameter("@State",Convert.ToInt32(enum_EmployeeState.current))
                                   };
            DataTable dt = SqlHelper.ExecuteDataTable(sql, paras);

            if (dt != null && dt.Rows.Count == 1)
            {
                hash = (Hashtable)JsonHelper.DataTableToArrayList(dt)[0];

                return true;
            }
            else
            {
                hash = null;
                return false;
            }
        }

        /// <summary>
        /// 登出
        /// </summary>
        /// <param name="context"></param>
        public void logingOut(HttpContext context)
        {
            context.Session.Clear();
        }

        /// <summary>
        /// 得到具体权限
        /// </summary>
        /// <param name="roleid"></param>
        /// <returns></returns>
        public DataTable getPower(int roleid)
        {
            string sql = "select r.PowerDetail,Code from RolePower as r left join PowerObject as p on r.PowerId=p.Id where RoleId=" + roleid;
            return SqlHelper.ExecuteDataTable(sql);
        }

        public string isLogin(HttpContext context, out DataTable dtPower)
        {
            dtPower = null;
            if (getSession(context, out dtPower))
            {
                return string.Empty;
            }
            else
            {
                Hashtable result = new Hashtable();
                result["error"] = -2;
                result["message"] = "登录超时";
                return JsonHelper.Encode(result);
            }
        }

        /// <summary>
        /// 判断是否登录 并返回 当前用户和用户权限
        /// </summary>
        /// <param name="context"></param>
        /// <param name="employee"></param>
        /// <param name="dtPower"></param>
        /// <returns></returns>
        private bool getSession(HttpContext context, out DataTable dtPower)
        {
            dtPower = null;

            try
            {
                if (context.Session["employee"] == null)
                {
                    return false;
                }
                if (context.Session["power"] != null)
                    dtPower = (DataTable)context.Session["power"];
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
            //return true;
        }
    }
}
