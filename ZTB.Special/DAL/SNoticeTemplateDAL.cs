using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZtbSoft;

namespace ZTB.Special.DAL
{
    public class SNoticeTemplateDAL
    {
        /// <summary>
        /// 获取公告模版列表
        /// </summary>
        /// <returns></returns>
        public DataTable GetNoticeTemplateList()
        {
            var dt = new DataTable();
            string sql = @"
SELECT a.TemplateId,a.TemplateCode,a.TemplateName,a.TemplateType,a.Remark,b.DictId,b.PId,b.DictName FROM dbo.FlowTemplate a
	INNER JOIN dbo.Dict b ON a.TemplateType=b.DictCode
";
            dt = SqlHelper.ExecuteDataTable(sql);
            return dt;
        }
    }
}
