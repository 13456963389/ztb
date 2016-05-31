using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZTB.Special.DAL;

namespace ZTB.Special.BLL
{
    public class SFileInfoBLL
    {
        /// <summary>
        /// 获取附件列表
        /// </summary>
        /// <param name="projectId"></param>
        /// <param name="fileType"></param>
        /// <returns></returns>
        public DataTable GetFileListByProjectInfoId(string projectId, string fileType)
        {
            return new SFileInfoDAL().GetFileListByProjectInfoId(projectId, fileType);
        }
    }
}
