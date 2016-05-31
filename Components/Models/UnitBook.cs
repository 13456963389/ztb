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
    /// 企业证书信息
    /// </summary>
	[Serializable()]
	public class UnitBook
	{	
        /// <summary>
        /// 证书ID
        /// </summary>
        [DataMember(IsRequired = false)]
		public int UnitBookId{get;set;}
        /// <summary>
        /// 单位Id
        /// </summary>
        [DataMember(IsRequired = false)]
		public int UnitId{get;set;}
        /// <summary>
        /// 证书类别
        /// </summary>
        [DataMember(IsRequired = false)]
		public int BookType{get;set;}
        /// <summary>
        /// 证书编号
        /// </summary>
        [DataMember(IsRequired = false)]
		public string BookNum{get;set;}
        /// <summary>
        /// 发证机构
        /// </summary>
        [DataMember(IsRequired = false)]
		public string AwardName{get;set;}
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
        /// 企业证书信息
        /// </summary>
        public UnitBook() { }
        
        
        /// <summary>
        /// 企业证书信息
        /// </summary>
        public UnitBook(DataRow dr)
        {
            if (dr.Table.Columns.Contains("UnitBookId") && !dr.IsNull("UnitBookId"))
            {
                UnitBookId = Convert.ToInt32(dr["UnitBookId"]);
            }
            if (dr.Table.Columns.Contains("UnitId") && !dr.IsNull("UnitId"))
            {
                UnitId = Convert.ToInt32(dr["UnitId"]);
            }
            if (dr.Table.Columns.Contains("BookType") && !dr.IsNull("BookType"))
            {
                BookType = Convert.ToInt32(dr["BookType"]);
            }
            if (dr.Table.Columns.Contains("BookNum") && !dr.IsNull("BookNum"))
            {
                BookNum = dr["BookNum"].ToString();
            }
            if (dr.Table.Columns.Contains("AwardName") && !dr.IsNull("AwardName"))
            {
                AwardName = dr["AwardName"].ToString();
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
