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
	public partial class ExpertExtractDAL
	{
		/// <summary>
        /// 添加
        /// </summary>
        public int INSERT(ExpertExtract expertExtract)
		{	
			SqlParameter[] paras = new SqlParameter[]
				{
					new SqlParameter("@ExpertId", ToDBValue(expertExtract.ExpertId)),
					new SqlParameter("@ProjectId", ToDBValue(expertExtract.ProjectId)),
					new SqlParameter("@TradeCode", ToDBValue(expertExtract.TradeCode)),
					new SqlParameter("@IsSupplement", ToDBValue(expertExtract.IsSupplement)),
					new SqlParameter("@ExtractDate", ToDBValue(expertExtract.ExtractDate)),
					new SqlParameter("@EmployeeId", ToDBValue(expertExtract.EmployeeId)),
				};
             
			 return Convert.ToInt32(SqlHelper.ExecuteScalar(CommandType.StoredProcedure, "UP_ExpertExtract_INSERT", paras));
		}
        /// <summary>
        /// 添加
        /// </summary>
        public int INSERT_V(ExpertExtract expertExtract)
		{	
			string sql =@"INSERT INTO ExpertExtract (ExpertId,
						ProjectId,
						TradeCode,
						IsSupplement,
						ExtractDate,
						EmployeeId
						) VALUES (
						@ExpertId,
						@ProjectId,
						@TradeCode,
						@IsSupplement,
						@ExtractDate,
						@EmployeeId
						) select SCOPE_IDENTITY()";
			SqlParameter[] para = new SqlParameter[]
				{
					new SqlParameter("@ExpertId", ToDBValue(expertExtract.ExpertId)),
					new SqlParameter("@ProjectId", ToDBValue(expertExtract.ProjectId)),
					new SqlParameter("@TradeCode", ToDBValue(expertExtract.TradeCode)),
					new SqlParameter("@IsSupplement", ToDBValue(expertExtract.IsSupplement)),
					new SqlParameter("@ExtractDate", ToDBValue(expertExtract.ExtractDate)),
					new SqlParameter("@EmployeeId", ToDBValue(expertExtract.EmployeeId)),
				};
				
			int newId = Convert.ToInt32(SqlHelper.ExecuteScalar(sql, para));
			return newId;
		}

		/// <summary>
        /// 删除
        /// </summary>
        public int DeleteByExtractId(int extractId)
		{
           SqlParameter[] paras = new SqlParameter[]
			{
				new SqlParameter("@ExtractId", extractId)
			};
		
           return SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "UP_ExpertExtract_DELETE", paras);
		}
		
				
		/// <summary>
        /// 修改
        /// </summary>
        public int Update(ExpertExtract expertExtract)
        {
           SqlParameter[] paras = new SqlParameter[]
			{
				new SqlParameter("@ExtractId", expertExtract.ExtractId)
					,new SqlParameter("@ExpertId", ToDBValue(expertExtract.ExpertId))
					,new SqlParameter("@ProjectId", ToDBValue(expertExtract.ProjectId))
					,new SqlParameter("@TradeCode", ToDBValue(expertExtract.TradeCode))
					,new SqlParameter("@IsSupplement", ToDBValue(expertExtract.IsSupplement))
					,new SqlParameter("@ExtractDate", ToDBValue(expertExtract.ExtractDate))
					,new SqlParameter("@EmployeeId", ToDBValue(expertExtract.EmployeeId))
			};

			  return SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "UP_ExpertExtract_UPDATE", paras);
        }
        /// <summary>
        /// 修改
        /// </summary>
		public int Update_V(ExpertExtract expertExtract){
            string sql = "UPDATE ExpertExtract  SET ";
            
            string strSet=string.Empty;
            
            if(expertExtract.ExpertId != null)
                strSet+="ExpertId = @ExpertId," ;
                    
            if(expertExtract.ProjectId != null)
                strSet+="ProjectId = @ProjectId," ;
                    
            if(expertExtract.TradeCode != null)
                strSet+="TradeCode = @TradeCode," ;
                    
            if(expertExtract.IsSupplement != null)
                strSet+="IsSupplement = @IsSupplement," ;
                    
            if(expertExtract.ExtractDate != null)
                strSet+="ExtractDate = @ExtractDate," ;
                    
            if(expertExtract.EmployeeId != null)
                strSet+="EmployeeId = @EmployeeId," ;
                    
            strSet = strSet.TrimEnd(',');
               
            sql=sql+ strSet+" WHERE ExtractId = @ExtractId";


			SqlParameter[] para = new SqlParameter[]
			{
				new SqlParameter("@ExtractId", expertExtract.ExtractId)
					,new SqlParameter("@ExpertId", ToDBValue(expertExtract.ExpertId))
					,new SqlParameter("@ProjectId", ToDBValue(expertExtract.ProjectId))
					,new SqlParameter("@TradeCode", ToDBValue(expertExtract.TradeCode))
					,new SqlParameter("@IsSupplement", ToDBValue(expertExtract.IsSupplement))
					,new SqlParameter("@ExtractDate", ToDBValue(expertExtract.ExtractDate))
					,new SqlParameter("@EmployeeId", ToDBValue(expertExtract.EmployeeId))
			};

			return SqlHelper.ExecuteNonQuery(sql, para);
        }
		/// <summary>
        /// 通过主键 ExtractId  得到实体
        /// </summary>
        public ExpertExtract GetByExtractId(int extractId)
        {
            string sql = "ExtractId = "+extractId;
            
            DataTable dt = GetAll("*",sql,"");
            if (dt.Rows.Count > 0)
                return new ExpertExtract(dt.Rows[0]);
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
            string table = "ExpertExtract";
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
            string table = "ExpertExtract";
            if (string.IsNullOrWhiteSpace(sel_ord))
            {
                sel_ord = " ExtractId desc";
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

            string table = "ExpertExtract";
            if (string.IsNullOrWhiteSpace(sel_ord))
            {
                sel_ord = " ExtractId desc";
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
            string table = "ExpertExtract";
            if (string.IsNullOrWhiteSpace(sel_ord))
            {
                sel_ord = "  ExtractId desc";
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
