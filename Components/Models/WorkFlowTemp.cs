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
    /// 工作流
    /// </summary>
	[Serializable()]
	public class WorkFlowTemp
	{	
        /// <summary>
        /// 节点ID
        /// </summary>
        [DataMember(IsRequired = false)]
		public int NodeId{get;set;}
        /// <summary>
        /// 节点编码
        /// </summary>
        [DataMember(IsRequired = false)]
		public string NodeCode{get;set;}
        /// <summary>
        /// 节点名称
        /// </summary>
        [DataMember(IsRequired = false)]
		public string NodeName{get;set;}
        /// <summary>
        /// 节点地址
        /// </summary>
        [DataMember(IsRequired = false)]
		public string NodeUrl{get;set;}
        /// <summary>
        /// 父节点ID
        /// </summary>
        [DataMember(IsRequired = false)]
		public string PCode{get;set;}
        /// <summary>
        /// 前进节点
        /// </summary>
        [DataMember(IsRequired = false)]
		public string QjNodeCode{get;set;}
        /// <summary>
        /// 退回节点
        /// </summary>
        [DataMember(IsRequired = false)]
		public string ThNodeCode{get;set;}
        /// <summary>
        /// 节点状态
        /// </summary>
        [DataMember(IsRequired = false)]
		public int? NodeStatu{get;set;}
        /// <summary>
        /// 节点类型
        /// </summary>
        [DataMember(IsRequired = false)]
		public int NodeType{get;set;}
        /// <summary>
        /// 模版类型
        /// </summary>
        [DataMember(IsRequired = false)]
		public int? TemplateId{get;set;}
        /// <summary>
        /// 操作人
        /// </summary>
        [DataMember(IsRequired = false)]
		public int? EmployeeId{get;set;}
        /// <summary>
        /// 只读页面地址
        /// </summary>
        [DataMember(IsRequired = false)]
		public string NodeShowUrl{get;set;}
        /// <summary>
        /// 工作流
        /// </summary>
        public WorkFlowTemp() { }
        
        
        /// <summary>
        /// 工作流
        /// </summary>
        public WorkFlowTemp(DataRow dr)
        {
            if (dr.Table.Columns.Contains("NodeId") && !dr.IsNull("NodeId"))
            {
                NodeId = Convert.ToInt32(dr["NodeId"]);
            }
            if (dr.Table.Columns.Contains("NodeCode") && !dr.IsNull("NodeCode"))
            {
                NodeCode = dr["NodeCode"].ToString();
            }
            if (dr.Table.Columns.Contains("NodeName") && !dr.IsNull("NodeName"))
            {
                NodeName = dr["NodeName"].ToString();
            }
            if (dr.Table.Columns.Contains("NodeUrl") && !dr.IsNull("NodeUrl"))
            {
                NodeUrl = dr["NodeUrl"].ToString();
            }
            if (dr.Table.Columns.Contains("PCode") && !dr.IsNull("PCode"))
            {
                PCode = dr["PCode"].ToString();
            }
            if (dr.Table.Columns.Contains("QjNodeCode") && !dr.IsNull("QjNodeCode"))
            {
                QjNodeCode = dr["QjNodeCode"].ToString();
            }
            if (dr.Table.Columns.Contains("ThNodeCode") && !dr.IsNull("ThNodeCode"))
            {
                ThNodeCode = dr["ThNodeCode"].ToString();
            }
            if (dr.Table.Columns.Contains("NodeStatu") && !dr.IsNull("NodeStatu"))
            {
                NodeStatu = Convert.ToInt32(dr["NodeStatu"]);
            }
            if (dr.Table.Columns.Contains("NodeType") && !dr.IsNull("NodeType"))
            {
                NodeType = Convert.ToInt32(dr["NodeType"]);
            }
            if (dr.Table.Columns.Contains("TemplateId") && !dr.IsNull("TemplateId"))
            {
                TemplateId = Convert.ToInt32(dr["TemplateId"]);
            }
            if (dr.Table.Columns.Contains("EmployeeId") && !dr.IsNull("EmployeeId"))
            {
                EmployeeId = Convert.ToInt32(dr["EmployeeId"]);
            }
            if (dr.Table.Columns.Contains("NodeShowUrl") && !dr.IsNull("NodeShowUrl"))
            {
                NodeShowUrl = dr["NodeShowUrl"].ToString();
            }
        }
	}
}
