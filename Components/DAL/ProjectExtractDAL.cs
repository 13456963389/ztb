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
	public partial class ProjectExtractDAL
	{
		/// <summary>
        /// 添加
        /// </summary>
        public int INSERT(ProjectExtract projectExtract)
		{	
			SqlParameter[] paras = new SqlParameter[]
				{
					new SqlParameter("@ExtractTime", ToDBValue(projectExtract.ExtractTime)),
					new SqlParameter("@EmployeeId", ToDBValue(projectExtract.EmployeeId)),
					new SqlParameter("@YExtractCount", ToDBValue(projectExtract.YExtractCount)),
					new SqlParameter("@BExtractCount", ToDBValue(projectExtract.BExtractCount)),
				};
             
			 return Convert.ToInt32(SqlHelper.ExecuteScalar(CommandType.StoredProcedure, "UP_ProjectExtract_INSERT", paras));
		}
        /// <summary>
        /// 添加
        /// </summary>
        public int INSERT_V(ProjectExtract projectExtract)
		{	
			string sql =@"INSERT INTO ProjectExtract (ExtractTime,
						EmployeeId,
						YExtractCount,
						BExtractCount
						) VALUES (
						@ExtractTime,
						@EmployeeId,
						@YExtractCount,
						@BExtractCount
						) select SCOPE_IDENTITY()";
			SqlParameter[] para = new SqlParameter[]
				{
					new SqlParameter("@ExtractTime", ToDBValue(projectExtract.ExtractTime)),
					new SqlParameter("@EmployeeId", ToDBValue(projectExtract.EmployeeId)),
					new SqlParameter("@YExtractCount", ToDBValue(projectExtract.YExtractCount)),
					new SqlParameter("@BExtractCount", ToDBValue(projectExtract.BExtractCount)),
				};
				
			int newId = Convert.ToInt32(SqlHelper.ExecuteScalar(sql, para));
			return newId;
		}

		/// <summary>
        /// 删除
        /// </summary>
        public int DeleteByPEId(int pEId)
		{
           SqlParameter[] paras = new SqlParameter[]
			{
				new SqlParameter("@PEId", pEId)
			};
		
           return SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "UP_ProjectExtract_DELETE", paras);
		}
		
				
		/// <summary>
        /// 修改
        /// </summary>
        public int Update(ProjectExtract projectExtract)
        {
           SqlParameter[] paras = new SqlParameter[]
			{
				new SqlParameter("@PEId", projectExtract.PEId)
					,new SqlParameter("@ExtractTime", ToDBValue(projectExtract.ExtractTime))
					,new SqlParameter("@EmployeeId", ToDBValue(projectExtract.EmployeeId))
					,new SqlParameter("@YExtractCount", ToDBValue(projectExtract.YExtractCount))
					,new SqlParameter("@BExtractCount", ToDBValue(projectExtract.BExtractCount))
			};

			  return SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "UP_ProjectExtract_UPDATE", paras);
        }
        /// <summary>
        /// 修改
        /// </summary>
		public int Update_V(ProjectExtract projectExtract){
            string sql = "UPDATE ProjectExtract  SET ";
            
            string strSet=string.Empty;
            
            if(projectExtract.ExtractTime != null)
                strSet+="ExtractTime = @ExtractTime," ;
                    
            if(projectExtract.EmployeeId != null)
                strSet+="EmployeeId = @EmployeeId," ;
                    
            if(projectExtract.YExtractCount != null)
                strSet+="YExtractCount = @YExtractCount," ;
                    
            if(projectExtract.BExtractCount != null)
                strSet+="BExtractCount = @BExtractCount," ;
                    
            strSet = strSet.TrimEnd(',');
               
            sql=sql+ strSet+" WHERE PEId = @PEId";


			SqlParameter[] para = new SqlParameter[]
			{
				new SqlParameter("@PEId", projectExtract.PEId)
					,new SqlParameter("@ExtractTime", ToDBValue(projectExtract.ExtractTime))
					,new SqlParameter("@EmployeeId", ToDBValue(projectExtract.EmployeeId))
					,new SqlParameter("@YExtractCount", ToDBValue(projectExtract.YExtractCount))
					,new SqlParameter("@BExtractCount", ToDBValue(projectExtract.BExtractCount))
			};

			return SqlHelper.ExecuteNonQuery(sql, para);
        }
		/// <summary>
        /// 通过主键 PEId  得到实体
        /// </summary>
        public ProjectExtract GetByPEId(int pEId)
        {
            string sql = "PEId = "+pEId;
            
            DataTable dt = GetAll("*",sql,"");
            if (dt.Rows.Count > 0)
                return new ProjectExtract(dt.Rows[0]);
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
            string table = "ProjectExtract";
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
            string table = "ProjectExtract";
            if (string.IsNullOrWhiteSpace(sel_ord))
            {
                sel_ord = " PEId desc";
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

            string table = "ProjectExtract";
            if (string.IsNullOrWhiteSpace(sel_ord))
            {
                sel_ord = " PEId desc";
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
            string table = "ProjectExtract";
            if (string.IsNullOrWhiteSpace(sel_ord))
            {
                sel_ord = "  PEId desc";
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
