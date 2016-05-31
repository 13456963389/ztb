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
    /// 权限对象
    /// </summary>
	[Serializable()]
	public class PowerObject
	{	
        /// <summary>
        /// 权限对象ID
        /// </summary>
        [DataMember(IsRequired = false)]
		public int Id{get;set;}
        /// <summary>
        /// 权限对象父类ID
        /// </summary>
        [DataMember(IsRequired = false)]
		public int? ParentId{get;set;}
        /// <summary>
        /// 权限对象名称
        /// </summary>
        [DataMember(IsRequired = false)]
		public string Name{get;set;}
        /// <summary>
        /// 权限对象Code
        /// </summary>
        [DataMember(IsRequired = false)]
		public string Code{get;set;}
        /// <summary>
        /// URL
        /// </summary>
        [DataMember(IsRequired = false)]
		public string Url{get;set;}
        /// <summary>
        /// 图片
        /// </summary>
        [DataMember(IsRequired = false)]
		public string Img{get;set;}
        /// <summary>
        /// 权限对象排序
        /// </summary>
        [DataMember(IsRequired = false)]
		public int? Ord{get;set;}
        /// <summary>
        /// 操作权限
        /// </summary>
        [DataMember(IsRequired = false)]
		public string Detail{get;set;}
        /// <summary>
        /// 
        /// </summary>
        [DataMember(IsRequired = false)]
		public int? IsMenu{get;set;}
        /// <summary>
        /// 权限对象
        /// </summary>
        public PowerObject() { }
        
        
        /// <summary>
        /// 权限对象
        /// </summary>
        public PowerObject(DataRow dr)
        {
            if (dr.Table.Columns.Contains("Id") && !dr.IsNull("Id"))
            {
                Id = Convert.ToInt32(dr["Id"]);
            }
            if (dr.Table.Columns.Contains("ParentId") && !dr.IsNull("ParentId"))
            {
                ParentId = Convert.ToInt32(dr["ParentId"]);
            }
            if (dr.Table.Columns.Contains("Name") && !dr.IsNull("Name"))
            {
                Name = dr["Name"].ToString();
            }
            if (dr.Table.Columns.Contains("Code") && !dr.IsNull("Code"))
            {
                Code = dr["Code"].ToString();
            }
            if (dr.Table.Columns.Contains("Url") && !dr.IsNull("Url"))
            {
                Url = dr["Url"].ToString();
            }
            if (dr.Table.Columns.Contains("Img") && !dr.IsNull("Img"))
            {
                Img = dr["Img"].ToString();
            }
            if (dr.Table.Columns.Contains("Ord") && !dr.IsNull("Ord"))
            {
                Ord = Convert.ToInt32(dr["Ord"]);
            }
            if (dr.Table.Columns.Contains("Detail") && !dr.IsNull("Detail"))
            {
                Detail = dr["Detail"].ToString();
            }
            if (dr.Table.Columns.Contains("isMenu") && !dr.IsNull("isMenu"))
            {
                IsMenu = Convert.ToInt32(dr["isMenu"]);
            }
        }
	}
}