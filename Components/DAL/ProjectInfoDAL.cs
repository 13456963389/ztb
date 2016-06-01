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
	public partial class ProjectInfoDAL
	{
		/// <summary>
        /// 添加
        /// </summary>
        public int INSERT(ProjectInfo projectInfo)
		{	
			SqlParameter[] paras = new SqlParameter[]
				{
					new SqlParameter("@ProjectCode", ToDBValue(projectInfo.ProjectCode)),
					new SqlParameter("@ProjectName", ToDBValue(projectInfo.ProjectName)),
					new SqlParameter("@ProjectType", ToDBValue(projectInfo.ProjectType)),
					new SqlParameter("@Address", ToDBValue(projectInfo.Address)),
					new SqlParameter("@ProjectLegal", ToDBValue(projectInfo.ProjectLegal)),
					new SqlParameter("@TradeCode", ToDBValue(projectInfo.TradeCode)),
					new SqlParameter("@ProjectScale", ToDBValue(projectInfo.ProjectScale)),
					new SqlParameter("@TendereeId", ToDBValue(projectInfo.TendereeId)),
					new SqlParameter("@AgencyId", ToDBValue(projectInfo.AgencyId)),
					new SqlParameter("@Remark", ToDBValue(projectInfo.Remark)),
					new SqlParameter("@CheckStatu", ToDBValue(projectInfo.CheckStatu)),
					new SqlParameter("@EmployeeId", ToDBValue(projectInfo.EmployeeId)),
					new SqlParameter("@CreateTime", ToDBValue(projectInfo.CreateTime)),
					new SqlParameter("@TendereeType", ToDBValue(projectInfo.TendereeType)),
				};
             
			 return Convert.ToInt32(SqlHelper.ExecuteScalar(CommandType.StoredProcedure, "UP_ProjectInfo_INSERT", paras));
		}
        /// <summary>
        /// 添加
        /// </summary>
        public int INSERT_V(ProjectInfo projectInfo)
		{	
			string sql =@"INSERT INTO ProjectInfo (ProjectCode,
						ProjectName,
						ProjectType,
						Address,
						ProjectLegal,
						TradeCode,
						ProjectScale,
						TendereeId,
						AgencyId,
						Remark,
						CheckStatu,
						EmployeeId,
						CreateTime,
						TendereeType
						) VALUES (
						@ProjectCode,
						@ProjectName,
						@ProjectType,
						@Address,
						@ProjectLegal,
						@TradeCode,
						@ProjectScale,
						@TendereeId,
						@AgencyId,
						@Remark,
						@CheckStatu,
						@EmployeeId,
						@CreateTime,
						@TendereeType
						) select SCOPE_IDENTITY()";
			SqlParameter[] para = new SqlParameter[]
				{
					new SqlParameter("@ProjectCode", ToDBValue(projectInfo.ProjectCode)),
					new SqlParameter("@ProjectName", ToDBValue(projectInfo.ProjectName)),
					new SqlParameter("@ProjectType", ToDBValue(projectInfo.ProjectType)),
					new SqlParameter("@Address", ToDBValue(projectInfo.Address)),
					new SqlParameter("@ProjectLegal", ToDBValue(projectInfo.ProjectLegal)),
					new SqlParameter("@TradeCode", ToDBValue(projectInfo.TradeCode)),
					new SqlParameter("@ProjectScale", ToDBValue(projectInfo.ProjectScale)),
					new SqlParameter("@TendereeId", ToDBValue(projectInfo.TendereeId)),
					new SqlParameter("@AgencyId", ToDBValue(projectInfo.AgencyId)),
					new SqlParameter("@Remark", ToDBValue(projectInfo.Remark)),
					new SqlParameter("@CheckStatu", ToDBValue(projectInfo.CheckStatu)),
					new SqlParameter("@EmployeeId", ToDBValue(projectInfo.EmployeeId)),
					new SqlParameter("@CreateTime", ToDBValue(projectInfo.CreateTime)),
					new SqlParameter("@TendereeType", ToDBValue(projectInfo.TendereeType)),
				};
				
			int newId = Convert.ToInt32(SqlHelper.ExecuteScalar(sql, para));
			return newId;
		}

		/// <summary>
        /// 删除
        /// </summary>
        public int DeleteByProjectId(int projectId)
		{
           SqlParameter[] paras = new SqlParameter[]
			{
				new SqlParameter("@ProjectId", projectId)
			};
		
           return SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "UP_ProjectInfo_DELETE", paras);
		}
		
				
		/// <summary>
        /// 修改
        /// </summary>
        public int Update(ProjectInfo projectInfo)
        {
           SqlParameter[] paras = new SqlParameter[]
			{
				new SqlParameter("@ProjectId", projectInfo.ProjectId)
					,new SqlParameter("@ProjectCode", ToDBValue(projectInfo.ProjectCode))
					,new SqlParameter("@ProjectName", ToDBValue(projectInfo.ProjectName))
					,new SqlParameter("@ProjectType", ToDBValue(projectInfo.ProjectType))
					,new SqlParameter("@Address", ToDBValue(projectInfo.Address))
					,new SqlParameter("@ProjectLegal", ToDBValue(projectInfo.ProjectLegal))
					,new SqlParameter("@TradeCode", ToDBValue(projectInfo.TradeCode))
					,new SqlParameter("@ProjectScale", ToDBValue(projectInfo.ProjectScale))
					,new SqlParameter("@TendereeId", ToDBValue(projectInfo.TendereeId))
					,new SqlParameter("@AgencyId", ToDBValue(projectInfo.AgencyId))
					,new SqlParameter("@Remark", ToDBValue(projectInfo.Remark))
					,new SqlParameter("@CheckStatu", ToDBValue(projectInfo.CheckStatu))
					,new SqlParameter("@EmployeeId", ToDBValue(projectInfo.EmployeeId))
					,new SqlParameter("@CreateTime", ToDBValue(projectInfo.CreateTime))
					,new SqlParameter("@TendereeType", ToDBValue(projectInfo.TendereeType))
			};

			  return SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "UP_ProjectInfo_UPDATE", paras);
        }
        /// <summary>
        /// 修改
        /// </summary>
		public int Update_V(ProjectInfo projectInfo){
            string sql = "UPDATE ProjectInfo  SET ";
            
            string strSet=string.Empty;
            
            if(projectInfo.ProjectCode != null)
                strSet+="ProjectCode = @ProjectCode," ;
                    
            if(projectInfo.ProjectName != null)
                strSet+="ProjectName = @ProjectName," ;
                    
            if(projectInfo.ProjectType != null)
                strSet+="ProjectType = @ProjectType," ;
                    
            if(projectInfo.Address != null)
                strSet+="Address = @Address," ;
                    
            if(projectInfo.ProjectLegal != null)
                strSet+="ProjectLegal = @ProjectLegal," ;
                    
            if(projectInfo.TradeCode != null)
                strSet+="TradeCode = @TradeCode," ;
                    
            if(projectInfo.ProjectScale != null)
                strSet+="ProjectScale = @ProjectScale," ;
                    
            if(projectInfo.TendereeId != null)
                strSet+="TendereeId = @TendereeId," ;
                    
            if(projectInfo.AgencyId != null)
                strSet+="AgencyId = @AgencyId," ;
                    
            if(projectInfo.Remark != null)
                strSet+="Remark = @Remark," ;
                    
            if(projectInfo.CheckStatu != null)
                strSet+="CheckStatu = @CheckStatu," ;
                    
            if(projectInfo.EmployeeId != null)
                strSet+="EmployeeId = @EmployeeId," ;
                    
            if(projectInfo.CreateTime != null)
                strSet+="CreateTime = @CreateTime," ;
                    
            if(projectInfo.TendereeType != null)
                strSet+="TendereeType = @TendereeType," ;
                    
            strSet = strSet.TrimEnd(',');
               
            sql=sql+ strSet+" WHERE ProjectId = @ProjectId";


			SqlParameter[] para = new SqlParameter[]
			{
				new SqlParameter("@ProjectId", projectInfo.ProjectId)
					,new SqlParameter("@ProjectCode", ToDBValue(projectInfo.ProjectCode))
					,new SqlParameter("@ProjectName", ToDBValue(projectInfo.ProjectName))
					,new SqlParameter("@ProjectType", ToDBValue(projectInfo.ProjectType))
					,new SqlParameter("@Address", ToDBValue(projectInfo.Address))
					,new SqlParameter("@ProjectLegal", ToDBValue(projectInfo.ProjectLegal))
					,new SqlParameter("@TradeCode", ToDBValue(projectInfo.TradeCode))
					,new SqlParameter("@ProjectScale", ToDBValue(projectInfo.ProjectScale))
					,new SqlParameter("@TendereeId", ToDBValue(projectInfo.TendereeId))
					,new SqlParameter("@AgencyId", ToDBValue(projectInfo.AgencyId))
					,new SqlParameter("@Remark", ToDBValue(projectInfo.Remark))
					,new SqlParameter("@CheckStatu", ToDBValue(projectInfo.CheckStatu))
					,new SqlParameter("@EmployeeId", ToDBValue(projectInfo.EmployeeId))
					,new SqlParameter("@CreateTime", ToDBValue(projectInfo.CreateTime))
					,new SqlParameter("@TendereeType", ToDBValue(projectInfo.TendereeType))
			};

			return SqlHelper.ExecuteNonQuery(sql, para);
        }
		/// <summary>
        /// 通过主键 ProjectId  得到实体
        /// </summary>
        public ProjectInfo GetByProjectId(int projectId)
        {
            string sql = "ProjectId = "+projectId;
            
            DataTable dt = GetAll("*",sql,"");
            if (dt.Rows.Count > 0)
                return new ProjectInfo(dt.Rows[0]);
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
            string table = "ProjectInfo";
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
            string table = "ProjectInfo";
            if (string.IsNullOrWhiteSpace(sel_ord))
            {
                sel_ord = " ProjectId desc";
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

            string table = "ProjectInfo";
            if (string.IsNullOrWhiteSpace(sel_ord))
            {
                sel_ord = " ProjectId desc";
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
            string table = "ProjectInfo";
            if (string.IsNullOrWhiteSpace(sel_ord))
            {
                sel_ord = "  ProjectId desc";
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
