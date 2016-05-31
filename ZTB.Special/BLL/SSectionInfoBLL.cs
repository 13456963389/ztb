using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZTB.Special.DAL;
using ZtbSoft;
using ZtbSoft.DAL;
using ZtbSoft.Models;

namespace ZTB.Special.BLL
{
    public class SSectionInfoBLL
    {
        /// <summary>
        /// 添加标段列表
        /// </summary>
        /// <param name="secsJson"></param>
        /// <param name="projectInfoId"></param>
        /// <returns></returns>
        public void AddSectionListForProjectInfoId(string secsJson, int projectInfoId, int employeeId)
        {
            //删除原有标段
            new SSectionInfoDAL().DeleteByProjectInfoId(projectInfoId);
            //新标段列表
            var list = JsonHelper.JsonToObject<List<SectionInfo>>(secsJson);
            list.ForEach(m =>
            {
                m.ProjectId = projectInfoId;
                m.EmployeeId = employeeId;
                m.CreateTime = DateTime.Now;
                new SectionInfoDAL().INSERT(m);
            });
        }

        /// <summary>
        /// 根据项目ID删除标段信息
        /// </summary>
        /// <param name="projectInfoId"></param>
        /// <returns></returns>
        public int DeleteByProjectInfoId(int projectInfoId)
        {
            return new SSectionInfoDAL().DeleteByProjectInfoId(projectInfoId);
        }
    }
}
