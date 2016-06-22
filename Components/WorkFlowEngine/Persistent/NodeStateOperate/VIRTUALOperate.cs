using Components.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZtbSoft.Models;

namespace Components.WorkFlowEngine.Persistent.NodeStateOperate
{
    internal class VIRTUALOperate : INodeStateOperate
    {
        /// <summary>
        /// 虚节点提交
        ///     当前结点 待办事项改为通过，历史纪录增加通过记录,节点操作状态改为完成
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="wf"></param>
        /// <param name="retInfo"></param>
        public override void MoveNext<T>(T wf, RetInfo retInfo)
        {
            //当前节点
            WorkFlow wfCurr = wf as WorkFlow;
            if (!Ps.VirtualNodeMoveNext(wfCurr))
            {
                retInfo.Msg = string.Format(WfErrorCode.Error_3004, wfCurr.TemplateId, wfCurr.BusinessId, wfCurr.NodeCode);
                throw new Exception(retInfo.Msg);
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
