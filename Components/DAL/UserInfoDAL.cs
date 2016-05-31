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
	public partial class UserInfoDAL
	{
		/// <summary>
        /// 添加
        /// </summary>
        public int INSERT(UserInfo userInfo)
		{	
			SqlParameter[] paras = new SqlParameter[]
				{
					new SqlParameter("@UserName", ToDBValue(userInfo.UserName)),
					new SqlParameter("@Sex", ToDBValue(userInfo.Sex)),
					new SqlParameter("@BirthDay", ToDBValue(userInfo.BirthDay)),
					new SqlParameter("@UserNum", ToDBValue(userInfo.UserNum)),
					new SqlParameter("@PhoneNum", ToDBValue(userInfo.PhoneNum)),
					new SqlParameter("@Address", ToDBValue(userInfo.Address)),
					new SqlParameter("@Position", ToDBValue(userInfo.Position)),
					new SqlParameter("@Remark", ToDBValue(userInfo.Remark)),
					new SqlParameter("@EmployeeId", ToDBValue(userInfo.EmployeeId)),
					new SqlParameter("@CreateTime", ToDBValue(userInfo.CreateTime)),
				};
             
			 return Convert.ToInt32(SqlHelper.ExecuteScalar(CommandType.StoredProcedure, "UP_UserInfo_INSERT", paras));
		}
        /// <summary>
        /// 添加
        /// </summary>
        public int INSERT_V(UserInfo userInfo)
		{	
			string sql =@"INSERT INTO UserInfo (UserName,
						Sex,
						BirthDay,
						UserNum,
						PhoneNum,
						Address,
						Position,
						Remark,
						EmployeeId,
						CreateTime
						) VALUES (
						@UserName,
						@Sex,
						@BirthDay,
						@UserNum,
						@PhoneNum,
						@Address,
						@Position,
						@Remark,
						@EmployeeId,
						@CreateTime
						) select SCOPE_IDENTITY()";
			SqlParameter[] para = new SqlParameter[]
				{
					new SqlParameter("@UserName", ToDBValue(userInfo.UserName)),
					new SqlParameter("@Sex", ToDBValue(userInfo.Sex)),
					new SqlParameter("@BirthDay", ToDBValue(userInfo.BirthDay)),
					new SqlParameter("@UserNum", ToDBValue(userInfo.UserNum)),
					new SqlParameter("@PhoneNum", ToDBValue(userInfo.PhoneNum)),
					new SqlParameter("@Address", ToDBValue(userInfo.Address)),
					new SqlParameter("@Position", ToDBValue(userInfo.Position)),
					new SqlParameter("@Remark", ToDBValue(userInfo.Remark)),
					new SqlParameter("@EmployeeId", ToDBValue(userInfo.EmployeeId)),
					new SqlParameter("@CreateTime", ToDBValue(userInfo.CreateTime)),
				};
				
			int newId = Convert.ToInt32(SqlHelper.ExecuteScalar(sql, para));
			return newId;
		}

		/// <summary>
        /// 删除
        /// </summary>
        public int DeleteByUserId(int userId)
		{
           SqlParameter[] paras = new SqlParameter[]
			{
				new SqlParameter("@UserId", userId)
			};
		
           return SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "UP_UserInfo_DELETE", paras);
		}
		
				
		/// <summary>
        /// 修改
        /// </summary>
        public int Update(UserInfo userInfo)
        {
           SqlParameter[] paras = new SqlParameter[]
			{
				new SqlParameter("@UserId", userInfo.UserId)
					,new SqlParameter("@UserName", ToDBValue(userInfo.UserName))
					,new SqlParameter("@Sex", ToDBValue(userInfo.Sex))
					,new SqlParameter("@BirthDay", ToDBValue(userInfo.BirthDay))
					,new SqlParameter("@UserNum", ToDBValue(userInfo.UserNum))
					,new SqlParameter("@PhoneNum", ToDBValue(userInfo.PhoneNum))
					,new SqlParameter("@Address", ToDBValue(userInfo.Address))
					,new SqlParameter("@Position", ToDBValue(userInfo.Position))
					,new SqlParameter("@Remark", ToDBValue(userInfo.Remark))
					,new SqlParameter("@EmployeeId", ToDBValue(userInfo.EmployeeId))
					,new SqlParameter("@CreateTime", ToDBValue(userInfo.CreateTime))
			};

			  return SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "UP_UserInfo_UPDATE", paras);
        }
        /// <summary>
        /// 修改
        /// </summary>
		public int Update_V(UserInfo userInfo){
            string sql = "UPDATE UserInfo  SET ";
            
            string strSet=string.Empty;
            
            if(userInfo.UserName != null)
                strSet+="UserName = @UserName," ;
                    
            if(userInfo.Sex != null)
                strSet+="Sex = @Sex," ;
                    
            if(userInfo.BirthDay != null)
                strSet+="BirthDay = @BirthDay," ;
                    
            if(userInfo.UserNum != null)
                strSet+="UserNum = @UserNum," ;
                    
            if(userInfo.PhoneNum != null)
                strSet+="PhoneNum = @PhoneNum," ;
                    
            if(userInfo.Address != null)
                strSet+="Address = @Address," ;
                    
            if(userInfo.Position != null)
                strSet+="Position = @Position," ;
                    
            if(userInfo.Remark != null)
                strSet+="Remark = @Remark," ;
                    
            if(userInfo.EmployeeId != null)
                strSet+="EmployeeId = @EmployeeId," ;
                    
            if(userInfo.CreateTime != null)
                strSet+="CreateTime = @CreateTime," ;
                    
            strSet = strSet.TrimEnd(',');
               
            sql=sql+ strSet+" WHERE UserId = @UserId";


			SqlParameter[] para = new SqlParameter[]
			{
				new SqlParameter("@UserId", userInfo.UserId)
					,new SqlParameter("@UserName", ToDBValue(userInfo.UserName))
					,new SqlParameter("@Sex", ToDBValue(userInfo.Sex))
					,new SqlParameter("@BirthDay", ToDBValue(userInfo.BirthDay))
					,new SqlParameter("@UserNum", ToDBValue(userInfo.UserNum))
					,new SqlParameter("@PhoneNum", ToDBValue(userInfo.PhoneNum))
					,new SqlParameter("@Address", ToDBValue(userInfo.Address))
					,new SqlParameter("@Position", ToDBValue(userInfo.Position))
					,new SqlParameter("@Remark", ToDBValue(userInfo.Remark))
					,new SqlParameter("@EmployeeId", ToDBValue(userInfo.EmployeeId))
					,new SqlParameter("@CreateTime", ToDBValue(userInfo.CreateTime))
			};

			return SqlHelper.ExecuteNonQuery(sql, para);
        }
		/// <summary>
        /// 通过主键 UserId  得到实体
        /// </summary>
        public UserInfo GetByUserId(int userId)
        {
            string sql = "UserId = "+userId;
            
            DataTable dt = GetAll("*",sql,"");
            if (dt.Rows.Count > 0)
                return new UserInfo(dt.Rows[0]);
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
            string table = "UserInfo";
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
            string table = "UserInfo";
            if (string.IsNullOrWhiteSpace(sel_ord))
            {
                sel_ord = " UserId desc";
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

            string table = "UserInfo";
            if (string.IsNullOrWhiteSpace(sel_ord))
            {
                sel_ord = " UserId desc";
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
            string table = "UserInfo";
            if (string.IsNullOrWhiteSpace(sel_ord))
            {
                sel_ord = "  UserId desc";
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
