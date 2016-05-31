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
    /// 角色权限
    /// </summary>
	[Serializable()]
	public class RolePower
	{	
        /// <summary>
        /// 主键ID
        /// </summary>
        [DataMember(IsRequired = false)]
		public int RolePowerId{get;set;}
        /// <summary>
        /// 角色ID
        /// </summary>
        [DataMember(IsRequired = false)]
		public int? RoleId{get;set;}
        /// <summary>
        /// 权限ID
        /// </summary>
        [DataMember(IsRequired = false)]
		public int? PowerId{get;set;}
        /// <summary>
        /// 具体权限
        /// </summary>
        [DataMember(IsRequired = false)]
		public string PowerDetail{get;set;}
        /// <summary>
        /// 角色权限
        /// </summary>
        public RolePower() { }
        
        
        /// <summary>
        /// 角色权限
        /// </summary>
        public RolePower(DataRow dr)
        {
            if (dr.Table.Columns.Contains("RolePowerId") && !dr.IsNull("RolePowerId"))
            {
                RolePowerId = Convert.ToInt32(dr["RolePowerId"]);
            }
            if (dr.Table.Columns.Contains("RoleId") && !dr.IsNull("RoleId"))
            {
                RoleId = Convert.ToInt32(dr["RoleId"]);
            }
            if (dr.Table.Columns.Contains("PowerId") && !dr.IsNull("PowerId"))
            {
                PowerId = Convert.ToInt32(dr["PowerId"]);
            }
            if (dr.Table.Columns.Contains("PowerDetail") && !dr.IsNull("PowerDetail"))
            {
                PowerDetail = dr["PowerDetail"].ToString();
            }
        }
	}
}