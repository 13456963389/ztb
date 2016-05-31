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
	public partial class FlowTemplateDAL
	{
		/// <summary>
        /// 添加
        /// </summary>
        public int INSERT(FlowTemplate flowTemplate)
		{	
			SqlParameter[] paras = new SqlParameter[]
				{
					new SqlParameter("@TemplateCode", ToDBValue(flowTemplate.TemplateCode)),
					new SqlParameter("@TemplateName", ToDBValue(flowTemplate.TemplateName)),
					new SqlParameter("@TemplateType", ToDBValue(flowTemplate.TemplateType)),
					new SqlParameter("@Remark", ToDBValue(flowTemplate.Remark)),
					new SqlParameter("@Context", ToDBValue(flowTemplate.Context)),
				};
             
			 return Convert.ToInt32(SqlHelper.ExecuteScalar(CommandType.StoredProcedure, "UP_FlowTemplate_INSERT", paras));
		}
        /// <summary>
        /// 添加
        /// </summary>
        public int INSERT_V(FlowTemplate flowTemplate)
		{	
			string sql =@"INSERT INTO FlowTemplate (TemplateCode,
						TemplateName,
						TemplateType,
						Remark,
						Context
						) VALUES (
						@TemplateCode,
						@TemplateName,
						@TemplateType,
						@Remark,
						@Context
						) select SCOPE_IDENTITY()";
			SqlParameter[] para = new SqlParameter[]
				{
					new SqlParameter("@TemplateCode", ToDBValue(flowTemplate.TemplateCode)),
					new SqlParameter("@TemplateName", ToDBValue(flowTemplate.TemplateName)),
					new SqlParameter("@TemplateType", ToDBValue(flowTemplate.TemplateType)),
					new SqlParameter("@Remark", ToDBValue(flowTemplate.Remark)),
					new SqlParameter("@Context", ToDBValue(flowTemplate.Context)),
				};
				
			int newId = Convert.ToInt32(SqlHelper.ExecuteScalar(sql, para));
			return newId;
		}

		/// <summary>
        /// 删除
        /// </summary>
        public int DeleteByTemplateId(int templateId)
		{
           SqlParameter[] paras = new SqlParameter[]
			{
				new SqlParameter("@TemplateId", templateId)
			};
		
           return SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "UP_FlowTemplate_DELETE", paras);
		}
		
				
		/// <summary>
        /// 修改
        /// </summary>
        public int Update(FlowTemplate flowTemplate)
        {
           SqlParameter[] paras = new SqlParameter[]
			{
				new SqlParameter("@TemplateId", flowTemplate.TemplateId)
					,new SqlParameter("@TemplateCode", ToDBValue(flowTemplate.TemplateCode))
					,new SqlParameter("@TemplateName", ToDBValue(flowTemplate.TemplateName))
					,new SqlParameter("@TemplateType", ToDBValue(flowTemplate.TemplateType))
					,new SqlParameter("@Remark", ToDBValue(flowTemplate.Remark))
					,new SqlParameter("@Context", ToDBValue(flowTemplate.Context))
			};

			  return SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "UP_FlowTemplate_UPDATE", paras);
        }
        /// <summary>
        /// 修改
        /// </summary>
		public int Update_V(FlowTemplate flowTemplate){
            string sql = "UPDATE FlowTemplate  SET ";
            
            string strSet=string.Empty;
            
            if(flowTemplate.TemplateCode != null)
                strSet+="TemplateCode = @TemplateCode," ;
                    
            if(flowTemplate.TemplateName != null)
                strSet+="TemplateName = @TemplateName," ;
                    
            if(flowTemplate.TemplateType != null)
                strSet+="TemplateType = @TemplateType," ;
                    
            if(flowTemplate.Remark != null)
                strSet+="Remark = @Remark," ;
                    
            if(flowTemplate.Context != null)
                strSet+="Context = @Context," ;
                    
            strSet = strSet.TrimEnd(',');
               
            sql=sql+ strSet+" WHERE TemplateId = @TemplateId";


			SqlParameter[] para = new SqlParameter[]
			{
				new SqlParameter("@TemplateId", flowTemplate.TemplateId)
					,new SqlParameter("@TemplateCode", ToDBValue(flowTemplate.TemplateCode))
					,new SqlParameter("@TemplateName", ToDBValue(flowTemplate.TemplateName))
					,new SqlParameter("@TemplateType", ToDBValue(flowTemplate.TemplateType))
					,new SqlParameter("@Remark", ToDBValue(flowTemplate.Remark))
					,new SqlParameter("@Context", ToDBValue(flowTemplate.Context))
			};

			return SqlHelper.ExecuteNonQuery(sql, para);
        }
		/// <summary>
        /// 通过主键 TemplateId  得到实体
        /// </summary>
        public FlowTemplate GetByTemplateId(int templateId)
        {
            string sql = "TemplateId = "+templateId;
            
            DataTable dt = GetAll("*",sql,"");
            if (dt.Rows.Count > 0)
                return new FlowTemplate(dt.Rows[0]);
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
            string table = "FlowTemplate";
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
            string table = "FlowTemplate";
            if (string.IsNullOrWhiteSpace(sel_ord))
            {
                sel_ord = " TemplateId desc";
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

            string table = "FlowTemplate";
            if (string.IsNullOrWhiteSpace(sel_ord))
            {
                sel_ord = " TemplateId desc";
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
            string table = "FlowTemplate";
            if (string.IsNullOrWhiteSpace(sel_ord))
            {
                sel_ord = "  TemplateId desc";
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
