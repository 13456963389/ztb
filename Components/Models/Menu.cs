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
    /// 
    /// </summary>
	[Serializable()]
	public class Menu
	{	
        /// <summary>
        /// 
        /// </summary>
        [DataMember(IsRequired = false)]
		public string Id{get;set;}
        /// <summary>
        /// 
        /// </summary>
        [DataMember(IsRequired = false)]
		public string Pid{get;set;}
        /// <summary>
        /// 
        /// </summary>
        [DataMember(IsRequired = false)]
		public string Text{get;set;}
        /// <summary>
        /// 
        /// </summary>
        [DataMember(IsRequired = false)]
		public string Url{get;set;}
        /// <summary>
        /// 
        /// </summary>
        [DataMember(IsRequired = false)]
		public int Ord{get;set;}
        /// <summary>
        /// 
        /// </summary>
        [DataMember(IsRequired = false)]
		public string Img{get;set;}
        /// <summary>
        /// 
        /// </summary>
        public Menu() { }
        
        
        /// <summary>
        /// 
        /// </summary>
        public Menu(DataRow dr)
        {
            if (dr.Table.Columns.Contains("id") && !dr.IsNull("id"))
            {
                Id = dr["id"].ToString();
            }
            if (dr.Table.Columns.Contains("pid") && !dr.IsNull("pid"))
            {
                Pid = dr["pid"].ToString();
            }
            if (dr.Table.Columns.Contains("text") && !dr.IsNull("text"))
            {
                Text = dr["text"].ToString();
            }
            if (dr.Table.Columns.Contains("url") && !dr.IsNull("url"))
            {
                Url = dr["url"].ToString();
            }
            if (dr.Table.Columns.Contains("ord") && !dr.IsNull("ord"))
            {
                Ord = Convert.ToInt32(dr["ord"]);
            }
            if (dr.Table.Columns.Contains("img") && !dr.IsNull("img"))
            {
                Img = dr["img"].ToString();
            }
        }
	}
}