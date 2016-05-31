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
    /// 评标专家信息
    /// </summary>
	[Serializable()]
	public class ExpertInfo
	{	
        /// <summary>
        /// 专家ID
        /// </summary>
        [DataMember(IsRequired = false)]
		public int ExpertId{get;set;}
        /// <summary>
        /// 专家姓名
        /// </summary>
        [DataMember(IsRequired = false)]
		public string ExpertName{get;set;}
        /// <summary>
        /// 专家性别
        /// </summary>
        [DataMember(IsRequired = false)]
		public int Sex{get;set;}
        /// <summary>
        /// 行业类型
        /// </summary>
        [DataMember(IsRequired = false)]
		public int TradeCode{get;set;}
        /// <summary>
        /// 联系电话
        /// </summary>
        [DataMember(IsRequired = false)]
		public string Phone{get;set;}
        /// <summary>
        /// 联系地址
        /// </summary>
        [DataMember(IsRequired = false)]
		public string Address{get;set;}
        /// <summary>
        /// 状态
        /// </summary>
        [DataMember(IsRequired = false)]
		public int State{get;set;}
        /// <summary>
        /// 评标专家信息
        /// </summary>
        public ExpertInfo() { }
        
        
        /// <summary>
        /// 评标专家信息
        /// </summary>
        public ExpertInfo(DataRow dr)
        {
            if (dr.Table.Columns.Contains("ExpertId") && !dr.IsNull("ExpertId"))
            {
                ExpertId = Convert.ToInt32(dr["ExpertId"]);
            }
            if (dr.Table.Columns.Contains("ExpertName") && !dr.IsNull("ExpertName"))
            {
                ExpertName = dr["ExpertName"].ToString();
            }
            if (dr.Table.Columns.Contains("Sex") && !dr.IsNull("Sex"))
            {
                Sex = Convert.ToInt32(dr["Sex"]);
            }
            if (dr.Table.Columns.Contains("TradeCode") && !dr.IsNull("TradeCode"))
            {
                TradeCode = Convert.ToInt32(dr["TradeCode"]);
            }
            if (dr.Table.Columns.Contains("Phone") && !dr.IsNull("Phone"))
            {
                Phone = dr["Phone"].ToString();
            }
            if (dr.Table.Columns.Contains("Address") && !dr.IsNull("Address"))
            {
                Address = dr["Address"].ToString();
            }
            if (dr.Table.Columns.Contains("State") && !dr.IsNull("State"))
            {
                State = Convert.ToInt32(dr["State"]);
            }
        }
	}
}
