//============================================================
//author:于永博
//============================================================

using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using DSM.Models;
using ZtbSoft;

namespace DSM.DAL
{
	public partial class WorkFlowOHistDAL
	{
		/// <summary>
        /// 添加
        /// </summary>
        public int INSERT(WorkFlowOHist workFlowOHist)
		{	
			SqlParameter[] paras = new SqlParameter[]
				{
					new SqlParameter("@TemplateId", ToDBValue(workFlowOHist.TemplateId)),
					new SqlParameter("@UserId", ToDBValue(workFlowOHist.UserId)),
					new SqlParameter("@NodeId", ToDBValue(workFlowOHist.NodeId)),
					new SqlParameter("@NodeCode", ToDBValue(workFlowOHist.NodeCode)),
					new SqlParameter("@OperateTime", ToDBValue(workFlowOHist.OperateTime)),
					new SqlParameter("@OperateTime_order", ToDBValue(workFlowOHist.OperateTime_order)),
					new SqlParameter("@BusinessBillId", ToDBValue(workFlowOHist.BusinessBillId)),
					new SqlParameter("@OperateState", ToDBValue(workFlowOHist.OperateState)),
					new SqlParameter("@NodeActionStatus", ToDBValue(workFlowOHist.NodeActionStatus)),
					new SqlParameter("@WFActiveStatus", ToDBValue(workFlowOHist.WFActiveStatus)),
					new SqlParameter("@WFGUID", ToDBValue(workFlowOHist.WFGUID)),
				};
             
			 return Convert.ToInt32(SqlHelper.ExecuteScalar(CommandType.StoredProcedure, "UP_WorkFlowOHist_INSERT", paras));
		}
        /// <summary>
        /// 添加
        /// </summary>
        public int INSERT_V(WorkFlowOHist workFlowOHist)
		{	
			string sql =@"INSERT INTO WorkFlowOHist (TemplateId,
						UserId,
						NodeId,
						NodeCode,
						OperateTime,
						OperateTime_order,
						BusinessBillId,
						OperateState,
						NodeActionStatus,
						WFActiveStatus,
						WFGUID
						) VALUES (
						@TemplateId,
						@UserId,
						@NodeId,
						@NodeCode,
						@OperateTime,
						@OperateTime_order,
						@BusinessBillId,
						@OperateState,
						@NodeActionStatus,
						@WFActiveStatus,
						@WFGUID
						) select SCOPE_IDENTITY()";
			SqlParameter[] para = new SqlParameter[]
				{
					new SqlParameter("@TemplateId", ToDBValue(workFlowOHist.TemplateId)),
					new SqlParameter("@UserId", ToDBValue(workFlowOHist.UserId)),
					new SqlParameter("@NodeId", ToDBValue(workFlowOHist.NodeId)),
					new SqlParameter("@NodeCode", ToDBValue(workFlowOHist.NodeCode)),
					new SqlParameter("@OperateTime", ToDBValue(workFlowOHist.OperateTime)),
					new SqlParameter("@OperateTime_order", ToDBValue(workFlowOHist.OperateTime_order)),
					new SqlParameter("@BusinessBillId", ToDBValue(workFlowOHist.BusinessBillId)),
					new SqlParameter("@OperateState", ToDBValue(workFlowOHist.OperateState)),
					new SqlParameter("@NodeActionStatus", ToDBValue(workFlowOHist.NodeActionStatus)),
					new SqlParameter("@WFActiveStatus", ToDBValue(workFlowOHist.WFActiveStatus)),
					new SqlParameter("@WFGUID", ToDBValue(workFlowOHist.WFGUID)),
				};
				
			int newId = Convert.ToInt32(SqlHelper.ExecuteScalar(sql, para));
			return newId;
		}

