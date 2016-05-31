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
	public partial class NoticeDAL
	{
		/// <summary>
        /// 添加
        /// </summary>
        public int INSERT(Notice notice)
		{	
			SqlParameter[] paras = new SqlParameter[]
				{
					new SqlParameter("@NoticeName", ToDBValue(notice.NoticeName)),
					new SqlParameter("@NoticeContext", ToDBValue(notice.NoticeContext)),
					new SqlParameter("@NoticeStarDate", ToDBValue(notice.NoticeStarDate)),
					new SqlParameter("@NoticeEndDate", ToDBValue(notice.NoticeEndDate)),
					new SqlParameter("@CheckStatu", ToDBValue(notice.CheckStatu)),
					new SqlParameter("@ProjectId", ToDBValue(notice.ProjectId)),
					new SqlParameter("@EmployeeId", ToDBValue(notice.EmployeeId)),
					new SqlParameter("@CreateTime", ToDBValue(notice.CreateTime)),
					new SqlParameter("@NoticeType", ToDBValue(notice.NoticeType)),
					new SqlParameter("@ReviewDate", ToDBValue(notice.ReviewDate)),
				};
             
			 return Convert.ToInt32(SqlHelper.ExecuteScalar(CommandType.StoredProcedure, "UP_Notice_INSERT", paras));
		}
        /// <summary>
        /// 添加
        /// </summary>
        public int INSERT_V(Notice notice)
		{	
			string sql =@"INSERT INTO Notice (NoticeName,
						NoticeContext,
						NoticeStarDate,
						NoticeEndDate,
						CheckStatu,
						ProjectId,
						EmployeeId,
						CreateTime,
						NoticeType,
						ReviewDate
						) VALUES (
						@NoticeName,
						@NoticeContext,
						@NoticeStarDate,
						@NoticeEndDate,
						@CheckStatu,
						@ProjectId,
						@EmployeeId,
						@CreateTime,
						@NoticeType,
						@ReviewDate
						) select SCOPE_IDENTITY()";
			SqlParameter[] para = new SqlParameter[]
				{
					new SqlParameter("@NoticeName", ToDBValue(notice.NoticeName)),
					new SqlParameter("@NoticeContext", ToDBValue(notice.NoticeContext)),
					new SqlParameter("@NoticeStarDate", ToDBValue(notice.NoticeStarDate)),
					new SqlParameter("@NoticeEndDate", ToDBValue(notice.NoticeEndDate)),
					new SqlParameter("@CheckStatu", ToDBValue(notice.CheckStatu)),
					new SqlParameter("@ProjectId", ToDBValue(notice.ProjectId)),
					new SqlParameter("@EmployeeId", ToDBValue(notice.EmployeeId)),
					new SqlParameter("@CreateTime", ToDBValue(notice.CreateTime)),
					new SqlParameter("@NoticeType", ToDBValue(notice.NoticeType)),
					new SqlParameter("@ReviewDate", ToDBValue(notice.ReviewDate)),
				};
				
			int newId = Convert.ToInt32(SqlHelper.ExecuteScalar(sql, para));
			return newId;
		}

		/// <summary>
        /// 删除
        /// </summary>
        public int DeleteByNoticeId(int noticeId)
		{
           SqlParameter[] paras = new SqlParameter[]
			{
				new SqlParameter("@NoticeId", noticeId)
			};
		
           return SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "UP_Notice_DELETE", paras);
		}
		
				
		/// <summary>
        /// 修改
        /// </summary>
        public int Update(Notice notice)
        {
           SqlParameter[] paras = new SqlParameter[]
			{
				new SqlParameter("@NoticeId", notice.NoticeId)
					,new SqlParameter("@NoticeName", ToDBValue(notice.NoticeName))
					,new SqlParameter("@NoticeContext", ToDBValue(notice.NoticeContext))
					,new SqlParameter("@NoticeStarDate", ToDBValue(notice.NoticeStarDate))
					,new SqlParameter("@NoticeEndDate", ToDBValue(notice.NoticeEndDate))
					,new SqlParameter("@CheckStatu", ToDBValue(notice.CheckStatu))
					,new SqlParameter("@ProjectId", ToDBValue(notice.ProjectId))
					,new SqlParameter("@EmployeeId", ToDBValue(notice.EmployeeId))
					,new SqlParameter("@CreateTime", ToDBValue(notice.CreateTime))
					,new SqlParameter("@NoticeType", ToDBValue(notice.NoticeType))
					,new SqlParameter("@ReviewDate", ToDBValue(notice.ReviewDate))
			};

			  return SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "UP_Notice_UPDATE", paras);
        }
        /// <summary>
        /// 修改
        /// </summary>
		public int Update_V(Notice notice){
            string sql = "UPDATE Notice  SET ";
            
            string strSet=string.Empty;
            
            if(notice.NoticeName != null)
                strSet+="NoticeName = @NoticeName," ;
                    
            if(notice.NoticeContext != null)
                strSet+="NoticeContext = @NoticeContext," ;
                    
            if(notice.NoticeStarDate != null)
                strSet+="NoticeStarDate = @NoticeStarDate," ;
                    
            if(notice.NoticeEndDate != null)
                strSet+="NoticeEndDate = @NoticeEndDate," ;
                    
            if(notice.CheckStatu != null)
                strSet+="CheckStatu = @CheckStatu," ;
                    
            if(notice.ProjectId != null)
                strSet+="ProjectId = @ProjectId," ;
                    
            if(notice.EmployeeId != null)
                strSet+="EmployeeId = @EmployeeId," ;
                    
            if(notice.CreateTime != null)
                strSet+="CreateTime = @CreateTime," ;
                    
            if(notice.NoticeType != null)
                strSet+="NoticeType = @NoticeType," ;
                    
            if(notice.ReviewDate != null)
                strSet+="ReviewDate = @ReviewDate," ;
                    
            strSet = strSet.TrimEnd(',');
               
            sql=sql+ strSet+" WHERE NoticeId = @NoticeId";


			SqlParameter[] para = new SqlParameter[]
			{
				new SqlParameter("@NoticeId", notice.NoticeId)
					,new SqlParameter("@NoticeName", ToDBValue(notice.NoticeName))
					,new SqlParameter("@NoticeContext", ToDBValue(notice.NoticeContext))
					,new SqlParameter("@NoticeStarDate", ToDBValue(notice.NoticeStarDate))
					,new SqlParameter("@NoticeEndDate", ToDBValue(notice.NoticeEndDate))
					,new SqlParameter("@CheckStatu", ToDBValue(notice.CheckStatu))
					,new SqlParameter("@ProjectId", ToDBValue(notice.ProjectId))
					,new SqlParameter("@EmployeeId", ToDBValue(notice.EmployeeId))
					,new SqlParameter("@CreateTime", ToDBValue(notice.CreateTime))
					,new SqlParameter("@NoticeType", ToDBValue(notice.NoticeType))
					,new SqlParameter("@ReviewDate", ToDBValue(notice.ReviewDate))
			};

			return SqlHelper.ExecuteNonQuery(sql, para);
        }
		/// <summary>
        /// 通过主键 NoticeId  得到实体
        /// </summary>
        public Notice GetByNoticeId(int noticeId)
        {
            string sql = "NoticeId = "+noticeId;
            
            DataTable dt = GetAll("*",sql,"");
            if (dt.Rows.Count > 0)
                return new Notice(dt.Rows[0]);
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
            string table = "Notice";
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
            string table = "Notice";
            if (string.IsNullOrWhiteSpace(sel_ord))
            {
                sel_ord = " NoticeId desc";
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

            string table = "Notice";
            if (string.IsNullOrWhiteSpace(sel_ord))
            {
                sel_ord = " NoticeId desc";
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
            string table = "Notice";
            if (string.IsNullOrWhiteSpace(sel_ord))
            {
                sel_ord = "  NoticeId desc";
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
