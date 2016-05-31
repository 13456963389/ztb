//============================================================
//author:于永博
//============================================================

using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using ZtbSoft.Models;

namespace ZtbSoft.DAL
{
    public partial class RolePowerDAL
    {
        /// <summary>
        /// 添加
        /// </summary>
        public int INSERT(RolePower rolePower)
        {
            SqlParameter[] paras = new SqlParameter[]
				{
					new SqlParameter("@RoleId", ToDBValue(rolePower.RoleId)),
					new SqlParameter("@PowerId", ToDBValue(rolePower.PowerId)),
					new SqlParameter("@PowerDetail", ToDBValue(rolePower.PowerDetail)),
				};

            return Convert.ToInt32(SqlHelper.ExecuteScalar(CommandType.StoredProcedure, "UP_RolePower_INSERT", paras));
        }
        /// <summary>
        /// 添加
        /// </summary>
        public int INSERT_V(RolePower rolePower)
        {
            string sql = @"INSERT INTO RolePower (RoleId,
						PowerId,
						PowerDetail
						) VALUES (
						@RoleId,
						@PowerId,
						@PowerDetail
						) select SCOPE_IDENTITY()";
            SqlParameter[] para = new SqlParameter[]
				{
					new SqlParameter("@RoleId", ToDBValue(rolePower.RoleId)),
					new SqlParameter("@PowerId", ToDBValue(rolePower.PowerId)),
					new SqlParameter("@PowerDetail", ToDBValue(rolePower.PowerDetail)),
				};

            int newId = Convert.ToInt32(SqlHelper.ExecuteScalar(sql, para));
            return newId;
        }

