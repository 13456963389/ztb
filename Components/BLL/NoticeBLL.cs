using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Collections;
using ZtbSoft.DAL;
using ZtbSoft.Models;

namespace ZtbSoft.BLL
{

    public partial class NoticeBLL
    {
        /// <summary>
        /// 新增
        /// </summary>
        public int Insert(string json)
        {
            Notice notice = JsonHelper.JsonToObject<Notice>(json);
            return new NoticeDAL().INSERT(notice);
        }
        
        /// <summary>
        /// 删除
        /// </summary>
        public int DeleteByNoticeId(int noticeId)
        {
            return new NoticeDAL().DeleteByNoticeId(noticeId);
        }
        
        /// <summary>
        /// 修改
        /// </summary>
		public int Update(string json)
        {
            Notice notice = JsonHelper.JsonToObject<Notice>(json);
            return new NoticeDAL().Update_V(notice);
        }
        /// <summary>
        /// 修改
        /// </summary>
		public int Update_V(Notice notice)
        {
            return new NoticeDAL().Update_V(notice);
        }
        
        
        /// <summary>
        /// 得到实体
        /// </summary>
        public Notice GetByNoticeId(int noticeId)
        {
            return new NoticeDAL().GetByNoticeId(noticeId);
        }
        /// <summary>
        /// 得到所有
        /// </summary>
        /// <param name="whe">条件</param>
        /// <returns></returns>
        public ArrayList GetAll(string whe)
        {
            DataTable dt = new NoticeDAL().GetAll("*", whe, "");
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
            count = new NoticeDAL().GetCount(sel_whe);
            DataTable dt = new NoticeDAL().GetPage(sel_col, sel_whe, sel_ord, page_size, page);
            return JsonHelper.DataTableToArrayList(dt);
        }
        
    }
}
