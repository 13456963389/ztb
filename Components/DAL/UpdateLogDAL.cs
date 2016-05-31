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
	public partial class UpdateLogDAL
	{
		/// <summary>
        /// 添加
        /// </summary>
        public int INSERT(UpdateLog updateLog)
		{	
			SqlParameter[] paras = new SqlParameter[]
				{
					new SqlParameter("@Title", ToDBValue(updateLog.Title)),
					new SqlParameter("@Version", ToDBValue(updateLog.Version)),
					new SqlParameter("@Time", ToDBValue(updateLog.Time)),
					new SqlParameter("@Description", ToDBValue(updateLog.Description)),
					new SqlParameter("@Text", ToDBValue(updateLog.Text)),
				};
             
			 return Convert.ToInt32(SqlHelper.ExecuteScalar(CommandType.StoredProcedure, "UP_UpdateLog_INSERT", paras));
		}
        /// <summary>
        /// 添加
        /// </summary>
        public int INSERT_V(UpdateLog updateLog)
		{	
			string sql =@"INSERT INTO UpdateLog (Title,
						Version,
						Time,
						Description,
						Text
						) VALUES (
						@Title,
						@Version,
						@Time,
						@Description,
						@Text
						) select SCOPE_IDENTITY()";
			SqlParameter[] para = new SqlParameter[]
				{
					new SqlParameter("@Title", ToDBValue(updateLog.Title)),
					new SqlParameter("@Version", ToDBValue(updateLog.Version)),
					new SqlParameter("@Time", ToDBValue(updateLog.Time)),
					new SqlParameter("@Description", ToDBValue(updateLog.Description)),
					new SqlParameter("@Text", ToDBValue(updateLog.Text)),
				};
				
			int newId = Convert.ToInt32(SqlHelper.ExecuteScalar(sql, para));
			return newId;
		}

		/// <summary>
        /// 删除
        /// </summary>
        public int DeleteByUpdateLogId(int updateLogId)
		{
           SqlParameter[] paras = new SqlParameter[]
			{
				new SqlParameter("@UpdateLogId", updateLogId)
			};
		
           return SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "UP_UpdateLog_DELETE", paras);
		}
		
				
		/// <summary>
        /// 修改
        /// </summary>
        public int Update(UpdateLog updateLog)
        {
           SqlParameter[] paras = new SqlParameter[]
			{
				new SqlParameter("@UpdateLogId", updateLog.UpdateLogId)
					,new SqlParameter("@Title", ToDBValue(updateLog.Title))
					,new SqlParameter("@Version", ToDBValue(updateLog.Version))
					,new SqlParameter("@Time", ToDBValue(updateLog.Time))
					,new SqlParameter("@Description", ToDBValue(updateLog.Description))
					,new SqlParameter("@Text", ToDBValue(updateLog.Text))
			};

			  return SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "UP_UpdateLog_UPDATE", paras);
        }
        /// <summary>
        /// 修改
        /// </summary>
		public int Update_V(UpdateLog updateLog){
            string sql = "UPDATE UpdateLog  SET ";
            
            string strSet=string.Empty;
            
            if(updateLog.Title != null)
                strSet+="Title = @Title," ;
                    
            if(updateLog.Version != null)
                strSet+="Version = @Version," ;
                    
            if(updateLog.Time != null)
                strSet+="Time = @Time," ;
                    
            if(updateLog.Description != null)
                strSet+="Description = @Description," ;
                    
            if(updateLog.Text != null)
                strSet+="Text = @Text," ;
                    
            strSet = strSet.TrimEnd(',');
               
            sql=sql+ strSet+" WHERE UpdateLogId = @UpdateLogId";


			SqlParameter[] para = new SqlParameter[]
			{
				new SqlParameter("@UpdateLogId", updateLog.UpdateLogId)
					,new SqlParameter("@Title", ToDBValue(updateLog.Title))
					,new SqlParameter("@Version", ToDBValue(updateLog.Version))
					,new SqlParameter("@Time", ToDBValue(updateLog.Time))
					,new SqlParameter("@Description", ToDBValue(updateLog.Description))
					,new SqlParameter("@Text", ToDBValue(updateLog.Text))
			};

			return SqlHelper.ExecuteNonQuery(sql, para);
        }
		/// <summary>
        /// 通过主键 UpdateLogId  得到实体
        /// </summary>
        public UpdateLog GetByUpdateLogId(int updateLogId)
        {
            string sql = "UpdateLogId = "+updateLogId;
            
            DataTable dt = GetAll("*",sql,"");
            if (dt.Rows.Count > 0)
                return new UpdateLog(dt.Rows[0]);
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
            string table = "UpdateLog";
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
            string table = "UpdateLog";
            if (string.IsNullOrWhiteSpace(sel_ord))
            {
                sel_ord = " UpdateLogId desc";
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

            string table = "UpdateLog";
            if (string.IsNullOrWhiteSpace(sel_ord))
            {
                sel_ord = " UpdateLogId desc";
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
            string table = "UpdateLog";
            if (string.IsNullOrWhiteSpace(sel_ord))
            {
                sel_ord = "  UpdateLogId desc";
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