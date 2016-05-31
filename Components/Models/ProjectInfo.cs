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
    /// 项目基本信息
    /// </summary>
	[Serializable()]
	public class ProjectInfo
	{	
        /// <summary>
        /// 项目ID
        /// </summary>
        [DataMember(IsRequired = false)]
		public int ProjectId{get;set;}
        /// <summary>
        /// 项目编号
        /// </summary>
        [DataMember(IsRequired = false)]
		public string ProjectCode{get;set;}
        /// <summary>
        /// 项目名称
        /// </summary>
        [DataMember(IsRequired = false)]
		public string ProjectName{get;set;}
        /// <summary>
        /// 项目类型
        /// </summary>
        [DataMember(IsRequired = false)]
		public int ProjectType{get;set;}
        /// <summary>
        /// 项目所在地
        /// </summary>
        [DataMember(IsRequired = false)]
		public string Address{get;set;}
        /// <summary>
        /// 项目法人
        /// </summary>
        [DataMember(IsRequired = false)]
		public string ProjectLegal{get;set;}
        /// <summary>
        /// 行业分类
        /// </summary>
        [DataMember(IsRequired = false)]
		public int? TradeCode{get;set;}
        /// <summary>
        /// 项目规模
        /// </summary>
        [DataMember(IsRequired = false)]
		public string ProjectScale{get;set;}
        /// <summary>
        /// 招标人
        /// </summary>
        [DataMember(IsRequired = false)]
		public int TendereeId{get;set;}
        /// <summary>
        /// 招标代理
        /// </summary>
        [DataMember(IsRequired = false)]
		public int AgencyId{get;set;}
        /// <summary>
        /// 其他说明
        /// </summary>
        [DataMember(IsRequired = false)]
		public string Remark{get;set;}
        /// <summary>
        /// 审核状态
        /// </summary>
        [DataMember(IsRequired = false)]
		public int CheckStatu{get;set;}
        /// <summary>
        /// 创建人
        /// </summary>
        [DataMember(IsRequired = false)]
		public int? EmployeeId{get;set;}
        /// <summary>
        /// 创建时间
        /// </summary>
        [DataMember(IsRequired = false)]
		public DateTime? CreateTime{get;set;}
        /// <summary>
        /// 项目基本信息
        /// </summary>
        public ProjectInfo() { }
        
        
        /// <summary>
        /// 项目基本信息
        /// </summary>
        public ProjectInfo(DataRow dr)
        {
            if (dr.Table.Columns.Contains("ProjectId") && !dr.IsNull("ProjectId"))
            {
                ProjectId = Convert.ToInt32(dr["ProjectId"]);
            }
            if (dr.Table.Columns.Contains("ProjectCode") && !dr.IsNull("ProjectCode"))
            {
                ProjectCode = dr["ProjectCode"].ToString();
            }
            if (dr.Table.Columns.Contains("ProjectName") && !dr.IsNull("ProjectName"))
            {
                ProjectName = dr["ProjectName"].ToString();
            }
            if (dr.Table.Columns.Contains("ProjectType") && !dr.IsNull("ProjectType"))
            {
                ProjectType = Convert.ToInt32(dr["ProjectType"]);
            }
            if (dr.Table.Columns.Contains("Address") && !dr.IsNull("Address"))
            {
                Address = dr["Address"].ToString();
            }
            if (dr.Table.Columns.Contains("ProjectLegal") && !dr.IsNull("ProjectLegal"))
            {
                ProjectLegal = dr["ProjectLegal"].ToString();
            }
            if (dr.Table.Columns.Contains("TradeCode") && !dr.IsNull("TradeCode"))
            {
                TradeCode = Convert.ToInt32(dr["TradeCode"]);
            }
            if (dr.Table.Columns.Contains("ProjectScale") && !dr.IsNull("ProjectScale"))
            {
                ProjectScale = dr["ProjectScale"].ToString();
            }
            if (dr.Table.Columns.Contains("TendereeId") && !dr.IsNull("TendereeId"))
            {
                TendereeId = Convert.ToInt32(dr["TendereeId"]);
            }
            if (dr.Table.Columns.Contains("AgencyId") && !dr.IsNull("AgencyId"))
            {
                AgencyId = Convert.ToInt32(dr["AgencyId"]);
            }
            if (dr.Table.Columns.Contains("Remark") && !dr.IsNull("Remark"))
            {
                Remark = dr["Remark"].ToString();
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
        }
	}
}
