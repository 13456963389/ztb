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
    /// 模版管理
    /// </summary>
	[Serializable()]
	public class FlowTemplate
	{	
        /// <summary>
        /// 模版ID
        /// </summary>
        [DataMember(IsRequired = false)]
		public int TemplateId{get;set;}
        /// <summary>
        /// 模版编号
        /// </summary>
        [DataMember(IsRequired = false)]
		public string TemplateCode{get;set;}
        /// <summary>
        /// 模版名称
        /// </summary>
        [DataMember(IsRequired = false)]
		public string TemplateName{get;set;}
        /// <summary>
        /// 模版类型
        /// </summary>
        [DataMember(IsRequired = false)]
		public string TemplateType{get;set;}
        /// <summary>
        /// 备注
        /// </summary>
        [DataMember(IsRequired = false)]
		public string Remark{get;set;}
        /// <summary>
        /// 内容
        /// </summary>
        [DataMember(IsRequired = false)]
		public string Context{get;set;}
        /// <summary>
        /// 模版管理
        /// </summary>
        public FlowTemplate() { }
        
        
        /// <summary>
        /// 模版管理
        /// </summary>
        public FlowTemplate(DataRow dr)
        {
            if (dr.Table.Columns.Contains("TemplateId") && !dr.IsNull("TemplateId"))
            {
                TemplateId = Convert.ToInt32(dr["TemplateId"]);
            }
            if (dr.Table.Columns.Contains("TemplateCode") && !dr.IsNull("TemplateCode"))
            {
                TemplateCode = dr["TemplateCode"].ToString();
            }
            if (dr.Table.Columns.Contains("TemplateName") && !dr.IsNull("TemplateName"))
            {
                TemplateName = dr["TemplateName"].ToString();
            }
            if (dr.Table.Columns.Contains("TemplateType") && !dr.IsNull("TemplateType"))
            {
                TemplateType = dr["TemplateType"].ToString();
            }
            if (dr.Table.Columns.Contains("Remark") && !dr.IsNull("Remark"))
            {
                Remark = dr["Remark"].ToString();
            }
            if (dr.Table.Columns.Contains("Context") && !dr.IsNull("Context"))
            {
                Context = dr["Context"].ToString();
            }
        }
	}
}
