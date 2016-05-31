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
    public class SFileInfoDAL
    {
        public DataTable GetFileListByFileType(string fileType)
        {
            var dt = new DataTable();
            dt = new FileInfoDAL().GetAll("BusinessId,FileName,FileUrl", "FileType=" + fileType, "");
            return dt;
        }

        /// <summary>
        /// 获取附件列表
        /// </summary>
        /// <param name="projectId"></param>
        /// <param name="fileType"></param>
        /// <returns></returns>
        public DataTable GetFileListByProjectInfoId(string projectId,string fileType)
        {
            string sql = @"
SELECT a.*,b.FileId,b.[FileName],b.FileUrl FROM dbo.SectionInfo a
	LEFT JOIN dbo.FileInfo b ON a.ProjectId=b.BusinessId
WHERE b.FileType=@fileType AND a.ProjectId=@projectId
";
            SqlParameter[] paras = new SqlParameter[]
                {
                    new SqlParameter("@fileType", fileType),
                    new SqlParameter("@projectId", projectId)
                };
            return SqlHelper.ExecuteDataTable(CommandType.Text, sql, paras);
        }
    }
}
