using Components.Properties;
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
            if (!rs.CheckWorkFlowIsCopy(wf))
            {
                int flag = ps.CopyWorkFlowFromTemplate(wf);
                if (flag < 0)
                {
                    retInfo.Msg = string.Format(WfErrorCode.Error_3000, wf.TemplateId);
                    throw new Exception(retInfo.Msg);
                }
            }
            // init wf
            rs.GetRootEntranceNode(wf)
                .GetEntranceNode(wf);
            if (wf == null)
            {
                retInfo.Msg = string.Format(WfErrorCode.Error_3001, wf.TemplateId);
                throw new NullReferenceException(retInfo.Msg);
            }
            List<WorkFlow> wfList = new List<WorkFlow>();
        }
    }
}
