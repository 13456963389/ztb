//============================================================
//author:于永博
//============================================================

using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Runtime.Serialization;

namespace ZtbSoft.Models
{	
    /// <summary>
    /// 异议表
    /// </summary>
	[Serializable()]
	public class Question
	{	
        /// <summary>
        /// 异议ID
        /// </summary>
        [DataMember(IsRequired = false)]
		public int QuestionId{get;set;}
        /// <summary>
        /// 提疑时间
        /// </summary>
        [DataMember(IsRequired = false)]
		public DateTime WriteDate{get;set;}
        /// <summary>
        /// 提疑内容
        /// </summary>
        [DataMember(IsRequired = false)]
		public string Context{get;set;}
        /// <summary>
        /// 状态
        /// </summary>
        [DataMember(IsRequired = false)]
		public int Staru{get;set;}
        /// <summary>
        /// 答疑时间
        /// </summary>
        [DataMember(IsRequired = false)]
		public DateTime? AnswerDate{get;set;}
        /// <summary>
        /// 答疑内容
        /// </summary>
        [DataMember(IsRequired = false)]
		public string Answer{get;set;}
        /// <summary>
        /// 异议类型
        /// </summary>
        [DataMember(IsRequired = false)]
		public int QType{get;set;}
        /// <summary>
        /// 提疑人
        /// </summary>
        [DataMember(IsRequired = false)]
		public string UnitName{get;set;}
        /// <summary>
        /// 答疑人
        /// </summary>
        [DataMember(IsRequired = false)]
		public string EmployeeName{get;set;}
        /// <summary>
        /// 项目ID
        /// </summary>
        [DataMember(IsRequired = false)]
		public int ProjectId{get;set;}
        /// <summary>
        /// 标段ID
        /// </summary>
        [DataMember(IsRequired = false)]
		public int SectionId{get;set;}
        /// <summary>
        /// 创建人
        /// </summary>
        [DataMember(IsRequired = false)]
		public int EmployeeId{get;set;}
        /// <summary>
        /// 创建时间
        /// </summary>
        [DataMember(IsRequired = false)]
		public DateTime CreateTime{get;set;}
        /// <summary>
        /// 异议表
        /// </summary>
        public Question() { }
        
        
        /// <summary>
        /// 异议表
        /// </summary>
        public Question(DataRow dr)
        {
            if (dr.Table.Columns.Contains("QuestionId") && !dr.IsNull("QuestionId"))
            {
                QuestionId = Convert.ToInt32(dr["QuestionId"]);
            }
            if (dr.Table.Columns.Contains("WriteDate") && !dr.IsNull("WriteDate"))
            {
                WriteDate = Convert.ToDateTime(dr["WriteDate"]);
            }
            if (dr.Table.Columns.Contains("Context") && !dr.IsNull("Context"))
            {
                Context = dr["Context"].ToString();
            }
            if (dr.Table.Columns.Contains("Staru") && !dr.IsNull("Staru"))
            {
                Staru = Convert.ToInt32(dr["Staru"]);
            }
            if (dr.Table.Columns.Contains("AnswerDate") && !dr.IsNull("AnswerDate"))
            {
                AnswerDate = Convert.ToDateTime(dr["AnswerDate"]);
            }
            if (dr.Table.Columns.Contains("Answer") && !dr.IsNull("Answer"))
            {
                Answer = dr["Answer"].ToString();
            }
            if (dr.Table.Columns.Contains("QType") && !dr.IsNull("QType"))
            {
                QType = Convert.ToInt32(dr["QType"]);
            }
            if (dr.Table.Columns.Contains("UnitName") && !dr.IsNull("UnitName"))
            {
                UnitName = dr["UnitName"].ToString();
            }
            if (dr.Table.Columns.Contains("EmployeeName") && !dr.IsNull("EmployeeName"))
            {
                EmployeeName = dr["EmployeeName"].ToString();
            }
            if (dr.Table.Columns.Contains("ProjectId") && !dr.IsNull("ProjectId"))
            {
                ProjectId = Convert.ToInt32(dr["ProjectId"]);
            }
            if (dr.Table.Columns.Contains("SectionId") && !dr.IsNull("SectionId"))
            {
                SectionId = Convert.ToInt32(dr["SectionId"]);
            }
            if (dr.Table.Columns.Contains("EmployeeId") && !dr.IsNull("EmployeeId"))
            {
                EmployeeId = Convert.ToInt32(dr["EmployeeId"]);
            }
            if (dr.Table.Columns.Contains("CreateTime") && !dr.IsNull("CreateTime"))
            {
                CreateTime = Convert.ToDateTime(dr["CreateTime"]);
            }
        }
	}
}
