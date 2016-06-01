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
	public partial class ExpertInfoDAL
	{
		/// <summary>
        /// 添加
        /// </summary>
        public int INSERT(ExpertInfo expertInfo)
		{	
			SqlParameter[] paras = new SqlParameter[]
				{
					new SqlParameter("@ExpertName", ToDBValue(expertInfo.ExpertName)),
					new SqlParameter("@Sex", ToDBValue(expertInfo.Sex)),
					new SqlParameter("@TradeCode", ToDBValue(expertInfo.TradeCode)),
					new SqlParameter("@Phone", ToDBValue(expertInfo.Phone)),
					new SqlParameter("@Address", ToDBValue(expertInfo.Address)),
					new SqlParameter("@State", ToDBValue(expertInfo.State)),
					new SqlParameter("@Title", ToDBValue(expertInfo.Title)),
					new SqlParameter("@UnitName", ToDBValue(expertInfo.UnitName)),
					new SqlParameter("@Birthday", ToDBValue(expertInfo.Birthday)),
					new SqlParameter("@Duties", ToDBValue(expertInfo.Duties)),
				};
             
			 return Convert.ToInt32(SqlHelper.ExecuteScalar(CommandType.StoredProcedure, "UP_ExpertInfo_INSERT", paras));
		}
        /// <summary>
        /// 添加
        /// </summary>
        public int INSERT_V(ExpertInfo expertInfo)
		{	
			string sql =@"INSERT INTO ExpertInfo (ExpertName,
						Sex,
						TradeCode,
						Phone,
						Address,
						State,
						Title,
						UnitName,
						Birthday,
						Duties
						) VALUES (
						@ExpertName,
						@Sex,
						@TradeCode,
						@Phone,
						@Address,
						@State,
						@Title,
						@UnitName,
						@Birthday,
						@Duties
						) select SCOPE_IDENTITY()";
			SqlParameter[] para = new SqlParameter[]
				{
					new SqlParameter("@ExpertName", ToDBValue(expertInfo.ExpertName)),
					new SqlParameter("@Sex", ToDBValue(expertInfo.Sex)),
					new SqlParameter("@TradeCode", ToDBValue(expertInfo.TradeCode)),
					new SqlParameter("@Phone", ToDBValue(expertInfo.Phone)),
					new SqlParameter("@Address", ToDBValue(expertInfo.Address)),
					new SqlParameter("@State", ToDBValue(expertInfo.State)),
					new SqlParameter("@Title", ToDBValue(expertInfo.Title)),
					new SqlParameter("@UnitName", ToDBValue(expertInfo.UnitName)),
					new SqlParameter("@Birthday", ToDBValue(expertInfo.Birthday)),
					new SqlParameter("@Duties", ToDBValue(expertInfo.Duties)),
				};
				
			int newId = Convert.ToInt32(SqlHelper.ExecuteScalar(sql, para));
			return newId;
		}

		/// <summary>
        /// 删除
        /// </summary>
        public int DeleteByExpertId(int expertId)
		{
           SqlParameter[] paras = new SqlParameter[]
			{
				new SqlParameter("@ExpertId", expertId)
			};
		
           return SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "UP_ExpertInfo_DELETE", paras);
		}
		
				
		/// <summary>
        /// 修改
        /// </summary>
        public int Update(ExpertInfo expertInfo)
        {
           SqlParameter[] paras = new SqlParameter[]
			{
				new SqlParameter("@ExpertId", expertInfo.ExpertId)
					,new SqlParameter("@ExpertName", ToDBValue(expertInfo.ExpertName))
					,new SqlParameter("@Sex", ToDBValue(expertInfo.Sex))
					,new SqlParameter("@TradeCode", ToDBValue(expertInfo.TradeCode))
					,new SqlParameter("@Phone", ToDBValue(expertInfo.Phone))
					,new SqlParameter("@Address", ToDBValue(expertInfo.Address))
					,new SqlParameter("@State", ToDBValue(expertInfo.State))
					,new SqlParameter("@Title", ToDBValue(expertInfo.Title))
					,new SqlParameter("@UnitName", ToDBValue(expertInfo.UnitName))
					,new SqlParameter("@Birthday", ToDBValue(expertInfo.Birthday))
					,new SqlParameter("@Duties", ToDBValue(expertInfo.Duties))
			};

			  return SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "UP_ExpertInfo_UPDATE", paras);
        }
        /// <summary>
        /// 修改
        /// </summary>
		public int Update_V(ExpertInfo expertInfo){
            string sql = "UPDATE ExpertInfo  SET ";
            
            string strSet=string.Empty;
            
            if(expertInfo.ExpertName != null)
                strSet+="ExpertName = @ExpertName," ;
                    
            if(expertInfo.Sex != null)
                strSet+="Sex = @Sex," ;
                    
            if(expertInfo.TradeCode != null)
                strSet+="TradeCode = @TradeCode," ;
                    
            if(expertInfo.Phone != null)
                strSet+="Phone = @Phone," ;
                    
            if(expertInfo.Address != null)
                strSet+="Address = @Address," ;
                    
            if(expertInfo.State != null)
                strSet+="State = @State," ;
                    
            if(expertInfo.Title != null)
                strSet+="Title = @Title," ;
                    
            if(expertInfo.UnitName != null)
                strSet+="UnitName = @UnitName," ;
                    
            if(expertInfo.Birthday != null)
                strSet+="Birthday = @Birthday," ;
                    
            if(expertInfo.Duties != null)
                strSet+="Duties = @Duties," ;
                    
            strSet = strSet.TrimEnd(',');
               
            sql=sql+ strSet+" WHERE ExpertId = @ExpertId";


			SqlParameter[] para = new SqlParameter[]
			{
				new SqlParameter("@ExpertId", expertInfo.ExpertId)
					,new SqlParameter("@ExpertName", ToDBValue(expertInfo.ExpertName))
					,new SqlParameter("@Sex", ToDBValue(expertInfo.Sex))
					,new SqlParameter("@TradeCode", ToDBValue(expertInfo.TradeCode))
					,new SqlParameter("@Phone", ToDBValue(expertInfo.Phone))
					,new SqlParameter("@Address", ToDBValue(expertInfo.Address))
					,new SqlParameter("@State", ToDBValue(expertInfo.State))
					,new SqlParameter("@Title", ToDBValue(expertInfo.Title))
					,new SqlParameter("@UnitName", ToDBValue(expertInfo.UnitName))
					,new SqlParameter("@Birthday", ToDBValue(expertInfo.Birthday))
					,new SqlParameter("@Duties", ToDBValue(expertInfo.Duties))
			};

			return SqlHelper.ExecuteNonQuery(sql, para);
        }
		/// <summary>
        /// 通过主键 ExpertId  得到实体
        /// </summary>
        public ExpertInfo GetByExpertId(int expertId)
        {
            string sql = "ExpertId = "+expertId;
            
            DataTable dt = GetAll("*",sql,"");
            if (dt.Rows.Count > 0)
                return new ExpertInfo(dt.Rows[0]);
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
            string table = "ExpertInfo";
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
            string table = "ExpertInfo";
            if (string.IsNullOrWhiteSpace(sel_ord))
            {
                sel_ord = " ExpertId desc";
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

            string table = "ExpertInfo";
            if (string.IsNullOrWhiteSpace(sel_ord))
            {
                sel_ord = " ExpertId desc";
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
            string table = "ExpertInfo";
            if (string.IsNullOrWhiteSpace(sel_ord))
            {
                sel_ord = "  ExpertId desc";
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
