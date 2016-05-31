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
    /// 附件管理
    /// </summary>
	[Serializable()]
	public class FileInfo
	{	
        /// <summary>
        /// 文件ID
        /// </summary>
        [DataMember(IsRequired = false)]
		public int FileId{get;set;}
        /// <summary>
        /// 文件名称
        /// </summary>
        [DataMember(IsRequired = false)]
		public string FileName{get;set;}
        /// <summary>
        /// 文件路径
        /// </summary>
        [DataMember(IsRequired = false)]
		public string FileUrl{get;set;}
        /// <summary>
        /// 文件类型
        /// </summary>
        [DataMember(IsRequired = false)]
		public int FileType{get;set;}
        /// <summary>
        /// 业务ID
        /// </summary>
        [DataMember(IsRequired = false)]
		public int BusinessId{get;set;}
        /// <summary>
        /// 扩展名
        /// </summary>
        [DataMember(IsRequired = false)]
		public string KZM{get;set;}
        /// <summary>
        /// 大小
        /// </summary>
        [DataMember(IsRequired = false)]
		public int? FileSize{get;set;}
        /// <summary>
        /// 上传人
        /// </summary>
        [DataMember(IsRequired = false)]
		public int? EmployeeId{get;set;}
        /// <summary>
        /// 上传时间
        /// </summary>
        [DataMember(IsRequired = false)]
		public DateTime? CreateTime{get;set;}
        /// <summary>
        /// 
        /// </summary>
        [DataMember(IsRequired = false)]
		public int? UnitId{get;set;}
        /// <summary>
        /// 
        /// </summary>
        [DataMember(IsRequired = false)]
		public DateTime? DjTime{get;set;}
        /// <summary>
        /// 附件管理
        /// </summary>
        public FileInfo() { }
        
        
        /// <summary>
        /// 附件管理
        /// </summary>
        public FileInfo(DataRow dr)
        {
            if (dr.Table.Columns.Contains("FileId") && !dr.IsNull("FileId"))
            {
                FileId = Convert.ToInt32(dr["FileId"]);
            }
            if (dr.Table.Columns.Contains("FileName") && !dr.IsNull("FileName"))
            {
                FileName = dr["FileName"].ToString();
            }
            if (dr.Table.Columns.Contains("FileUrl") && !dr.IsNull("FileUrl"))
            {
                FileUrl = dr["FileUrl"].ToString();
            }
            if (dr.Table.Columns.Contains("FileType") && !dr.IsNull("FileType"))
            {
                FileType = Convert.ToInt32(dr["FileType"]);
            }
            if (dr.Table.Columns.Contains("BusinessId") && !dr.IsNull("BusinessId"))
            {
                BusinessId = Convert.ToInt32(dr["BusinessId"]);
            }
            if (dr.Table.Columns.Contains("KZM") && !dr.IsNull("KZM"))
            {
                KZM = dr["KZM"].ToString();
            }
            if (dr.Table.Columns.Contains("FileSize") && !dr.IsNull("FileSize"))
            {
                FileSize = Convert.ToInt32(dr["FileSize"]);
            }
            if (dr.Table.Columns.Contains("EmployeeId") && !dr.IsNull("EmployeeId"))
            {
                EmployeeId = Convert.ToInt32(dr["EmployeeId"]);
            }
            if (dr.Table.Columns.Contains("CreateTime") && !dr.IsNull("CreateTime"))
            {
                CreateTime = Convert.ToDateTime(dr["CreateTime"]);
            }
            if (dr.Table.Columns.Contains("UnitId") && !dr.IsNull("UnitId"))
            {
                UnitId = Convert.ToInt32(dr["UnitId"]);
            }
            if (dr.Table.Columns.Contains("DjTime") && !dr.IsNull("DjTime"))
            {
                DjTime = Convert.ToDateTime(dr["DjTime"]);
            }
        }
	}
}
