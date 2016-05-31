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
	public partial class UnitBookDAL
	{
		/// <summary>
        /// 添加
        /// </summary>
        public int INSERT(UnitBook unitBook)
		{	
			SqlParameter[] paras = new SqlParameter[]
				{
					new SqlParameter("@UnitId", ToDBValue(unitBook.UnitId)),
					new SqlParameter("@BookType", ToDBValue(unitBook.BookType)),
					new SqlParameter("@BookNum", ToDBValue(unitBook.BookNum)),
					new SqlParameter("@AwardName", ToDBValue(unitBook.AwardName)),
					new SqlParameter("@StarDate", ToDBValue(unitBook.StarDate)),
					new SqlParameter("@EndDate", ToDBValue(unitBook.EndDate)),
					new SqlParameter("@Remark", ToDBValue(unitBook.Remark)),
					new SqlParameter("@EmployeeId", ToDBValue(unitBook.EmployeeId)),
					new SqlParameter("@CreateTime", ToDBValue(unitBook.CreateTime)),
				};
             
			 return Convert.ToInt32(SqlHelper.ExecuteScalar(CommandType.StoredProcedure, "UP_UnitBook_INSERT", paras));
		}
        /// <summary>
        /// 添加
        /// </summary>
        public int INSERT_V(UnitBook unitBook)
		{	
			string sql =@"INSERT INTO UnitBook (UnitId,
						BookType,
						BookNum,
						AwardName,
						StarDate,
						EndDate,
						Remark,
						EmployeeId,
						CreateTime
						) VALUES (
						@UnitId,
						@BookType,
						@BookNum,
						@AwardName,
						@StarDate,
						@EndDate,
						@Remark,
						@EmployeeId,
						@CreateTime
						) select SCOPE_IDENTITY()";
			SqlParameter[] para = new SqlParameter[]
				{
					new SqlParameter("@UnitId", ToDBValue(unitBook.UnitId)),
					new SqlParameter("@BookType", ToDBValue(unitBook.BookType)),
					new SqlParameter("@BookNum", ToDBValue(unitBook.BookNum)),
					new SqlParameter("@AwardName", ToDBValue(unitBook.AwardName)),
					new SqlParameter("@StarDate", ToDBValue(unitBook.StarDate)),
					new SqlParameter("@EndDate", ToDBValue(unitBook.EndDate)),
					new SqlParameter("@Remark", ToDBValue(unitBook.Remark)),
					new SqlParameter("@EmployeeId", ToDBValue(unitBook.EmployeeId)),
					new SqlParameter("@CreateTime", ToDBValue(unitBook.CreateTime)),
				};
				
			int newId = Convert.ToInt32(SqlHelper.ExecuteScalar(sql, para));
			return newId;
		}

		/// <summary>
        /// 删除
        /// </summary>
        public int DeleteByUnitBookId(int unitBookId)
		{
           SqlParameter[] paras = new SqlParameter[]
			{
				new SqlParameter("@UnitBookId", unitBookId)
			};
		
           return SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "UP_UnitBook_DELETE", paras);
		}
		
				
		/// <summary>
        /// 修改
        /// </summary>
        public int Update(UnitBook unitBook)
        {
           SqlParameter[] paras = new SqlParameter[]
			{
				new SqlParameter("@UnitBookId", unitBook.UnitBookId)
					,new SqlParameter("@UnitId", ToDBValue(unitBook.UnitId))
					,new SqlParameter("@BookType", ToDBValue(unitBook.BookType))
					,new SqlParameter("@BookNum", ToDBValue(unitBook.BookNum))
					,new SqlParameter("@AwardName", ToDBValue(unitBook.AwardName))
					,new SqlParameter("@StarDate", ToDBValue(unitBook.StarDate))
					,new SqlParameter("@EndDate", ToDBValue(unitBook.EndDate))
					,new SqlParameter("@Remark", ToDBValue(unitBook.Remark))
					,new SqlParameter("@EmployeeId", ToDBValue(unitBook.EmployeeId))
					,new SqlParameter("@CreateTime", ToDBValue(unitBook.CreateTime))
			};

			  return SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "UP_UnitBook_UPDATE", paras);
        }
        /// <summary>
        /// 修改
        /// </summary>
		public int Update_V(UnitBook unitBook){
            string sql = "UPDATE UnitBook  SET ";
            
            string strSet=string.Empty;
            
            if(unitBook.UnitId != null)
                strSet+="UnitId = @UnitId," ;
                    
            if(unitBook.BookType != null)
                strSet+="BookType = @BookType," ;
                    
            if(unitBook.BookNum != null)
                strSet+="BookNum = @BookNum," ;
                    
            if(unitBook.AwardName != null)
                strSet+="AwardName = @AwardName," ;
                    
            if(unitBook.StarDate != null)
                strSet+="StarDate = @StarDate," ;
                    
            if(unitBook.EndDate != null)
                strSet+="EndDate = @EndDate," ;
                    
            if(unitBook.Remark != null)
                strSet+="Remark = @Remark," ;
                    
            if(unitBook.EmployeeId != null)
                strSet+="EmployeeId = @EmployeeId," ;
                    
            if(unitBook.CreateTime != null)
                strSet+="CreateTime = @CreateTime," ;
                    
            strSet = strSet.TrimEnd(',');
               
            sql=sql+ strSet+" WHERE UnitBookId = @UnitBookId";


			SqlParameter[] para = new SqlParameter[]
			{
				new SqlParameter("@UnitBookId", unitBook.UnitBookId)
					,new SqlParameter("@UnitId", ToDBValue(unitBook.UnitId))
					,new SqlParameter("@BookType", ToDBValue(unitBook.BookType))
					,new SqlParameter("@BookNum", ToDBValue(unitBook.BookNum))
					,new SqlParameter("@AwardName", ToDBValue(unitBook.AwardName))
					,new SqlParameter("@StarDate", ToDBValue(unitBook.StarDate))
					,new SqlParameter("@EndDate", ToDBValue(unitBook.EndDate))
					,new SqlParameter("@Remark", ToDBValue(unitBook.Remark))
					,new SqlParameter("@EmployeeId", ToDBValue(unitBook.EmployeeId))
					,new SqlParameter("@CreateTime", ToDBValue(unitBook.CreateTime))
			};

			return SqlHelper.ExecuteNonQuery(sql, para);
        }
		/// <summary>
        /// 通过主键 UnitBookId  得到实体
        /// </summary>
        public UnitBook GetByUnitBookId(int unitBookId)
        {
            string sql = "UnitBookId = "+unitBookId;
            
            DataTable dt = GetAll("*",sql,"");
            if (dt.Rows.Count > 0)
                return new UnitBook(dt.Rows[0]);
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
            string table = "UnitBook";
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
            string table = "UnitBook";
            if (string.IsNullOrWhiteSpace(sel_ord))
            {
                sel_ord = " UnitBookId desc";
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

            string table = "UnitBook";
            if (string.IsNullOrWhiteSpace(sel_ord))
            {
                sel_ord = " UnitBookId desc";
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
            string table = "UnitBook";
            if (string.IsNullOrWhiteSpace(sel_ord))
            {
                sel_ord = "  UnitBookId desc";
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
