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
    /// 角色信息
    /// </summary>
	[Serializable()]
	public class Role
	{	
        /// <summary>
        /// 角色ID
        /// </summary>
        [DataMember(IsRequired = false)]
		public int RoleId{get;set;}
        /// <summary>
        /// 角色名称
        /// </summary>
        [DataMember(IsRequired = false)]
		public string RoleName{get;set;}
        /// <summary>
        /// 状态
        /// </summary>
        [DataMember(IsRequired = false)]
		public byte? State{get;set;}
        /// <summary>
        /// 备注
        /// </summary>
        [DataMember(IsRequired = false)]
		public string Remark{get;set;}
        /// <summary>
        /// 角色信息
        /// </summary>
        public Role() { }
        
        
        /// <summary>
        /// 角色信息
        /// </summary>
        public Role(DataRow dr)
        {
            if (dr.Table.Columns.Contains("RoleId") && !dr.IsNull("RoleId"))
            {
                RoleId = Convert.ToInt32(dr["RoleId"]);
            }
            if (dr.Table.Columns.Contains("RoleName") && !dr.IsNull("RoleName"))
            {
                RoleName = dr["RoleName"].ToString();
            }
            if (dr.Table.Columns.Contains("State") && !dr.IsNull("State"))
            {
                State = Convert.ToByte(dr["State"]);
            }
            if (dr.Table.Columns.Contains("Remark") && !dr.IsNull("Remark"))
            {
                Remark = dr["Remark"].ToString();
            }
        }
	}
}