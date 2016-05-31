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
	public partial class FirstResultDAL
	{
		/// <summary>
        /// 添加
        /// </summary>
        public int INSERT(FirstResult firstResult)
		{	
			SqlParameter[] paras = new SqlParameter[]
				{
					new SqlParameter("@ProjectId", ToDBValue(firstResult.ProjectId)),
					new SqlParameter("@SectionId", ToDBValue(firstResult.SectionId)),
					new SqlParameter("@UnitId", ToDBValue(firstResult.UnitId)),
					new SqlParameter("@ResultStatu", ToDBValue(firstResult.ResultStatu)),
					new SqlParameter("@ResultDate", ToDBValue(firstResult.ResultDate)),
					new SqlParameter("@CheckStatu", ToDBValue(firstResult.CheckStatu)),
					new SqlParameter("@EmployeeId", ToDBValue(firstResult.EmployeeId)),
					new SqlParameter("@CreateTime", ToDBValue(firstResult.CreateTime)),
					new SqlParameter("@YTrueStatu", ToDBValue(firstResult.YTrueStatu)),
					new SqlParameter("@TrueStaru", ToDBValue(firstResult.TrueStaru)),
				};
             
			 return Convert.ToInt32(SqlHelper.ExecuteScalar(CommandType.StoredProcedure, "UP_FirstResult_INSERT", paras));
		}
        /// <summary>
        /// 添加
        /// </summary>
        public int INSERT_V(FirstResult firstResult)
		{	
			string sql =@"INSERT INTO FirstResult (ProjectId,
						SectionId,
						UnitId,
						ResultStatu,
						ResultDate,
						CheckStatu,
						EmployeeId,
						CreateTime,
						YTrueStatu,
						TrueStaru
						) VALUES (
						@ProjectId,
						@SectionId,
						@UnitId,
						@ResultStatu,
						@ResultDate,
						@CheckStatu,
						@EmployeeId,
						@CreateTime,
						@YTrueStatu,
						@TrueStaru
						) select SCOPE_IDENTITY()";
			SqlParameter[] para = new SqlParameter[]
				{
					new SqlParameter("@ProjectId", ToDBValue(firstResult.ProjectId)),
					new SqlParameter("@SectionId", ToDBValue(firstResult.SectionId)),
					new SqlParameter("@UnitId", ToDBValue(firstResult.UnitId)),
					new SqlParameter("@ResultStatu", ToDBValue(firstResult.ResultStatu)),
					new SqlParameter("@ResultDate", ToDBValue(firstResult.ResultDate)),
					new SqlParameter("@CheckStatu", ToDBValue(firstResult.CheckStatu)),
					new SqlParameter("@EmployeeId", ToDBValue(firstResult.EmployeeId)),
					new SqlParameter("@CreateTime", ToDBValue(firstResult.CreateTime)),
					new SqlParameter("@YTrueStatu", ToDBValue(firstResult.YTrueStatu)),
					new SqlParameter("@TrueStaru", ToDBValue(firstResult.TrueStaru)),
				};
				
			int newId = Convert.ToInt32(SqlHelper.ExecuteScalar(sql, para));
			return newId;
		}

		/// <summary>
        /// 删除
        /// </summary>
        public int DeleteByFirstResultId(int firstResultId)
		{
           SqlParameter[] paras = new SqlParameter[]
			{
				new SqlParameter("@FirstResultId", firstResultId)
			};
		
           return SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "UP_FirstResult_DELETE", paras);
		}
		
				
		/// <summary>
        /// 修改
        /// </summary>
        public int Update(FirstResult firstResult)
        {
           SqlParameter[] paras = new SqlParameter[]
			{
				new SqlParameter("@FirstResultId", firstResult.FirstResultId)
					,new SqlParameter("@ProjectId", ToDBValue(firstResult.ProjectId))
					,new SqlParameter("@SectionId", ToDBValue(firstResult.SectionId))
					,new SqlParameter("@UnitId", ToDBValue(firstResult.UnitId))
					,new SqlParameter("@ResultStatu", ToDBValue(firstResult.ResultStatu))
					,new SqlParameter("@ResultDate", ToDBValue(firstResult.ResultDate))
					,new SqlParameter("@CheckStatu", ToDBValue(firstResult.CheckStatu))
					,new SqlParameter("@EmployeeId", ToDBValue(firstResult.EmployeeId))
					,new SqlParameter("@CreateTime", ToDBValue(firstResult.CreateTime))
					,new SqlParameter("@YTrueStatu", ToDBValue(firstResult.YTrueStatu))
					,new SqlParameter("@TrueStaru", ToDBValue(firstResult.TrueStaru))
			};

			  return SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "UP_FirstResult_UPDATE", paras);
        }
        /// <summary>
        /// 修改
        /// </summary>
		public int Update_V(FirstResult firstResult){
            string sql = "UPDATE FirstResult  SET ";
            
            string strSet=string.Empty;
            
            if(firstResult.ProjectId != null)
                strSet+="ProjectId = @ProjectId," ;
                    
            if(firstResult.SectionId != null)
                strSet+="SectionId = @SectionId," ;
                    
            if(firstResult.UnitId != null)
                strSet+="UnitId = @UnitId," ;
                    
            if(firstResult.ResultStatu != null)
                strSet+="ResultStatu = @ResultStatu," ;
                    
            if(firstResult.ResultDate != null)
                strSet+="ResultDate = @ResultDate," ;
                    
            if(firstResult.CheckStatu != null)
                strSet+="CheckStatu = @CheckStatu," ;
                    
            if(firstResult.EmployeeId != null)
                strSet+="EmployeeId = @EmployeeId," ;
                    
            if(firstResult.CreateTime != null)
                strSet+="CreateTime = @CreateTime," ;
                    
            if(firstResult.YTrueStatu != null)
                strSet+="YTrueStatu = @YTrueStatu," ;
                    
            if(firstResult.TrueStaru != null)
                strSet+="TrueStaru = @TrueStaru," ;
                    
            strSet = strSet.TrimEnd(',');
               
            sql=sql+ strSet+" WHERE FirstResultId = @FirstResultId";


			SqlParameter[] para = new SqlParameter[]
			{
				new SqlParameter("@FirstResultId", firstResult.FirstResultId)
					,new SqlParameter("@ProjectId", ToDBValue(firstResult.ProjectId))
					,new SqlParameter("@SectionId", ToDBValue(firstResult.SectionId))
					,new SqlParameter("@UnitId", ToDBValue(firstResult.UnitId))
					,new SqlParameter("@ResultStatu", ToDBValue(firstResult.ResultStatu))
					,new SqlParameter("@ResultDate", ToDBValue(firstResult.ResultDate))
					,new SqlParameter("@CheckStatu", ToDBValue(firstResult.CheckStatu))
					,new SqlParameter("@EmployeeId", ToDBValue(firstResult.EmployeeId))
					,new SqlParameter("@CreateTime", ToDBValue(firstResult.CreateTime))
					,new SqlParameter("@YTrueStatu", ToDBValue(firstResult.YTrueStatu))
					,new SqlParameter("@TrueStaru", ToDBValue(firstResult.TrueStaru))
			};

			return SqlHelper.ExecuteNonQuery(sql, para);
        }
		/// <summary>
        /// 通过主键 FirstResultId  得到实体
        /// </summary>
        public FirstResult GetByFirstResultId(int firstResultId)
        {
            string sql = "FirstResultId = "+firstResultId;
            
            DataTable dt = GetAll("*",sql,"");
            if (dt.Rows.Count > 0)
                return new FirstResult(dt.Rows[0]);
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
            string table = "FirstResult";
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
            string table = "FirstResult";
            if (string.IsNullOrWhiteSpace(sel_ord))
            {
                sel_ord = " FirstResultId desc";
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

            string table = "FirstResult";
            if (string.IsNullOrWhiteSpace(sel_ord))
            {
                sel_ord = " FirstResultId desc";
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
            string table = "FirstResult";
            if (string.IsNullOrWhiteSpace(sel_ord))
            {
                sel_ord = "  FirstResultId desc";
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
