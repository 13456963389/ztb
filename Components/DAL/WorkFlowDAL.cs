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
	public partial class WorkFlowDAL
	{
		/// <summary>
        /// 添加
        /// </summary>
        public int INSERT(WorkFlow workFlow)
		{	
			SqlParameter[] paras = new SqlParameter[]
				{
					new SqlParameter("@NodeId", ToDBValue(workFlow.NodeId)),
					new SqlParameter("@NodeCode", ToDBValue(workFlow.NodeCode)),
					new SqlParameter("@NodeName", ToDBValue(workFlow.NodeName)),
					new SqlParameter("@NodeUrl", ToDBValue(workFlow.NodeUrl)),
					new SqlParameter("@PCode", ToDBValue(workFlow.PCode)),
					new SqlParameter("@QjNodeCode", ToDBValue(workFlow.QjNodeCode)),
					new SqlParameter("@ThNodeCode", ToDBValue(workFlow.ThNodeCode)),
					new SqlParameter("@NodeStatu", ToDBValue(workFlow.NodeStatu)),
					new SqlParameter("@NodeType", ToDBValue(workFlow.NodeType)),
					new SqlParameter("@TemplateId", ToDBValue(workFlow.TemplateId)),
					new SqlParameter("@ProjectId", ToDBValue(workFlow.ProjectId)),
					new SqlParameter("@EmployeeId", ToDBValue(workFlow.EmployeeId)),
					new SqlParameter("@DoTime", ToDBValue(workFlow.DoTime)),
					new SqlParameter("@NodeShowUrl", ToDBValue(workFlow.NodeShowUrl)),
					new SqlParameter("@BusinessId", ToDBValue(workFlow.BusinessId)),
				};
             
			 return Convert.ToInt32(SqlHelper.ExecuteScalar(CommandType.StoredProcedure, "UP_WorkFlow_INSERT", paras));
		}
        /// <summary>
        /// 添加
        /// </summary>
        public int INSERT_V(WorkFlow workFlow)
		{	
			string sql =@"INSERT INTO WorkFlow (NodeId,
						NodeCode,
						NodeName,
						NodeUrl,
						PCode,
						QjNodeCode,
						ThNodeCode,
						NodeStatu,
						NodeType,
						TemplateId,
						ProjectId,
						EmployeeId,
						DoTime,
						NodeShowUrl,
						BusinessId
						) VALUES (
						@NodeId,
						@NodeCode,
						@NodeName,
						@NodeUrl,
						@PCode,
						@QjNodeCode,
						@ThNodeCode,
						@NodeStatu,
						@NodeType,
						@TemplateId,
						@ProjectId,
						@EmployeeId,
						@DoTime,
						@NodeShowUrl,
						@BusinessId
						) select SCOPE_IDENTITY()";
			SqlParameter[] para = new SqlParameter[]
				{
					new SqlParameter("@NodeId", ToDBValue(workFlow.NodeId)),
					new SqlParameter("@NodeCode", ToDBValue(workFlow.NodeCode)),
					new SqlParameter("@NodeName", ToDBValue(workFlow.NodeName)),
					new SqlParameter("@NodeUrl", ToDBValue(workFlow.NodeUrl)),
					new SqlParameter("@PCode", ToDBValue(workFlow.PCode)),
					new SqlParameter("@QjNodeCode", ToDBValue(workFlow.QjNodeCode)),
					new SqlParameter("@ThNodeCode", ToDBValue(workFlow.ThNodeCode)),
					new SqlParameter("@NodeStatu", ToDBValue(workFlow.NodeStatu)),
					new SqlParameter("@NodeType", ToDBValue(workFlow.NodeType)),
					new SqlParameter("@TemplateId", ToDBValue(workFlow.TemplateId)),
					new SqlParameter("@ProjectId", ToDBValue(workFlow.ProjectId)),
					new SqlParameter("@EmployeeId", ToDBValue(workFlow.EmployeeId)),
					new SqlParameter("@DoTime", ToDBValue(workFlow.DoTime)),
					new SqlParameter("@NodeShowUrl", ToDBValue(workFlow.NodeShowUrl)),
					new SqlParameter("@BusinessId", ToDBValue(workFlow.BusinessId)),
				};
				
			int newId = Convert.ToInt32(SqlHelper.ExecuteScalar(sql, para));
			return newId;
		}

		/// <summary>
        /// 删除
        /// </summary>
        public int DeleteByCaseId(int caseId)
		{
           SqlParameter[] paras = new SqlParameter[]
			{
				new SqlParameter("@CaseId", caseId)
			};
		
           return SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "UP_WorkFlow_DELETE", paras);
		}
		
				
		/// <summary>
        /// 修改
        /// </summary>
        public int Update(WorkFlow workFlow)
        {
           SqlParameter[] paras = new SqlParameter[]
			{
				new SqlParameter("@CaseId", workFlow.CaseId)
					,new SqlParameter("@NodeId", ToDBValue(workFlow.NodeId))
					,new SqlParameter("@NodeCode", ToDBValue(workFlow.NodeCode))
					,new SqlParameter("@NodeName", ToDBValue(workFlow.NodeName))
					,new SqlParameter("@NodeUrl", ToDBValue(workFlow.NodeUrl))
					,new SqlParameter("@PCode", ToDBValue(workFlow.PCode))
					,new SqlParameter("@QjNodeCode", ToDBValue(workFlow.QjNodeCode))
					,new SqlParameter("@ThNodeCode", ToDBValue(workFlow.ThNodeCode))
					,new SqlParameter("@NodeStatu", ToDBValue(workFlow.NodeStatu))
					,new SqlParameter("@NodeType", ToDBValue(workFlow.NodeType))
					,new SqlParameter("@TemplateId", ToDBValue(workFlow.TemplateId))
					,new SqlParameter("@ProjectId", ToDBValue(workFlow.ProjectId))
					,new SqlParameter("@EmployeeId", ToDBValue(workFlow.EmployeeId))
					,new SqlParameter("@DoTime", ToDBValue(workFlow.DoTime))
					,new SqlParameter("@NodeShowUrl", ToDBValue(workFlow.NodeShowUrl))
					,new SqlParameter("@BusinessId", ToDBValue(workFlow.BusinessId))
			};

			  return SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "UP_WorkFlow_UPDATE", paras);
        }
        /// <summary>
        /// 修改
        /// </summary>
		public int Update_V(WorkFlow workFlow){
            string sql = "UPDATE WorkFlow  SET ";
            
            string strSet=string.Empty;
            
            if(workFlow.NodeId != null)
                strSet+="NodeId = @NodeId," ;
                    
            if(workFlow.NodeCode != null)
                strSet+="NodeCode = @NodeCode," ;
                    
            if(workFlow.NodeName != null)
                strSet+="NodeName = @NodeName," ;
                    
            if(workFlow.NodeUrl != null)
                strSet+="NodeUrl = @NodeUrl," ;
                    
            if(workFlow.PCode != null)
                strSet+="PCode = @PCode," ;
                    
            if(workFlow.QjNodeCode != null)
                strSet+="QjNodeCode = @QjNodeCode," ;
                    
            if(workFlow.ThNodeCode != null)
                strSet+="ThNodeCode = @ThNodeCode," ;
                    
            if(workFlow.NodeStatu != null)
                strSet+="NodeStatu = @NodeStatu," ;
                    
            if(workFlow.NodeType != null)
                strSet+="NodeType = @NodeType," ;
                    
            if(workFlow.TemplateId != null)
                strSet+="TemplateId = @TemplateId," ;
                    
            if(workFlow.ProjectId != null)
                strSet+="ProjectId = @ProjectId," ;
                    
            if(workFlow.EmployeeId != null)
                strSet+="EmployeeId = @EmployeeId," ;
                    
            if(workFlow.DoTime != null)
                strSet+="DoTime = @DoTime," ;
                    
            if(workFlow.NodeShowUrl != null)
                strSet+="NodeShowUrl = @NodeShowUrl," ;
                    
            if(workFlow.BusinessId != null)
                strSet+="BusinessId = @BusinessId," ;
                    
            strSet = strSet.TrimEnd(',');
               
            sql=sql+ strSet+" WHERE CaseId = @CaseId";


			SqlParameter[] para = new SqlParameter[]
			{
				new SqlParameter("@CaseId", workFlow.CaseId)
					,new SqlParameter("@NodeId", ToDBValue(workFlow.NodeId))
					,new SqlParameter("@NodeCode", ToDBValue(workFlow.NodeCode))
					,new SqlParameter("@NodeName", ToDBValue(workFlow.NodeName))
					,new SqlParameter("@NodeUrl", ToDBValue(workFlow.NodeUrl))
					,new SqlParameter("@PCode", ToDBValue(workFlow.PCode))
					,new SqlParameter("@QjNodeCode", ToDBValue(workFlow.QjNodeCode))
					,new SqlParameter("@ThNodeCode", ToDBValue(workFlow.ThNodeCode))
					,new SqlParameter("@NodeStatu", ToDBValue(workFlow.NodeStatu))
					,new SqlParameter("@NodeType", ToDBValue(workFlow.NodeType))
					,new SqlParameter("@TemplateId", ToDBValue(workFlow.TemplateId))
					,new SqlParameter("@ProjectId", ToDBValue(workFlow.ProjectId))
					,new SqlParameter("@EmployeeId", ToDBValue(workFlow.EmployeeId))
					,new SqlParameter("@DoTime", ToDBValue(workFlow.DoTime))
					,new SqlParameter("@NodeShowUrl", ToDBValue(workFlow.NodeShowUrl))
					,new SqlParameter("@BusinessId", ToDBValue(workFlow.BusinessId))
			};

			return SqlHelper.ExecuteNonQuery(sql, para);
        }
		/// <summary>
        /// 通过主键 CaseId  得到实体
        /// </summary>
        public WorkFlow GetByCaseId(int caseId)
        {
            string sql = "CaseId = "+caseId;
            
            DataTable dt = GetAll("*",sql,"");
            if (dt.Rows.Count > 0)
                return new WorkFlow(dt.Rows[0]);
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
            string table = "WorkFlow";
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
            string table = "WorkFlow";
            if (string.IsNullOrWhiteSpace(sel_ord))
            {
                sel_ord = " CaseId desc";
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

            string table = "WorkFlow";
            if (string.IsNullOrWhiteSpace(sel_ord))
            {
                sel_ord = " CaseId desc";
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
            string table = "WorkFlow";
            if (string.IsNullOrWhiteSpace(sel_ord))
            {
                sel_ord = "  CaseId desc";
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
