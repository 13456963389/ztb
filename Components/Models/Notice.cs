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
    /// 公告表
    /// </summary>
	[Serializable()]
	public class Notice
	{	
        /// <summary>
        /// 公告ID
        /// </summary>
        [DataMember(IsRequired = false)]
		public int NoticeId{get;set;}
        /// <summary>
        /// 公告名称
        /// </summary>
        [DataMember(IsRequired = false)]
		public string NoticeName{get;set;}
        /// <summary>
        /// 公告内容
        /// </summary>
        [DataMember(IsRequired = false)]
		public string NoticeContext{get;set;}
        /// <summary>
        /// 公告发布时间
        /// </summary>
        [DataMember(IsRequired = false)]
		public DateTime NoticeStarDate{get;set;}
        /// <summary>
        /// 公告截止时间
        /// </summary>
        [DataMember(IsRequired = false)]
		public DateTime NoticeEndDate{get;set;}
        /// <summary>
        /// 审核状态
        /// </summary>
        [DataMember(IsRequired = false)]
		public int CheckStatu{get;set;}
        /// <summary>
        /// 项目ID
        /// </summary>
        [DataMember(IsRequired = false)]
		public int ProjectId{get;set;}
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
        /// 公告类型
        /// </summary>
        [DataMember(IsRequired = false)]
		public int NoticeType{get;set;}
        /// <summary>
        /// 开标时间
        /// </summary>
        [DataMember(IsRequired = false)]
		public DateTime ReviewDate{get;set;}
        /// <summary>
        /// 公告表
        /// </summary>
        public Notice() { }
        
        
        /// <summary>
        /// 公告表
        /// </summary>
        public Notice(DataRow dr)
        {
            if (dr.Table.Columns.Contains("NoticeId") && !dr.IsNull("NoticeId"))
            {
                NoticeId = Convert.ToInt32(dr["NoticeId"]);
            }
            if (dr.Table.Columns.Contains("NoticeName") && !dr.IsNull("NoticeName"))
            {
                NoticeName = dr["NoticeName"].ToString();
            }
            if (dr.Table.Columns.Contains("NoticeContext") && !dr.IsNull("NoticeContext"))
            {
                NoticeContext = dr["NoticeContext"].ToString();
            }
            if (dr.Table.Columns.Contains("NoticeStarDate") && !dr.IsNull("NoticeStarDate"))
            {
                NoticeStarDate = Convert.ToDateTime(dr["NoticeStarDate"]);
            }
            if (dr.Table.Columns.Contains("NoticeEndDate") && !dr.IsNull("NoticeEndDate"))
            {
                NoticeEndDate = Convert.ToDateTime(dr["NoticeEndDate"]);
            }
            if (dr.Table.Columns.Contains("CheckStatu") && !dr.IsNull("CheckStatu"))
            {
                CheckStatu = Convert.ToInt32(dr["CheckStatu"]);
            }
            if (dr.Table.Columns.Contains("ProjectId") && !dr.IsNull("ProjectId"))
            {
                ProjectId = Convert.ToInt32(dr["ProjectId"]);
            }
            if (dr.Table.Columns.Contains("EmployeeId") && !dr.IsNull("EmployeeId"))
            {
                EmployeeId = Convert.ToInt32(dr["EmployeeId"]);
            }
            if (dr.Table.Columns.Contains("CreateTime") && !dr.IsNull("CreateTime"))
            {
                CreateTime = Convert.ToDateTime(dr["CreateTime"]);
            }
            if (dr.Table.Columns.Contains("NoticeType") && !dr.IsNull("NoticeType"))
            {
                NoticeType = Convert.ToInt32(dr["NoticeType"]);
            }
            if (dr.Table.Columns.Contains("ReviewDate") && !dr.IsNull("ReviewDate"))
            {
                ReviewDate = Convert.ToDateTime(dr["ReviewDate"]);
            }
        }
	}
}
