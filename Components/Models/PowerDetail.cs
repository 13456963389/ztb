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
    /// 操作权限代码
    /// </summary>
	[Serializable()]
	public class PowerDetail
	{	
        /// <summary>
        /// 主键ID
        /// </summary>
        [DataMember(IsRequired = false)]
		public int PowerDetailId{get;set;}
        /// <summary>
        /// 名称
        /// </summary>
        [DataMember(IsRequired = false)]
		public string PowerDetailName{get;set;}
        /// <summary>
        /// 编码
        /// </summary>
        [DataMember(IsRequired = false)]
		public string PowerDetailCode{get;set;}
        /// <summary>
        /// 操作权限代码
        /// </summary>
        public PowerDetail() { }
        
        
        /// <summary>
        /// 操作权限代码
        /// </summary>
        public PowerDetail(DataRow dr)
        {
            if (dr.Table.Columns.Contains("PowerDetailId") && !dr.IsNull("PowerDetailId"))
            {
                PowerDetailId = Convert.ToInt32(dr["PowerDetailId"]);
            }
            if (dr.Table.Columns.Contains("PowerDetailName") && !dr.IsNull("PowerDetailName"))
            {
                PowerDetailName = dr["PowerDetailName"].ToString();
            }
            if (dr.Table.Columns.Contains("PowerDetailCode") && !dr.IsNull("PowerDetailCode"))
            {
                PowerDetailCode = dr["PowerDetailCode"].ToString();
            }
        }
	}
}