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
    /// 企业人员信息
    /// </summary>
	[Serializable()]
	public class UserInfo
	{	
        /// <summary>
        /// 人员ID
        /// </summary>
        [DataMember(IsRequired = false)]
		public int UserId{get;set;}
        /// <summary>
        /// 人员姓名
        /// </summary>
        [DataMember(IsRequired = false)]
		public string UserName{get;set;}
        /// <summary>
        /// 性别
        /// </summary>
        [DataMember(IsRequired = false)]
		public int Sex{get;set;}
        /// <summary>
        /// 出生年月
        /// </summary>
        [DataMember(IsRequired = false)]
		public DateTime? BirthDay{get;set;}
        /// <summary>
        /// 身份证号
        /// </summary>
        [DataMember(IsRequired = false)]
		public string UserNum{get;set;}
        /// <summary>
        /// 电话
        /// </summary>
        [DataMember(IsRequired = false)]
		public string PhoneNum{get;set;}
        /// <summary>
        /// 联系地址
        /// </summary>
        [DataMember(IsRequired = false)]
		public string Address{get;set;}
        /// <summary>
        /// 职务
        /// </summary>
        [DataMember(IsRequired = false)]
		public int Position{get;set;}
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
        /// 企业人员信息
        /// </summary>
        public UserInfo() { }
        
        
        /// <summary>
        /// 企业人员信息
        /// </summary>
        public UserInfo(DataRow dr)
        {
            if (dr.Table.Columns.Contains("UserId") && !dr.IsNull("UserId"))
            {
                UserId = Convert.ToInt32(dr["UserId"]);
            }
            if (dr.Table.Columns.Contains("UserName") && !dr.IsNull("UserName"))
            {
                UserName = dr["UserName"].ToString();
            }
            if (dr.Table.Columns.Contains("Sex") && !dr.IsNull("Sex"))
            {
                Sex = Convert.ToInt32(dr["Sex"]);
            }
            if (dr.Table.Columns.Contains("BirthDay") && !dr.IsNull("BirthDay"))
            {
                BirthDay = Convert.ToDateTime(dr["BirthDay"]);
            }
            if (dr.Table.Columns.Contains("UserNum") && !dr.IsNull("UserNum"))
            {
                UserNum = dr["UserNum"].ToString();
            }
            if (dr.Table.Columns.Contains("PhoneNum") && !dr.IsNull("PhoneNum"))
            {
                PhoneNum = dr["PhoneNum"].ToString();
            }
            if (dr.Table.Columns.Contains("Address") && !dr.IsNull("Address"))
            {
                Address = dr["Address"].ToString();
            }
            if (dr.Table.Columns.Contains("Position") && !dr.IsNull("Position"))
            {
                Position = Convert.ToInt32(dr["Position"]);
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
