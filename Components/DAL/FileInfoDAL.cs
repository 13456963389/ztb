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
	public partial class FileInfoDAL
	{
		/// <summary>
        /// 添加
        /// </summary>
        public int INSERT(FileInfo fileInfo)
		{	
			SqlParameter[] paras = new SqlParameter[]
				{
					new SqlParameter("@FileName", ToDBValue(fileInfo.FileName)),
					new SqlParameter("@FileUrl", ToDBValue(fileInfo.FileUrl)),
					new SqlParameter("@FileType", ToDBValue(fileInfo.FileType)),
					new SqlParameter("@BusinessId", ToDBValue(fileInfo.BusinessId)),
					new SqlParameter("@KZM", ToDBValue(fileInfo.KZM)),
					new SqlParameter("@FileSize", ToDBValue(fileInfo.FileSize)),
					new SqlParameter("@EmployeeId", ToDBValue(fileInfo.EmployeeId)),
					new SqlParameter("@CreateTime", ToDBValue(fileInfo.CreateTime)),
					new SqlParameter("@UnitId", ToDBValue(fileInfo.UnitId)),
					new SqlParameter("@DjTime", ToDBValue(fileInfo.DjTime)),
				};
             
			 return Convert.ToInt32(SqlHelper.ExecuteScalar(CommandType.StoredProcedure, "UP_FileInfo_INSERT", paras));
		}
        /// <summary>
        /// 添加
        /// </summary>
        public int INSERT_V(FileInfo fileInfo)
		{	
			string sql =@"INSERT INTO FileInfo (FileName,
						FileUrl,
						FileType,
						BusinessId,
						KZM,
						FileSize,
						EmployeeId,
						CreateTime,
						UnitId,
						DjTime
						) VALUES (
						@FileName,
						@FileUrl,
						@FileType,
						@BusinessId,
						@KZM,
						@FileSize,
						@EmployeeId,
						@CreateTime,
						@UnitId,
						@DjTime
						) select SCOPE_IDENTITY()";
			SqlParameter[] para = new SqlParameter[]
				{
					new SqlParameter("@FileName", ToDBValue(fileInfo.FileName)),
					new SqlParameter("@FileUrl", ToDBValue(fileInfo.FileUrl)),
					new SqlParameter("@FileType", ToDBValue(fileInfo.FileType)),
					new SqlParameter("@BusinessId", ToDBValue(fileInfo.BusinessId)),
					new SqlParameter("@KZM", ToDBValue(fileInfo.KZM)),
					new SqlParameter("@FileSize", ToDBValue(fileInfo.FileSize)),
					new SqlParameter("@EmployeeId", ToDBValue(fileInfo.EmployeeId)),
					new SqlParameter("@CreateTime", ToDBValue(fileInfo.CreateTime)),
					new SqlParameter("@UnitId", ToDBValue(fileInfo.UnitId)),
					new SqlParameter("@DjTime", ToDBValue(fileInfo.DjTime)),
				};
				
			int newId = Convert.ToInt32(SqlHelper.ExecuteScalar(sql, para));
			return newId;
		}

		/// <summary>
        /// 删除
        /// </summary>
        public int DeleteByFileId(int fileId)
		{
           SqlParameter[] paras = new SqlParameter[]
			{
				new SqlParameter("@FileId", fileId)
			};
		
           return SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "UP_FileInfo_DELETE", paras);
		}
		
				
		/// <summary>
        /// 修改
        /// </summary>
        public int Update(FileInfo fileInfo)
        {
           SqlParameter[] paras = new SqlParameter[]
			{
				new SqlParameter("@FileId", fileInfo.FileId)
					,new SqlParameter("@FileName", ToDBValue(fileInfo.FileName))
					,new SqlParameter("@FileUrl", ToDBValue(fileInfo.FileUrl))
					,new SqlParameter("@FileType", ToDBValue(fileInfo.FileType))
					,new SqlParameter("@BusinessId", ToDBValue(fileInfo.BusinessId))
					,new SqlParameter("@KZM", ToDBValue(fileInfo.KZM))
					,new SqlParameter("@FileSize", ToDBValue(fileInfo.FileSize))
					,new SqlParameter("@EmployeeId", ToDBValue(fileInfo.EmployeeId))
					,new SqlParameter("@CreateTime", ToDBValue(fileInfo.CreateTime))
					,new SqlParameter("@UnitId", ToDBValue(fileInfo.UnitId))
					,new SqlParameter("@DjTime", ToDBValue(fileInfo.DjTime))
			};

			  return SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "UP_FileInfo_UPDATE", paras);
        }
        /// <summary>
        /// 修改
        /// </summary>
		public int Update_V(FileInfo fileInfo){
            string sql = "UPDATE FileInfo  SET ";
            
            string strSet=string.Empty;
            
            if(fileInfo.FileName != null)
                strSet+="FileName = @FileName," ;
                    
            if(fileInfo.FileUrl != null)
                strSet+="FileUrl = @FileUrl," ;
                    
            if(fileInfo.FileType != null)
                strSet+="FileType = @FileType," ;
                    
            if(fileInfo.BusinessId != null)
                strSet+="BusinessId = @BusinessId," ;
                    
            if(fileInfo.KZM != null)
                strSet+="KZM = @KZM," ;
                    
            if(fileInfo.FileSize != null)
                strSet+="FileSize = @FileSize," ;
                    
            if(fileInfo.EmployeeId != null)
                strSet+="EmployeeId = @EmployeeId," ;
                    
            if(fileInfo.CreateTime != null)
                strSet+="CreateTime = @CreateTime," ;
                    
            if(fileInfo.UnitId != null)
                strSet+="UnitId = @UnitId," ;
                    
            if(fileInfo.DjTime != null)
                strSet+="DjTime = @DjTime," ;
                    
            strSet = strSet.TrimEnd(',');
               
            sql=sql+ strSet+" WHERE FileId = @FileId";


			SqlParameter[] para = new SqlParameter[]
			{
				new SqlParameter("@FileId", fileInfo.FileId)
					,new SqlParameter("@FileName", ToDBValue(fileInfo.FileName))
					,new SqlParameter("@FileUrl", ToDBValue(fileInfo.FileUrl))
					,new SqlParameter("@FileType", ToDBValue(fileInfo.FileType))
					,new SqlParameter("@BusinessId", ToDBValue(fileInfo.BusinessId))
					,new SqlParameter("@KZM", ToDBValue(fileInfo.KZM))
					,new SqlParameter("@FileSize", ToDBValue(fileInfo.FileSize))
					,new SqlParameter("@EmployeeId", ToDBValue(fileInfo.EmployeeId))
					,new SqlParameter("@CreateTime", ToDBValue(fileInfo.CreateTime))
					,new SqlParameter("@UnitId", ToDBValue(fileInfo.UnitId))
					,new SqlParameter("@DjTime", ToDBValue(fileInfo.DjTime))
			};

			return SqlHelper.ExecuteNonQuery(sql, para);
        }
		/// <summary>
        /// 通过主键 FileId  得到实体
        /// </summary>
        public FileInfo GetByFileId(int fileId)
        {
            string sql = "FileId = "+fileId;
            
            DataTable dt = GetAll("*",sql,"");
            if (dt.Rows.Count > 0)
                return new FileInfo(dt.Rows[0]);
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
            string table = "FileInfo";
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
            string table = "FileInfo";
            if (string.IsNullOrWhiteSpace(sel_ord))
            {
                sel_ord = " FileId desc";
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

            string table = "FileInfo";
            if (string.IsNullOrWhiteSpace(sel_ord))
            {
                sel_ord = " FileId desc";
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
            string table = "FileInfo";
            if (string.IsNullOrWhiteSpace(sel_ord))
            {
                sel_ord = "  FileId desc";
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
