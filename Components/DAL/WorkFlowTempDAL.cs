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
	public partial class WorkFlowTempDAL
	{
		/// <summary>
        /// 添加
        /// </summary>
        public int INSERT(WorkFlowTemp workFlowTemp)
		{	
			SqlParameter[] paras = new SqlParameter[]
				{
					new SqlParameter("@NodeCode", ToDBValue(workFlowTemp.NodeCode)),
					new SqlParameter("@NodeName", ToDBValue(workFlowTemp.NodeName)),
					new SqlParameter("@NodeUrl", ToDBValue(workFlowTemp.NodeUrl)),
					new SqlParameter("@PCode", ToDBValue(workFlowTemp.PCode)),
					new SqlParameter("@QjNodeCode", ToDBValue(workFlowTemp.QjNodeCode)),
					new SqlParameter("@ThNodeCode", ToDBValue(workFlowTemp.ThNodeCode)),
					new SqlParameter("@NodeStatu", ToDBValue(workFlowTemp.NodeStatu)),
					new SqlParameter("@NodeType", ToDBValue(workFlowTemp.NodeType)),
					new SqlParameter("@TemplateId", ToDBValue(workFlowTemp.TemplateId)),
					new SqlParameter("@EmployeeId", ToDBValue(workFlowTemp.EmployeeId)),
				};
             
			 return Convert.ToInt32(SqlHelper.ExecuteScalar(CommandType.StoredProcedure, "UP_WorkFlowTemp_INSERT", paras));
		}
        /// <summary>
        /// 添加
        /// </summary>
        public int INSERT_V(WorkFlowTemp workFlowTemp)
		{	
			string sql =@"INSERT INTO WorkFlowTemp (NodeCode,
						NodeName,
						NodeUrl,
						PCode,
						QjNodeCode,
						ThNodeCode,
						NodeStatu,
						NodeType,
						TemplateId,
						EmployeeId
						) VALUES (
						@NodeCode,
						@NodeName,
						@NodeUrl,
						@PCode,
						@QjNodeCode,
						@ThNodeCode,
						@NodeStatu,
						@NodeType,
						@TemplateId,
						@EmployeeId
						) select SCOPE_IDENTITY()";
			SqlParameter[] para = new SqlParameter[]
				{
					new SqlParameter("@NodeCode", ToDBValue(workFlowTemp.NodeCode)),
					new SqlParameter("@NodeName", ToDBValue(workFlowTemp.NodeName)),
					new SqlParameter("@NodeUrl", ToDBValue(workFlowTemp.NodeUrl)),
					new SqlParameter("@PCode", ToDBValue(workFlowTemp.PCode)),
					new SqlParameter("@QjNodeCode", ToDBValue(workFlowTemp.QjNodeCode)),
					new SqlParameter("@ThNodeCode", ToDBValue(workFlowTemp.ThNodeCode)),
					new SqlParameter("@NodeStatu", ToDBValue(workFlowTemp.NodeStatu)),
					new SqlParameter("@NodeType", ToDBValue(workFlowTemp.NodeType)),
					new SqlParameter("@TemplateId", ToDBValue(workFlowTemp.TemplateId)),
					new SqlParameter("@EmployeeId", ToDBValue(workFlowTemp.EmployeeId)),
				};
				
			int newId = Convert.ToInt32(SqlHelper.ExecuteScalar(sql, para));
			return newId;
		}

		/// <summary>
        /// 删除
        /// </summary>
        public int DeleteByNodeId(int nodeId)
		{
           SqlParameter[] paras = new SqlParameter[]
			{
				new SqlParameter("@NodeId", nodeId)
			};
		
           return SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "UP_WorkFlowTemp_DELETE", paras);
		}
		
				
		/// <summary>
        /// 修改
        /// </summary>
        public int Update(WorkFlowTemp workFlowTemp)
        {
           SqlParameter[] paras = new SqlParameter[]
			{
				new SqlParameter("@NodeId", workFlowTemp.NodeId)
					,new SqlParameter("@NodeCode", ToDBValue(workFlowTemp.NodeCode))
					,new SqlParameter("@NodeName", ToDBValue(workFlowTemp.NodeName))
					,new SqlParameter("@NodeUrl", ToDBValue(workFlowTemp.NodeUrl))
					,new SqlParameter("@PCode", ToDBValue(workFlowTemp.PCode))
					,new SqlParameter("@QjNodeCode", ToDBValue(workFlowTemp.QjNodeCode))
					,new SqlParameter("@ThNodeCode", ToDBValue(workFlowTemp.ThNodeCode))
					,new SqlParameter("@NodeStatu", ToDBValue(workFlowTemp.NodeStatu))
					,new SqlParameter("@NodeType", ToDBValue(workFlowTemp.NodeType))
					,new SqlParameter("@TemplateId", ToDBValue(workFlowTemp.TemplateId))
					,new SqlParameter("@EmployeeId", ToDBValue(workFlowTemp.EmployeeId))
			};

			  return SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "UP_WorkFlowTemp_UPDATE", paras);
        }
        /// <summary>
        /// 修改
        /// </summary>
		public int Update_V(WorkFlowTemp workFlowTemp){
            string sql = "UPDATE WorkFlowTemp  SET ";
            
            string strSet=string.Empty;
            
            if(workFlowTemp.NodeCode != null)
                strSet+="NodeCode = @NodeCode," ;
                    
            if(workFlowTemp.NodeName != null)
                strSet+="NodeName = @NodeName," ;
                    
            if(workFlowTemp.NodeUrl != null)
                strSet+="NodeUrl = @NodeUrl," ;
                    
            if(workFlowTemp.PCode != null)
                strSet+="PCode = @PCode," ;
                    
            if(workFlowTemp.QjNodeCode != null)
                strSet+="QjNodeCode = @QjNodeCode," ;
                    
            if(workFlowTemp.ThNodeCode != null)
                strSet+="ThNodeCode = @ThNodeCode," ;
                    
            if(workFlowTemp.NodeStatu != null)
                strSet+="NodeStatu = @NodeStatu," ;
                    
            if(workFlowTemp.NodeType != null)
                strSet+="NodeType = @NodeType," ;
                    
            if(workFlowTemp.TemplateId != null)
                strSet+="TemplateId = @TemplateId," ;
                    
            if(workFlowTemp.EmployeeId != null)
                strSet+="EmployeeId = @EmployeeId," ;
                    
            strSet = strSet.TrimEnd(',');
               
            sql=sql+ strSet+" WHERE NodeId = @NodeId";


			SqlParameter[] para = new SqlParameter[]
			{
				new SqlParameter("@NodeId", workFlowTemp.NodeId)
					,new SqlParameter("@NodeCode", ToDBValue(workFlowTemp.NodeCode))
					,new SqlParameter("@NodeName", ToDBValue(workFlowTemp.NodeName))
					,new SqlParameter("@NodeUrl", ToDBValue(workFlowTemp.NodeUrl))
					,new SqlParameter("@PCode", ToDBValue(workFlowTemp.PCode))
					,new SqlParameter("@QjNodeCode", ToDBValue(workFlowTemp.QjNodeCode))
					,new SqlParameter("@ThNodeCode", ToDBValue(workFlowTemp.ThNodeCode))
					,new SqlParameter("@NodeStatu", ToDBValue(workFlowTemp.NodeStatu))
					,new SqlParameter("@NodeType", ToDBValue(workFlowTemp.NodeType))
					,new SqlParameter("@TemplateId", ToDBValue(workFlowTemp.TemplateId))
					,new SqlParameter("@EmployeeId", ToDBValue(workFlowTemp.EmployeeId))
			};

			return SqlHelper.ExecuteNonQuery(sql, para);
        }
		/// <summary>
        /// 通过主键 NodeId  得到实体
        /// </summary>
        public WorkFlowTemp GetByNodeId(int nodeId)
        {
            string sql = "NodeId = "+nodeId;
            
            DataTable dt = GetAll("*",sql,"");
            if (dt.Rows.Count > 0)
                return new WorkFlowTemp(dt.Rows[0]);
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
            string table = "WorkFlowTemp";
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
            string table = "WorkFlowTemp";
            if (string.IsNullOrWhiteSpace(sel_ord))
            {
                sel_ord = " NodeId desc";
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

            string table = "WorkFlowTemp";
            if (string.IsNullOrWhiteSpace(sel_ord))
            {
                sel_ord = " NodeId desc";
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
            string table = "WorkFlowTemp";
            if (string.IsNullOrWhiteSpace(sel_ord))
            {
                sel_ord = "  NodeId desc";
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