		/// <summary>
        /// 删除
        /// </summary>
        public int DeleteByWfHisId(int wfHisId)
		{
           SqlParameter[] paras = new SqlParameter[]
			{
				new SqlParameter("@WfHisId", wfHisId)
			};
		
           return SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "UP_WorkFlowOHist_DELETE", paras);
		}
		
				
		/// <summary>
        /// 修改
        /// </summary>
        public int Update(WorkFlowOHist workFlowOHist)
        {
           SqlParameter[] paras = new SqlParameter[]
			{
				new SqlParameter("@WfHisId", workFlowOHist.WfHisId)
					,new SqlParameter("@TemplateId", ToDBValue(workFlowOHist.TemplateId))
					,new SqlParameter("@UserId", ToDBValue(workFlowOHist.UserId))
					,new SqlParameter("@NodeId", ToDBValue(workFlowOHist.NodeId))
					,new SqlParameter("@NodeCode", ToDBValue(workFlowOHist.NodeCode))
					,new SqlParameter("@OperateTime", ToDBValue(workFlowOHist.OperateTime))
					,new SqlParameter("@OperateTime_order", ToDBValue(workFlowOHist.OperateTime_order))
					,new SqlParameter("@BusinessBillId", ToDBValue(workFlowOHist.BusinessBillId))
					,new SqlParameter("@OperateState", ToDBValue(workFlowOHist.OperateState))
					,new SqlParameter("@NodeActionStatus", ToDBValue(workFlowOHist.NodeActionStatus))
					,new SqlParameter("@WFActiveStatus", ToDBValue(workFlowOHist.WFActiveStatus))
					,new SqlParameter("@WFGUID", ToDBValue(workFlowOHist.WFGUID))
			};

			  return SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "UP_WorkFlowOHist_UPDATE", paras);
        }
        /// <summary>
        /// 修改
        /// </summary>
		public int Update_V(WorkFlowOHist workFlowOHist){
            string sql = "UPDATE WorkFlowOHist  SET ";
            
            string strSet=string.Empty;
            
            if(workFlowOHist.TemplateId != null)
                strSet+="TemplateId = @TemplateId," ;
                    
            if(workFlowOHist.UserId != null)
                strSet+="UserId = @UserId," ;
                    
            if(workFlowOHist.NodeId != null)
                strSet+="NodeId = @NodeId," ;
                    
            if(workFlowOHist.NodeCode != null)
                strSet+="NodeCode = @NodeCode," ;
                    
            if(workFlowOHist.OperateTime != null)
                strSet+="OperateTime = @OperateTime," ;
                    
            if(workFlowOHist.OperateTime_order != null)
                strSet+="OperateTime_order = @OperateTime_order," ;
                    
            if(workFlowOHist.BusinessBillId != null)
                strSet+="BusinessBillId = @BusinessBillId," ;
                    
            if(workFlowOHist.OperateState != null)
                strSet+="OperateState = @OperateState," ;
                    
            if(workFlowOHist.NodeActionStatus != null)
                strSet+="NodeActionStatus = @NodeActionStatus," ;
                    
            if(workFlowOHist.WFActiveStatus != null)
                strSet+="WFActiveStatus = @WFActiveStatus," ;
                    
            if(workFlowOHist.WFGUID != null)
                strSet+="WFGUID = @WFGUID," ;
                    
            strSet = strSet.TrimEnd(',');
               
            sql=sql+ strSet+" WHERE WfHisId = @WfHisId";


			SqlParameter[] para = new SqlParameter[]
			{
				new SqlParameter("@WfHisId", workFlowOHist.WfHisId)
					,new SqlParameter("@TemplateId", ToDBValue(workFlowOHist.TemplateId))
					,new SqlParameter("@UserId", ToDBValue(workFlowOHist.UserId))
					,new SqlParameter("@NodeId", ToDBValue(workFlowOHist.NodeId))
					,new SqlParameter("@NodeCode", ToDBValue(workFlowOHist.NodeCode))
					,new SqlParameter("@OperateTime", ToDBValue(workFlowOHist.OperateTime))
					,new SqlParameter("@OperateTime_order", ToDBValue(workFlowOHist.OperateTime_order))
					,new SqlParameter("@BusinessBillId", ToDBValue(workFlowOHist.BusinessBillId))
					,new SqlParameter("@OperateState", ToDBValue(workFlowOHist.OperateState))
					,new SqlParameter("@NodeActionStatus", ToDBValue(workFlowOHist.NodeActionStatus))
					,new SqlParameter("@WFActiveStatus", ToDBValue(workFlowOHist.WFActiveStatus))
					,new SqlParameter("@WFGUID", ToDBValue(workFlowOHist.WFGUID))
			};

			return SqlHelper.ExecuteNonQuery(sql, para);
        }
		/// <summary>
        /// 通过主键 WfHisId  得到实体
        /// </summary>
        public WorkFlowOHist GetByWfHisId(int wfHisId)
        {
            string sql = "WfHisId = "+wfHisId;
            
            DataTable dt = GetAll("*",sql,"");
            if (dt.Rows.Count > 0)
                return new WorkFlowOHist(dt.Rows[0]);
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
            string table = "WorkFlowOHist";
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
            string table = "WorkFlowOHist";
            if (string.IsNullOrWhiteSpace(sel_ord))
            {
                sel_ord = " WfHisId desc";
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

            string table = "WorkFlowOHist";
            if (string.IsNullOrWhiteSpace(sel_ord))
            {
                sel_ord = " WfHisId desc";
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
            string table = "WorkFlowOHist";
            if (string.IsNullOrWhiteSpace(sel_ord))
            {
                sel_ord = "  WfHisId desc";
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
