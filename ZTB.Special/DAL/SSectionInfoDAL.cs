using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZtbSoft;

namespace ZTB.Special.DAL
{
    public class SSectionInfoDAL
    {
        /// <summary>
        /// 根据项目ID删除标段信息
        /// </summary>
        /// <param name="projectInfoId"></param>
        /// <returns></returns>
        public int DeleteByProjectInfoId(int projectInfoId)
        {
            int rtn = 0;
            string sql = "DELETE FROM dbo.SectionInfo WHERE ProjectId=" + projectInfoId;
            rtn = SqlHelper.ExecuteNonQuery(sql);
            return rtn;
        }
    }
}
