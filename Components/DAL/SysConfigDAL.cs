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
	public partial class SysConfigDAL
	{
		/// <summary>
        /// 添加
        /// </summary>
        public int INSERT(SysConfig sysConfig)
		{	
			SqlParameter[] paras = new SqlParameter[]
				{
					new SqlParameter("@ConfigCode", ToDBValue(sysConfig.ConfigCode)),
					new SqlParameter("@ConfigName", ToDBValue(sysConfig.ConfigName)),
					new SqlParameter("@ConfigValue", ToDBValue(sysConfig.ConfigValue)),
					new SqlParameter("@Remark", ToDBValue(sysConfig.Remark)),
				};
             
			 return Convert.ToInt32(SqlHelper.ExecuteScalar(CommandType.StoredProcedure, "UP_SysConfig_INSERT", paras));
		}
        /// <summary>
        /// 添加
        /// </summary>
        public int INSERT_V(SysConfig sysConfig)
		{	
			string sql =@"INSERT INTO SysConfig (ConfigCode,
						ConfigName,
						ConfigValue,
						Remark
						) VALUES (
						@ConfigCode,
						@ConfigName,
						@ConfigValue,
						@Remark
						) select SCOPE_IDENTITY()";
			SqlParameter[] para = new SqlParameter[]
				{
					new SqlParameter("@ConfigCode", ToDBValue(sysConfig.ConfigCode)),
					new SqlParameter("@ConfigName", ToDBValue(sysConfig.ConfigName)),
					new SqlParameter("@ConfigValue", ToDBValue(sysConfig.ConfigValue)),
					new SqlParameter("@Remark", ToDBValue(sysConfig.Remark)),
				};
				
			int newId = Convert.ToInt32(SqlHelper.ExecuteScalar(sql, para));
			return newId;
		}

		/// <summary>
        /// 删除
        /// </summary>
        public int DeleteByConfigId(int configId)
		{
           SqlParameter[] paras = new SqlParameter[]
			{
				new SqlParameter("@ConfigId", configId)
			};
		
           return SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "UP_SysConfig_DELETE", paras);
		}
		
				
		/// <summary>
        /// 修改
        /// </summary>
        public int Update(SysConfig sysConfig)
        {
           SqlParameter[] paras = new SqlParameter[]
			{
				new SqlParameter("@ConfigId", sysConfig.ConfigId)
					,new SqlParameter("@ConfigCode", ToDBValue(sysConfig.ConfigCode))
					,new SqlParameter("@ConfigName", ToDBValue(sysConfig.ConfigName))
					,new SqlParameter("@ConfigValue", ToDBValue(sysConfig.ConfigValue))
					,new SqlParameter("@Remark", ToDBValue(sysConfig.Remark))
			};

			  return SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "UP_SysConfig_UPDATE", paras);
        }
        /// <summary>
        /// 修改
        /// </summary>
		public int Update_V(SysConfig sysConfig){
            string sql = "UPDATE SysConfig  SET ";
            
            string strSet=string.Empty;
            
            if(sysConfig.ConfigCode != null)
                strSet+="ConfigCode = @ConfigCode," ;
                    
            if(sysConfig.ConfigName != null)
                strSet+="ConfigName = @ConfigName," ;
                    
            if(sysConfig.ConfigValue != null)
                strSet+="ConfigValue = @ConfigValue," ;
                    
            if(sysConfig.Remark != null)
                strSet+="Remark = @Remark," ;
                    
            strSet = strSet.TrimEnd(',');
               
            sql=sql+ strSet+" WHERE ConfigId = @ConfigId";


			SqlParameter[] para = new SqlParameter[]
			{
				new SqlParameter("@ConfigId", sysConfig.ConfigId)
					,new SqlParameter("@ConfigCode", ToDBValue(sysConfig.ConfigCode))
					,new SqlParameter("@ConfigName", ToDBValue(sysConfig.ConfigName))
					,new SqlParameter("@ConfigValue", ToDBValue(sysConfig.ConfigValue))
					,new SqlParameter("@Remark", ToDBValue(sysConfig.Remark))
			};

			return SqlHelper.ExecuteNonQuery(sql, para);
        }
		/// <summary>
        /// 通过主键 ConfigId  得到实体
        /// </summary>
        public SysConfig GetByConfigId(int configId)
        {
            string sql = "ConfigId = "+configId;
            
            DataTable dt = GetAll("*",sql,"");
            if (dt.Rows.Count > 0)
                return new SysConfig(dt.Rows[0]);
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
            string table = "SysConfig";
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
            string table = "SysConfig";
            if (string.IsNullOrWhiteSpace(sel_ord))
            {
                sel_ord = " ConfigId desc";
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

            string table = "SysConfig";
            if (string.IsNullOrWhiteSpace(sel_ord))
            {
                sel_ord = " ConfigId desc";
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
            string table = "SysConfig";
            if (string.IsNullOrWhiteSpace(sel_ord))
            {
                sel_ord = "  ConfigId desc";
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
