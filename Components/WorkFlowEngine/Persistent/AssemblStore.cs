using Components.Properties;
using DSM.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZtbSoft.Models;

namespace Components.WorkFlowEngine.Persistent
{
    public class AssemblStore
    {

        private ReadStore rs;
        private PersistentStore ps;

        public AssemblStore()
        {
            rs = new ReadStore();
            ps = new PersistentStore();
        }

        /// <summary>
        /// 流程开始
        /// </summary>
        internal void Start(WorkFlow wf, RetInfo retInfo)
        {
            WorkFlow initWf = wf;
            if (!rs.CheckWorkFlowIsCopy(wf))
            {
                int flag = ps.CopyWorkFlowFromTemplate(wf);
                if (flag < 0)
                {
                    retInfo.Msg = string.Format(WfErrorCode.Error_3000, wf.TemplateId);
                    throw new Exception(retInfo.Msg);
                }
            }
            //验证是否已开始

            // init wf
            rs.GetRootEntranceNode(wf)
                .GetEntranceNode(wf);
            if (wf == null)
            {
                retInfo.Msg = string.Format(WfErrorCode.Error_3001, wf.TemplateId, wf.BusinessId);
                throw new NullReferenceException(retInfo.Msg);
            }
            List<WorkFlow> wfList = rs.GetNextNodes(wf);
            bool perFlag = ps.WfStartPreData(initWf, wf, wfList);
            if (!perFlag)
            {
                retInfo.RetInt = -1;
                retInfo.Success = false;
            }
            else
            {
                retInfo.RetInt = 1;
                retInfo.Success = true;
                retInfo.Msg = "操作成功";
            }
        }
    }
}
