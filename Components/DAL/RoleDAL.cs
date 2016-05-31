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
	public partial class RoleDAL
	{
		/// <summary>
        /// 添加
        /// </summary>
        public int INSERT(Role role)
		{	
			SqlParameter[] paras = new SqlParameter[]
				{
					new SqlParameter("@RoleName", ToDBValue(role.RoleName)),
					new SqlParameter("@State", ToDBValue(role.State)),
					new SqlParameter("@Remark", ToDBValue(role.Remark)),
				};
             
			 return Convert.ToInt32(SqlHelper.ExecuteScalar(CommandType.StoredProcedure, "UP_Role_INSERT", paras));
		}
        /// <summary>
        /// 添加
        /// </summary>
        public int INSERT_V(Role role)
		{	
			string sql =@"INSERT INTO Role (RoleName,
						State,
						Remark
						) VALUES (
						@RoleName,
						@State,
						@Remark
						) select SCOPE_IDENTITY()";
			SqlParameter[] para = new SqlParameter[]
				{
					new SqlParameter("@RoleName", ToDBValue(role.RoleName)),
					new SqlParameter("@State", ToDBValue(role.State)),
					new SqlParameter("@Remark", ToDBValue(role.Remark)),
				};
				
			int newId = Convert.ToInt32(SqlHelper.ExecuteScalar(sql, para));
			return newId;
		}

		/// <summary>
        /// 删除
        /// </summary>
        public int DeleteByRoleId(int roleId)
		{
           SqlParameter[] paras = new SqlParameter[]
			{
				new SqlParameter("@RoleId", roleId)
			};
		
           return SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "UP_Role_DELETE", paras);
		}
		
				
		/// <summary>
        /// 修改
        /// </summary>
        public int Update(Role role)
        {
           SqlParameter[] paras = new SqlParameter[]
			{
				new SqlParameter("@RoleId", role.RoleId)
					,new SqlParameter("@RoleName", ToDBValue(role.RoleName))
					,new SqlParameter("@State", ToDBValue(role.State))
					,new SqlParameter("@Remark", ToDBValue(role.Remark))
			};

			  return SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "UP_Role_UPDATE", paras);
        }
        /// <summary>
        /// 修改
        /// </summary>
		public int Update_V(Role role){
            string sql = "UPDATE Role  SET ";
            
            string strSet=string.Empty;
            
            if(role.RoleName != null)
                strSet+="RoleName = @RoleName," ;
                    
            if(role.State != null)
                strSet+="State = @State," ;
                    
            if(role.Remark != null)
                strSet+="Remark = @Remark," ;
                    
            strSet = strSet.TrimEnd(',');
               
            sql=sql+ strSet+" WHERE RoleId = @RoleId";


			SqlParameter[] para = new SqlParameter[]
			{
				new SqlParameter("@RoleId", role.RoleId)
					,new SqlParameter("@RoleName", ToDBValue(role.RoleName))
					,new SqlParameter("@State", ToDBValue(role.State))
					,new SqlParameter("@Remark", ToDBValue(role.Remark))
			};

			return SqlHelper.ExecuteNonQuery(sql, para);
        }
		/// <summary>
        /// 通过主键 RoleId  得到实体
        /// </summary>
        public Role GetByRoleId(int roleId)
        {
            string sql = "RoleId = "+roleId;
            
            DataTable dt = GetAll("*",sql,"");
            if (dt.Rows.Count > 0)
                return new Role(dt.Rows[0]);
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
            string table = "Role";
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
            string table = "Role";
            if (string.IsNullOrWhiteSpace(sel_ord))
            {
                sel_ord = " RoleId desc";
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

            string table = "Role";
            if (string.IsNullOrWhiteSpace(sel_ord))
            {
                sel_ord = " RoleId desc";
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
            string table = "Role";
            if (string.IsNullOrWhiteSpace(sel_ord))
            {
                sel_ord = "  RoleId desc";
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
		
		protected object ToDBValue(object value)
		{
			if(value==null)
			{
				return DBNull.Value;
			}
			else
			{
				return value;
			}
		}
	}
}