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
	public partial class QualificationDAL
	{
		/// <summary>
        /// 添加
        /// </summary>
        public int INSERT(Qualification qualification)
		{	
			SqlParameter[] paras = new SqlParameter[]
				{
					new SqlParameter("@UnitId", ToDBValue(qualification.UnitId)),
					new SqlParameter("@UserId", ToDBValue(qualification.UserId)),
					new SqlParameter("@QName", ToDBValue(qualification.QName)),
					new SqlParameter("@QCode", ToDBValue(qualification.QCode)),
					new SqlParameter("@StarDate", ToDBValue(qualification.StarDate)),
					new SqlParameter("@EndDate", ToDBValue(qualification.EndDate)),
					new SqlParameter("@Remark", ToDBValue(qualification.Remark)),
					new SqlParameter("@EmployeeId", ToDBValue(qualification.EmployeeId)),
					new SqlParameter("@CreateTime", ToDBValue(qualification.CreateTime)),
				};
             
			 return Convert.ToInt32(SqlHelper.ExecuteScalar(CommandType.StoredProcedure, "UP_Qualification_INSERT", paras));
		}
        /// <summary>
        /// 添加
        /// </summary>
        public int INSERT_V(Qualification qualification)
		{	
			string sql =@"INSERT INTO Qualification (UnitId,
						UserId,
						QName,
						QCode,
						StarDate,
						EndDate,
						Remark,
						EmployeeId,
						CreateTime
						) VALUES (
						@UnitId,
						@UserId,
						@QName,
						@QCode,
						@StarDate,
						@EndDate,
						@Remark,
						@EmployeeId,
						@CreateTime
						) select SCOPE_IDENTITY()";
			SqlParameter[] para = new SqlParameter[]
				{
					new SqlParameter("@UnitId", ToDBValue(qualification.UnitId)),
					new SqlParameter("@UserId", ToDBValue(qualification.UserId)),
					new SqlParameter("@QName", ToDBValue(qualification.QName)),
					new SqlParameter("@QCode", ToDBValue(qualification.QCode)),
					new SqlParameter("@StarDate", ToDBValue(qualification.StarDate)),
					new SqlParameter("@EndDate", ToDBValue(qualification.EndDate)),
					new SqlParameter("@Remark", ToDBValue(qualification.Remark)),
					new SqlParameter("@EmployeeId", ToDBValue(qualification.EmployeeId)),
					new SqlParameter("@CreateTime", ToDBValue(qualification.CreateTime)),
				};
				
			int newId = Convert.ToInt32(SqlHelper.ExecuteScalar(sql, para));
			return newId;
		}

		/// <summary>
        /// 删除
        /// </summary>
        public int DeleteByUQId(int uQId)
		{
           SqlParameter[] paras = new SqlParameter[]
			{
				new SqlParameter("@UQId", uQId)
			};
		
           return SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "UP_Qualification_DELETE", paras);
		}
		
				
		/// <summary>
        /// 修改
        /// </summary>
        public int Update(Qualification qualification)
        {
           SqlParameter[] paras = new SqlParameter[]
			{
				new SqlParameter("@UQId", qualification.UQId)
					,new SqlParameter("@UnitId", ToDBValue(qualification.UnitId))
					,new SqlParameter("@UserId", ToDBValue(qualification.UserId))
					,new SqlParameter("@QName", ToDBValue(qualification.QName))
					,new SqlParameter("@QCode", ToDBValue(qualification.QCode))
					,new SqlParameter("@StarDate", ToDBValue(qualification.StarDate))
					,new SqlParameter("@EndDate", ToDBValue(qualification.EndDate))
					,new SqlParameter("@Remark", ToDBValue(qualification.Remark))
					,new SqlParameter("@EmployeeId", ToDBValue(qualification.EmployeeId))
					,new SqlParameter("@CreateTime", ToDBValue(qualification.CreateTime))
			};

			  return SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "UP_Qualification_UPDATE", paras);
        }
        /// <summary>
        /// 修改
        /// </summary>
		public int Update_V(Qualification qualification){
            string sql = "UPDATE Qualification  SET ";
            
            string strSet=string.Empty;
            
            if(qualification.UnitId != null)
                strSet+="UnitId = @UnitId," ;
                    
            if(qualification.UserId != null)
                strSet+="UserId = @UserId," ;
                    
            if(qualification.QName != null)
                strSet+="QName = @QName," ;
                    
            if(qualification.QCode != null)
                strSet+="QCode = @QCode," ;
                    
            if(qualification.StarDate != null)
                strSet+="StarDate = @StarDate," ;
                    
            if(qualification.EndDate != null)
                strSet+="EndDate = @EndDate," ;
                    
            if(qualification.Remark != null)
                strSet+="Remark = @Remark," ;
                    
            if(qualification.EmployeeId != null)
                strSet+="EmployeeId = @EmployeeId," ;
                    
            if(qualification.CreateTime != null)
                strSet+="CreateTime = @CreateTime," ;
                    
            strSet = strSet.TrimEnd(',');
               
            sql=sql+ strSet+" WHERE UQId = @UQId";


			SqlParameter[] para = new SqlParameter[]
			{
				new SqlParameter("@UQId", qualification.UQId)
					,new SqlParameter("@UnitId", ToDBValue(qualification.UnitId))
					,new SqlParameter("@UserId", ToDBValue(qualification.UserId))
					,new SqlParameter("@QName", ToDBValue(qualification.QName))
					,new SqlParameter("@QCode", ToDBValue(qualification.QCode))
					,new SqlParameter("@StarDate", ToDBValue(qualification.StarDate))
					,new SqlParameter("@EndDate", ToDBValue(qualification.EndDate))
					,new SqlParameter("@Remark", ToDBValue(qualification.Remark))
					,new SqlParameter("@EmployeeId", ToDBValue(qualification.EmployeeId))
					,new SqlParameter("@CreateTime", ToDBValue(qualification.CreateTime))
			};

			return SqlHelper.ExecuteNonQuery(sql, para);
        }
		/// <summary>
        /// 通过主键 UQId  得到实体
        /// </summary>
        public Qualification GetByUQId(int uQId)
        {
            string sql = "UQId = "+uQId;
            
            DataTable dt = GetAll("*",sql,"");
            if (dt.Rows.Count > 0)
                return new Qualification(dt.Rows[0]);
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
            string table = "Qualification";
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
            string table = "Qualification";
            if (string.IsNullOrWhiteSpace(sel_ord))
            {
                sel_ord = " UQId desc";
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

            string table = "Qualification";
            if (string.IsNullOrWhiteSpace(sel_ord))
            {
                sel_ord = " UQId desc";
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
            string table = "Qualification";
            if (string.IsNullOrWhiteSpace(sel_ord))
            {
                sel_ord = "  UQId desc";
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
