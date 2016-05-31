using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Collections;
using ZtbSoft.DAL;
using ZtbSoft.Models;

namespace ZtbSoft.BLL
{

    public partial class QualificationBLL
    {
        /// <summary>
        /// 新增
        /// </summary>
        public int Insert(string json)
        {
            Qualification qualification = JsonHelper.JsonToObject<Qualification>(json);
            return new QualificationDAL().INSERT(qualification);
        }
        
        /// <summary>
        /// 删除
        /// </summary>
        public int DeleteByUQId(int uQId)
        {
            return new QualificationDAL().DeleteByUQId(uQId);
        }
        
        /// <summary>
        /// 修改
        /// </summary>
		public int Update(string json)
        {
            Qualification qualification = JsonHelper.JsonToObject<Qualification>(json);
            return new QualificationDAL().Update_V(qualification);
        }
        /// <summary>
        /// 修改
        /// </summary>
		public int Update_V(Qualification qualification)
        {
            return new QualificationDAL().Update_V(qualification);
        }
        
        
        /// <summary>
        /// 得到实体
        /// </summary>
        public Qualification GetByUQId(int uQId)
        {
            return new QualificationDAL().GetByUQId(uQId);
        }
        /// <summary>
        /// 得到所有
        /// </summary>
        /// <param name="whe">条件</param>
        /// <returns></returns>
        public ArrayList GetAll(string whe)
        {
            DataTable dt = new QualificationDAL().GetAll("*", whe, "");
            return JsonHelper.DataTableToArrayList(dt);
        }
		
        /// <summary>
        /// 分页查询
        /// </summary>
        /// <param name="sel_col">查询列</param>
        /// <param name="sel_whe">条件</param>
        /// <param name="sel_ord">排序</param>
        /// <param name="page_size">页大小</param>
        /// <param name="page">页码</param>
        /// <returns></returns>
        public ArrayList GetPage(string sel_col, string sel_whe, string sel_ord, int page_size, int page, out int count)
        {
            count = new QualificationDAL().GetCount(sel_whe);
            DataTable dt = new QualificationDAL().GetPage(sel_col, sel_whe, sel_ord, page_size, page);
            return JsonHelper.DataTableToArrayList(dt);
        }
        
    }
}
