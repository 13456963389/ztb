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
	public partial class QuestionDAL
	{
		/// <summary>
        /// 添加
        /// </summary>
        public int INSERT(Question question)
		{	
			SqlParameter[] paras = new SqlParameter[]
				{
					new SqlParameter("@WriteDate", ToDBValue(question.WriteDate)),
					new SqlParameter("@Context", ToDBValue(question.Context)),
					new SqlParameter("@Staru", ToDBValue(question.Staru)),
					new SqlParameter("@AnswerDate", ToDBValue(question.AnswerDate)),
					new SqlParameter("@Answer", ToDBValue(question.Answer)),
					new SqlParameter("@QType", ToDBValue(question.QType)),
					new SqlParameter("@UnitName", ToDBValue(question.UnitName)),
					new SqlParameter("@EmployeeName", ToDBValue(question.EmployeeName)),
					new SqlParameter("@ProjectId", ToDBValue(question.ProjectId)),
					new SqlParameter("@SectionId", ToDBValue(question.SectionId)),
					new SqlParameter("@EmployeeId", ToDBValue(question.EmployeeId)),
					new SqlParameter("@CreateTime", ToDBValue(question.CreateTime)),
				};
             
			 return Convert.ToInt32(SqlHelper.ExecuteScalar(CommandType.StoredProcedure, "UP_Question_INSERT", paras));
		}
        /// <summary>
        /// 添加
        /// </summary>
        public int INSERT_V(Question question)
		{	
			string sql =@"INSERT INTO Question (WriteDate,
						Context,
						Staru,
						AnswerDate,
						Answer,
						QType,
						UnitName,
						EmployeeName,
						ProjectId,
						SectionId,
						EmployeeId,
						CreateTime
						) VALUES (
						@WriteDate,
						@Context,
						@Staru,
						@AnswerDate,
						@Answer,
						@QType,
						@UnitName,
						@EmployeeName,
						@ProjectId,
						@SectionId,
						@EmployeeId,
						@CreateTime
						) select SCOPE_IDENTITY()";
			SqlParameter[] para = new SqlParameter[]
				{
					new SqlParameter("@WriteDate", ToDBValue(question.WriteDate)),
					new SqlParameter("@Context", ToDBValue(question.Context)),
					new SqlParameter("@Staru", ToDBValue(question.Staru)),
					new SqlParameter("@AnswerDate", ToDBValue(question.AnswerDate)),
					new SqlParameter("@Answer", ToDBValue(question.Answer)),
					new SqlParameter("@QType", ToDBValue(question.QType)),
					new SqlParameter("@UnitName", ToDBValue(question.UnitName)),
					new SqlParameter("@EmployeeName", ToDBValue(question.EmployeeName)),
					new SqlParameter("@ProjectId", ToDBValue(question.ProjectId)),
					new SqlParameter("@SectionId", ToDBValue(question.SectionId)),
					new SqlParameter("@EmployeeId", ToDBValue(question.EmployeeId)),
					new SqlParameter("@CreateTime", ToDBValue(question.CreateTime)),
				};
				
			int newId = Convert.ToInt32(SqlHelper.ExecuteScalar(sql, para));
			return newId;
		}

		/// <summary>
        /// 删除
        /// </summary>
        public int DeleteByQuestionId(int questionId)
		{
           SqlParameter[] paras = new SqlParameter[]
			{
				new SqlParameter("@QuestionId", questionId)
			};
		
           return SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "UP_Question_DELETE", paras);
		}
		
				
		/// <summary>
        /// 修改
        /// </summary>
        public int Update(Question question)
        {
           SqlParameter[] paras = new SqlParameter[]
			{
				new SqlParameter("@QuestionId", question.QuestionId)
					,new SqlParameter("@WriteDate", ToDBValue(question.WriteDate))
					,new SqlParameter("@Context", ToDBValue(question.Context))
					,new SqlParameter("@Staru", ToDBValue(question.Staru))
					,new SqlParameter("@AnswerDate", ToDBValue(question.AnswerDate))
					,new SqlParameter("@Answer", ToDBValue(question.Answer))
					,new SqlParameter("@QType", ToDBValue(question.QType))
					,new SqlParameter("@UnitName", ToDBValue(question.UnitName))
					,new SqlParameter("@EmployeeName", ToDBValue(question.EmployeeName))
					,new SqlParameter("@ProjectId", ToDBValue(question.ProjectId))
					,new SqlParameter("@SectionId", ToDBValue(question.SectionId))
					,new SqlParameter("@EmployeeId", ToDBValue(question.EmployeeId))
					,new SqlParameter("@CreateTime", ToDBValue(question.CreateTime))
			};

			  return SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "UP_Question_UPDATE", paras);
        }
        /// <summary>
        /// 修改
        /// </summary>
		public int Update_V(Question question){
            string sql = "UPDATE Question  SET ";
            
            string strSet=string.Empty;
            
            if(question.WriteDate != null)
                strSet+="WriteDate = @WriteDate," ;
                    
            if(question.Context != null)
                strSet+="Context = @Context," ;
                    
            if(question.Staru != null)
                strSet+="Staru = @Staru," ;
                    
            if(question.AnswerDate != null)
                strSet+="AnswerDate = @AnswerDate," ;
                    
            if(question.Answer != null)
                strSet+="Answer = @Answer," ;
                    
            if(question.QType != null)
                strSet+="QType = @QType," ;
                    
            if(question.UnitName != null)
                strSet+="UnitName = @UnitName," ;
                    
            if(question.EmployeeName != null)
                strSet+="EmployeeName = @EmployeeName," ;
                    
            if(question.ProjectId != null)
                strSet+="ProjectId = @ProjectId," ;
                    
            if(question.SectionId != null)
                strSet+="SectionId = @SectionId," ;
                    
            if(question.EmployeeId != null)
                strSet+="EmployeeId = @EmployeeId," ;
                    
            if(question.CreateTime != null)
                strSet+="CreateTime = @CreateTime," ;
                    
            strSet = strSet.TrimEnd(',');
               
            sql=sql+ strSet+" WHERE QuestionId = @QuestionId";


			SqlParameter[] para = new SqlParameter[]
			{
				new SqlParameter("@QuestionId", question.QuestionId)
					,new SqlParameter("@WriteDate", ToDBValue(question.WriteDate))
					,new SqlParameter("@Context", ToDBValue(question.Context))
					,new SqlParameter("@Staru", ToDBValue(question.Staru))
					,new SqlParameter("@AnswerDate", ToDBValue(question.AnswerDate))
					,new SqlParameter("@Answer", ToDBValue(question.Answer))
					,new SqlParameter("@QType", ToDBValue(question.QType))
					,new SqlParameter("@UnitName", ToDBValue(question.UnitName))
					,new SqlParameter("@EmployeeName", ToDBValue(question.EmployeeName))
					,new SqlParameter("@ProjectId", ToDBValue(question.ProjectId))
					,new SqlParameter("@SectionId", ToDBValue(question.SectionId))
					,new SqlParameter("@EmployeeId", ToDBValue(question.EmployeeId))
					,new SqlParameter("@CreateTime", ToDBValue(question.CreateTime))
			};

			return SqlHelper.ExecuteNonQuery(sql, para);
        }
		/// <summary>
        /// 通过主键 QuestionId  得到实体
        /// </summary>
        public Question GetByQuestionId(int questionId)
        {
            string sql = "QuestionId = "+questionId;
            
            DataTable dt = GetAll("*",sql,"");
            if (dt.Rows.Count > 0)
                return new Question(dt.Rows[0]);
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
            string table = "Question";
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
            string table = "Question";
            if (string.IsNullOrWhiteSpace(sel_ord))
            {
                sel_ord = " QuestionId desc";
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

            string table = "Question";
            if (string.IsNullOrWhiteSpace(sel_ord))
            {
                sel_ord = " QuestionId desc";
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
            string table = "Question";
            if (string.IsNullOrWhiteSpace(sel_ord))
            {
                sel_ord = "  QuestionId desc";
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
