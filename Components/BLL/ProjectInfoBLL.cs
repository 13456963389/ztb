using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Collections;
using ZtbSoft.DAL;
using ZtbSoft.Models;

namespace ZtbSoft.BLL
{

    public partial class ProjectInfoBLL
    {
        /// <summary>
        /// 新增
        /// </summary>
        public int Insert(string json)
        {
            ProjectInfo projectInfo = JsonHelper.JsonToObject<ProjectInfo>(json);
            return new ProjectInfoDAL().INSERT(projectInfo);
        }
        
        /// <summary>
        /// 删除
        /// </summary>
        public int DeleteByProjectId(int projectId)
        {
            return new ProjectInfoDAL().DeleteByProjectId(projectId);
        }
        
        /// <summary>
        /// 修改
        /// </summary>
		public int Update(string json)
        {
            ProjectInfo projectInfo = JsonHelper.JsonToObject<ProjectInfo>(json);
            return new ProjectInfoDAL().Update_V(projectInfo);
        }
        /// <summary>
        /// 修改
        /// </summary>
		public int Update_V(ProjectInfo projectInfo)
        {
            return new ProjectInfoDAL().Update_V(projectInfo);
        }
        
        
        /// <summary>
        /// 得到实体
        /// </summary>
        public ProjectInfo GetByProjectId(int projectId)
        {
            return new ProjectInfoDAL().GetByProjectId(projectId);
        }
        /// <summary>
        /// 得到所有
        /// </summary>
        /// <param name="whe">条件</param>
        /// <returns></returns>
        public ArrayList GetAll(string whe)
        {
            DataTable dt = new ProjectInfoDAL().GetAll("*", whe, "");
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
            count = new ProjectInfoDAL().GetCount(sel_whe);
            DataTable dt = new ProjectInfoDAL().GetPage(sel_col, sel_whe, sel_ord, page_size, page);
            return JsonHelper.DataTableToArrayList(dt);
        }
        
    }
}