        /// <summary>
        /// 删除
        /// </summary>
        public int DeleteByRolePowerId(int rolePowerId)
        {
            SqlParameter[] paras = new SqlParameter[]
			{
				new SqlParameter("@RolePowerId", rolePowerId)
			};

            return SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "UP_RolePower_DELETE", paras);
        }
        /// <summary>
        /// 通过角色ID 删除权限
        /// </summary>
        /// <param name="roleId"></param>
        /// <returns></returns>
        public int DeleteByRoleId(int roleId)
        {
            string sql = "DELETE FROM [RolePower] WHERE RoleId=@RoleId";
            SqlParameter[] paras = new SqlParameter[]
			{
				new SqlParameter("@RoleId", roleId)
			};
            return SqlHelper.ExecuteNonQuery(sql, paras);
        }

        /// <summary>
        /// 修改
        /// </summary>
        public int Update(RolePower rolePower)
        {
            SqlParameter[] paras = new SqlParameter[]
			{
				new SqlParameter("@RolePowerId", rolePower.RolePowerId)
					,new SqlParameter("@RoleId", ToDBValue(rolePower.RoleId))
					,new SqlParameter("@PowerId", ToDBValue(rolePower.PowerId))
					,new SqlParameter("@PowerDetail", ToDBValue(rolePower.PowerDetail))
			};

            return SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "UP_RolePower_UPDATE", paras);
        }
        /// <summary>
        /// 修改
        /// </summary>
        public int Update_V(RolePower rolePower)
        {
            string sql = "UPDATE RolePower  SET ";

            string strSet = string.Empty;

            if (rolePower.RoleId != null)
                strSet += "RoleId = @RoleId,";

            if (rolePower.PowerId != null)
                strSet += "PowerId = @PowerId,";

            if (rolePower.PowerDetail != null)
                strSet += "PowerDetail = @PowerDetail,";

            strSet = strSet.TrimEnd(',');

            sql = sql + strSet + " WHERE RolePowerId = @RolePowerId";


            SqlParameter[] para = new SqlParameter[]
			{
				new SqlParameter("@RolePowerId", rolePower.RolePowerId)
					,new SqlParameter("@RoleId", ToDBValue(rolePower.RoleId))
					,new SqlParameter("@PowerId", ToDBValue(rolePower.PowerId))
					,new SqlParameter("@PowerDetail", ToDBValue(rolePower.PowerDetail))
			};

            return SqlHelper.ExecuteNonQuery(sql, para);
        }

        public int Update_Detail(int roleId, int powerId, string detail)
        {
            string sql = @"UPDATE RolePower  SET
                        PowerDetail = @PowerDetail
                        where RoleId = @RoleId and PowerId = @PowerId";

            SqlParameter[] para = new SqlParameter[]
			{		new SqlParameter("@RoleId", roleId)
					,new SqlParameter("@PowerId", powerId)
					,new SqlParameter("@PowerDetail", detail)
			};

            return SqlHelper.ExecuteNonQuery(sql, para);
        }

        /// <summary>
        /// 通过主键 RolePowerId  得到实体
        /// </summary>
        public RolePower GetByRolePowerId(int rolePowerId)
        {
            string sql = "RolePowerId = " + rolePowerId;

            DataTable dt = GetAll("*", sql, "");
            if (dt.Rows.Count > 0)
                return new RolePower(dt.Rows[0]);
            else
                return null;

        }

        // <summary>
        /// 根据条件得到总数
        /// </summary>
        /// <param name="whe"></param>
        /// <returns></returns>
        public int GetCount(string whe)
        {
            string table = "RolePower";
            SqlParameter[] paras = {
                     new SqlParameter("@TABLE",table),
                    new SqlParameter("@SEL_WHR",whe)
                };
            return Convert.ToInt32(SqlHelper.ExecuteScalar(CommandType.StoredProcedure, "UP_SELECT_COUNT", paras));
        }
        /// <summary>
        /// 得到所有
        /// </summary>
        /// <param name="whe"></param>
        /// <returns></returns>
        public DataTable GetAll(string sel_col, string sel_whe, string sel_ord)
        {
            string table = "RolePower";
            if (string.IsNullOrWhiteSpace(sel_ord))
            {
                sel_ord = " RolePowerId desc";
            }
            SqlParameter[] paras = {
                    new SqlParameter("@TABLE",table),
                    new SqlParameter("@SEL_COL",sel_col),
                    new SqlParameter("@SEL_WHR",sel_whe),
                    new SqlParameter("@ORD",sel_ord),
            };

            return SqlHelper.ExecuteDataTable(CommandType.StoredProcedure, "UP_SELECT_ALL", paras);
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
        public DataTable GetPage(string sel_col, string sel_whe, string sel_ord, int page_size, int page)
        {

            string table = "RolePower";
            if (string.IsNullOrWhiteSpace(sel_ord))
            {
                sel_ord = " RolePowerId desc";
            }
            SqlParameter[] paras = {
                    new SqlParameter("@TABLE",table),
                    new SqlParameter("@SEL_COL",sel_col),
                    new SqlParameter("@SEL_WHR",sel_whe),
                    new SqlParameter("@ORD",sel_ord),
                    new SqlParameter("@NUM_PER_PAGE",page_size),
                    new SqlParameter("@PGE_INDEX",page)
            };

            return SqlHelper.ExecuteDataTable(CommandType.StoredProcedure, "UP_SELECT_PAGE", paras);
        }

        /// <summary>
        /// 查询前几列
        /// </summary>
        /// <param name="top"></param>
        /// <param name="sel_col">查询列</param>
        /// <param name="sel_whe">条件</param>
        /// <param name="sel_ord">排序</param>
        /// <returns></returns>
        public DataTable GetTop(int top, string sel_col, string sel_whe, string sel_ord)
        {
            string table = "RolePower";
            if (string.IsNullOrWhiteSpace(sel_ord))
            {
                sel_ord = "  RolePowerId desc";
            }
            SqlParameter[] paras = {
                    new SqlParameter("@TABLE",table),
                    new SqlParameter("@SEL_COL",sel_col),
                    new SqlParameter("@SEL_WHR",sel_whe),
                    new SqlParameter("@ORD",sel_ord),
                    new SqlParameter("@TOP_NUM",top)
            };

            return SqlHelper.ExecuteDataTable(CommandType.StoredProcedure, "UP_SELECT_TOP", paras);
        }

        /// <summary>
        /// 得到菜单
        /// </summary>
        /// <param name="roleid"></param>
        /// <returns></returns>
        public DataTable GetMenu(int roleid)
        {
            string table = "vRolePower";

            string sel_ord = " Ord asc";

            SqlParameter[] paras = {
                    new SqlParameter("@TABLE",table),
                    new SqlParameter("@SEL_COL","[id],[pid],[name],[url],[img]"),
                    new SqlParameter("@SEL_WHR","roleid="+roleid+" and IsMenu=1"),
                    new SqlParameter("@ORD",sel_ord),
            };

            return SqlHelper.ExecuteDataTable(CommandType.StoredProcedure, "UP_SELECT_ALL", paras);

        }

        protected object ToDBValue(object value)
        {
            if (value == null)
            {
                return DBNull.Value;
            }
            else
            {
                return value;
            }
        }

        internal DataTable GetPowerTreeByRoleId(int roleId)
        {
            string sql = @"select id,ParentId,Name,Detail,RolePowerId,PowerDetail from PowerObject as o left join 
                            (select * from RolePower where RoleId=@RoleId) as r on o.Id=r.PowerId
                            order by Ord asc";
            SqlParameter[] paras = {
                    new SqlParameter("@RoleId",roleId)
            };

            return SqlHelper.ExecuteDataTable(sql, paras);
        }
    }
}