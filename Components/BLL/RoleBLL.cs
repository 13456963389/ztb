using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Collections;
using ZtbSoft.DAL;
using ZtbSoft.Models;

namespace ZtbSoft.BLL
{

    public partial class RoleBLL
    {
        /// <summary>
        /// 新增
        /// </summary>
        public int Insert(string json)
        {
            Role role = JsonHelper.JsonToObject<Role>(json);
            return new RoleDAL().INSERT(role);
        }
        
        /// <summary>
        /// 删除
        /// </summary>
        public int DeleteByRoleId(int roleId)
        {
            return new RoleDAL().DeleteByRoleId(roleId);
        }
        
        /// <summary>
        /// 修改
        /// </summary>
		public int Update(string json)
        {
            Role role = JsonHelper.JsonToObject<Role>(json);
            return new RoleDAL().Update_V(role);
        }
        /// <summary>
        /// 修改
        /// </summary>
		public int Update_V(Role role)
        {
            return new RoleDAL().Update_V(role);
        }
        
        
        /// <summary>
        /// 得到实体
        /// </summary>
        public Role GetByRoleId(int roleId)
        {
            return new RoleDAL().GetByRoleId(roleId);
        }
        /// <summary>
        /// 得到所有
        /// </summary>
        /// <param name="whe">条件</param>
        /// <returns></returns>
        public ArrayList GetAll(string whe)
        {
            DataTable dt = new RoleDAL().GetAll("*", whe, "");
            return JsonHelper.DataTableToArrayList(dt);
        }
		
        /// <summary>
        /// 分页查询
        /// </summary>
        /// <param name="sel_col">查询列</param>
        /// <param name="sel_whe">条件</param>
        /// <param name="sel_ord">排序</param>
        /// <param name="page_size">页大小</param>
        /// <param name="page">页码</param>
        /// <returns></returns>
        public ArrayList GetPage(string sel_col, string sel_whe, string sel_ord, int page_size, int page, out int count)
        {
            count = new RoleDAL().GetCount(sel_whe);
            DataTable dt = new RoleDAL().GetPage(sel_col, sel_whe, sel_ord, page_size, page);
            return JsonHelper.DataTableToArrayList(dt);
        }
        
    }
}