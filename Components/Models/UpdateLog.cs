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
    /// 更新日志
    /// </summary>
	[Serializable()]
	public class UpdateLog
	{	
        /// <summary>
        /// 主键ID
        /// </summary>
        [DataMember(IsRequired = false)]
		public int UpdateLogId{get;set;}
        /// <summary>
        /// 标题
        /// </summary>
        [DataMember(IsRequired = false)]
		public string Title{get;set;}
        /// <summary>
        /// 版本号
        /// </summary>
        [DataMember(IsRequired = false)]
		public string Version{get;set;}
        /// <summary>
        /// 时间
        /// </summary>
        [DataMember(IsRequired = false)]
		public DateTime? Time{get;set;}
        /// <summary>
        /// 描述
        /// </summary>
        [DataMember(IsRequired = false)]
		public string Description{get;set;}
        /// <summary>
        /// 内容
        /// </summary>
        [DataMember(IsRequired = false)]
		public string Text{get;set;}
        /// <summary>
        /// 更新日志
        /// </summary>
        public UpdateLog() { }
        
        
        /// <summary>
        /// 更新日志
        /// </summary>
        public UpdateLog(DataRow dr)
        {
            if (dr.Table.Columns.Contains("UpdateLogId") && !dr.IsNull("UpdateLogId"))
            {
                UpdateLogId = Convert.ToInt32(dr["UpdateLogId"]);
            }
            if (dr.Table.Columns.Contains("Title") && !dr.IsNull("Title"))
            {
                Title = dr["Title"].ToString();
            }
            if (dr.Table.Columns.Contains("Version") && !dr.IsNull("Version"))
            {
                Version = dr["Version"].ToString();
            }
            if (dr.Table.Columns.Contains("Time") && !dr.IsNull("Time"))
            {
                Time = Convert.ToDateTime(dr["Time"]);
            }
            if (dr.Table.Columns.Contains("Description") && !dr.IsNull("Description"))
            {
                Description = dr["Description"].ToString();
            }
            if (dr.Table.Columns.Contains("Text") && !dr.IsNull("Text"))
            {
                Text = dr["Text"].ToString();
            }
        }
	}
}