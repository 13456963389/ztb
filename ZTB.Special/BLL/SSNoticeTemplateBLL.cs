using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZTB.Special.DAL;

namespace ZTB.Special.BLL
{
    public class SSNoticeTemplateBLL
    {
        /// <summary>
        /// 获取公告模版列表
        /// </summary>
        /// <returns></returns>
        public DataTable GetNoticeTemplateList()
        {
            return new SNoticeTemplateDAL().GetNoticeTemplateList();
        }
    }
}
