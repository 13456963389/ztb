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
    public partial class JobLevelDAL
    {
        /// <summary>
        /// 添加
        /// </summary>
        public int INSERT(JobLevel jobLevel)
        {
            SqlParameter[] paras = new SqlParameter[]
				{
					new SqlParameter("@JobLevelName", ToDBValue(jobLevel.JobLevelName)),
					new SqlParameter("@State", ToDBValue(jobLevel.State)),
					new SqlParameter("@Remark", ToDBValue(jobLevel.Remark)),
                    new SqlParameter("@jobLevelDcmID",ToDBValue(jobLevel.jobLevelDcmID))
				};

            return Convert.ToInt32(SqlHelper.ExecuteScalar(CommandType.StoredProcedure, "UP_JobLevel_INSERT", paras));
        }
        /// <summary>
        /// 添加
        /// </summary>
        public int INSERT_V(JobLevel jobLevel)
        {
            string sql = @"INSERT INTO JobLevel (JobLevelName,
						State,
						Remark,
                        jobLevelDcmID
						) VALUES (
						@JobLevelName,
						@State,
						@Remark,
                        @jobLevelDcmID
						) select SCOPE_IDENTITY()";
            SqlParameter[] para = new SqlParameter[]
				{
					new SqlParameter("@JobLevelName", ToDBValue(jobLevel.JobLevelName)),
					new SqlParameter("@State", ToDBValue(jobLevel.State)),
					new SqlParameter("@Remark", ToDBValue(jobLevel.Remark)),
                    new SqlParameter("@jobLevelDcmID",ToDBValue(jobLevel.jobLevelDcmID))
				};

            int newId = Convert.ToInt32(SqlHelper.ExecuteScalar(sql, para));
            return newId;
        }

        /// <summary>
        /// 删除
        /// </summary>
        public int DeleteByJobLevelId(int jobLevelId)
        {
            SqlParameter[] paras = new SqlParameter[]
			{
				new SqlParameter("@JobLevelId", jobLevelId)
			};

            return SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "UP_JobLevel_DELETE", paras);
        }


        /// <summary>
        /// 修改
        /// </summary>
        public int Update(JobLevel jobLevel)
        {
            SqlParameter[] paras = new SqlParameter[]
			{
				new SqlParameter("@JobLevelId", jobLevel.JobLevelId)
					,new SqlParameter("@JobLevelName", ToDBValue(jobLevel.JobLevelName))
					,new SqlParameter("@State", ToDBValue(jobLevel.State))
					,new SqlParameter("@Remark", ToDBValue(jobLevel.Remark))
                    ,new SqlParameter("@jobLevelDcmID",ToDBValue(jobLevel.jobLevelDcmID))
			};

            return SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "UP_JobLevel_UPDATE", paras);
        }
        /// <summary>
        /// 修改
        /// </summary>
        public int Update_V(JobLevel jobLevel)
        {
            string sql = "UPDATE JobLevel  SET ";

            string strSet = string.Empty;

            if (jobLevel.JobLevelName != null)
                strSet += "JobLevelName = @JobLevelName,";

            if (jobLevel.State != null)
                strSet += "State = @State,";

            if (jobLevel.Remark != null)
                strSet += "Remark = @Remark,";

            if (jobLevel.jobLevelDcmID != null)
                strSet += "jobLevelDcmID = @jobLevelDcmID,";

            strSet = strSet.TrimEnd(',');

            sql = sql + strSet + " WHERE JobLevelId = @JobLevelId";


            SqlParameter[] para = new SqlParameter[]
			{
				new SqlParameter("@JobLevelId", jobLevel.JobLevelId)
					,new SqlParameter("@JobLevelName", ToDBValue(jobLevel.JobLevelName))
					,new SqlParameter("@State", ToDBValue(jobLevel.State))
					,new SqlParameter("@Remark", ToDBValue(jobLevel.Remark))
                    ,new SqlParameter("@jobLevelDcmID",ToDBValue(jobLevel.jobLevelDcmID))
			};

            return SqlHelper.ExecuteNonQuery(sql, para);
        }
        /// <summary>
        /// 通过主键 JobLevelId  得到实体
        /// </summary>
        public JobLevel GetByJobLevelId(int jobLevelId)
        {
            string sql = "JobLevelId = " + jobLevelId;

            DataTable dt = GetAll("*", sql, "");
            if (dt.Rows.Count > 0)
                return new JobLevel(dt.Rows[0]);
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
            string table = "JobLevel";
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
            string table = "JobLevel";
            if (string.IsNullOrWhiteSpace(sel_ord))
            {
                sel_ord = " JobLevelId asc";
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

            string table = "JobLevel";
            if (string.IsNullOrWhiteSpace(sel_ord))
            {
                sel_ord = " JobLevelId asc";
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
            string table = "JobLevel";
            if (string.IsNullOrWhiteSpace(sel_ord))
            {
                sel_ord = "  JobLevelId asc";
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
            if (value == null)
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