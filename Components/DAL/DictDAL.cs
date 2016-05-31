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
    public partial class DictDAL
    {
        /// <summary>
        /// 添加
        /// </summary>
        public int INSERT(Dict dict)
        {
            SqlParameter[] paras = new SqlParameter[]
				{
					new SqlParameter("@DictCode", ToDBValue(dict.DictCode)),
					new SqlParameter("@DictName", ToDBValue(dict.DictName)),
					new SqlParameter("@DictValue", ToDBValue(dict.DictValue)),
					new SqlParameter("@PId", ToDBValue(dict.PId)),
					new SqlParameter("@Remark", ToDBValue(dict.Remark)),
				};

            return Convert.ToInt32(SqlHelper.ExecuteScalar(CommandType.StoredProcedure, "UP_Dict_INSERT", paras));
        }
        /// <summary>
        /// 添加
        /// </summary>
        public int INSERT_V(Dict dict)
        {
            string sql = @"INSERT INTO Dict (DictCode,
						DictName,
						DictValue,
						PId,
						Remark
						) VALUES (
						@DictCode,
						@DictName,
						@DictValue,
						@PId,
						@Remark
						) select SCOPE_IDENTITY()";
            SqlParameter[] para = new SqlParameter[]
				{
					new SqlParameter("@DictCode", ToDBValue(dict.DictCode)),
					new SqlParameter("@DictName", ToDBValue(dict.DictName)),
					new SqlParameter("@DictValue", ToDBValue(dict.DictValue)),
					new SqlParameter("@PId", ToDBValue(dict.PId)),
					new SqlParameter("@Remark", ToDBValue(dict.Remark)),
				};

            int newId = Convert.ToInt32(SqlHelper.ExecuteScalar(sql, para));
            return newId;
        }

        /// <summary>
        /// 删除
        /// </summary>
        public int DeleteByDictId(int dictId)
        {
            SqlParameter[] paras = new SqlParameter[]
			{
				new SqlParameter("@DictId", dictId)
			};

            return SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "UP_Dict_DELETE", paras);
        }


        /// <summary>
        /// 修改
        /// </summary>
        public int Update(Dict dict)
        {
            SqlParameter[] paras = new SqlParameter[]
			{
				new SqlParameter("@DictId", dict.DictId)
					,new SqlParameter("@DictCode", ToDBValue(dict.DictCode))
					,new SqlParameter("@DictName", ToDBValue(dict.DictName))
					,new SqlParameter("@DictValue", ToDBValue(dict.DictValue))
					,new SqlParameter("@PId", ToDBValue(dict.PId))
					,new SqlParameter("@Remark", ToDBValue(dict.Remark))
			};

            return SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "UP_Dict_UPDATE", paras);
        }
        /// <summary>
        /// 修改
        /// </summary>
        public int Update_V(Dict dict)
        {
            string sql = "UPDATE Dict  SET ";

            string strSet = string.Empty;

            if (dict.DictCode != null)
                strSet += "DictCode = @DictCode,";

            if (dict.DictName != null)
                strSet += "DictName = @DictName,";

            if (dict.DictValue != null)
                strSet += "DictValue = @DictValue,";

            if (dict.PId != null)
                strSet += "PId = @PId,";

            if (dict.Remark != null)
                strSet += "Remark = @Remark,";

            strSet = strSet.TrimEnd(',');

            sql = sql + strSet + " WHERE DictId = @DictId";


            SqlParameter[] para = new SqlParameter[]
			{
				new SqlParameter("@DictId", dict.DictId)
					,new SqlParameter("@DictCode", ToDBValue(dict.DictCode))
					,new SqlParameter("@DictName", ToDBValue(dict.DictName))
					,new SqlParameter("@DictValue", ToDBValue(dict.DictValue))
					,new SqlParameter("@PId", ToDBValue(dict.PId))
					,new SqlParameter("@Remark", ToDBValue(dict.Remark))
			};

            return SqlHelper.ExecuteNonQuery(sql, para);
        }
        /// <summary>
        /// 通过主键 DictId  得到实体
        /// </summary>
        public Dict GetByDictId(int dictId)
        {
            string sql = "DictId = " + dictId;

            DataTable dt = GetAll("*", sql, "");
            if (dt.Rows.Count > 0)
                return new Dict(dt.Rows[0]);
            else if (dictId == 0)
            {
                var model = new Dict();
                model.DictId = 0;
                model.DictCode = "0000";
                model.DictName = "基础节点";
                model.DictValue = "请添加子节点";
                model.PId = -1;
                return model;
            }
            else
                return null;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dictId"></param>
        /// <returns></returns>
        public DataTable GetModelByDictId(int dictId)
        {
            var dt = new DataTable();
            string sql = "SELECT a.*,b.DictName AS PName FROM dbo.Dict a LEFT JOIN dbo.Dict b ON b.DictId=a.PId WHERE a.DictId=" + dictId;
            dt = SqlHelper.ExecuteDataTable(sql);
            return dt;
        }

        // <summary>
        /// 根据条件得到总数
        /// </summary>
        /// <param name="whe"></param>
        /// <returns></returns>
        public int GetCount(string whe)
        {
            string table = "Dict";
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
            var dt = new DataTable();
            string table = "Dict";
            if (string.IsNullOrWhiteSpace(sel_ord))
            {
                sel_ord = " DictId desc";
            }
            SqlParameter[] paras = {
                    new SqlParameter("@TABLE",table),
                    new SqlParameter("@SEL_COL",sel_col),
                    new SqlParameter("@SEL_WHR",sel_whe),
                    new SqlParameter("@ORD",sel_ord),
            };
            dt = SqlHelper.ExecuteDataTable(CommandType.StoredProcedure, "UP_SELECT_ALL", paras);
            var row = dt.NewRow();
            row["DictId"] = 0;
            row["DictCode"] = "0000";
            row["DictName"] = "基础节点";
            row["DictValue"] = "只读节点不可操作";
            row["Pid"] = -1;
            row["Remark"] = "根节点不可操作";
            dt.Rows.Add(row);
            return dt;
        }

        /// <summary>
        /// 获取数据字典下拉列表
        /// </summary>
        /// <param name="dictCode"></param>
        /// <returns></returns>
        public DataTable GetDictDrop(string dictCode)
        {
            string sql = "select DictId as Id,DictName as Name from Dict where Pid=(SELECT DictId FROM dbo.Dict WHERE DictCode='" + dictCode + "')";
            return SqlHelper.ExecuteDataTable(sql);
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
            var dt = new DataTable();
            string table = "Dict";
            if (string.IsNullOrWhiteSpace(sel_ord))
            {
                sel_ord = " DictId desc";
            }
            SqlParameter[] paras = {
                    new SqlParameter("@TABLE",table),
                    new SqlParameter("@SEL_COL",sel_col),
                    new SqlParameter("@SEL_WHR",sel_whe),
                    new SqlParameter("@ORD",sel_ord),
                    new SqlParameter("@NUM_PER_PAGE",page_size),
                    new SqlParameter("@PGE_INDEX",page)
            };

            dt = SqlHelper.ExecuteDataTable(CommandType.StoredProcedure, "UP_SELECT_PAGE", paras);
            var row = dt.NewRow();
            row["DictId"] = 0;
            row["DictCode"] = "0000";
            row["DictName"] = "基础节点";
            row["DictValue"] = "只读节点不可操作";
            row["Pid"] = -1;
            row["Remark"] = "根节点不可操作";
            dt.Rows.Add(row);
            return dt;
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
            string table = "Dict";
            if (string.IsNullOrWhiteSpace(sel_ord))
            {
                sel_ord = "  DictId desc";
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
