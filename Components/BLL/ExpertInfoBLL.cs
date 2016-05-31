using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Collections;
using ZtbSoft.DAL;
using ZtbSoft.Models;

namespace ZtbSoft.BLL
{

    public partial class ExpertInfoBLL
    {
        /// <summary>
        /// 新增
        /// </summary>
        public int Insert(string json)
        {
            ExpertInfo expertInfo = JsonHelper.JsonToObject<ExpertInfo>(json);
            return new ExpertInfoDAL().INSERT(expertInfo);
        }
        
        /// <summary>
        /// 删除
        /// </summary>
        public int DeleteByExpertId(int expertId)
        {
            return new ExpertInfoDAL().DeleteByExpertId(expertId);
        }
        
        /// <summary>
        /// 修改
        /// </summary>
		public int Update(string json)
        {
            ExpertInfo expertInfo = JsonHelper.JsonToObject<ExpertInfo>(json);
            return new ExpertInfoDAL().Update_V(expertInfo);
        }
        /// <summary>
        /// 修改
        /// </summary>
		public int Update_V(ExpertInfo expertInfo)
        {
            return new ExpertInfoDAL().Update_V(expertInfo);
        }
        
        
        /// <summary>
        /// 得到实体
        /// </summary>
        public ExpertInfo GetByExpertId(int expertId)
        {
            return new ExpertInfoDAL().GetByExpertId(expertId);
        }
        /// <summary>
        /// 得到所有
        /// </summary>
        /// <param name="whe">条件</param>
        /// <returns></returns>
        public ArrayList GetAll(string whe)
        {
            DataTable dt = new ExpertInfoDAL().GetAll("*", whe, "");
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
            count = new ExpertInfoDAL().GetCount(sel_whe);
            DataTable dt = new ExpertInfoDAL().GetPage(sel_col, sel_whe, sel_ord, page_size, page);
            return JsonHelper.DataTableToArrayList(dt);
        }
        
    }
}
