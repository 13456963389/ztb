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
	public partial class CostManagementDAL
	{
		/// <summary>
        /// 添加
        /// </summary>
        public int INSERT(CostManagement costManagement)
		{	
			SqlParameter[] paras = new SqlParameter[]
				{
					new SqlParameter("@CostType", ToDBValue(costManagement.CostType)),
					new SqlParameter("@CostPrice", ToDBValue(costManagement.CostPrice)),
					new SqlParameter("@ComeEmployeeId", ToDBValue(costManagement.ComeEmployeeId)),
					new SqlParameter("@ProjectId", ToDBValue(costManagement.ProjectId)),
					new SqlParameter("@ComeTime", ToDBValue(costManagement.ComeTime)),
					new SqlParameter("@ComePrice", ToDBValue(costManagement.ComePrice)),
					new SqlParameter("@OutTime", ToDBValue(costManagement.OutTime)),
					new SqlParameter("@OutPrice", ToDBValue(costManagement.OutPrice)),
					new SqlParameter("@OutEmployeeId", ToDBValue(costManagement.OutEmployeeId)),
					new SqlParameter("@GoEmployeeId", ToDBValue(costManagement.GoEmployeeId)),
					new SqlParameter("@UnitId", ToDBValue(costManagement.UnitId)),
					new SqlParameter("@CheckStatu", ToDBValue(costManagement.CheckStatu)),
					new SqlParameter("@EmployeeId", ToDBValue(costManagement.EmployeeId)),
					new SqlParameter("@CreateTime", ToDBValue(costManagement.CreateTime)),
					new SqlParameter("@SectionId", ToDBValue(costManagement.SectionId)),
				};
             
			 return Convert.ToInt32(SqlHelper.ExecuteScalar(CommandType.StoredProcedure, "UP_CostManagement_INSERT", paras));
		}
        /// <summary>
        /// 添加
        /// </summary>
        public int INSERT_V(CostManagement costManagement)
		{	
			string sql =@"INSERT INTO CostManagement (CostType,
						CostPrice,
						ComeEmployeeId,
						ProjectId,
						ComeTime,
						ComePrice,
						OutTime,
						OutPrice,
						OutEmployeeId,
						GoEmployeeId,
						UnitId,
						CheckStatu,
						EmployeeId,
						CreateTime,
						SectionId
						) VALUES (
						@CostType,
						@CostPrice,
						@ComeEmployeeId,
						@ProjectId,
						@ComeTime,
						@ComePrice,
						@OutTime,
						@OutPrice,
						@OutEmployeeId,
						@GoEmployeeId,
						@UnitId,
						@CheckStatu,
						@EmployeeId,
						@CreateTime,
						@SectionId
						) select SCOPE_IDENTITY()";
			SqlParameter[] para = new SqlParameter[]
				{
					new SqlParameter("@CostType", ToDBValue(costManagement.CostType)),
					new SqlParameter("@CostPrice", ToDBValue(costManagement.CostPrice)),
					new SqlParameter("@ComeEmployeeId", ToDBValue(costManagement.ComeEmployeeId)),
					new SqlParameter("@ProjectId", ToDBValue(costManagement.ProjectId)),
					new SqlParameter("@ComeTime", ToDBValue(costManagement.ComeTime)),
					new SqlParameter("@ComePrice", ToDBValue(costManagement.ComePrice)),
					new SqlParameter("@OutTime", ToDBValue(costManagement.OutTime)),
					new SqlParameter("@OutPrice", ToDBValue(costManagement.OutPrice)),
					new SqlParameter("@OutEmployeeId", ToDBValue(costManagement.OutEmployeeId)),
					new SqlParameter("@GoEmployeeId", ToDBValue(costManagement.GoEmployeeId)),
					new SqlParameter("@UnitId", ToDBValue(costManagement.UnitId)),
					new SqlParameter("@CheckStatu", ToDBValue(costManagement.CheckStatu)),
					new SqlParameter("@EmployeeId", ToDBValue(costManagement.EmployeeId)),
					new SqlParameter("@CreateTime", ToDBValue(costManagement.CreateTime)),
					new SqlParameter("@SectionId", ToDBValue(costManagement.SectionId)),
				};
				
			int newId = Convert.ToInt32(SqlHelper.ExecuteScalar(sql, para));
			return newId;
		}

		/// <summary>
        /// 删除
        /// </summary>
        public int DeleteByCostId(int costId)
		{
           SqlParameter[] paras = new SqlParameter[]
			{
				new SqlParameter("@CostId", costId)
			};
		
           return SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "UP_CostManagement_DELETE", paras);
		}
		
				
		/// <summary>
        /// 修改
        /// </summary>
        public int Update(CostManagement costManagement)
        {
           SqlParameter[] paras = new SqlParameter[]
			{
				new SqlParameter("@CostId", costManagement.CostId)
					,new SqlParameter("@CostType", ToDBValue(costManagement.CostType))
					,new SqlParameter("@CostPrice", ToDBValue(costManagement.CostPrice))
					,new SqlParameter("@ComeEmployeeId", ToDBValue(costManagement.ComeEmployeeId))
					,new SqlParameter("@ProjectId", ToDBValue(costManagement.ProjectId))
					,new SqlParameter("@ComeTime", ToDBValue(costManagement.ComeTime))
					,new SqlParameter("@ComePrice", ToDBValue(costManagement.ComePrice))
					,new SqlParameter("@OutTime", ToDBValue(costManagement.OutTime))
					,new SqlParameter("@OutPrice", ToDBValue(costManagement.OutPrice))
					,new SqlParameter("@OutEmployeeId", ToDBValue(costManagement.OutEmployeeId))
					,new SqlParameter("@GoEmployeeId", ToDBValue(costManagement.GoEmployeeId))
					,new SqlParameter("@UnitId", ToDBValue(costManagement.UnitId))
					,new SqlParameter("@CheckStatu", ToDBValue(costManagement.CheckStatu))
					,new SqlParameter("@EmployeeId", ToDBValue(costManagement.EmployeeId))
					,new SqlParameter("@CreateTime", ToDBValue(costManagement.CreateTime))
					,new SqlParameter("@SectionId", ToDBValue(costManagement.SectionId))
			};

			  return SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "UP_CostManagement_UPDATE", paras);
        }
        /// <summary>
        /// 修改
        /// </summary>
		public int Update_V(CostManagement costManagement){
            string sql = "UPDATE CostManagement  SET ";
            
            string strSet=string.Empty;
            
            if(costManagement.CostType != null)
                strSet+="CostType = @CostType," ;
                    
            if(costManagement.CostPrice != null)
                strSet+="CostPrice = @CostPrice," ;
                    
            if(costManagement.ComeEmployeeId != null)
                strSet+="ComeEmployeeId = @ComeEmployeeId," ;
                    
            if(costManagement.ProjectId != null)
                strSet+="ProjectId = @ProjectId," ;
                    
            if(costManagement.ComeTime != null)
                strSet+="ComeTime = @ComeTime," ;
                    
            if(costManagement.ComePrice != null)
                strSet+="ComePrice = @ComePrice," ;
                    
            if(costManagement.OutTime != null)
                strSet+="OutTime = @OutTime," ;
                    
            if(costManagement.OutPrice != null)
                strSet+="OutPrice = @OutPrice," ;
                    
            if(costManagement.OutEmployeeId != null)
                strSet+="OutEmployeeId = @OutEmployeeId," ;
                    
            if(costManagement.GoEmployeeId != null)
                strSet+="GoEmployeeId = @GoEmployeeId," ;
                    
            if(costManagement.UnitId != null)
                strSet+="UnitId = @UnitId," ;
                    
            if(costManagement.CheckStatu != null)
                strSet+="CheckStatu = @CheckStatu," ;
                    
            if(costManagement.EmployeeId != null)
                strSet+="EmployeeId = @EmployeeId," ;
                    
            if(costManagement.CreateTime != null)
                strSet+="CreateTime = @CreateTime," ;
                    
            if(costManagement.SectionId != null)
                strSet+="SectionId = @SectionId," ;
                    
            strSet = strSet.TrimEnd(',');
               
            sql=sql+ strSet+" WHERE CostId = @CostId";


			SqlParameter[] para = new SqlParameter[]
			{
				new SqlParameter("@CostId", costManagement.CostId)
					,new SqlParameter("@CostType", ToDBValue(costManagement.CostType))
					,new SqlParameter("@CostPrice", ToDBValue(costManagement.CostPrice))
					,new SqlParameter("@ComeEmployeeId", ToDBValue(costManagement.ComeEmployeeId))
					,new SqlParameter("@ProjectId", ToDBValue(costManagement.ProjectId))
					,new SqlParameter("@ComeTime", ToDBValue(costManagement.ComeTime))
					,new SqlParameter("@ComePrice", ToDBValue(costManagement.ComePrice))
					,new SqlParameter("@OutTime", ToDBValue(costManagement.OutTime))
					,new SqlParameter("@OutPrice", ToDBValue(costManagement.OutPrice))
					,new SqlParameter("@OutEmployeeId", ToDBValue(costManagement.OutEmployeeId))
					,new SqlParameter("@GoEmployeeId", ToDBValue(costManagement.GoEmployeeId))
					,new SqlParameter("@UnitId", ToDBValue(costManagement.UnitId))
					,new SqlParameter("@CheckStatu", ToDBValue(costManagement.CheckStatu))
					,new SqlParameter("@EmployeeId", ToDBValue(costManagement.EmployeeId))
					,new SqlParameter("@CreateTime", ToDBValue(costManagement.CreateTime))
					,new SqlParameter("@SectionId", ToDBValue(costManagement.SectionId))
			};

			return SqlHelper.ExecuteNonQuery(sql, para);
        }
		/// <summary>
        /// 通过主键 CostId  得到实体
        /// </summary>
        public CostManagement GetByCostId(int costId)
        {
            string sql = "CostId = "+costId;
            
            DataTable dt = GetAll("*",sql,"");
            if (dt.Rows.Count > 0)
                return new CostManagement(dt.Rows[0]);
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
            string table = "CostManagement";
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
            string table = "CostManagement";
            if (string.IsNullOrWhiteSpace(sel_ord))
            {
                sel_ord = " CostId desc";
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

            string table = "CostManagement";
            if (string.IsNullOrWhiteSpace(sel_ord))
            {
                sel_ord = " CostId desc";
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
            string table = "CostManagement";
            if (string.IsNullOrWhiteSpace(sel_ord))
            {
                sel_ord = "  CostId desc";
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
