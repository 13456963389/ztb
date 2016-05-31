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
    /// 费用管理
    /// </summary>
	[Serializable()]
	public class CostManagement
	{	
        /// <summary>
        /// 费用ID
        /// </summary>
        [DataMember(IsRequired = false)]
		public int CostId{get;set;}
        /// <summary>
        /// 费用类型
        /// </summary>
        [DataMember(IsRequired = false)]
		public int CostType{get;set;}
        /// <summary>
        /// 费用金额
        /// </summary>
        [DataMember(IsRequired = false)]
		public decimal CostPrice{get;set;}
        /// <summary>
        /// 收费人
        /// </summary>
        [DataMember(IsRequired = false)]
		public int ComeEmployeeId{get;set;}
        /// <summary>
        /// 项目ID
        /// </summary>
        [DataMember(IsRequired = false)]
		public int? ProjectId{get;set;}
        /// <summary>
        /// 收取时间
        /// </summary>
        [DataMember(IsRequired = false)]
		public DateTime? ComeTime{get;set;}
        /// <summary>
        /// 收取金额
        /// </summary>
        [DataMember(IsRequired = false)]
		public decimal? ComePrice{get;set;}
        /// <summary>
        /// 退回时间
        /// </summary>
        [DataMember(IsRequired = false)]
		public DateTime? OutTime{get;set;}
        /// <summary>
        /// 退回金额
        /// </summary>
        [DataMember(IsRequired = false)]
		public decimal? OutPrice{get;set;}
        /// <summary>
        /// 退款人
        /// </summary>
        [DataMember(IsRequired = false)]
		public int? OutEmployeeId{get;set;}
        /// <summary>
        /// 接收人
        /// </summary>
        [DataMember(IsRequired = false)]
		public int? GoEmployeeId{get;set;}
        /// <summary>
        /// 企业Id
        /// </summary>
        [DataMember(IsRequired = false)]
		public int? UnitId{get;set;}
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
        /// 
        /// </summary>
        [DataMember(IsRequired = false)]
		public int? SectionId{get;set;}
        /// <summary>
        /// 费用管理
        /// </summary>
        public CostManagement() { }
        
        
        /// <summary>
        /// 费用管理
        /// </summary>
        public CostManagement(DataRow dr)
        {
            if (dr.Table.Columns.Contains("CostId") && !dr.IsNull("CostId"))
            {
                CostId = Convert.ToInt32(dr["CostId"]);
            }
            if (dr.Table.Columns.Contains("CostType") && !dr.IsNull("CostType"))
            {
                CostType = Convert.ToInt32(dr["CostType"]);
            }
            if (dr.Table.Columns.Contains("CostPrice") && !dr.IsNull("CostPrice"))
            {
                CostPrice = Convert.ToDecimal(dr["CostPrice"]);
            }
            if (dr.Table.Columns.Contains("ComeEmployeeId") && !dr.IsNull("ComeEmployeeId"))
            {
                ComeEmployeeId = Convert.ToInt32(dr["ComeEmployeeId"]);
            }
            if (dr.Table.Columns.Contains("ProjectId") && !dr.IsNull("ProjectId"))
            {
                ProjectId = Convert.ToInt32(dr["ProjectId"]);
            }
            if (dr.Table.Columns.Contains("ComeTime") && !dr.IsNull("ComeTime"))
            {
                ComeTime = Convert.ToDateTime(dr["ComeTime"]);
            }
            if (dr.Table.Columns.Contains("ComePrice") && !dr.IsNull("ComePrice"))
            {
                ComePrice = Convert.ToDecimal(dr["ComePrice"]);
            }
            if (dr.Table.Columns.Contains("OutTime") && !dr.IsNull("OutTime"))
            {
                OutTime = Convert.ToDateTime(dr["OutTime"]);
            }
            if (dr.Table.Columns.Contains("OutPrice") && !dr.IsNull("OutPrice"))
            {
                OutPrice = Convert.ToDecimal(dr["OutPrice"]);
            }
            if (dr.Table.Columns.Contains("OutEmployeeId") && !dr.IsNull("OutEmployeeId"))
            {
                OutEmployeeId = Convert.ToInt32(dr["OutEmployeeId"]);
            }
            if (dr.Table.Columns.Contains("GoEmployeeId") && !dr.IsNull("GoEmployeeId"))
            {
                GoEmployeeId = Convert.ToInt32(dr["GoEmployeeId"]);
            }
            if (dr.Table.Columns.Contains("UnitId") && !dr.IsNull("UnitId"))
            {
                UnitId = Convert.ToInt32(dr["UnitId"]);
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
            if (dr.Table.Columns.Contains("SectionId") && !dr.IsNull("SectionId"))
            {
                SectionId = Convert.ToInt32(dr["SectionId"]);
            }
        }
	}
}
