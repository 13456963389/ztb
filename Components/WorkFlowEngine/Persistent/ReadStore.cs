using Components.WorkFlowEngine.DBDAL;
using Components.WorkFlowEngine.Persistent.RealSpecific;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZtbSoft.Models;

namespace Components.WorkFlowEngine.Persistent
{
    internal class ReadStore
    {

        private CheckField checkField;
        private WF_WorkFlowDAL wfDAL;

        public ReadStore()
        {
            checkField = new Assembler().Create<CheckField>();
            wfDAL = new WF_WorkFlowDAL();
        }


        /// <summary>
        /// 检查流程是否已被复制
        /// </summary>
        /// <param name="wf"></param>
        public bool CheckWorkFlowIsCopy(WorkFlow wf)
        {
            checkField
                .CheckBusinessId(wf)
                .CheckTemplateId(wf);
            return wfDAL.CheckWorkFlowIsCopy(wf) > 0 ?
                true : false;
        }

        /// <summary>
        /// 获取 流程名称节点
        /// </summary>
        /// <param name="wf"></param>
        /// <returns></returns>
        public ReadStore GetRootEntranceNode(WorkFlow wf)
        {
            checkField
                .CheckBusinessId(wf)
                .CheckTemplateId(wf);
            wf = wfDAL.GetRootEntranceNode(wf);
            return this;
        }

        /// <summary>
        /// 获取入口节点
        /// </summary>
        /// <param name="wf"></param>
        /// <returns></returns>
        public ReadStore GetEntranceNode(WorkFlow wf)
        {
            checkField
                .CheckBusinessId(wf)
                .CheckTemplateId(wf)
                .CheckNodeCode(wf);
            wf = wfDAL.GetEntranceNode(wf);
            return this;
        }

        /// <summary>
        /// 获取下一步所有节点
        /// </summary>
        /// <param name="wf"></param>
        /// <returns></returns>
        internal List<WorkFlow> GetNextNodes(WorkFlow wf)
        {
            checkField
                .CheckBusinessId(wf)
                .CheckTemplateId(wf)
                .CheckNodeCode(wf);
            List<WorkFlow> wfNodes = new List<WorkFlow>();
            wfNodes = wfDAL.GetNextNodes(wf);
            return wfNodes;
        }


    }
}
