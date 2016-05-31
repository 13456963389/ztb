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
    }
}
