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
	public partial class UnitInfoDAL
	{
		/// <summary>
        /// 添加
        /// </summary>
        public int INSERT(UnitInfo unitInfo)
		{	
			SqlParameter[] paras = new SqlParameter[]
				{
					new SqlParameter("@District", ToDBValue(unitInfo.District)),
					new SqlParameter("@UnitTypeId", ToDBValue(unitInfo.UnitTypeId)),
					new SqlParameter("@UnitName", ToDBValue(unitInfo.UnitName)),
					new SqlParameter("@UnitAddress", ToDBValue(unitInfo.UnitAddress)),
					new SqlParameter("@PostCode", ToDBValue(unitInfo.PostCode)),
					new SqlParameter("@TradeCode", ToDBValue(unitInfo.TradeCode)),
					new SqlParameter("@UnitProperty", ToDBValue(unitInfo.UnitProperty)),
					new SqlParameter("@BusinessLicenseNum", ToDBValue(unitInfo.BusinessLicenseNum)),
					new SqlParameter("@RegisterCapital", ToDBValue(unitInfo.RegisterCapital)),
					new SqlParameter("@TaxNum", ToDBValue(unitInfo.TaxNum)),
					new SqlParameter("@Responsible", ToDBValue(unitInfo.Responsible)),
					new SqlParameter("@ResponsiblePhone", ToDBValue(unitInfo.ResponsiblePhone)),
					new SqlParameter("@ResponsibleCardNo", ToDBValue(unitInfo.ResponsibleCardNo)),
					new SqlParameter("@BusinessScope", ToDBValue(unitInfo.BusinessScope)),
					new SqlParameter("@MainBank", ToDBValue(unitInfo.MainBank)),
					new SqlParameter("@DepositBank", ToDBValue(unitInfo.DepositBank)),
					new SqlParameter("@BankNo", ToDBValue(unitInfo.BankNo)),
					new SqlParameter("@AmountNum", ToDBValue(unitInfo.AmountNum)),
					new SqlParameter("@Remark", ToDBValue(unitInfo.Remark)),
					new SqlParameter("@State", ToDBValue(unitInfo.State)),
					new SqlParameter("@EmployeeId", ToDBValue(unitInfo.EmployeeId)),
					new SqlParameter("@CreateTime", ToDBValue(unitInfo.CreateTime)),
				};
             
			 return Convert.ToInt32(SqlHelper.ExecuteScalar(CommandType.StoredProcedure, "UP_UnitInfo_INSERT", paras));
		}
        /// <summary>
        /// 添加
        /// </summary>
        public int INSERT_V(UnitInfo unitInfo)
		{	
			string sql =@"INSERT INTO UnitInfo (District,
						UnitTypeId,
						UnitName,
						UnitAddress,
						PostCode,
						TradeCode,
						UnitProperty,
						BusinessLicenseNum,
						RegisterCapital,
						TaxNum,
						Responsible,
						ResponsiblePhone,
						ResponsibleCardNo,
						BusinessScope,
						MainBank,
						DepositBank,
						BankNo,
						AmountNum,
						Remark,
						State,
						EmployeeId,
						CreateTime
						) VALUES (
						@District,
						@UnitTypeId,
						@UnitName,
						@UnitAddress,
						@PostCode,
						@TradeCode,
						@UnitProperty,
						@BusinessLicenseNum,
						@RegisterCapital,
						@TaxNum,
						@Responsible,
						@ResponsiblePhone,
						@ResponsibleCardNo,
						@BusinessScope,
						@MainBank,
						@DepositBank,
						@BankNo,
						@AmountNum,
						@Remark,
						@State,
						@EmployeeId,
						@CreateTime
						) select SCOPE_IDENTITY()";
			SqlParameter[] para = new SqlParameter[]
				{
					new SqlParameter("@District", ToDBValue(unitInfo.District)),
					new SqlParameter("@UnitTypeId", ToDBValue(unitInfo.UnitTypeId)),
					new SqlParameter("@UnitName", ToDBValue(unitInfo.UnitName)),
					new SqlParameter("@UnitAddress", ToDBValue(unitInfo.UnitAddress)),
					new SqlParameter("@PostCode", ToDBValue(unitInfo.PostCode)),
					new SqlParameter("@TradeCode", ToDBValue(unitInfo.TradeCode)),
					new SqlParameter("@UnitProperty", ToDBValue(unitInfo.UnitProperty)),
					new SqlParameter("@BusinessLicenseNum", ToDBValue(unitInfo.BusinessLicenseNum)),
					new SqlParameter("@RegisterCapital", ToDBValue(unitInfo.RegisterCapital)),
					new SqlParameter("@TaxNum", ToDBValue(unitInfo.TaxNum)),
					new SqlParameter("@Responsible", ToDBValue(unitInfo.Responsible)),
					new SqlParameter("@ResponsiblePhone", ToDBValue(unitInfo.ResponsiblePhone)),
					new SqlParameter("@ResponsibleCardNo", ToDBValue(unitInfo.ResponsibleCardNo)),
					new SqlParameter("@BusinessScope", ToDBValue(unitInfo.BusinessScope)),
					new SqlParameter("@MainBank", ToDBValue(unitInfo.MainBank)),
					new SqlParameter("@DepositBank", ToDBValue(unitInfo.DepositBank)),
					new SqlParameter("@BankNo", ToDBValue(unitInfo.BankNo)),
					new SqlParameter("@AmountNum", ToDBValue(unitInfo.AmountNum)),
					new SqlParameter("@Remark", ToDBValue(unitInfo.Remark)),
					new SqlParameter("@State", ToDBValue(unitInfo.State)),
					new SqlParameter("@EmployeeId", ToDBValue(unitInfo.EmployeeId)),
					new SqlParameter("@CreateTime", ToDBValue(unitInfo.CreateTime)),
				};
				
			int newId = Convert.ToInt32(SqlHelper.ExecuteScalar(sql, para));
			return newId;
		}

		/// <summary>
        /// 删除
        /// </summary>
        public int DeleteByUnitId(int unitId)
		{
           SqlParameter[] paras = new SqlParameter[]
			{
				new SqlParameter("@UnitId", unitId)
			};
		
           return SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "UP_UnitInfo_DELETE", paras);
		}
		
				
		/// <summary>
        /// 修改
        /// </summary>
        public int Update(UnitInfo unitInfo)
        {
           SqlParameter[] paras = new SqlParameter[]
			{
				new SqlParameter("@UnitId", unitInfo.UnitId)
					,new SqlParameter("@District", ToDBValue(unitInfo.District))
					,new SqlParameter("@UnitTypeId", ToDBValue(unitInfo.UnitTypeId))
					,new SqlParameter("@UnitName", ToDBValue(unitInfo.UnitName))
					,new SqlParameter("@UnitAddress", ToDBValue(unitInfo.UnitAddress))
					,new SqlParameter("@PostCode", ToDBValue(unitInfo.PostCode))
					,new SqlParameter("@TradeCode", ToDBValue(unitInfo.TradeCode))
					,new SqlParameter("@UnitProperty", ToDBValue(unitInfo.UnitProperty))
					,new SqlParameter("@BusinessLicenseNum", ToDBValue(unitInfo.BusinessLicenseNum))
					,new SqlParameter("@RegisterCapital", ToDBValue(unitInfo.RegisterCapital))
					,new SqlParameter("@TaxNum", ToDBValue(unitInfo.TaxNum))
					,new SqlParameter("@Responsible", ToDBValue(unitInfo.Responsible))
					,new SqlParameter("@ResponsiblePhone", ToDBValue(unitInfo.ResponsiblePhone))
					,new SqlParameter("@ResponsibleCardNo", ToDBValue(unitInfo.ResponsibleCardNo))
					,new SqlParameter("@BusinessScope", ToDBValue(unitInfo.BusinessScope))
					,new SqlParameter("@MainBank", ToDBValue(unitInfo.MainBank))
					,new SqlParameter("@DepositBank", ToDBValue(unitInfo.DepositBank))
					,new SqlParameter("@BankNo", ToDBValue(unitInfo.BankNo))
					,new SqlParameter("@AmountNum", ToDBValue(unitInfo.AmountNum))
					,new SqlParameter("@Remark", ToDBValue(unitInfo.Remark))
					,new SqlParameter("@State", ToDBValue(unitInfo.State))
			};

			  return SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "UP_UnitInfo_UPDATE", paras);
        }
        /// <summary>
        /// 修改
        /// </summary>
		public int Update_V(UnitInfo unitInfo){
            string sql = "UPDATE UnitInfo  SET ";
            
            string strSet=string.Empty;
            
            if(unitInfo.District != null)
                strSet+="District = @District," ;
                    
            if(unitInfo.UnitTypeId != null)
                strSet+="UnitTypeId = @UnitTypeId," ;
                    
            if(unitInfo.UnitName != null)
                strSet+="UnitName = @UnitName," ;
                    
            if(unitInfo.UnitAddress != null)
                strSet+="UnitAddress = @UnitAddress," ;
                    
            if(unitInfo.PostCode != null)
                strSet+="PostCode = @PostCode," ;
                    
            if(unitInfo.TradeCode != null)
                strSet+="TradeCode = @TradeCode," ;
                    
            if(unitInfo.UnitProperty != null)
                strSet+="UnitProperty = @UnitProperty," ;
                    
            if(unitInfo.BusinessLicenseNum != null)
                strSet+="BusinessLicenseNum = @BusinessLicenseNum," ;
                    
            if(unitInfo.RegisterCapital != null)
                strSet+="RegisterCapital = @RegisterCapital," ;
                    
            if(unitInfo.TaxNum != null)
                strSet+="TaxNum = @TaxNum," ;
                    
            if(unitInfo.Responsible != null)
                strSet+="Responsible = @Responsible," ;
                    
            if(unitInfo.ResponsiblePhone != null)
                strSet+="ResponsiblePhone = @ResponsiblePhone," ;
                    
            if(unitInfo.ResponsibleCardNo != null)
                strSet+="ResponsibleCardNo = @ResponsibleCardNo," ;
                    
            if(unitInfo.BusinessScope != null)
                strSet+="BusinessScope = @BusinessScope," ;
                    
            if(unitInfo.MainBank != null)
                strSet+="MainBank = @MainBank," ;
                    
            if(unitInfo.DepositBank != null)
                strSet+="DepositBank = @DepositBank," ;
                    
            if(unitInfo.BankNo != null)
                strSet+="BankNo = @BankNo," ;
                    
            if(unitInfo.AmountNum != null)
                strSet+="AmountNum = @AmountNum," ;
                    
            if(unitInfo.Remark != null)
                strSet+="Remark = @Remark," ;
                    
            if(unitInfo.State != null)
                strSet+="State = @State," ;
                    
            strSet = strSet.TrimEnd(',');
               
            sql=sql+ strSet+" WHERE UnitId = @UnitId";


			SqlParameter[] para = new SqlParameter[]
			{
				new SqlParameter("@UnitId", unitInfo.UnitId)
					,new SqlParameter("@District", ToDBValue(unitInfo.District))
					,new SqlParameter("@UnitTypeId", ToDBValue(unitInfo.UnitTypeId))
					,new SqlParameter("@UnitName", ToDBValue(unitInfo.UnitName))
					,new SqlParameter("@UnitAddress", ToDBValue(unitInfo.UnitAddress))
					,new SqlParameter("@PostCode", ToDBValue(unitInfo.PostCode))
					,new SqlParameter("@TradeCode", ToDBValue(unitInfo.TradeCode))
					,new SqlParameter("@UnitProperty", ToDBValue(unitInfo.UnitProperty))
					,new SqlParameter("@BusinessLicenseNum", ToDBValue(unitInfo.BusinessLicenseNum))
					,new SqlParameter("@RegisterCapital", ToDBValue(unitInfo.RegisterCapital))
					,new SqlParameter("@TaxNum", ToDBValue(unitInfo.TaxNum))
					,new SqlParameter("@Responsible", ToDBValue(unitInfo.Responsible))
					,new SqlParameter("@ResponsiblePhone", ToDBValue(unitInfo.ResponsiblePhone))
					,new SqlParameter("@ResponsibleCardNo", ToDBValue(unitInfo.ResponsibleCardNo))
					,new SqlParameter("@BusinessScope", ToDBValue(unitInfo.BusinessScope))
					,new SqlParameter("@MainBank", ToDBValue(unitInfo.MainBank))
					,new SqlParameter("@DepositBank", ToDBValue(unitInfo.DepositBank))
					,new SqlParameter("@BankNo", ToDBValue(unitInfo.BankNo))
					,new SqlParameter("@AmountNum", ToDBValue(unitInfo.AmountNum))
					,new SqlParameter("@Remark", ToDBValue(unitInfo.Remark))
					,new SqlParameter("@State", ToDBValue(unitInfo.State))
			};

			return SqlHelper.ExecuteNonQuery(sql, para);
        }
		/// <summary>
        /// 通过主键 UnitId  得到实体
        /// </summary>
        public UnitInfo GetByUnitId(int unitId)
        {
            string sql = "UnitId = "+unitId;
            
            DataTable dt = GetAll("*",sql,"");
            if (dt.Rows.Count > 0)
                return new UnitInfo(dt.Rows[0]);
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
            string table = "UnitInfo";
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
            string table = "UnitInfo";
            if (string.IsNullOrWhiteSpace(sel_ord))
            {
                sel_ord = " UnitId desc";
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

            string table = "UnitInfo";
            if (string.IsNullOrWhiteSpace(sel_ord))
            {
                sel_ord = " UnitId desc";
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
            string table = "UnitInfo";
            if (string.IsNullOrWhiteSpace(sel_ord))
            {
                sel_ord = "  UnitId desc";
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
