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
	public class WorkFlowOHist
	{	
        /// <summary>
        /// 
        /// </summary>
        [DataMember(IsRequired = false)]
		public int WfHisId{get;set;}
        /// <summary>
        /// 流程唯一编号(外键-WorkFlow)
        /// </summary>
        [DataMember(IsRequired = false)]
		public int? TemplateId{get;set;}
        /// <summary>
        /// 用户编号
        /// </summary>
        [DataMember(IsRequired = false)]
		public int? UserId{get;set;}
        /// <summary>
        /// 节点id
        /// </summary>
        [DataMember(IsRequired = false)]
		public int? NodeId{get;set;}
        /// <summary>
        /// 节点code
        /// </summary>
        [DataMember(IsRequired = false)]
		public string NodeCode{get;set;}
        /// <summary>
        /// 操作时间
        /// </summary>
        [DataMember(IsRequired = false)]
		public DateTime? OperateTime{get;set;}
        /// <summary>
        /// 操作时间
        /// </summary>
        [DataMember(IsRequired = false)]
		public int? OperateTime_order{get;set;}
        /// <summary>
        /// 业务编号
        /// </summary>
        [DataMember(IsRequired = false)]
		public int? BusinessBillId{get;set;}
        /// <summary>
        /// 操作状态
        /// </summary>
        [DataMember(IsRequired = false)]
		public int? OperateState{get;set;}
        /// <summary>
        /// 节点状态
        /// </summary>
        [DataMember(IsRequired = false)]
		public int? NodeActionStatus{get;set;}
        /// <summary>
        /// 流程状态
        /// </summary>
        [DataMember(IsRequired = false)]
		public int? WFActiveStatus{get;set;}
        /// <summary>
        /// 
        /// </summary>
        [DataMember(IsRequired = false)]
		public string WFGUID{get;set;}
        /// <summary>
        /// 
        /// </summary>
        public WorkFlowOHist() { }
        
        
        /// <summary>
        /// 
        /// </summary>
        public WorkFlowOHist(DataRow dr)
        {
            if (dr.Table.Columns.Contains("WfHisId") && !dr.IsNull("WfHisId"))
            {
                WfHisId = Convert.ToInt32(dr["WfHisId"]);
            }
            if (dr.Table.Columns.Contains("TemplateId") && !dr.IsNull("TemplateId"))
            {
                TemplateId = Convert.ToInt32(dr["TemplateId"]);
            }
            if (dr.Table.Columns.Contains("UserId") && !dr.IsNull("UserId"))
            {
                UserId = Convert.ToInt32(dr["UserId"]);
            }
            if (dr.Table.Columns.Contains("NodeId") && !dr.IsNull("NodeId"))
            {
                NodeId = Convert.ToInt32(dr["NodeId"]);
            }
            if (dr.Table.Columns.Contains("NodeCode") && !dr.IsNull("NodeCode"))
            {
                NodeCode = dr["NodeCode"].ToString();
            }
            if (dr.Table.Columns.Contains("OperateTime") && !dr.IsNull("OperateTime"))
            {
                OperateTime = Convert.ToDateTime(dr["OperateTime"]);
            }
            if (dr.Table.Columns.Contains("OperateTime_order") && !dr.IsNull("OperateTime_order"))
            {
                OperateTime_order = Convert.ToInt32(dr["OperateTime_order"]);
            }
            if (dr.Table.Columns.Contains("BusinessBillId") && !dr.IsNull("BusinessBillId"))
            {
                BusinessBillId = Convert.ToInt32(dr["BusinessBillId"]);
            }
            if (dr.Table.Columns.Contains("OperateState") && !dr.IsNull("OperateState"))
            {
                OperateState = Convert.ToInt32(dr["OperateState"]);
            }
            if (dr.Table.Columns.Contains("NodeActionStatus") && !dr.IsNull("NodeActionStatus"))
            {
                NodeActionStatus = Convert.ToInt32(dr["NodeActionStatus"]);
            }
            if (dr.Table.Columns.Contains("WFActiveStatus") && !dr.IsNull("WFActiveStatus"))
            {
                WFActiveStatus = Convert.ToInt32(dr["WFActiveStatus"]);
            }
            if (dr.Table.Columns.Contains("WFGUID") && !dr.IsNull("WFGUID"))
            {
                WFGUID = dr["WFGUID"].ToString();
            }
        }
	}
}
