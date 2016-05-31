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
	public partial class SectionInfoDAL
	{
		/// <summary>
        /// 添加
        /// </summary>
        public int INSERT(SectionInfo sectionInfo)
		{	
			SqlParameter[] paras = new SqlParameter[]
				{
					new SqlParameter("@SectionCode", ToDBValue(sectionInfo.SectionCode)),
					new SqlParameter("@ContractPrice", ToDBValue(sectionInfo.ContractPrice)),
					new SqlParameter("@ControlPrice", ToDBValue(sectionInfo.ControlPrice)),
					new SqlParameter("@SectionContext", ToDBValue(sectionInfo.SectionContext)),
					new SqlParameter("@SectionName", ToDBValue(sectionInfo.SectionName)),
					new SqlParameter("@UnitQualificationId", ToDBValue(sectionInfo.UnitQualificationId)),
					new SqlParameter("@UnitQName", ToDBValue(sectionInfo.UnitQName)),
					new SqlParameter("@UserQualificationsId", ToDBValue(sectionInfo.UserQualificationsId)),
					new SqlParameter("@UserQName", ToDBValue(sectionInfo.UserQName)),
					new SqlParameter("@Remark", ToDBValue(sectionInfo.Remark)),
					new SqlParameter("@BookPrice", ToDBValue(sectionInfo.BookPrice)),
					new SqlParameter("@BookStarDate", ToDBValue(sectionInfo.BookStarDate)),
					new SqlParameter("@BookEndDate", ToDBValue(sectionInfo.BookEndDate)),
					new SqlParameter("@NoticePrice", ToDBValue(sectionInfo.NoticePrice)),
					new SqlParameter("@FileStarDate", ToDBValue(sectionInfo.FileStarDate)),
					new SqlParameter("@FileEndDate", ToDBValue(sectionInfo.FileEndDate)),
					new SqlParameter("@CheckStatu", ToDBValue(sectionInfo.CheckStatu)),
					new SqlParameter("@ProjectId", ToDBValue(sectionInfo.ProjectId)),
					new SqlParameter("@EmployeeId", ToDBValue(sectionInfo.EmployeeId)),
					new SqlParameter("@CreateTime", ToDBValue(sectionInfo.CreateTime)),
				};
             
			 return Convert.ToInt32(SqlHelper.ExecuteScalar(CommandType.StoredProcedure, "UP_SectionInfo_INSERT", paras));
		}
        /// <summary>
        /// 添加
        /// </summary>
        public int INSERT_V(SectionInfo sectionInfo)
		{	
			string sql =@"INSERT INTO SectionInfo (SectionCode,
						ContractPrice,
						ControlPrice,
						SectionContext,
						SectionName,
						UnitQualificationId,
						UnitQName,
						UserQualificationsId,
						UserQName,
						Remark,
						BookPrice,
						BookStarDate,
						BookEndDate,
						NoticePrice,
						FileStarDate,
						FileEndDate,
						CheckStatu,
						ProjectId,
						EmployeeId,
						CreateTime
						) VALUES (
						@SectionCode,
						@ContractPrice,
						@ControlPrice,
						@SectionContext,
						@SectionName,
						@UnitQualificationId,
						@UnitQName,
						@UserQualificationsId,
						@UserQName,
						@Remark,
						@BookPrice,
						@BookStarDate,
						@BookEndDate,
						@NoticePrice,
						@FileStarDate,
						@FileEndDate,
						@CheckStatu,
						@ProjectId,
						@EmployeeId,
						@CreateTime
						) select SCOPE_IDENTITY()";
			SqlParameter[] para = new SqlParameter[]
				{
					new SqlParameter("@SectionCode", ToDBValue(sectionInfo.SectionCode)),
					new SqlParameter("@ContractPrice", ToDBValue(sectionInfo.ContractPrice)),
					new SqlParameter("@ControlPrice", ToDBValue(sectionInfo.ControlPrice)),
					new SqlParameter("@SectionContext", ToDBValue(sectionInfo.SectionContext)),
					new SqlParameter("@SectionName", ToDBValue(sectionInfo.SectionName)),
					new SqlParameter("@UnitQualificationId", ToDBValue(sectionInfo.UnitQualificationId)),
					new SqlParameter("@UnitQName", ToDBValue(sectionInfo.UnitQName)),
					new SqlParameter("@UserQualificationsId", ToDBValue(sectionInfo.UserQualificationsId)),
					new SqlParameter("@UserQName", ToDBValue(sectionInfo.UserQName)),
					new SqlParameter("@Remark", ToDBValue(sectionInfo.Remark)),
					new SqlParameter("@BookPrice", ToDBValue(sectionInfo.BookPrice)),
					new SqlParameter("@BookStarDate", ToDBValue(sectionInfo.BookStarDate)),
					new SqlParameter("@BookEndDate", ToDBValue(sectionInfo.BookEndDate)),
					new SqlParameter("@NoticePrice", ToDBValue(sectionInfo.NoticePrice)),
					new SqlParameter("@FileStarDate", ToDBValue(sectionInfo.FileStarDate)),
					new SqlParameter("@FileEndDate", ToDBValue(sectionInfo.FileEndDate)),
					new SqlParameter("@CheckStatu", ToDBValue(sectionInfo.CheckStatu)),
					new SqlParameter("@ProjectId", ToDBValue(sectionInfo.ProjectId)),
					new SqlParameter("@EmployeeId", ToDBValue(sectionInfo.EmployeeId)),
					new SqlParameter("@CreateTime", ToDBValue(sectionInfo.CreateTime)),
				};
				
			int newId = Convert.ToInt32(SqlHelper.ExecuteScalar(sql, para));
			return newId;
		}

		/// <summary>
        /// 删除
        /// </summary>
        public int DeleteBySectionId(int sectionId)
		{
           SqlParameter[] paras = new SqlParameter[]
			{
				new SqlParameter("@SectionId", sectionId)
			};
		
           return SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "UP_SectionInfo_DELETE", paras);
		}
		
				
		/// <summary>
        /// 修改
        /// </summary>
        public int Update(SectionInfo sectionInfo)
        {
           SqlParameter[] paras = new SqlParameter[]
			{
				new SqlParameter("@SectionId", sectionInfo.SectionId)
					,new SqlParameter("@SectionCode", ToDBValue(sectionInfo.SectionCode))
					,new SqlParameter("@ContractPrice", ToDBValue(sectionInfo.ContractPrice))
					,new SqlParameter("@ControlPrice", ToDBValue(sectionInfo.ControlPrice))
					,new SqlParameter("@SectionContext", ToDBValue(sectionInfo.SectionContext))
					,new SqlParameter("@SectionName", ToDBValue(sectionInfo.SectionName))
					,new SqlParameter("@UnitQualificationId", ToDBValue(sectionInfo.UnitQualificationId))
					,new SqlParameter("@UnitQName", ToDBValue(sectionInfo.UnitQName))
					,new SqlParameter("@UserQualificationsId", ToDBValue(sectionInfo.UserQualificationsId))
					,new SqlParameter("@UserQName", ToDBValue(sectionInfo.UserQName))
					,new SqlParameter("@Remark", ToDBValue(sectionInfo.Remark))
					,new SqlParameter("@BookPrice", ToDBValue(sectionInfo.BookPrice))
					,new SqlParameter("@BookStarDate", ToDBValue(sectionInfo.BookStarDate))
					,new SqlParameter("@BookEndDate", ToDBValue(sectionInfo.BookEndDate))
					,new SqlParameter("@NoticePrice", ToDBValue(sectionInfo.NoticePrice))
					,new SqlParameter("@FileStarDate", ToDBValue(sectionInfo.FileStarDate))
					,new SqlParameter("@FileEndDate", ToDBValue(sectionInfo.FileEndDate))
					,new SqlParameter("@CheckStatu", ToDBValue(sectionInfo.CheckStatu))
					,new SqlParameter("@ProjectId", ToDBValue(sectionInfo.ProjectId))
					,new SqlParameter("@EmployeeId", ToDBValue(sectionInfo.EmployeeId))
					,new SqlParameter("@CreateTime", ToDBValue(sectionInfo.CreateTime))
			};

			  return SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "UP_SectionInfo_UPDATE", paras);
        }
        /// <summary>
        /// 修改
        /// </summary>
		public int Update_V(SectionInfo sectionInfo){
            string sql = "UPDATE SectionInfo  SET ";
            
            string strSet=string.Empty;
            
            if(sectionInfo.SectionCode != null)
                strSet+="SectionCode = @SectionCode," ;
                    
            if(sectionInfo.ContractPrice != null)
                strSet+="ContractPrice = @ContractPrice," ;
                    
            if(sectionInfo.ControlPrice != null)
                strSet+="ControlPrice = @ControlPrice," ;
                    
            if(sectionInfo.SectionContext != null)
                strSet+="SectionContext = @SectionContext," ;
                    
            if(sectionInfo.SectionName != null)
                strSet+="SectionName = @SectionName," ;
                    
            if(sectionInfo.UnitQualificationId != null)
                strSet+="UnitQualificationId = @UnitQualificationId," ;
                    
            if(sectionInfo.UnitQName != null)
                strSet+="UnitQName = @UnitQName," ;
                    
            if(sectionInfo.UserQualificationsId != null)
                strSet+="UserQualificationsId = @UserQualificationsId," ;
                    
            if(sectionInfo.UserQName != null)
                strSet+="UserQName = @UserQName," ;
                    
            if(sectionInfo.Remark != null)
                strSet+="Remark = @Remark," ;
                    
            if(sectionInfo.BookPrice != null)
                strSet+="BookPrice = @BookPrice," ;
                    
            if(sectionInfo.BookStarDate != null)
                strSet+="BookStarDate = @BookStarDate," ;
                    
            if(sectionInfo.BookEndDate != null)
                strSet+="BookEndDate = @BookEndDate," ;
                    
            if(sectionInfo.NoticePrice != null)
                strSet+="NoticePrice = @NoticePrice," ;
                    
            if(sectionInfo.FileStarDate != null)
                strSet+="FileStarDate = @FileStarDate," ;
                    
            if(sectionInfo.FileEndDate != null)
                strSet+="FileEndDate = @FileEndDate," ;
                    
            if(sectionInfo.CheckStatu != null)
                strSet+="CheckStatu = @CheckStatu," ;
                    
            if(sectionInfo.ProjectId != null)
                strSet+="ProjectId = @ProjectId," ;
                    
            if(sectionInfo.EmployeeId != null)
                strSet+="EmployeeId = @EmployeeId," ;
                    
            if(sectionInfo.CreateTime != null)
                strSet+="CreateTime = @CreateTime," ;
                    
            strSet = strSet.TrimEnd(',');
               
            sql=sql+ strSet+" WHERE SectionId = @SectionId";


			SqlParameter[] para = new SqlParameter[]
			{
				new SqlParameter("@SectionId", sectionInfo.SectionId)
					,new SqlParameter("@SectionCode", ToDBValue(sectionInfo.SectionCode))
					,new SqlParameter("@ContractPrice", ToDBValue(sectionInfo.ContractPrice))
					,new SqlParameter("@ControlPrice", ToDBValue(sectionInfo.ControlPrice))
					,new SqlParameter("@SectionContext", ToDBValue(sectionInfo.SectionContext))
					,new SqlParameter("@SectionName", ToDBValue(sectionInfo.SectionName))
					,new SqlParameter("@UnitQualificationId", ToDBValue(sectionInfo.UnitQualificationId))
					,new SqlParameter("@UnitQName", ToDBValue(sectionInfo.UnitQName))
					,new SqlParameter("@UserQualificationsId", ToDBValue(sectionInfo.UserQualificationsId))
					,new SqlParameter("@UserQName", ToDBValue(sectionInfo.UserQName))
					,new SqlParameter("@Remark", ToDBValue(sectionInfo.Remark))
					,new SqlParameter("@BookPrice", ToDBValue(sectionInfo.BookPrice))
					,new SqlParameter("@BookStarDate", ToDBValue(sectionInfo.BookStarDate))
					,new SqlParameter("@BookEndDate", ToDBValue(sectionInfo.BookEndDate))
					,new SqlParameter("@NoticePrice", ToDBValue(sectionInfo.NoticePrice))
					,new SqlParameter("@FileStarDate", ToDBValue(sectionInfo.FileStarDate))
					,new SqlParameter("@FileEndDate", ToDBValue(sectionInfo.FileEndDate))
					,new SqlParameter("@CheckStatu", ToDBValue(sectionInfo.CheckStatu))
					,new SqlParameter("@ProjectId", ToDBValue(sectionInfo.ProjectId))
					,new SqlParameter("@EmployeeId", ToDBValue(sectionInfo.EmployeeId))
					,new SqlParameter("@CreateTime", ToDBValue(sectionInfo.CreateTime))
			};

			return SqlHelper.ExecuteNonQuery(sql, para);
        }
		/// <summary>
        /// 通过主键 SectionId  得到实体
        /// </summary>
        public SectionInfo GetBySectionId(int sectionId)
        {
            string sql = "SectionId = "+sectionId;
            
            DataTable dt = GetAll("*",sql,"");
            if (dt.Rows.Count > 0)
                return new SectionInfo(dt.Rows[0]);
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
            string table = "SectionInfo";
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
            string table = "SectionInfo";
            if (string.IsNullOrWhiteSpace(sel_ord))
            {
                sel_ord = " SectionId desc";
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

            string table = "SectionInfo";
            if (string.IsNullOrWhiteSpace(sel_ord))
            {
                sel_ord = " SectionId desc";
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
            string table = "SectionInfo";
            if (string.IsNullOrWhiteSpace(sel_ord))
            {
                sel_ord = "  SectionId desc";
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
