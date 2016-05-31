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
    /// 资质信息
    /// </summary>
	[Serializable()]
	public class Qualification
	{	
        /// <summary>
        /// 资质ID
        /// </summary>
        [DataMember(IsRequired = false)]
		public int UQId{get;set;}
        /// <summary>
        /// 单位Id
        /// </summary>
        [DataMember(IsRequired = false)]
		public int UnitId{get;set;}
        /// <summary>
        /// 人员Id
        /// </summary>
        [DataMember(IsRequired = false)]
		public int UserId{get;set;}
        /// <summary>
        /// 资质名称
        /// </summary>
        [DataMember(IsRequired = false)]
		public string QName{get;set;}
        /// <summary>
        /// 资质编号
        /// </summary>
        [DataMember(IsRequired = false)]
		public string QCode{get;set;}
        /// <summary>
        /// 颁发时间
        /// </summary>
        [DataMember(IsRequired = false)]
		public DateTime StarDate{get;set;}
        /// <summary>
        /// 有效截止时间
        /// </summary>
        [DataMember(IsRequired = false)]
		public DateTime EndDate{get;set;}
        /// <summary>
        /// 备注
        /// </summary>
        [DataMember(IsRequired = false)]
		public string Remark{get;set;}
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
        /// 资质信息
        /// </summary>
        public Qualification() { }
        
        
        /// <summary>
        /// 资质信息
        /// </summary>
        public Qualification(DataRow dr)
        {
            if (dr.Table.Columns.Contains("UQId") && !dr.IsNull("UQId"))
            {
                UQId = Convert.ToInt32(dr["UQId"]);
            }
            if (dr.Table.Columns.Contains("UnitId") && !dr.IsNull("UnitId"))
            {
                UnitId = Convert.ToInt32(dr["UnitId"]);
            }
            if (dr.Table.Columns.Contains("UserId") && !dr.IsNull("UserId"))
            {
                UserId = Convert.ToInt32(dr["UserId"]);
            }
            if (dr.Table.Columns.Contains("QName") && !dr.IsNull("QName"))
            {
                QName = dr["QName"].ToString();
            }
            if (dr.Table.Columns.Contains("QCode") && !dr.IsNull("QCode"))
            {
                QCode = dr["QCode"].ToString();
            }
            if (dr.Table.Columns.Contains("StarDate") && !dr.IsNull("StarDate"))
            {
                StarDate = Convert.ToDateTime(dr["StarDate"]);
            }
            if (dr.Table.Columns.Contains("EndDate") && !dr.IsNull("EndDate"))
            {
                EndDate = Convert.ToDateTime(dr["EndDate"]);
            }
            if (dr.Table.Columns.Contains("Remark") && !dr.IsNull("Remark"))
            {
                Remark = dr["Remark"].ToString();
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
