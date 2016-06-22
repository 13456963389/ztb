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

        internal ReadStore()
        {
            checkField = new Assembler().Create<CheckField>();
            wfDAL = new WF_WorkFlowDAL();
        }


        /// <summary>
        /// 检查流程是否已被复制
        /// </summary>
        /// <param name="wf"></param>
        internal bool CheckWorkFlowIsCopy(WorkFlow wf)
        {
            checkField
                .CheckBusinessId(wf)
                .CheckTemplateId(wf);
            return wfDAL.CheckWorkFlowIsCopy(wf) > 0 ?
                true : false;
        }

        /// <summary>
        /// 模糊获取下一步节点集合
        /// </summary>
        /// <param name="wfCurr"></param>
        /// <returns></returns>
        internal List<WorkFlow> GetNextVagueNodes(WorkFlow wf)
        {
            checkField
                .CheckBusinessId(wf)
                .CheckTemplateId(wf)
                .CheckPCode(wf)
                .CheckNodeCode(wf);
            return wfDAL.GetNextVagueNodes(wf);
        }

        /// <summary>
        /// 获取当前节点的平行节点
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="wf"></param>
        /// <returns></returns>
        internal List<WorkFlow> GetCurrentSameLevelNodes(WorkFlow wf)
        {
            checkField
                .CheckBusinessId(wf)
                .CheckTemplateId(wf)
                .CheckQjNodeCode(wf)
                .CheckPCode(wf);
            return wfDAL.GetCurrentSameLevelNodes(wf);
        }

        /// <summary>
        /// 检查流程是否已开始
        /// </summary>
        /// <param name="wf"></param>
        /// <returns> true:已开始 ； false：尚未开始</returns>
        internal bool CheckWorkFlowIsStarted(WorkFlow wf)
        {
            checkField
                .CheckBusinessId(wf)
                .CheckTemplateId(wf);
            int countFlag = wfDAL.GetWFHistoryCounts(wf);
            return countFlag > 0;
        }

        /// <summary>
        /// 获取 流程名称节点
        /// </summary>
        /// <param name="wf"></param>
        /// <returns></returns>
        internal ReadStore GetRootEntranceNode(ref WorkFlow wf)
        {
            checkField
                .CheckBusinessId(wf)
                .CheckTemplateId(wf);
            wf = wfDAL.GetRootEntranceNode(wf);
            return this;
        }

        /// <summary>
        /// 获取该节点下所有子流程节点
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        internal List<WorkFlow> GetChildNodes(WorkFlow wf)
        {
            checkField
                .CheckBusinessId(wf)
                .CheckTemplateId(wf)
                .CheckNodeCode(wf);
            List<WorkFlow> wfLists = wfDAL.GetChildNodes(wf);
            return wfLists;
        }

        /// <summary>
        /// 获取入口节点
        /// </summary>
        /// <param name="wf"></param>
        /// <returns></returns>
        internal ReadStore GetEntranceNode(ref WorkFlow wf)
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

        /// <summary>
        /// 获取当前节点
        /// </summary>
        /// <param name="wf"></param>
        /// <returns></returns>
        internal WorkFlow GetCurrentNode(WorkFlow wf)
        {
            checkField
                .CheckBusinessId(wf)
                .CheckNodeCode(wf);
            return wfDAL.GetCurrentNode(wf);
        }

        /// <summary>
        /// 验证节点是否结束节点
        ///     该节点父节点类型是否是 NAMEDES，如果是，则是流程结束节点
        /// </summary>
        /// <param name="wf"></param>
        /// <returns>1:整个流程结束节点  2:子流程结束节点 0:非结束节点</returns>
        internal int CheckNodeIsTrueEnd(WorkFlow wf)
        {
            checkField
                .CheckBusinessId(wf)
                .CheckTemplateId(wf)
                .CheckNodeCode(wf);
            if (wf.NodeType == Convert.ToInt32(NodeTypeStatus.END))
            {
                if (wfDAL.CheckNodeIsRootEndNode(wf))
                {
                    return 1;
                }
                return 2;
            }
            return 0;
        }

        /// <summary>
        /// 获取子流程父节点
        /// </summary>
        /// <param name="wf"></param>
        /// <returns></returns>
        internal WorkFlow GetChildNodeParentNode(WorkFlow wf)
        {
            checkField
                .CheckBusinessId(wf)
                .CheckTemplateId(wf)
                .CheckNodeCode(wf);
            return wfDAL.GetChildNodeParentNode(wf);
        }

        /// <summary>
        /// 获取上一级节点
        /// </summary>
        /// <param name="wfCurr"></param>
        /// <returns></returns>
        internal WorkFlow GetPrevNode(WorkFlow wf)
        {
            checkField
                .CheckBusinessId(wf)
                .CheckTemplateId(wf)
                .CheckNodeCode(wf);
            return wfDAL.GetPrevNode(wf);
        }
    }
}
