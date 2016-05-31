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
    /// 职别代码表
    /// </summary>
    [Serializable()]
    public class JobLevel
    {
        /// <summary>
        /// 主键ID
        /// </summary>
        [DataMember(IsRequired = false)]
        public int JobLevelId { get; set; }
        /// <summary>
        /// 职别名称
        /// </summary>
        [DataMember(IsRequired = false)]
        public string JobLevelName { get; set; }
        /// <summary>
        /// 门店ID
        /// </summary>
        [DataMember(IsRequired = false)]
        public int? PointId { get; set; }
        /// <summary>
        /// 状态
        /// </summary>
        [DataMember(IsRequired = false)]
        public byte? State { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        [DataMember(IsRequired = false)]
        public string Remark { get; set; }
        /// <summary>
        /// 职能主键ID
        /// </summary>
        [DataMember(IsRequired = false)]
        public string jobLevelDcmID { get; set; }
        /// <summary>
        /// 职别代码表
        /// </summary>
        public JobLevel() { }


        /// <summary>
        /// 职别代码表
        /// </summary>
        public JobLevel(DataRow dr)
        {
            if (dr.Table.Columns.Contains("JobLevelId") && !dr.IsNull("JobLevelId"))
            {
                JobLevelId = Convert.ToInt32(dr["JobLevelId"]);
            }
            if (dr.Table.Columns.Contains("JobLevelName") && !dr.IsNull("JobLevelName"))
            {
                JobLevelName = dr["JobLevelName"].ToString();
            }
            if (dr.Table.Columns.Contains("PointId") && !dr.IsNull("PointId"))
            {
                PointId = Convert.ToInt32(dr["PointId"]);
            }
            if (dr.Table.Columns.Contains("State") && !dr.IsNull("State"))
            {
                State = Convert.ToByte(dr["State"]);
            }
            if (dr.Table.Columns.Contains("Remark") && !dr.IsNull("Remark"))
            {
                Remark = dr["Remark"].ToString();
            }
            if (dr.Table.Columns.Contains("jobLevelDcmID") && !dr.IsNull("jobLevelDcmID"))
            {
                jobLevelDcmID = dr["jobLevelDcmID"].ToString();
            }
        }
    }
}