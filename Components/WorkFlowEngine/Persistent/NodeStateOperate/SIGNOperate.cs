using Components.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZtbSoft.Models;

namespace Components.WorkFlowEngine.Persistent.NodeStateOperate
{
    internal class SIGNOperate : INodeStateOperate
    {
        /// <summary>
        /// 会签节点
        ///     所有节点审核通过直接进入下一步
        ///     平行节点是否都已经在下一步汇合，如果不是，抛出异常
        ///     当前节点待办事项改为通过，历史纪录增加通过记录,节点操作状态改为完成
        ///     验证当前节点其它平行节点是否已通过，
        ///         是则 下一步节点增加待办事项，且节点操作状态改为进行中
        ///         否则 不操作任何状态
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="wf"></param>
        /// <param name="retInfo"></param>
        public override void MoveNext<T>(T wf, RetInfo retInfo)
        {
            WorkFlow wfCurr = wf as WorkFlow;
            //获取其它平行节点
            List<WorkFlow> currSlNodes = Rs.GetCurrentSameLevelNodes(wfCurr);
            //获取下一步节点
            WorkFlow nextNode = Rs.GetNextVagueNodes(wfCurr).Find(item =>
            {
                return item.QjNodeCode.Split(',').ToList<string>().Contains(wfCurr.NodeCode);
            });
            WorkFlow unCheckWf = currSlNodes.Find(item =>
            {
                return !nextNode.QjNodeCode.Split(',').ToList<string>().Contains(item.NodeCode);
            });
            if (unCheckWf != null)
            {
                retInfo.Msg = string.Format(WfErrorCode.Error_4001, wfCurr.TemplateId, wfCurr.BusinessId, wfCurr.NodeCode);
                throw new Exception(retInfo.Msg);
            }
            if (!currSlNodes.Remove(wfCurr))
            {
                retInfo.Msg = string.Format(WfErrorCode.Error_5001, wfCurr.TemplateId, wfCurr.BusinessId, wfCurr.NodeCode);
                throw new Exception(retInfo.Msg);
            }
            //未审核平行节点
            WorkFlow unReviewNode = currSlNodes.Find(item =>
            {
                return item.NodeStatu == Convert.ToInt32(NodeActionStatus.DOING);
            });
            if (unReviewNode != null)
            {
                if (!Ps.SignNodeMoveNext(wfCurr))
                {
                    retInfo.Msg = string.Format(WfErrorCode.Error_3004, wfCurr.TemplateId, wfCurr.BusinessId, wfCurr.NodeCode);
                    throw new Exception(retInfo.Msg);
                }
            }
            else
            {
                if (!Ps.SignNodeMoveNext(wfCurr, nextNode))
                {
                    retInfo.Msg = string.Format(WfErrorCode.Error_3004, wfCurr.TemplateId, wfCurr.BusinessId, wfCurr.NodeCode);
                    throw new Exception(retInfo.Msg);
                }
            }
        }

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
