using Components.WorkFlowEngine.DBDAL;
using DSM.DAL;
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

        /// <summary>
        /// 流程开始->
        ///     操作历史
        ///     待办
        /// </summary>
        /// <returns></returns>
        public bool WfStartPreData(WorkFlow initWf, WorkFlow currWf, List<WorkFlow> wfList)
        {
            checkField
                .CheckBusinessId(currWf)
                .CheckTemplateId(currWf)
                .CheckEmployeeId(initWf);
            return wfDAL.WfStartPreData(initWf, currWf, wfList);
        }
    }
}
