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

            //插入历史纪录
            int hisWfId = new WorkFlowOHistDAL().INSERT(new DSM.Models.WorkFlowOHist
            {
                BusinessBillId = currWf.BusinessId,
                NodeActionStatus = Convert.ToInt32(NodeActionStatus.OVER),
                NodeCode = currWf.NodeCode,
                NodeId = currWf.NodeId,
                OperateState = Convert.ToInt32(WFOperateState.AGREE),
                OperateTime = DateTime.Now,
                OperateTime_order = DateTime.Now.Ticks,
                TemplateId = currWf.TemplateId,
                UserId = initWf.EmployeeId,
                WFActiveStatus = Convert.ToInt32(WFActiveStatus.DOING),
                WFGUID = Guid.NewGuid().ToString()
            });
            //插入待办记录
            wfList.ForEach(item =>
            {
                int beDoneId = new WorkFlowBeDoneDAL().INSERT(new DSM.Models.WorkFlowBeDone
                {
                    BusinessBillId = item.BusinessId,
                    NodeCode = item.NodeCode,
                    NodeId = item.NodeId,
                    OperateDate = DateTime.Now,
                    OperateDate_Order = DateTime.Now.Ticks,
                    OperateState = Convert.ToInt32(WFOperateState.BEDONE),
                    TemplateId = item.TemplateId,
                    UserId = item.EmployeeId
                });
            });
            return true;
        }
    }
}
