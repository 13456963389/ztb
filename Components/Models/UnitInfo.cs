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
    /// 企业基本信息
    /// </summary>
	[Serializable()]
	public class UnitInfo
	{	
        /// <summary>
        /// 企业ID
        /// </summary>
        [DataMember(IsRequired = false)]
		public int UnitId{get;set;}
        /// <summary>
        /// 行政区
        /// </summary>
        [DataMember(IsRequired = false)]
		public string District{get;set;}
        /// <summary>
        /// 交易主体类型
        /// </summary>
        [DataMember(IsRequired = false)]
		public int UnitTypeId{get;set;}
        /// <summary>
        /// 企业名称
        /// </summary>
        [DataMember(IsRequired = false)]
		public string UnitName{get;set;}
        /// <summary>
        /// 联系地址
        /// </summary>
        [DataMember(IsRequired = false)]
		public string UnitAddress{get;set;}
        /// <summary>
        /// 邮政编码
        /// </summary>
        [DataMember(IsRequired = false)]
		public int? PostCode{get;set;}
        /// <summary>
        /// 行业代码
        /// </summary>
        [DataMember(IsRequired = false)]
		public int? TradeCode{get;set;}
        /// <summary>
        /// 单位性质
        /// </summary>
        [DataMember(IsRequired = false)]
		public int? UnitProperty{get;set;}
        /// <summary>
        /// 营业执照号码
        /// </summary>
        [DataMember(IsRequired = false)]
		public string BusinessLicenseNum{get;set;}
        /// <summary>
        /// 注册资金
        /// </summary>
        [DataMember(IsRequired = false)]
		public decimal? RegisterCapital{get;set;}
        /// <summary>
        /// 税务登记证号
        /// </summary>
        [DataMember(IsRequired = false)]
		public string TaxNum{get;set;}
        /// <summary>
        /// 企业负责人
        /// </summary>
        [DataMember(IsRequired = false)]
		public string Responsible{get;set;}
        /// <summary>
        /// 负责人手机
        /// </summary>
        [DataMember(IsRequired = false)]
		public string ResponsiblePhone{get;set;}
        /// <summary>
        /// 负责人身份证号
        /// </summary>
        [DataMember(IsRequired = false)]
		public string ResponsibleCardNo{get;set;}
        /// <summary>
        /// 经营范围
        /// </summary>
        [DataMember(IsRequired = false)]
		public string BusinessScope{get;set;}
        /// <summary>
        /// 所属银行
        /// </summary>
        [DataMember(IsRequired = false)]
		public int? MainBank{get;set;}
        /// <summary>
        /// 开户行
        /// </summary>
        [DataMember(IsRequired = false)]
		public string DepositBank{get;set;}
        /// <summary>
        /// 银行行号
        /// </summary>
        [DataMember(IsRequired = false)]
		public string BankNo{get;set;}
        /// <summary>
        /// 基本账户账号
        /// </summary>
        [DataMember(IsRequired = false)]
		public string AmountNum{get;set;}
        /// <summary>
        /// 备注
        /// </summary>
        [DataMember(IsRequired = false)]
		public string Remark{get;set;}
        /// <summary>
        /// 状态
        /// </summary>
        [DataMember(IsRequired = false)]
		public int State{get;set;}
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
        /// 企业基本信息
        /// </summary>
        public UnitInfo() { }
        
        
        /// <summary>
        /// 企业基本信息
        /// </summary>
        public UnitInfo(DataRow dr)
        {
            if (dr.Table.Columns.Contains("UnitId") && !dr.IsNull("UnitId"))
            {
                UnitId = Convert.ToInt32(dr["UnitId"]);
            }
            if (dr.Table.Columns.Contains("District") && !dr.IsNull("District"))
            {
                District = dr["District"].ToString();
            }
            if (dr.Table.Columns.Contains("UnitTypeId") && !dr.IsNull("UnitTypeId"))
            {
                UnitTypeId = Convert.ToInt32(dr["UnitTypeId"]);
            }
            if (dr.Table.Columns.Contains("UnitName") && !dr.IsNull("UnitName"))
            {
                UnitName = dr["UnitName"].ToString();
            }
            if (dr.Table.Columns.Contains("UnitAddress") && !dr.IsNull("UnitAddress"))
            {
                UnitAddress = dr["UnitAddress"].ToString();
            }
            if (dr.Table.Columns.Contains("PostCode") && !dr.IsNull("PostCode"))
            {
                PostCode = Convert.ToInt32(dr["PostCode"]);
            }
            if (dr.Table.Columns.Contains("TradeCode") && !dr.IsNull("TradeCode"))
            {
                TradeCode = Convert.ToInt32(dr["TradeCode"]);
            }
            if (dr.Table.Columns.Contains("UnitProperty") && !dr.IsNull("UnitProperty"))
            {
                UnitProperty = Convert.ToInt32(dr["UnitProperty"]);
            }
            if (dr.Table.Columns.Contains("BusinessLicenseNum") && !dr.IsNull("BusinessLicenseNum"))
            {
                BusinessLicenseNum = dr["BusinessLicenseNum"].ToString();
            }
            if (dr.Table.Columns.Contains("RegisterCapital") && !dr.IsNull("RegisterCapital"))
            {
                RegisterCapital = Convert.ToDecimal(dr["RegisterCapital"]);
            }
            if (dr.Table.Columns.Contains("TaxNum") && !dr.IsNull("TaxNum"))
            {
                TaxNum = dr["TaxNum"].ToString();
            }
            if (dr.Table.Columns.Contains("Responsible") && !dr.IsNull("Responsible"))
            {
                Responsible = dr["Responsible"].ToString();
            }
            if (dr.Table.Columns.Contains("ResponsiblePhone") && !dr.IsNull("ResponsiblePhone"))
            {
                ResponsiblePhone = dr["ResponsiblePhone"].ToString();
            }
            if (dr.Table.Columns.Contains("ResponsibleCardNo") && !dr.IsNull("ResponsibleCardNo"))
            {
                ResponsibleCardNo = dr["ResponsibleCardNo"].ToString();
            }
            if (dr.Table.Columns.Contains("BusinessScope") && !dr.IsNull("BusinessScope"))
            {
                BusinessScope = dr["BusinessScope"].ToString();
            }
            if (dr.Table.Columns.Contains("MainBank") && !dr.IsNull("MainBank"))
            {
                MainBank = Convert.ToInt32(dr["MainBank"]);
            }
            if (dr.Table.Columns.Contains("DepositBank") && !dr.IsNull("DepositBank"))
            {
                DepositBank = dr["DepositBank"].ToString();
            }
            if (dr.Table.Columns.Contains("BankNo") && !dr.IsNull("BankNo"))
            {
                BankNo = dr["BankNo"].ToString();
            }
            if (dr.Table.Columns.Contains("AmountNum") && !dr.IsNull("AmountNum"))
            {
                AmountNum = dr["AmountNum"].ToString();
            }
            if (dr.Table.Columns.Contains("Remark") && !dr.IsNull("Remark"))
            {
                Remark = dr["Remark"].ToString();
            }
            if (dr.Table.Columns.Contains("State") && !dr.IsNull("State"))
            {
                State = Convert.ToInt32(dr["State"]);
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
