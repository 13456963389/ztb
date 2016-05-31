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
    public partial class PowerObjectDAL
    {
        /// <summary>
        /// 添加
        /// </summary>
        public int INSERT(PowerObject powerObject)
        {
            SqlParameter[] paras = new SqlParameter[]
				{
					new SqlParameter("@ParentId", ToDBValue(powerObject.ParentId)),
					new SqlParameter("@Name", ToDBValue(powerObject.Name)),
					new SqlParameter("@Code", ToDBValue(powerObject.Code)),
					new SqlParameter("@Url", ToDBValue(powerObject.Url)),
					new SqlParameter("@Img", ToDBValue(powerObject.Img)),
					new SqlParameter("@Ord", ToDBValue(powerObject.Ord)),
					new SqlParameter("@Detail", ToDBValue(powerObject.Detail)),
					new SqlParameter("@isMenu", ToDBValue(powerObject.IsMenu)),
				};

            return Convert.ToInt32(SqlHelper.ExecuteScalar(CommandType.StoredProcedure, "UP_PowerObject_INSERT", paras));
        }
        /// <summary>
        /// 添加
        /// </summary>
        public int INSERT_V(PowerObject powerObject)
        {
            string sql = @"INSERT INTO PowerObject (ParentId,
						Name,
						Code,
						Url,
						Img,
						Ord,
						Detail,
						isMenu
						) VALUES (
						@ParentId,
						@Name,
						@Code,
						@Url,
						@Img,
						@Ord,
						@Detail,
						@isMenu
						) select SCOPE_IDENTITY()";
            SqlParameter[] para = new SqlParameter[]
				{
					new SqlParameter("@ParentId", ToDBValue(powerObject.ParentId)),
					new SqlParameter("@Name", ToDBValue(powerObject.Name)),
					new SqlParameter("@Code", ToDBValue(powerObject.Code)),
					new SqlParameter("@Url", ToDBValue(powerObject.Url)),
					new SqlParameter("@Img", ToDBValue(powerObject.Img)),
					new SqlParameter("@Ord", ToDBValue(powerObject.Ord)),
					new SqlParameter("@Detail", ToDBValue(powerObject.Detail)),
					new SqlParameter("@isMenu", ToDBValue(powerObject.IsMenu)),
				};

            int newId = Convert.ToInt32(SqlHelper.ExecuteScalar(sql, para));
            return newId;
        }

        /// <summary>
        /// 删除
        /// </summary>
        public int DeleteById(int id)
        {
            SqlParameter[] paras = new SqlParameter[]
			{
				new SqlParameter("@Id", id)
			};

            return SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "UP_PowerObject_DELETE", paras);
        }



        /// <summary>
        /// 修改
        /// </summary>
        public int Update(PowerObject powerObject)
        {
            SqlParameter[] paras = new SqlParameter[]
			{
				new SqlParameter("@Id", powerObject.Id)
					,new SqlParameter("@ParentId", ToDBValue(powerObject.ParentId))
					,new SqlParameter("@Name", ToDBValue(powerObject.Name))
					,new SqlParameter("@Code", ToDBValue(powerObject.Code))
					,new SqlParameter("@Url", ToDBValue(powerObject.Url))
					,new SqlParameter("@Img", ToDBValue(powerObject.Img))
					,new SqlParameter("@Ord", ToDBValue(powerObject.Ord))
					,new SqlParameter("@Detail", ToDBValue(powerObject.Detail))
					,new SqlParameter("@isMenu", ToDBValue(powerObject.IsMenu))
			};

            return SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "UP_PowerObject_UPDATE", paras);
        }
        /// <summary>
        /// 修改
        /// </summary>
        public int Update_V(PowerObject powerObject)
        {
            string sql = "UPDATE PowerObject  SET ";

            string strSet = string.Empty;

            if (powerObject.ParentId != null)
                strSet += "ParentId = @ParentId,";

            if (powerObject.Name != null)
                strSet += "Name = @Name,";

            if (powerObject.Code != null)
                strSet += "Code = @Code,";

            if (powerObject.Url != null)
                strSet += "Url = @Url,";

            if (powerObject.Img != null)
                strSet += "Img = @Img,";

            if (powerObject.Ord != null)
                strSet += "Ord = @Ord,";

            if (powerObject.Detail != null)
                strSet += "Detail = @Detail,";

            if (powerObject.IsMenu != null)
                strSet += "isMenu = @isMenu,";

            strSet = strSet.TrimEnd(',');

            sql = sql + strSet + " WHERE Id = @Id";


            SqlParameter[] para = new SqlParameter[]
			{
				new SqlParameter("@Id", powerObject.Id)
					,new SqlParameter("@ParentId", ToDBValue(powerObject.ParentId))
					,new SqlParameter("@Name", ToDBValue(powerObject.Name))
					,new SqlParameter("@Code", ToDBValue(powerObject.Code))
					,new SqlParameter("@Url", ToDBValue(powerObject.Url))
					,new SqlParameter("@Img", ToDBValue(powerObject.Img))
					,new SqlParameter("@Ord", ToDBValue(powerObject.Ord))
					,new SqlParameter("@Detail", ToDBValue(powerObject.Detail))
					,new SqlParameter("@isMenu", ToDBValue(powerObject.IsMenu))
			};

            return SqlHelper.ExecuteNonQuery(sql, para);
        }

        /// <summary>
        /// 通过主键 Id  得到实体
        /// </summary>
        public PowerObject GetById(int id)
        {
            string sql = "Id = " + id;

            DataTable dt = GetAll("*", sql, "");
            if (dt.Rows.Count > 0)
                return new PowerObject(dt.Rows[0]);
            else
                return null;

        }

        /// <summary>
        /// 根据条件得到总数
        /// </summary>
        /// <param name="whe"></param>
        /// <returns></returns>
        public int GetCount(string whe)
        {
            string table = "PowerObject";
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
            string table = "PowerObject";
            if (string.IsNullOrWhiteSpace(sel_ord))
            {
                sel_ord = " Id desc";
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

            string table = "PowerObject";
            if (string.IsNullOrWhiteSpace(sel_ord))
            {
                sel_ord = " Id desc";
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
            string table = "PowerObject";
            if (string.IsNullOrWhiteSpace(sel_ord))
            {
                sel_ord = "  Id desc";
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