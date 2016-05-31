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
    /// 数据字典
    /// </summary>
	[Serializable()]
	public class Dict
	{	
        /// <summary>
        /// 字典ID
        /// </summary>
        [DataMember(IsRequired = false)]
		public int DictId{get;set;}
        /// <summary>
        /// 编号
        /// </summary>
        [DataMember(IsRequired = false)]
		public string DictCode{get;set;}
        /// <summary>
        /// 名称
        /// </summary>
        [DataMember(IsRequired = false)]
		public string DictName{get;set;}
        /// <summary>
        /// 值
        /// </summary>
        [DataMember(IsRequired = false)]
		public string DictValue{get;set;}
        /// <summary>
        /// 父节点
        /// </summary>
        [DataMember(IsRequired = false)]
		public int PId{get;set;}
        /// <summary>
        /// 说明
        /// </summary>
        [DataMember(IsRequired = false)]
		public string Remark{get;set;}
        /// <summary>
        /// 数据字典
        /// </summary>
        public Dict() { }
        
        
        /// <summary>
        /// 数据字典
        /// </summary>
        public Dict(DataRow dr)
        {
            if (dr.Table.Columns.Contains("DictId") && !dr.IsNull("DictId"))
            {
                DictId = Convert.ToInt32(dr["DictId"]);
            }
            if (dr.Table.Columns.Contains("DictCode") && !dr.IsNull("DictCode"))
            {
                DictCode = dr["DictCode"].ToString();
            }
            if (dr.Table.Columns.Contains("DictName") && !dr.IsNull("DictName"))
            {
                DictName = dr["DictName"].ToString();
            }
            if (dr.Table.Columns.Contains("DictValue") && !dr.IsNull("DictValue"))
            {
                DictValue = dr["DictValue"].ToString();
            }
            if (dr.Table.Columns.Contains("PId") && !dr.IsNull("PId"))
            {
                PId = Convert.ToInt32(dr["PId"]);
            }
            if (dr.Table.Columns.Contains("Remark") && !dr.IsNull("Remark"))
            {
                Remark = dr["Remark"].ToString();
            }
        }
	}
}
