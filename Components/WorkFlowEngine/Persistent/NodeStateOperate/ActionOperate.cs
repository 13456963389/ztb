using Components.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZtbSoft.Models;

namespace Components.WorkFlowEngine.Persistent.NodeStateOperate
{
    internal class ActionOperate : INodeStateOperate
    {

        /// <summary>
        /// 交互节点下一步
        ///     当前节点 操作C
        ///     当前节点其它平行节点
        ///         如果均通过，则下一节点 操作B
        ///         如果有交互节点未通过，则无任何操作
        ///         如果仅虚结点未通过，则下一节点 操作B，且未通过虚节点 操作A
        ///                 
        ///     操作A : 待办事项放弃，历史纪录增加关闭记录，节点操作状态改为关闭
        ///     操作B : 增加待办事项，且节点操作状态改为进行中
        ///     操作C : 待办事项改为通过，历史纪录增加通过记录,节点操作状态改为完成
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="wf"></param>
        /// <param name="retInfo"></param>
        public override void MoveNext<T>(T wf, RetInfo retInfo)
        {
            //当前节点
            WorkFlow wfCurr = wf as WorkFlow;
            List<WorkFlow> wfCurrList = new List<WorkFlow>();
            wfCurrList.Add(wfCurr);
            //获取其它平行节点
            List<WorkFlow> currSlNodes = Rs.GetCurrentSameLevelNodes(wfCurr);
            //获取下一步节点
            List<WorkFlow> nextNodes = Rs.GetNextVagueNodes(wfCurr).FindAll(item =>
            {
                return item.QjNodeCode.Split(',').ToList<string>().Contains(wfCurr.NodeCode);
            });
            if (!currSlNodes.Remove(wfCurr))
            {
                retInfo.Msg = string.Format(WfErrorCode.Error_5001, wfCurr.TemplateId, wfCurr.BusinessId, wfCurr.NodeCode);
                throw new Exception(retInfo.Msg);
            }
            //未审核平行交互节点
            List<WorkFlow> unReviewAcNodes = currSlNodes.FindAll(item =>
            {
                return (item.NodeStatu == Convert.ToInt32(NodeActionStatus.DOING)
                        || item.NodeStatu == Convert.ToInt32(NodeActionStatus.PAUSE))
                        && item.NodeType == Convert.ToInt32(NodeTypeStatus.ACTION);
            });
            //未审核平行虚节点
            List<WorkFlow> unReviewViNodes = currSlNodes.FindAll(item =>
            {
                return item.NodeStatu == Convert.ToInt32(NodeActionStatus.DOING)
                        && item.NodeType == Convert.ToInt32(NodeTypeStatus.VIRTUAL);
            });
            //验证下一步节点是否有子流程
            List<WorkFlow> nextNodesList = new List<WorkFlow>();
            List<WorkFlow> parentNodesList = new List<WorkFlow>();
            nextNodes.ForEach(item =>
            {
                List<WorkFlow> chNodesList = Rs.GetChildNodes(item);
                if (chNodesList != null && chNodesList.Count > 0)
                {
                    nextNodesList.AddRange(Rs.GetNextNodes(chNodesList.Find(chidItem =>
                        {
                            return (chidItem.NodeType == 1);
                        })
                    ));
                    parentNodesList.Add(item);
                }
                else
                    nextNodesList.Add(item);
            });
            //提交
            if ((unReviewAcNodes == null || unReviewAcNodes.Count == 0) &&
                (unReviewAcNodes == null || unReviewAcNodes.Count == 0))
            {
                //验证下一步节点是否是结束节点
                nextNodesList = CheckIsEndRootNode(wfCurrList, nextNodes, nextNodesList);
                if (!Ps.ActionNodeMoveNext(wfCurrList, nextNodes, parentNodesList))
                {
                    retInfo.Msg = string.Format(WfErrorCode.Error_3004, wfCurr.TemplateId, wfCurr.BusinessId, wfCurr.NodeCode);
                    throw new Exception(retInfo.Msg);
                }
            }
            else if (unReviewAcNodes != null && unReviewAcNodes.Count != 0)
            {
                if (!Ps.ActionNodeMoveNext(wfCurrList, parentNodesList))
                {
                    retInfo.Msg = string.Format(WfErrorCode.Error_3004, wfCurr.TemplateId, wfCurr.BusinessId, wfCurr.NodeCode);
                    throw new Exception(retInfo.Msg);
                }
            }
            else if ((unReviewAcNodes == null || unReviewAcNodes.Count == 0) &&
                (unReviewAcNodes != null && unReviewAcNodes.Count != 0))
            {
                //验证下一步节点是否是结束节点
                nextNodesList = CheckIsEndRootNode(wfCurrList, nextNodes, nextNodesList);
                if (!Ps.ActionNodeMoveNext(wfCurrList, nextNodes, unReviewViNodes, parentNodesList))
                {
                    retInfo.Msg = string.Format(WfErrorCode.Error_3004, wfCurr.TemplateId, wfCurr.BusinessId, wfCurr.NodeCode);
                    throw new Exception(retInfo.Msg);
                }
            }

        }

        /// <summary>
        /// 验证是否根结束节点
        /// </summary>
        /// <param name="wfCurrList"></param>
        /// <param name="nextNodes"></param>
        /// <param name="nextNodesList"></param>
        /// <returns></returns>
        private List<WorkFlow> CheckIsEndRootNode(List<WorkFlow> wfCurrList, List<WorkFlow> nextNodes, List<WorkFlow> nextNodesList)
        {
            if (nextNodes != null && nextNodes.Count == 1)
            {
                WorkFlow wfNextNode = nextNodes[1];
                if (Rs.CheckNodeIsTrueEnd(wfNextNode) == 1)
                {
                    //是结束节点
                }
                else if (Rs.CheckNodeIsTrueEnd(wfNextNode) == 2)
                {
                    //子流程结束节点
                    WorkFlow wfCurrNode = Rs.GetChildNodeParentNode(wfNextNode);
                    wfCurrList.Add(wfCurrNode);
                    nextNodesList = Rs.GetNextNodes(wfCurrNode);
                }
            }
            return nextNodesList;
        }

        /// <summary>
        /// 交互节点退回
        ///     当前节点状态改为初始化，待办状态改为不通过，历史纪录增加不通过纪录
        ///     上一级节点待办改为进行中，待办状态添加一条待办
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="wf"></param>
        /// <param name="retInfo"></param>
        public override void MovePrev<T>(T wf, RetInfo retInfo)
        {
            //当前节点
            WorkFlow wfCurr = wf as WorkFlow;
            if (string.IsNullOrWhiteSpace(wfCurr.ThNodeCode))
            {
                retInfo.Msg = string.Format(WfErrorCode.Error_1009, wfCurr.BusinessId, wfCurr.NodeCode);
                throw new NullReferenceException(retInfo.Msg);
            }
            WorkFlow wfPrev = Rs.GetPrevNode(wfCurr);
            if (!Ps.ActionNodeMovePrev(wfCurr, wfPrev))
            {
                retInfo.Msg = string.Format(WfErrorCode.Error_3005, wfCurr.TemplateId, wfCurr.BusinessId, wfCurr.NodeCode);
                throw new Exception(retInfo.Msg);
            }
        }
    }
}
