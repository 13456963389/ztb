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
    /// 评标专家抽取记录
    /// </summary>
	[Serializable()]
	public class ExpertExtract
	{	
        /// <summary>
        /// 抽取ID
        /// </summary>
        [DataMember(IsRequired = false)]
		public int ExtractId{get;set;}
        /// <summary>
        /// 专家ID
        /// </summary>
        [DataMember(IsRequired = false)]
		public int ExpertId{get;set;}
        /// <summary>
        /// 项目ID
        /// </summary>
        [DataMember(IsRequired = false)]
		public int ProjectId{get;set;}
        /// <summary>
        /// 行业类型
        /// </summary>
        [DataMember(IsRequired = false)]
		public int TradeCode{get;set;}
        /// <summary>
        /// 是否补抽
        /// </summary>
        [DataMember(IsRequired = false)]
		public int IsSupplement{get;set;}
        /// <summary>
        /// 抽取时间
        /// </summary>
        [DataMember(IsRequired = false)]
		public DateTime? ExtractDate{get;set;}
        /// <summary>
        /// 抽取人
        /// </summary>
        [DataMember(IsRequired = false)]
		public int? EmployeeId{get;set;}
        /// <summary>
        /// 评标专家抽取记录
        /// </summary>
        public ExpertExtract() { }
        
        
        /// <summary>
        /// 评标专家抽取记录
        /// </summary>
        public ExpertExtract(DataRow dr)
        {
            if (dr.Table.Columns.Contains("ExtractId") && !dr.IsNull("ExtractId"))
            {
                ExtractId = Convert.ToInt32(dr["ExtractId"]);
            }
            if (dr.Table.Columns.Contains("ExpertId") && !dr.IsNull("ExpertId"))
            {
                ExpertId = Convert.ToInt32(dr["ExpertId"]);
            }
            if (dr.Table.Columns.Contains("ProjectId") && !dr.IsNull("ProjectId"))
            {
                ProjectId = Convert.ToInt32(dr["ProjectId"]);
            }
            if (dr.Table.Columns.Contains("TradeCode") && !dr.IsNull("TradeCode"))
            {
                TradeCode = Convert.ToInt32(dr["TradeCode"]);
            }
            if (dr.Table.Columns.Contains("IsSupplement") && !dr.IsNull("IsSupplement"))
            {
                IsSupplement = Convert.ToInt32(dr["IsSupplement"]);
            }
            if (dr.Table.Columns.Contains("ExtractDate") && !dr.IsNull("ExtractDate"))
            {
                ExtractDate = Convert.ToDateTime(dr["ExtractDate"]);
            }
            if (dr.Table.Columns.Contains("EmployeeId") && !dr.IsNull("EmployeeId"))
            {
                EmployeeId = Convert.ToInt32(dr["EmployeeId"]);
            }
        }
	}
}
