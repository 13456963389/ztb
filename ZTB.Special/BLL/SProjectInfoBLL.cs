using System.Data;
using ZTB.Special.DAL;

namespace ZTB.Special.BLL
{
    public class SProjectInfoBLL
    {
        /// <summary>
        /// 根据项目名称搜索ID集合（用于查询）
        /// </summary>
        /// <param name="selProjectName">模糊查询项目名称</param>
        /// <returns></returns>
        public string GetSearchProjectIdsByProjectName(string selProjectName)
        {
            return new SProjectInfoDAL().GetSearchProjectIdsByProjectName(selProjectName);
        }

        /// <summary>
        /// 专家抽取页面项目基本信息
        /// </summary>
        /// <param name="projectId"></param>
        /// <returns></returns>
        public DataTable GetZJCQProjectInfoByProjectId(string projectId)
        {
            return new SProjectInfoDAL().GetZJCQProjectInfoByProjectId(projectId);
        }
    }
}
