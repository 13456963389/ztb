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
    /// 资格预审结果
    /// </summary>
	[Serializable()]
	public class FirstResult
	{	
        /// <summary>
        /// 资格预审结果ID
        /// </summary>
        [DataMember(IsRequired = false)]
		public int FirstResultId{get;set;}
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
        /// 单位Id
        /// </summary>
        [DataMember(IsRequired = false)]
		public int UnitId{get;set;}
        /// <summary>
        /// 资审状态
        /// </summary>
        [DataMember(IsRequired = false)]
		public int ResultStatu{get;set;}
        /// <summary>
        /// 资审时间
        /// </summary>
        [DataMember(IsRequired = false)]
		public DateTime ResultDate{get;set;}
        /// <summary>
        /// 审核状态
        /// </summary>
        [DataMember(IsRequired = false)]
		public int CheckStatu{get;set;}
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
        /// 预中标状态
        /// </summary>
        [DataMember(IsRequired = false)]
		public int? YTrueStatu{get;set;}
        /// <summary>
        /// 中标状态
        /// </summary>
        [DataMember(IsRequired = false)]
		public int? TrueStaru{get;set;}
        /// <summary>
        /// 资格预审结果
        /// </summary>
        public FirstResult() { }
        
        
        /// <summary>
        /// 资格预审结果
        /// </summary>
        public FirstResult(DataRow dr)
        {
            if (dr.Table.Columns.Contains("FirstResultId") && !dr.IsNull("FirstResultId"))
            {
                FirstResultId = Convert.ToInt32(dr["FirstResultId"]);
            }
            if (dr.Table.Columns.Contains("ProjectId") && !dr.IsNull("ProjectId"))
            {
                ProjectId = Convert.ToInt32(dr["ProjectId"]);
            }
            if (dr.Table.Columns.Contains("SectionId") && !dr.IsNull("SectionId"))
            {
                SectionId = Convert.ToInt32(dr["SectionId"]);
            }
            if (dr.Table.Columns.Contains("UnitId") && !dr.IsNull("UnitId"))
            {
                UnitId = Convert.ToInt32(dr["UnitId"]);
            }
            if (dr.Table.Columns.Contains("ResultStatu") && !dr.IsNull("ResultStatu"))
            {
                ResultStatu = Convert.ToInt32(dr["ResultStatu"]);
            }
            if (dr.Table.Columns.Contains("ResultDate") && !dr.IsNull("ResultDate"))
            {
                ResultDate = Convert.ToDateTime(dr["ResultDate"]);
            }
            if (dr.Table.Columns.Contains("CheckStatu") && !dr.IsNull("CheckStatu"))
            {
                CheckStatu = Convert.ToInt32(dr["CheckStatu"]);
            }
            if (dr.Table.Columns.Contains("EmployeeId") && !dr.IsNull("EmployeeId"))
            {
                EmployeeId = Convert.ToInt32(dr["EmployeeId"]);
            }
            if (dr.Table.Columns.Contains("CreateTime") && !dr.IsNull("CreateTime"))
            {
                CreateTime = Convert.ToDateTime(dr["CreateTime"]);
            }
            if (dr.Table.Columns.Contains("YTrueStatu") && !dr.IsNull("YTrueStatu"))
            {
                YTrueStatu = Convert.ToInt32(dr["YTrueStatu"]);
            }
            if (dr.Table.Columns.Contains("TrueStaru") && !dr.IsNull("TrueStaru"))
            {
                TrueStaru = Convert.ToInt32(dr["TrueStaru"]);
            }
        }
	}
}
