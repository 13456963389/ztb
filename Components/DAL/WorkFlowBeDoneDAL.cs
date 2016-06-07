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
	public partial class WorkFlowBeDoneDAL
	{
		/// <summary>
        /// 添加
        /// </summary>
        public int INSERT(WorkFlowBeDone workFlowBeDone)
		{	
			SqlParameter[] paras = new SqlParameter[]
				{
					new SqlParameter("@UserId", ToDBValue(workFlowBeDone.UserId)),
					new SqlParameter("@TemplateId", ToDBValue(workFlowBeDone.TemplateId)),
					new SqlParameter("@BusinessBillId", ToDBValue(workFlowBeDone.BusinessBillId)),
					new SqlParameter("@NodeId", ToDBValue(workFlowBeDone.NodeId)),
					new SqlParameter("@NodeCode", ToDBValue(workFlowBeDone.NodeCode)),
					new SqlParameter("@OperateState", ToDBValue(workFlowBeDone.OperateState)),
					new SqlParameter("@OperateDate", ToDBValue(workFlowBeDone.OperateDate)),
					new SqlParameter("@OperateDate_Order", ToDBValue(workFlowBeDone.OperateDate_Order)),
					new SqlParameter("@OperateDesc", ToDBValue(workFlowBeDone.OperateDesc)),
					new SqlParameter("@Remark", ToDBValue(workFlowBeDone.Remark)),
				};
             
			 return Convert.ToInt32(SqlHelper.ExecuteScalar(CommandType.StoredProcedure, "UP_WorkFlowBeDone_INSERT", paras));
		}
        /// <summary>
        /// 添加
        /// </summary>
        public int INSERT_V(WorkFlowBeDone workFlowBeDone)
		{	
			string sql =@"INSERT INTO WorkFlowBeDone (UserId,
						TemplateId,
						BusinessBillId,
						NodeId,
						NodeCode,
						OperateState,
						OperateDate,
						OperateDate_Order,
						OperateDesc,
						Remark
						) VALUES (
						@UserId,
						@TemplateId,
						@BusinessBillId,
						@NodeId,
						@NodeCode,
						@OperateState,
						@OperateDate,
						@OperateDate_Order,
						@OperateDesc,
						@Remark
						) select SCOPE_IDENTITY()";
			SqlParameter[] para = new SqlParameter[]
				{
					new SqlParameter("@UserId", ToDBValue(workFlowBeDone.UserId)),
					new SqlParameter("@TemplateId", ToDBValue(workFlowBeDone.TemplateId)),
					new SqlParameter("@BusinessBillId", ToDBValue(workFlowBeDone.BusinessBillId)),
					new SqlParameter("@NodeId", ToDBValue(workFlowBeDone.NodeId)),
					new SqlParameter("@NodeCode", ToDBValue(workFlowBeDone.NodeCode)),
					new SqlParameter("@OperateState", ToDBValue(workFlowBeDone.OperateState)),
					new SqlParameter("@OperateDate", ToDBValue(workFlowBeDone.OperateDate)),
					new SqlParameter("@OperateDate_Order", ToDBValue(workFlowBeDone.OperateDate_Order)),
					new SqlParameter("@OperateDesc", ToDBValue(workFlowBeDone.OperateDesc)),
					new SqlParameter("@Remark", ToDBValue(workFlowBeDone.Remark)),
				};
				
			int newId = Convert.ToInt32(SqlHelper.ExecuteScalar(sql, para));
			return newId;
		}

		/// <summary>
        /// 删除
        /// </summary>
        public int DeleteByWFDoneId(int wFDoneId)
		{
           SqlParameter[] paras = new SqlParameter[]
			{
				new SqlParameter("@WFDoneId", wFDoneId)
			};
		
           return SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "UP_WorkFlowBeDone_DELETE", paras);
		}
		
				
		/// <summary>
        /// 修改
        /// </summary>
        public int Update(WorkFlowBeDone workFlowBeDone)
        {
           SqlParameter[] paras = new SqlParameter[]
			{
				new SqlParameter("@WFDoneId", workFlowBeDone.WFDoneId)
					,new SqlParameter("@UserId", ToDBValue(workFlowBeDone.UserId))
					,new SqlParameter("@TemplateId", ToDBValue(workFlowBeDone.TemplateId))
					,new SqlParameter("@BusinessBillId", ToDBValue(workFlowBeDone.BusinessBillId))
					,new SqlParameter("@NodeId", ToDBValue(workFlowBeDone.NodeId))
					,new SqlParameter("@NodeCode", ToDBValue(workFlowBeDone.NodeCode))
					,new SqlParameter("@OperateState", ToDBValue(workFlowBeDone.OperateState))
					,new SqlParameter("@OperateDate", ToDBValue(workFlowBeDone.OperateDate))
					,new SqlParameter("@OperateDate_Order", ToDBValue(workFlowBeDone.OperateDate_Order))
					,new SqlParameter("@OperateDesc", ToDBValue(workFlowBeDone.OperateDesc))
					,new SqlParameter("@Remark", ToDBValue(workFlowBeDone.Remark))
			};

			  return SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "UP_WorkFlowBeDone_UPDATE", paras);
        }
        /// <summary>
        /// 修改
        /// </summary>
		public int Update_V(WorkFlowBeDone workFlowBeDone){
            string sql = "UPDATE WorkFlowBeDone  SET ";
            
            string strSet=string.Empty;
            
            if(workFlowBeDone.UserId != null)
                strSet+="UserId = @UserId," ;
                    
            if(workFlowBeDone.TemplateId != null)
                strSet+="TemplateId = @TemplateId," ;
                    
            if(workFlowBeDone.BusinessBillId != null)
                strSet+="BusinessBillId = @BusinessBillId," ;
                    
            if(workFlowBeDone.NodeId != null)
                strSet+="NodeId = @NodeId," ;
                    
            if(workFlowBeDone.NodeCode != null)
                strSet+="NodeCode = @NodeCode," ;
                    
            if(workFlowBeDone.OperateState != null)
                strSet+="OperateState = @OperateState," ;
                    
            if(workFlowBeDone.OperateDate != null)
                strSet+="OperateDate = @OperateDate," ;
                    
            if(workFlowBeDone.OperateDate_Order != null)
                strSet+="OperateDate_Order = @OperateDate_Order," ;
                    
            if(workFlowBeDone.OperateDesc != null)
                strSet+="OperateDesc = @OperateDesc," ;
                    
            if(workFlowBeDone.Remark != null)
                strSet+="Remark = @Remark," ;
                    
            strSet = strSet.TrimEnd(',');
               
            sql=sql+ strSet+" WHERE WFDoneId = @WFDoneId";


			SqlParameter[] para = new SqlParameter[]
			{
				new SqlParameter("@WFDoneId", workFlowBeDone.WFDoneId)
					,new SqlParameter("@UserId", ToDBValue(workFlowBeDone.UserId))
					,new SqlParameter("@TemplateId", ToDBValue(workFlowBeDone.TemplateId))
					,new SqlParameter("@BusinessBillId", ToDBValue(workFlowBeDone.BusinessBillId))
					,new SqlParameter("@NodeId", ToDBValue(workFlowBeDone.NodeId))
					,new SqlParameter("@NodeCode", ToDBValue(workFlowBeDone.NodeCode))
					,new SqlParameter("@OperateState", ToDBValue(workFlowBeDone.OperateState))
					,new SqlParameter("@OperateDate", ToDBValue(workFlowBeDone.OperateDate))
					,new SqlParameter("@OperateDate_Order", ToDBValue(workFlowBeDone.OperateDate_Order))
					,new SqlParameter("@OperateDesc", ToDBValue(workFlowBeDone.OperateDesc))
					,new SqlParameter("@Remark", ToDBValue(workFlowBeDone.Remark))
			};

			return SqlHelper.ExecuteNonQuery(sql, para);
        }
		/// <summary>
        /// 通过主键 WFDoneId  得到实体
        /// </summary>
        public WorkFlowBeDone GetByWFDoneId(int wFDoneId)
        {
            string sql = "WFDoneId = "+wFDoneId;
            
            DataTable dt = GetAll("*",sql,"");
            if (dt.Rows.Count > 0)
                return new WorkFlowBeDone(dt.Rows[0]);
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
            string table = "WorkFlowBeDone";
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
            string table = "WorkFlowBeDone";
            if (string.IsNullOrWhiteSpace(sel_ord))
            {
                sel_ord = " WFDoneId desc";
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

            string table = "WorkFlowBeDone";
            if (string.IsNullOrWhiteSpace(sel_ord))
            {
                sel_ord = " WFDoneId desc";
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
            string table = "WorkFlowBeDone";
            if (string.IsNullOrWhiteSpace(sel_ord))
            {
                sel_ord = "  WFDoneId desc";
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
