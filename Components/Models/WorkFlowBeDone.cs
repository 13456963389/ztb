//============================================================
//author:于永博
//============================================================

using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Runtime.Serialization;

namespace DSM.Models
{	
    /// <summary>
    /// 
    /// </summary>
	[Serializable()]
	public class WorkFlowBeDone
	{	
        /// <summary>
        /// 待办主键
        /// </summary>
        [DataMember(IsRequired = false)]
		public int WFDoneId{get;set;}
        /// <summary>
        /// 
        /// </summary>
        [DataMember(IsRequired = false)]
		public int? UserId{get;set;}
        /// <summary>
        /// 流程ID
        /// </summary>
        [DataMember(IsRequired = false)]
		public int? TemplateId{get;set;}
        /// <summary>
        /// 业务id
        /// </summary>
        [DataMember(IsRequired = false)]
		public int? BusinessBillId{get;set;}
        /// <summary>
        /// 节点ID
        /// </summary>
        [DataMember(IsRequired = false)]
		public int? NodeId{get;set;}
        /// <summary>
        /// 节点Code
        /// </summary>
        [DataMember(IsRequired = false)]
		public string NodeCode{get;set;}
        /// <summary>
        /// 操作，nil或BeDone为待办
        /// </summary>
        [DataMember(IsRequired = false)]
		public int? OperateState{get;set;}
        /// <summary>
        /// 操作时间
        /// </summary>
        [DataMember(IsRequired = false)]
		public DateTime? OperateDate{get;set;}
        /// <summary>
        /// 操作时间
        /// </summary>
        [DataMember(IsRequired = false)]
		public int? OperateDate_Order{get;set;}
        /// <summary>
        /// 描述
        /// </summary>
        [DataMember(IsRequired = false)]
		public string OperateDesc{get;set;}
        /// <summary>
        /// 备注
        /// </summary>
        [DataMember(IsRequired = false)]
		public string Remark{get;set;}
        /// <summary>
        /// 
        /// </summary>
        public WorkFlowBeDone() { }
        
        
        /// <summary>
        /// 
        /// </summary>
        public WorkFlowBeDone(DataRow dr)
        {
            if (dr.Table.Columns.Contains("WFDoneId") && !dr.IsNull("WFDoneId"))
            {
                WFDoneId = Convert.ToInt32(dr["WFDoneId"]);
            }
            if (dr.Table.Columns.Contains("UserId") && !dr.IsNull("UserId"))
            {
                UserId = Convert.ToInt32(dr["UserId"]);
            }
            if (dr.Table.Columns.Contains("TemplateId") && !dr.IsNull("TemplateId"))
            {
                TemplateId = Convert.ToInt32(dr["TemplateId"]);
            }
            if (dr.Table.Columns.Contains("BusinessBillId") && !dr.IsNull("BusinessBillId"))
            {
                BusinessBillId = Convert.ToInt32(dr["BusinessBillId"]);
            }
            if (dr.Table.Columns.Contains("NodeId") && !dr.IsNull("NodeId"))
            {
                NodeId = Convert.ToInt32(dr["NodeId"]);
            }
            if (dr.Table.Columns.Contains("NodeCode") && !dr.IsNull("NodeCode"))
            {
                NodeCode = dr["NodeCode"].ToString();
            }
            if (dr.Table.Columns.Contains("OperateState") && !dr.IsNull("OperateState"))
            {
                OperateState = Convert.ToInt32(dr["OperateState"]);
            }
            if (dr.Table.Columns.Contains("OperateDate") && !dr.IsNull("OperateDate"))
            {
                OperateDate = Convert.ToDateTime(dr["OperateDate"]);
            }
            if (dr.Table.Columns.Contains("OperateDate_Order") && !dr.IsNull("OperateDate_Order"))
            {
                OperateDate_Order = Convert.ToInt32(dr["OperateDate_Order"]);
            }
            if (dr.Table.Columns.Contains("OperateDesc") && !dr.IsNull("OperateDesc"))
            {
                OperateDesc = dr["OperateDesc"].ToString();
            }
            if (dr.Table.Columns.Contains("Remark") && !dr.IsNull("Remark"))
            {
                Remark = dr["Remark"].ToString();
            }
        }
	}
}
