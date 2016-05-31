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
	public partial class EmployeeDAL
	{
		/// <summary>
        /// 添加
        /// </summary>
        public int INSERT(Employee employee)
		{	
			SqlParameter[] paras = new SqlParameter[]
				{
					new SqlParameter("@EmployeeName", ToDBValue(employee.EmployeeName)),
					new SqlParameter("@EmployeeSex", ToDBValue(employee.EmployeeSex)),
					new SqlParameter("@JobLevelId", ToDBValue(employee.JobLevelId)),
					new SqlParameter("@JobLevel", ToDBValue(employee.JobLevel)),
					new SqlParameter("@EmployeePhone", ToDBValue(employee.EmployeePhone)),
					new SqlParameter("@EmployeeBirthday", ToDBValue(employee.EmployeeBirthday)),
					new SqlParameter("@EmployeeEntryDate", ToDBValue(employee.EmployeeEntryDate)),
					new SqlParameter("@EmployeeEmail", ToDBValue(employee.EmployeeEmail)),
					new SqlParameter("@EmployeeQQ", ToDBValue(employee.EmployeeQQ)),
					new SqlParameter("@EmployeeWeixin", ToDBValue(employee.EmployeeWeixin)),
					new SqlParameter("@EmployeeAddress", ToDBValue(employee.EmployeeAddress)),
					new SqlParameter("@EmployeeEducation", ToDBValue(employee.EmployeeEducation)),
					new SqlParameter("@EmployeeSchool", ToDBValue(employee.EmployeeSchool)),
					new SqlParameter("@EmployeeIDCode", ToDBValue(employee.EmployeeIDCode)),
					new SqlParameter("@EmployeeUsername", ToDBValue(employee.EmployeeUsername)),
					new SqlParameter("@EmployeeUserpass", ToDBValue(employee.EmployeeUserpass)),
					new SqlParameter("@RoleId", ToDBValue(employee.RoleId)),
					new SqlParameter("@EmployeeWages", ToDBValue(employee.EmployeeWages)),
					new SqlParameter("@Remark", ToDBValue(employee.Remark)),
					new SqlParameter("@State", ToDBValue(employee.State)),
					new SqlParameter("@Bank", ToDBValue(employee.Bank)),
					new SqlParameter("@BankCard", ToDBValue(employee.BankCard)),
					new SqlParameter("@CreateTime", ToDBValue(employee.CreateTime)),
					new SqlParameter("@ModifyTime", ToDBValue(employee.ModifyTime)),
				};
             
			 return Convert.ToInt32(SqlHelper.ExecuteScalar(CommandType.StoredProcedure, "UP_Employee_INSERT", paras));
		}
        /// <summary>
        /// 添加
        /// </summary>
        public int INSERT_V(Employee employee)
		{	
			string sql =@"INSERT INTO Employee (EmployeeName,
						EmployeeSex,
						JobLevelId,
						JobLevel,
						PointId,
						EmployeePhone,
						EmployeeBirthday,
						EmployeeEntryDate,
						EmployeeEmail,
						EmployeeQQ,
						EmployeeWeixin,
						EmployeeAddress,
						EmployeeEducation,
						EmployeeSchool,
						EmployeeIDCode,
						EmployeeUsername,
						EmployeeUserpass,
						RoleId,
						EmployeeStarId,
						EmployeeWages,
						Remark,
						State,
						Bank,
						BankCard,
						CreateTime,
						ModifyTime
						) VALUES (
						@EmployeeName,
						@EmployeeSex,
						@JobLevelId,
						@JobLevel,
						@EmployeePhone,
						@EmployeeBirthday,
						@EmployeeEntryDate,
						@EmployeeEmail,
						@EmployeeQQ,
						@EmployeeWeixin,
						@EmployeeAddress,
						@EmployeeEducation,
						@EmployeeSchool,
						@EmployeeIDCode,
						@EmployeeUsername,
						@EmployeeUserpass,
						@RoleId,
						@EmployeeWages,
						@Remark,
						@State,
						@Bank,
						@BankCard,
						@CreateTime,
						@ModifyTime
						) select SCOPE_IDENTITY()";
			SqlParameter[] para = new SqlParameter[]
				{
					new SqlParameter("@EmployeeName", ToDBValue(employee.EmployeeName)),
					new SqlParameter("@EmployeeSex", ToDBValue(employee.EmployeeSex)),
					new SqlParameter("@JobLevelId", ToDBValue(employee.JobLevelId)),
					new SqlParameter("@JobLevel", ToDBValue(employee.JobLevel)),
					new SqlParameter("@EmployeePhone", ToDBValue(employee.EmployeePhone)),
					new SqlParameter("@EmployeeBirthday", ToDBValue(employee.EmployeeBirthday)),
					new SqlParameter("@EmployeeEntryDate", ToDBValue(employee.EmployeeEntryDate)),
					new SqlParameter("@EmployeeEmail", ToDBValue(employee.EmployeeEmail)),
					new SqlParameter("@EmployeeQQ", ToDBValue(employee.EmployeeQQ)),
					new SqlParameter("@EmployeeWeixin", ToDBValue(employee.EmployeeWeixin)),
					new SqlParameter("@EmployeeAddress", ToDBValue(employee.EmployeeAddress)),
					new SqlParameter("@EmployeeEducation", ToDBValue(employee.EmployeeEducation)),
					new SqlParameter("@EmployeeSchool", ToDBValue(employee.EmployeeSchool)),
					new SqlParameter("@EmployeeIDCode", ToDBValue(employee.EmployeeIDCode)),
					new SqlParameter("@EmployeeUsername", ToDBValue(employee.EmployeeUsername)),
					new SqlParameter("@EmployeeUserpass", ToDBValue(employee.EmployeeUserpass)),
					new SqlParameter("@RoleId", ToDBValue(employee.RoleId)),
					new SqlParameter("@EmployeeWages", ToDBValue(employee.EmployeeWages)),
					new SqlParameter("@Remark", ToDBValue(employee.Remark)),
					new SqlParameter("@State", ToDBValue(employee.State)),
					new SqlParameter("@Bank", ToDBValue(employee.Bank)),
					new SqlParameter("@BankCard", ToDBValue(employee.BankCard)),
					new SqlParameter("@CreateTime", ToDBValue(employee.CreateTime)),
					new SqlParameter("@ModifyTime", ToDBValue(employee.ModifyTime)),
				};
				
			int newId = Convert.ToInt32(SqlHelper.ExecuteScalar(sql, para));
			return newId;
		}

		/// <summary>
        /// 删除
        /// </summary>
        public int DeleteByEmployeeId(int employeeId)
		{
           SqlParameter[] paras = new SqlParameter[]
			{
				new SqlParameter("@EmployeeId", employeeId)
			};
		
           return SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "UP_Employee_DELETE", paras);
		}
		
				
		/// <summary>
        /// 修改
        /// </summary>
        public int Update(Employee employee)
        {
           SqlParameter[] paras = new SqlParameter[]
			{
				new SqlParameter("@EmployeeId", employee.EmployeeId)
					,new SqlParameter("@EmployeeName", ToDBValue(employee.EmployeeName))
					,new SqlParameter("@EmployeeSex", ToDBValue(employee.EmployeeSex))
					,new SqlParameter("@JobLevelId", ToDBValue(employee.JobLevelId))
					,new SqlParameter("@JobLevel", ToDBValue(employee.JobLevel))
					,new SqlParameter("@EmployeePhone", ToDBValue(employee.EmployeePhone))
					,new SqlParameter("@EmployeeBirthday", ToDBValue(employee.EmployeeBirthday))
					,new SqlParameter("@EmployeeEntryDate", ToDBValue(employee.EmployeeEntryDate))
					,new SqlParameter("@EmployeeEmail", ToDBValue(employee.EmployeeEmail))
					,new SqlParameter("@EmployeeQQ", ToDBValue(employee.EmployeeQQ))
					,new SqlParameter("@EmployeeWeixin", ToDBValue(employee.EmployeeWeixin))
					,new SqlParameter("@EmployeeAddress", ToDBValue(employee.EmployeeAddress))
					,new SqlParameter("@EmployeeEducation", ToDBValue(employee.EmployeeEducation))
					,new SqlParameter("@EmployeeSchool", ToDBValue(employee.EmployeeSchool))
					,new SqlParameter("@EmployeeIDCode", ToDBValue(employee.EmployeeIDCode))
					,new SqlParameter("@EmployeeUsername", ToDBValue(employee.EmployeeUsername))
					,new SqlParameter("@EmployeeUserpass", ToDBValue(employee.EmployeeUserpass))
					,new SqlParameter("@RoleId", ToDBValue(employee.RoleId))
					,new SqlParameter("@EmployeeWages", ToDBValue(employee.EmployeeWages))
					,new SqlParameter("@Remark", ToDBValue(employee.Remark))
					,new SqlParameter("@State", ToDBValue(employee.State))
					,new SqlParameter("@Bank", ToDBValue(employee.Bank))
					,new SqlParameter("@BankCard", ToDBValue(employee.BankCard))
					,new SqlParameter("@CreateTime", ToDBValue(employee.CreateTime))
					,new SqlParameter("@ModifyTime", ToDBValue(employee.ModifyTime))
			};

			  return SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "UP_Employee_UPDATE", paras);
        }
        /// <summary>
        /// 修改
        /// </summary>
		public int Update_V(Employee employee){
            string sql = "UPDATE Employee  SET ";
            
            string strSet=string.Empty;
            
            if(employee.EmployeeName != null)
                strSet+="EmployeeName = @EmployeeName," ;
                    
            if(employee.EmployeeSex != null)
                strSet+="EmployeeSex = @EmployeeSex," ;
                    
            if(employee.JobLevelId != null)
                strSet+="JobLevelId = @JobLevelId," ;
                    
            if(employee.JobLevel != null)
                strSet+="JobLevel = @JobLevel," ;
                    
            if(employee.EmployeePhone != null)
                strSet+="EmployeePhone = @EmployeePhone," ;
                    
            if(employee.EmployeeBirthday != null)
                strSet+="EmployeeBirthday = @EmployeeBirthday," ;
                    
            if(employee.EmployeeEntryDate != null)
                strSet+="EmployeeEntryDate = @EmployeeEntryDate," ;
                    
            if(employee.EmployeeEmail != null)
                strSet+="EmployeeEmail = @EmployeeEmail," ;
                    
            if(employee.EmployeeQQ != null)
                strSet+="EmployeeQQ = @EmployeeQQ," ;
                    
            if(employee.EmployeeWeixin != null)
                strSet+="EmployeeWeixin = @EmployeeWeixin," ;
                    
            if(employee.EmployeeAddress != null)
                strSet+="EmployeeAddress = @EmployeeAddress," ;
                    
            if(employee.EmployeeEducation != null)
                strSet+="EmployeeEducation = @EmployeeEducation," ;
                    
            if(employee.EmployeeSchool != null)
                strSet+="EmployeeSchool = @EmployeeSchool," ;
                    
            if(employee.EmployeeIDCode != null)
                strSet+="EmployeeIDCode = @EmployeeIDCode," ;
                    
            if(employee.EmployeeUsername != null)
                strSet+="EmployeeUsername = @EmployeeUsername," ;
                    
            if(employee.EmployeeUserpass != null)
                strSet+="EmployeeUserpass = @EmployeeUserpass," ;
                    
            if(employee.RoleId != null)
                strSet+="RoleId = @RoleId," ;
                    
            if(employee.EmployeeWages != null)
                strSet+="EmployeeWages = @EmployeeWages," ;
                    
            if(employee.Remark != null)
                strSet+="Remark = @Remark," ;
                    
            if(employee.State != null)
                strSet+="State = @State," ;
                    
            if(employee.Bank != null)
                strSet+="Bank = @Bank," ;
                    
            if(employee.BankCard != null)
                strSet+="BankCard = @BankCard," ;
                    
            if(employee.CreateTime != null)
                strSet+="CreateTime = @CreateTime," ;
                    
            if(employee.ModifyTime != null)
                strSet+="ModifyTime = @ModifyTime," ;
                    
            strSet = strSet.TrimEnd(',');
               
            sql=sql+ strSet+" WHERE EmployeeId = @EmployeeId";


			SqlParameter[] para = new SqlParameter[]
			{
				new SqlParameter("@EmployeeId", employee.EmployeeId)
					,new SqlParameter("@EmployeeName", ToDBValue(employee.EmployeeName))
					,new SqlParameter("@EmployeeSex", ToDBValue(employee.EmployeeSex))
					,new SqlParameter("@JobLevelId", ToDBValue(employee.JobLevelId))
					,new SqlParameter("@JobLevel", ToDBValue(employee.JobLevel))
					,new SqlParameter("@EmployeePhone", ToDBValue(employee.EmployeePhone))
					,new SqlParameter("@EmployeeBirthday", ToDBValue(employee.EmployeeBirthday))
					,new SqlParameter("@EmployeeEntryDate", ToDBValue(employee.EmployeeEntryDate))
					,new SqlParameter("@EmployeeEmail", ToDBValue(employee.EmployeeEmail))
					,new SqlParameter("@EmployeeQQ", ToDBValue(employee.EmployeeQQ))
					,new SqlParameter("@EmployeeWeixin", ToDBValue(employee.EmployeeWeixin))
					,new SqlParameter("@EmployeeAddress", ToDBValue(employee.EmployeeAddress))
					,new SqlParameter("@EmployeeEducation", ToDBValue(employee.EmployeeEducation))
					,new SqlParameter("@EmployeeSchool", ToDBValue(employee.EmployeeSchool))
					,new SqlParameter("@EmployeeIDCode", ToDBValue(employee.EmployeeIDCode))
					,new SqlParameter("@EmployeeUsername", ToDBValue(employee.EmployeeUsername))
					,new SqlParameter("@EmployeeUserpass", ToDBValue(employee.EmployeeUserpass))
					,new SqlParameter("@RoleId", ToDBValue(employee.RoleId))
					,new SqlParameter("@EmployeeWages", ToDBValue(employee.EmployeeWages))
					,new SqlParameter("@Remark", ToDBValue(employee.Remark))
					,new SqlParameter("@State", ToDBValue(employee.State))
					,new SqlParameter("@Bank", ToDBValue(employee.Bank))
					,new SqlParameter("@BankCard", ToDBValue(employee.BankCard))
					,new SqlParameter("@CreateTime", ToDBValue(employee.CreateTime))
					,new SqlParameter("@ModifyTime", ToDBValue(employee.ModifyTime))
			};

			return SqlHelper.ExecuteNonQuery(sql, para);
        }
		/// <summary>
        /// 通过主键 EmployeeId  得到实体
        /// </summary>
        public Employee GetByEmployeeId(int employeeId)
        {
            string sql = "EmployeeId = "+employeeId;
            
            DataTable dt = GetAll("*",sql,"");
            if (dt.Rows.Count > 0)
                return new Employee(dt.Rows[0]);
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
            string table = "Employee";
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
            string table = "vEmployee";
            if (string.IsNullOrWhiteSpace(sel_ord))
            {
                sel_ord = " EmployeeId desc";
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

            string table = "vEmployee";
            if (string.IsNullOrWhiteSpace(sel_ord))
            {
                sel_ord = " EmployeeId desc";
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
            string table = "vEmployee";
            if (string.IsNullOrWhiteSpace(sel_ord))
            {
                sel_ord = "  EmployeeId desc";
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