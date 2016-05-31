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
	public partial class PowerDetailDAL
	{
		/// <summary>
        /// 添加
        /// </summary>
        public int INSERT(PowerDetail powerDetail)
		{	
			SqlParameter[] paras = new SqlParameter[]
				{
					new SqlParameter("@PowerDetailName", ToDBValue(powerDetail.PowerDetailName)),
					new SqlParameter("@PowerDetailCode", ToDBValue(powerDetail.PowerDetailCode)),
				};
             
			 return Convert.ToInt32(SqlHelper.ExecuteScalar(CommandType.StoredProcedure, "UP_PowerDetail_INSERT", paras));
		}
        /// <summary>
        /// 添加
        /// </summary>
        public int INSERT_V(PowerDetail powerDetail)
		{	
			string sql =@"INSERT INTO PowerDetail (PowerDetailName,
						PowerDetailCode
						) VALUES (
						@PowerDetailName,
						@PowerDetailCode
						) select SCOPE_IDENTITY()";
			SqlParameter[] para = new SqlParameter[]
				{
					new SqlParameter("@PowerDetailName", ToDBValue(powerDetail.PowerDetailName)),
					new SqlParameter("@PowerDetailCode", ToDBValue(powerDetail.PowerDetailCode)),
				};
				
			int newId = Convert.ToInt32(SqlHelper.ExecuteScalar(sql, para));
			return newId;
		}

		/// <summary>
        /// 删除
        /// </summary>
        public int DeleteByPowerDetailId(int powerDetailId)
		{
           SqlParameter[] paras = new SqlParameter[]
			{
				new SqlParameter("@PowerDetailId", powerDetailId)
			};
		
           return SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "UP_PowerDetail_DELETE", paras);
		}
		
				
		/// <summary>
        /// 修改
        /// </summary>
        public int Update(PowerDetail powerDetail)
        {
           SqlParameter[] paras = new SqlParameter[]
			{
				new SqlParameter("@PowerDetailId", powerDetail.PowerDetailId)
					,new SqlParameter("@PowerDetailName", ToDBValue(powerDetail.PowerDetailName))
					,new SqlParameter("@PowerDetailCode", ToDBValue(powerDetail.PowerDetailCode))
			};

			  return SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "UP_PowerDetail_UPDATE", paras);
        }
        /// <summary>
        /// 修改
        /// </summary>
		public int Update_V(PowerDetail powerDetail){
            string sql = "UPDATE PowerDetail  SET ";
            
            string strSet=string.Empty;
            
            if(powerDetail.PowerDetailName != null)
                strSet+="PowerDetailName = @PowerDetailName," ;
                    
            if(powerDetail.PowerDetailCode != null)
                strSet+="PowerDetailCode = @PowerDetailCode," ;
                    
            strSet = strSet.TrimEnd(',');
               
            sql=sql+ strSet+" WHERE PowerDetailId = @PowerDetailId";


			SqlParameter[] para = new SqlParameter[]
			{
				new SqlParameter("@PowerDetailId", powerDetail.PowerDetailId)
					,new SqlParameter("@PowerDetailName", ToDBValue(powerDetail.PowerDetailName))
					,new SqlParameter("@PowerDetailCode", ToDBValue(powerDetail.PowerDetailCode))
			};

			return SqlHelper.ExecuteNonQuery(sql, para);
        }
		/// <summary>
        /// 通过主键 PowerDetailId  得到实体
        /// </summary>
        public PowerDetail GetByPowerDetailId(int powerDetailId)
        {
            string sql = "PowerDetailId = "+powerDetailId;
            
            DataTable dt = GetAll("*",sql,"");
            if (dt.Rows.Count > 0)
                return new PowerDetail(dt.Rows[0]);
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
            string table = "PowerDetail";
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
            string table = "PowerDetail";
            if (string.IsNullOrWhiteSpace(sel_ord))
            {
                sel_ord = " PowerDetailId desc";
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

            string table = "PowerDetail";
            if (string.IsNullOrWhiteSpace(sel_ord))
            {
                sel_ord = " PowerDetailId desc";
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
            string table = "PowerDetail";
            if (string.IsNullOrWhiteSpace(sel_ord))
            {
                sel_ord = "  PowerDetailId desc";
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