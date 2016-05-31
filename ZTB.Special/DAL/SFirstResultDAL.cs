using System;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZtbSoft;
using ZtbSoft.DAL;

namespace ZTB.Special.DAL
{
    public class SFirstResultDAL
    {
        /// <summary>
        /// 获取公告列表
        /// </summary>
        /// <param name="projectId"></param>
        /// <param name="fileType"></param>
        /// <returns></returns>
        public DataTable GetResultListByProjectInfoId(string projectId)
        {
            string sql = @"
SELECT * FROM dbo.SectionInfo a
	LEFT JOIN dbo.FirstResult b ON b.ProjectId=a.ProjectId
WHERE a.ProjectId=@projectId
";
            SqlParameter[] paras = new SqlParameter[]
                {
                    new SqlParameter("@projectId", projectId)
                };
            return SqlHelper.ExecuteDataTable(CommandType.Text, sql, paras);
        }
    }
}
