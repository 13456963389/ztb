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
        private WF_WorkFlowPersiDAL wfDALPer;

        public PersistentStore()
        {
            checkField = new Assembler().Create<CheckField>();
            wfDAL = new WF_WorkFlowDAL();
            wfDALPer = new WF_WorkFlowPersiDAL();
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
        public bool WfStartPreData(WorkFlow initWf, WorkFlow currWf, List<WorkFlow> wfList, List<WorkFlow> parentNodesList)
        {
            checkField
                .CheckBusinessId(currWf)
                .CheckTemplateId(currWf)
                .CheckNodeId(currWf)
                .CheckEmployeeId(initWf);
            return wfDAL.WfStartPreData(initWf, currWf, wfList, parentNodesList);
        }

        /// <summary>
        /// 选签节点提交
        /// </summary>
        /// <param name="currWf"></param>
        /// <param name="currSlNodes"></param>
        /// <param name="nextNode"></param>
        /// <returns></returns>
        internal bool PickNodeMoveNext(WorkFlow currWf, List<WorkFlow> currSlNodes, WorkFlow nextNode)
        {
            checkField
                   .CheckBusinessId(currWf)
                   .CheckTemplateId(currWf)
                   .CheckNodeId(currWf)
                   .CheckEmployeeId(currWf);
            return wfDALPer.PickNodeMoveNext(currWf, currSlNodes, nextNode);
        }

        /// <summary>
        /// 会签提交，当前结点未结束
        /// </summary>
        /// <param name="currWf"></param>
        /// <returns></returns>
        internal bool SignNodeMoveNext(WorkFlow currWf)
        {
            return SignNodeMoveNext(currWf, null);
        }

        /// <summary>
        /// 会签提交，当前结点已结束
        /// </summary>
        /// <param name="currWf"></param>
        /// <param name="nextNode"></param>
        /// <returns></returns>
        internal bool SignNodeMoveNext(WorkFlow currWf, WorkFlow nextNode)
        {
            checkField
                      .CheckBusinessId(currWf)
                      .CheckTemplateId(currWf)
                      .CheckNodeId(currWf)
                      .CheckEmployeeId(currWf);
            return wfDALPer.SignNodeMoveNext(currWf, nextNode);
        }

        /// <summary>
        /// 交互节点提交
        /// </summary>
        /// <param name="currWf"></param>
        /// <returns></returns>
        internal bool ActionNodeMoveNext(List<WorkFlow> currWf,List<WorkFlow> parentNodesList)
        {
            return ActionNodeMoveNext(currWf, null, null, parentNodesList);
        }

        /// <summary>
        /// 交互节点提交
        /// </summary>
        /// <param name="currWf"></param>
        /// <returns></returns>
        internal bool ActionNodeMoveNext(List<WorkFlow> currWf, List<WorkFlow> nextNodes, List<WorkFlow> parentNodesList)
        {
            return ActionNodeMoveNext(currWf, nextNodes, null, parentNodesList);
        }

        /// <summary>
        /// 交互节点提交
        /// </summary>
        /// <param name="currWf"></param>
        /// <returns></returns>
        internal bool ActionNodeMoveNext(List<WorkFlow> currWfList, List<WorkFlow> nextNodes, List<WorkFlow> unReviewViNodes, List<WorkFlow> parentNodesList)
        {
            return wfDALPer.ActionNodeMoveNext(currWfList, nextNodes, unReviewViNodes, parentNodesList);
        }

        /// <summary>
        /// 虚节点提交
        /// </summary>
        /// <param name="wfCurr"></param>
        /// <returns></returns>
        internal bool VirtualNodeMoveNext(WorkFlow currWf)
        {
            checkField
                    .CheckBusinessId(currWf)
                    .CheckTemplateId(currWf)
                    .CheckNodeId(currWf)
                    .CheckEmployeeId(currWf);
            return wfDALPer.VirtualNodeMoveNext(currWf);
        }

        /// <summary>
        /// 交互节点退回
        /// </summary>
        /// <param name="wfCurr"></param>
        /// <param name="wfPrev"></param>
        /// <returns></returns>
        internal bool ActionNodeMovePrev(WorkFlow wfCurr, WorkFlow wfPrev)
        {
            return wfDALPer.ActionNodeMovePrev(wfCurr,wfPrev);
        }
    }
}
