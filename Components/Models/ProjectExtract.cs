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
    /// 
    /// </summary>
	[Serializable()]
	public class ProjectExtract
	{	
        /// <summary>
        /// 
        /// </summary>
        [DataMember(IsRequired = false)]
		public int PEId{get;set;}
        /// <summary>
        /// 抽取时间
        /// </summary>
        [DataMember(IsRequired = false)]
		public DateTime? ExtractTime{get;set;}
        /// <summary>
        /// 抽取人
        /// </summary>
        [DataMember(IsRequired = false)]
		public int? EmployeeId{get;set;}
        /// <summary>
        /// 拟抽取人数
        /// </summary>
        [DataMember(IsRequired = false)]
		public int? YExtractCount{get;set;}
        /// <summary>
        /// 备选人数
        /// </summary>
        [DataMember(IsRequired = false)]
		public int? BExtractCount{get;set;}
        /// <summary>
        /// 
        /// </summary>
        public ProjectExtract() { }
        
        
        /// <summary>
        /// 
        /// </summary>
        public ProjectExtract(DataRow dr)
        {
            if (dr.Table.Columns.Contains("PEId") && !dr.IsNull("PEId"))
            {
                PEId = Convert.ToInt32(dr["PEId"]);
            }
            if (dr.Table.Columns.Contains("ExtractTime") && !dr.IsNull("ExtractTime"))
            {
                ExtractTime = Convert.ToDateTime(dr["ExtractTime"]);
            }
            if (dr.Table.Columns.Contains("EmployeeId") && !dr.IsNull("EmployeeId"))
            {
                EmployeeId = Convert.ToInt32(dr["EmployeeId"]);
            }
            if (dr.Table.Columns.Contains("YExtractCount") && !dr.IsNull("YExtractCount"))
            {
                YExtractCount = Convert.ToInt32(dr["YExtractCount"]);
            }
            if (dr.Table.Columns.Contains("BExtractCount") && !dr.IsNull("BExtractCount"))
            {
                BExtractCount = Convert.ToInt32(dr["BExtractCount"]);
            }
        }
	}
}
