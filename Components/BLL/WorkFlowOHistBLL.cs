using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Collections;
using DSM.DAL;
using DSM.Models;
using ZtbSoft;

namespace DSM.BLL
{

    public partial class WorkFlowOHistBLL
    {
        /// <summary>
        /// 新增
        /// </summary>
        public int Insert(string json)
        {
            WorkFlowOHist workFlowOHist = JsonHelper.JsonToObject<WorkFlowOHist>(json);
            return new WorkFlowOHistDAL().INSERT(workFlowOHist);
        }
        
        /// <summary>
        /// 删除
        /// </summary>
        public int DeleteByWfHisId(int wfHisId)
        {
            return new WorkFlowOHistDAL().DeleteByWfHisId(wfHisId);
        }
        
        /// <summary>
        /// 修改
        /// </summary>
		public int Update(string json)
        {
            WorkFlowOHist workFlowOHist = JsonHelper.JsonToObject<WorkFlowOHist>(json);
            return new WorkFlowOHistDAL().Update_V(workFlowOHist);
        }
        /// <summary>
        /// 修改
        /// </summary>
		public int Update_V(WorkFlowOHist workFlowOHist)
        {
            return new WorkFlowOHistDAL().Update_V(workFlowOHist);
        }
        
        
        /// <summary>
        /// 得到实体
        /// </summary>
        public WorkFlowOHist GetByWfHisId(int wfHisId)
        {
            return new WorkFlowOHistDAL().GetByWfHisId(wfHisId);
        }
        /// <summary>
        /// 得到所有
        /// </summary>
        /// <param name="whe">条件</param>
        /// <returns></returns>
        public ArrayList GetAll(string whe)
        {
            DataTable dt = new WorkFlowOHistDAL().GetAll("*", whe, "");
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
            count = new WorkFlowOHistDAL().GetCount(sel_whe);
            DataTable dt = new WorkFlowOHistDAL().GetPage(sel_col, sel_whe, sel_ord, page_size, page);
            return JsonHelper.DataTableToArrayList(dt);
        }
        
    }
}
