using System.Data;
using ZtbSoft;
using ZtbSoft.DAL;

namespace ZTB.Special.DAL
{
    public class SProjectInfoDAL
    {
        /// <summary>
        /// 根据项目名称搜索ID集合（用于查询）
        /// </summary>
        /// <param name="selProjectName">模糊查询项目名称</param>
        /// <returns></returns>
        public string GetSearchProjectIdsByProjectName(string selProjectName)
        {
            string str = "";
            var dt = new ProjectInfoDAL().GetAll("ProjectId", "ProjectName like '%" + selProjectName + "%'", "");
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                str += "," + dt.Rows[i]["ProjectId"].ToString();
            }
            str = str.Length > 0 ? str.Substring(1) : str;
            return str;
        }

        /// <summary>
        /// 专家抽取页面项目基本信息
        /// </summary>
        /// <param name="projectId"></param>
        /// <returns></returns>
        public DataTable GetZJCQProjectInfoByProjectId(string projectId)
        {
            string sql = @"
SELECT ProjectId,ProjectCode,ProjectName,b.UnitName,c.DictName ,d.DictName AS TradeCode
FROM dbo.ProjectInfo a
	LEFT JOIN dbo.UnitInfo b ON b.UnitId=a.TendereeId
	LEFT JOIN dbo.Dict c ON c.DictId=a.TendereeType
	LEFT JOIN dbo.Dict d ON d.DictId=a.TradeCode
WHERE ProjectId=
" + projectId;
            return SqlHelper.ExecuteDataTable(sql);
        }
    }
}
