using Components.WorkFlowEngine.DBDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZtbSoft.Models;

namespace Components.WorkFlowEngine.Persistent
{

    internal class PersistentStore
    {
        private CheckField checkField;
        private WF_WorkFlowDAL wfDAL;

        public PersistentStore()
        {
            checkField = new Assembler().Create<CheckField>();
            wfDAL = new WF_WorkFlowDAL();
        }

        /// <summary>
        /// 复制模板到流程表
        /// </summary>
        /// <param name="wf"></param>
        /// <returns></returns>
        public int CopyWorkFlowFromTemplate(WorkFlow wf)
        {
            checkField
                .CheckBusinessId(wf)
                .CheckTemplateId(wf);
            return wfDAL.CopyWfFromTemplate(wf);
        }
    }
}
