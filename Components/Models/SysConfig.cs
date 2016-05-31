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
    /// 系统配置
    /// </summary>
	[Serializable()]
	public class SysConfig
	{	
        /// <summary>
        /// 配置ID
        /// </summary>
        [DataMember(IsRequired = false)]
		public int ConfigId{get;set;}
        /// <summary>
        /// 编号
        /// </summary>
        [DataMember(IsRequired = false)]
		public string ConfigCode{get;set;}
        /// <summary>
        /// 名称
        /// </summary>
        [DataMember(IsRequired = false)]
		public string ConfigName{get;set;}
        /// <summary>
        /// 值
        /// </summary>
        [DataMember(IsRequired = false)]
		public string ConfigValue{get;set;}
        /// <summary>
        /// 说明
        /// </summary>
        [DataMember(IsRequired = false)]
		public string Remark{get;set;}
        /// <summary>
        /// 系统配置
        /// </summary>
        public SysConfig() { }
        
        
        /// <summary>
        /// 系统配置
        /// </summary>
        public SysConfig(DataRow dr)
        {
            if (dr.Table.Columns.Contains("ConfigId") && !dr.IsNull("ConfigId"))
            {
                ConfigId = Convert.ToInt32(dr["ConfigId"]);
            }
            if (dr.Table.Columns.Contains("ConfigCode") && !dr.IsNull("ConfigCode"))
            {
                ConfigCode = dr["ConfigCode"].ToString();
            }
            if (dr.Table.Columns.Contains("ConfigName") && !dr.IsNull("ConfigName"))
            {
                ConfigName = dr["ConfigName"].ToString();
            }
            if (dr.Table.Columns.Contains("ConfigValue") && !dr.IsNull("ConfigValue"))
            {
                ConfigValue = dr["ConfigValue"].ToString();
            }
            if (dr.Table.Columns.Contains("Remark") && !dr.IsNull("Remark"))
            {
                Remark = dr["Remark"].ToString();
            }
        }
	}
}
