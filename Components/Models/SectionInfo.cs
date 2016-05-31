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
    /// 标段信息
    /// </summary>
	[Serializable()]
	public class SectionInfo
	{	
        /// <summary>
        /// 标段ID
        /// </summary>
        [DataMember(IsRequired = false)]
		public int SectionId{get;set;}
        /// <summary>
        /// 标段编号
        /// </summary>
        [DataMember(IsRequired = false)]
		public string SectionCode{get;set;}
        /// <summary>
        /// 合同估算价
        /// </summary>
        [DataMember(IsRequired = false)]
		public decimal? ContractPrice{get;set;}
        /// <summary>
        /// 控制价
        /// </summary>
        [DataMember(IsRequired = false)]
		public decimal? ControlPrice{get;set;}
        /// <summary>
        /// 标段内容
        /// </summary>
        [DataMember(IsRequired = false)]
		public string SectionContext{get;set;}
        /// <summary>
        /// 标段名称
        /// </summary>
        [DataMember(IsRequired = false)]
		public string SectionName{get;set;}
        /// <summary>
        /// 企业资质
        /// </summary>
        [DataMember(IsRequired = false)]
		public int? UnitQualificationId{get;set;}
        /// <summary>
        /// 企业资质名称
        /// </summary>
        [DataMember(IsRequired = false)]
		public string UnitQName{get;set;}
        /// <summary>
        /// 项目经理资质
        /// </summary>
        [DataMember(IsRequired = false)]
		public int? UserQualificationsId{get;set;}
        /// <summary>
        /// 项目经理资质名称
        /// </summary>
        [DataMember(IsRequired = false)]
		public string UserQName{get;set;}
        /// <summary>
        /// 备注
        /// </summary>
        [DataMember(IsRequired = false)]
		public string Remark{get;set;}
        /// <summary>
        /// 标书售价
        /// </summary>
        [DataMember(IsRequired = false)]
		public decimal? BookPrice{get;set;}
        /// <summary>
        /// 标书下载开始时间
        /// </summary>
        [DataMember(IsRequired = false)]
		public DateTime? BookStarDate{get;set;}
        /// <summary>
        /// 标书下载截止时间
        /// </summary>
        [DataMember(IsRequired = false)]
		public DateTime? BookEndDate{get;set;}
        /// <summary>
        /// 预审文件费
        /// </summary>
        [DataMember(IsRequired = false)]
		public decimal? NoticePrice{get;set;}
        /// <summary>
        /// 预审文件下载开始日期
        /// </summary>
        [DataMember(IsRequired = false)]
		public DateTime? FileStarDate{get;set;}
        /// <summary>
        /// 预审文件下载截止日期
        /// </summary>
        [DataMember(IsRequired = false)]
		public DateTime? FileEndDate{get;set;}
        /// <summary>
        /// 审核状态
        /// </summary>
        [DataMember(IsRequired = false)]
		public int? CheckStatu{get;set;}
        /// <summary>
        /// 项目ID
        /// </summary>
        [DataMember(IsRequired = false)]
		public int ProjectId{get;set;}
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
        /// 标段信息
        /// </summary>
        public SectionInfo() { }
        
        
        /// <summary>
        /// 标段信息
        /// </summary>
        public SectionInfo(DataRow dr)
        {
            if (dr.Table.Columns.Contains("SectionId") && !dr.IsNull("SectionId"))
            {
                SectionId = Convert.ToInt32(dr["SectionId"]);
            }
            if (dr.Table.Columns.Contains("SectionCode") && !dr.IsNull("SectionCode"))
            {
                SectionCode = dr["SectionCode"].ToString();
            }
            if (dr.Table.Columns.Contains("ContractPrice") && !dr.IsNull("ContractPrice"))
            {
                ContractPrice = Convert.ToDecimal(dr["ContractPrice"]);
            }
            if (dr.Table.Columns.Contains("ControlPrice") && !dr.IsNull("ControlPrice"))
            {
                ControlPrice = Convert.ToDecimal(dr["ControlPrice"]);
            }
            if (dr.Table.Columns.Contains("SectionContext") && !dr.IsNull("SectionContext"))
            {
                SectionContext = dr["SectionContext"].ToString();
            }
            if (dr.Table.Columns.Contains("SectionName") && !dr.IsNull("SectionName"))
            {
                SectionName = dr["SectionName"].ToString();
            }
            if (dr.Table.Columns.Contains("UnitQualificationId") && !dr.IsNull("UnitQualificationId"))
            {
                UnitQualificationId = Convert.ToInt32(dr["UnitQualificationId"]);
            }
            if (dr.Table.Columns.Contains("UnitQName") && !dr.IsNull("UnitQName"))
            {
                UnitQName = dr["UnitQName"].ToString();
            }
            if (dr.Table.Columns.Contains("UserQualificationsId") && !dr.IsNull("UserQualificationsId"))
            {
                UserQualificationsId = Convert.ToInt32(dr["UserQualificationsId"]);
            }
            if (dr.Table.Columns.Contains("UserQName") && !dr.IsNull("UserQName"))
            {
                UserQName = dr["UserQName"].ToString();
            }
            if (dr.Table.Columns.Contains("Remark") && !dr.IsNull("Remark"))
            {
                Remark = dr["Remark"].ToString();
            }
            if (dr.Table.Columns.Contains("BookPrice") && !dr.IsNull("BookPrice"))
            {
                BookPrice = Convert.ToDecimal(dr["BookPrice"]);
            }
            if (dr.Table.Columns.Contains("BookStarDate") && !dr.IsNull("BookStarDate"))
            {
                BookStarDate = Convert.ToDateTime(dr["BookStarDate"]);
            }
            if (dr.Table.Columns.Contains("BookEndDate") && !dr.IsNull("BookEndDate"))
            {
                BookEndDate = Convert.ToDateTime(dr["BookEndDate"]);
            }
            if (dr.Table.Columns.Contains("NoticePrice") && !dr.IsNull("NoticePrice"))
            {
                NoticePrice = Convert.ToDecimal(dr["NoticePrice"]);
            }
            if (dr.Table.Columns.Contains("FileStarDate") && !dr.IsNull("FileStarDate"))
            {
                FileStarDate = Convert.ToDateTime(dr["FileStarDate"]);
            }
            if (dr.Table.Columns.Contains("FileEndDate") && !dr.IsNull("FileEndDate"))
            {
                FileEndDate = Convert.ToDateTime(dr["FileEndDate"]);
            }
            if (dr.Table.Columns.Contains("CheckStatu") && !dr.IsNull("CheckStatu"))
            {
                CheckStatu = Convert.ToInt32(dr["CheckStatu"]);
            }
            if (dr.Table.Columns.Contains("ProjectId") && !dr.IsNull("ProjectId"))
            {
                ProjectId = Convert.ToInt32(dr["ProjectId"]);
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
