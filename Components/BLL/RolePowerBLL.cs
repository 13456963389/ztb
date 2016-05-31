using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Collections;
using ZtbSoft.DAL;
using ZtbSoft.Models;

namespace ZtbSoft.BLL
{

    public partial class RolePowerBLL
    {
        /// <summary>
        /// 新增
        /// </summary>
        public int Insert(string json)
        {
            RolePower rolePower = JsonHelper.JsonToObject<RolePower>(json);
            return new RolePowerDAL().INSERT(rolePower);
        }

        /// <summary>
        /// 删除
        /// </summary>
        public int DeleteByRolePowerId(int rolePowerId)
        {
            return new RolePowerDAL().DeleteByRolePowerId(rolePowerId);
        }

        /// <summary>
        /// 修改
        /// </summary>
        public int Update(string json)
        {
            RolePower rolePower = JsonHelper.JsonToObject<RolePower>(json);
            return new RolePowerDAL().Update_V(rolePower);
        }
        /// <summary>
        /// 修改
        /// </summary>
        public int Update_V(RolePower rolePower)
        {
            return new RolePowerDAL().Update_V(rolePower);
        }

        /// <summary>
        /// 修改权限详细
        /// </summary>
        /// <param name="roleId"></param>
        /// <param name="powerId"></param>
        /// <param name="detail"></param>
        /// <returns></returns>
        public int Update_Detail(int roleId, int powerId, string detail)
        {
            return new RolePowerDAL().Update_Detail(roleId, powerId, detail);
        }

        /// <summary>
        /// 得到菜单
        /// </summary>
        /// <param name="roleid"></param>
        /// <returns></returns>
        public ArrayList GetMenu(int roleid)
        {
            DataTable dt = new RolePowerDAL().GetMenu(roleid);
            return JsonHelper.DataTableToArrayList(dt);
        }

        /// <summary>
        /// 得到实体
        /// </summary>
        public RolePower GetByRolePowerId(int rolePowerId)
        {
            return new RolePowerDAL().GetByRolePowerId(rolePowerId);
        }
        /// <summary>
        /// 得到所有
        /// </summary>
        /// <param name="whe">条件</param>
        /// <returns></returns>
        public DataTable GetAll(string whe)
        {
            return new RolePowerDAL().GetAll("*", whe, "");
        }

        /// <summary>
        /// 得到当前角色,所有权限 为了分配权限
        /// </summary>
        /// <param name="roleId"></param>
        /// <returns></returns>
        public DataTable GetPowerTreeByRoleId(int roleId)
        {
            
            return new RolePowerDAL().GetPowerTreeByRoleId(roleId);

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
            count = new RolePowerDAL().GetCount(sel_whe);
            DataTable dt = new RolePowerDAL().GetPage(sel_col, sel_whe, sel_ord, page_size, page);
            return JsonHelper.DataTableToArrayList(dt);
        }


        public void DeleteByRoleId(int roleid)
        {
            new RolePowerDAL().DeleteByRoleId(roleid);
        }

        public int Insert(RolePower rolePower)
        {
            return new RolePowerDAL().INSERT(rolePower);
        }
    }
}