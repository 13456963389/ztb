using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace ZtbSoft.Components
{
    public class SessionCommon
    {
        #region 正式        
        /// <summary>
        /// 获取当前登录员工Id
        /// </summary>
        /// <returns></returns>
        public int GetEmployeeId(HttpContext context)
        {
            Hashtable hash = (Hashtable)context.Session["employee"];
            return Convert.ToInt32(hash["EmployeeId"]);

        }

        /// <summary>
        /// 获取当前登录员工Name
        /// </summary>
        /// <returns></returns>
        public string GetEmployeeName(HttpContext context)
        {
            Hashtable hash = (Hashtable)context.Session["employee"];
            return hash["EmployeeName"].ToString();

        }
        /// <summary>
        /// 得到当前角色ID
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public int GetRoleId(HttpContext context)
        {
            Hashtable hash = (Hashtable)context.Session["employee"];
            return Convert.ToInt32(hash["RoleId"]);
        }

        /// <summary>
        /// 得到当前角色名称
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public string GetRoleName(HttpContext context)
        {
            Hashtable hash = (Hashtable)context.Session["employee"];
            return hash["RoleName"].ToString();
        }
        #endregion
    }
}
