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
    public class SNoticeInfoDAL
    {
        /// <summary>
        /// 获取公示列表
        /// </summary>
        /// <param name="projectId"></param>
        /// <param name="fileType"></param>
        /// <returns></returns>
        public DataTable GetNoticeListByProjectInfoId(string projectId, string noticeType)
        {
            string sql = @"
SELECT * FROM dbo.SectionInfo a
	LEFT JOIN dbo.Notice b ON b.ProjectId=a.ProjectId
WHERE b.NoticeType=@noticeType AND a.ProjectId=@projectId
";
            SqlParameter[] paras = new SqlParameter[]
                {
                    new SqlParameter("@noticeType", noticeType),
                    new SqlParameter("@projectId", projectId)
                };
            return SqlHelper.ExecuteDataTable(CommandType.Text, sql, paras);
        }
    }
}
