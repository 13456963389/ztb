using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZTB.Special.DAL;

namespace ZTB.Special.BLL
{
    public class SFirstResultBLL
    {
        /// <summary>
        /// 获取公示列表
        /// </summary>
        /// <param name="projectId"></param>
        /// <returns></returns>
        public DataTable GetResultListByProjectInfoId(string projectId)
        {
            return new SFirstResultDAL().GetResultListByProjectInfoId(projectId);
        }
    }
}
