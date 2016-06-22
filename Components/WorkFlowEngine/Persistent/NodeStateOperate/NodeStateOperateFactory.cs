using Components.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZtbSoft.Models;

namespace Components.WorkFlowEngine.Persistent.NodeStateOperate
{
    internal class NodeStateOperateFactory
    {

        internal static INodeStateOperate GetFactoryInstance(RetInfo retInfo, WorkFlow initWf, WorkFlow currWf)
        {
            INodeStateOperate nodeOperateInstance = null;
            switch (currWf.NodeType)
            {
                case (int)NodeTypeStatus.PICK:
                    nodeOperateInstance = new PICKOperate();
                    break;
                case (int)NodeTypeStatus.SIGN:
                    nodeOperateInstance = new SIGNOperate();
                    break;
                case (int)NodeTypeStatus.ACTION:
                    nodeOperateInstance = new ActionOperate();
                    break;
                case (int)NodeTypeStatus.VIRTUAL:
                    nodeOperateInstance = new VIRTUALOperate();
                    break;
                default:
                    retInfo.Msg = string.Format(WfErrorCode.Error_1007, initWf.BusinessId, initWf.NodeCode);
                    throw new Exception(retInfo.Msg);
            }
            return nodeOperateInstance;
        }
    }
}
