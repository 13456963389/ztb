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

    public partial class WorkFlowBeDoneBLL
    {
        /// <summary>
        /// 新增
        /// </summary>
        public int Insert(string json)
        {
            WorkFlowBeDone workFlowBeDone = JsonHelper.JsonToObject<WorkFlowBeDone>(json);
            return new WorkFlowBeDoneDAL().INSERT(workFlowBeDone);
        }
        
        /// <summary>
        /// 删除
        /// </summary>
        public int DeleteByWFDoneId(int wFDoneId)
        {
            return new WorkFlowBeDoneDAL().DeleteByWFDoneId(wFDoneId);
        }
        
        /// <summary>
        /// 修改
        /// </summary>
		public int Update(string json)
        {
            WorkFlowBeDone workFlowBeDone = JsonHelper.JsonToObject<WorkFlowBeDone>(json);
            return new WorkFlowBeDoneDAL().Update_V(workFlowBeDone);
        }
        /// <summary>
        /// 修改
        /// </summary>
		public int Update_V(WorkFlowBeDone workFlowBeDone)
        {
            return new WorkFlowBeDoneDAL().Update_V(workFlowBeDone);
        }
        
        
        /// <summary>
        /// 得到实体
        /// </summary>
        public WorkFlowBeDone GetByWFDoneId(int wFDoneId)
        {
            return new WorkFlowBeDoneDAL().GetByWFDoneId(wFDoneId);
        }
        /// <summary>
        /// 得到所有
        /// </summary>
        /// <param name="whe">条件</param>
        /// <returns></returns>
        public ArrayList GetAll(string whe)
        {
            DataTable dt = new WorkFlowBeDoneDAL().GetAll("*", whe, "");
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
            count = new WorkFlowBeDoneDAL().GetCount(sel_whe);
            DataTable dt = new WorkFlowBeDoneDAL().GetPage(sel_col, sel_whe, sel_ord, page_size, page);
            return JsonHelper.DataTableToArrayList(dt);
        }
        
    }
}
