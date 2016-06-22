using Components.Properties;
using Components.WorkFlowEngine.Persistent.NodeStateOperate;
using DSM.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZtbSoft.Models;

namespace Components.WorkFlowEngine.Persistent
{
    public class AssemblStore
    {

        private ReadStore rs;
        private PersistentStore ps;

        public AssemblStore()
        {
            rs = new ReadStore();
            ps = new PersistentStore();
        }

        #region 流程开始-Start
        /// <summary>
        /// 流程开始
        /// </summary>
        internal void Start(WorkFlow wf, RetInfo retInfo)
        {
            WorkFlow initWf = wf;
            if (!rs.CheckWorkFlowIsCopy(wf))
            {
                int flag = ps.CopyWorkFlowFromTemplate(wf);
                if (flag < 0)
                {
                    retInfo.Msg = string.Format(WfErrorCode.Error_3000, wf.TemplateId);
                    throw new Exception(retInfo.Msg);
                }
            }
            //验证是否已开始
            if (!rs.CheckWorkFlowIsStarted(wf))
            {
                // init wf
                rs.GetRootEntranceNode(ref wf).GetEntranceNode(ref wf);
                if (wf == null)
                {
                    retInfo.Msg = string.Format(WfErrorCode.Error_3001, wf.TemplateId, wf.BusinessId);
                    throw new NullReferenceException(retInfo.Msg);
                }
                //下一步所有节点
                List<WorkFlow> wfList = rs.GetNextNodes(wf);
                List<WorkFlow> wfBeDoneList = new List<WorkFlow>();
                List<WorkFlow> parentNodesList = new List<WorkFlow>();
                //下一步节点是否存在子流程
                wfList.ForEach(item =>
                {
                    List<WorkFlow> chNodesList = rs.GetChildNodes(item);
                    if (chNodesList != null && chNodesList.Count > 0)
                    {
                        wfBeDoneList.AddRange(rs.GetNextNodes(chNodesList.Find(chidItem =>
                            {
                                return (chidItem.NodeType == 1);
                            }) 
                        ));
                        parentNodesList.Add(item);
                    }
                    else
                        wfBeDoneList.Add(item);
                });
                bool perFlag = ps.WfStartPreData(initWf, wf, wfBeDoneList, parentNodesList);
                if (!perFlag)
                {
                    retInfo.Msg = string.Format(WfErrorCode.Error_3003, wf.TemplateId, wf.BusinessId);
                    throw new Exception(retInfo.Msg);
                }
            }
            retInfo.RetInt = 1;
            retInfo.Success = true;
            retInfo.Msg = "操作成功";
        }
        #endregion

        #region 流程下一步-Next
        /// <summary>
        /// 下一步
        /// </summary>
        /// <param name="wf"></param>
        /// <param name="retInfo"></param>
        internal void Next(WorkFlow wf, RetInfo retInfo)
        {
            // 副本
            WorkFlow initWf = wf;
            WorkFlow currWf = rs.GetCurrentNode(wf);
            // 是否活动节点
            CheckIsActiveNode(retInfo, initWf, currWf);
            NodeStateOperateFactory
                .GetFactoryInstance(retInfo, initWf, currWf)
                .MoveNext<WorkFlow>(currWf, retInfo);
            retInfo.RetInt = 1;
            retInfo.Success = true;
            retInfo.Msg = "操作成功";
        }
        #endregion

        #region 退回上一步
        /// <summary>
        /// 退回
        /// </summary>
        /// <param name="wf"></param>
        /// <param name="retInfo"></param>
        internal void Prev(WorkFlow wf, RetInfo retInfo)
        {
            // 副本
            WorkFlow initWf = wf;
            WorkFlow currWf = rs.GetCurrentNode(wf);
            // 是否活动节点
            CheckIsActiveNode(retInfo, initWf, currWf);
            NodeStateOperateFactory
                .GetFactoryInstance(retInfo, initWf, currWf)
                .MovePrev<WorkFlow>(currWf, retInfo);
            retInfo.RetInt = 1;
            retInfo.Success = true;
            retInfo.Msg = "操作成功";
        }
        #endregion

        /// <summary>
        /// 检查是否活动节点
        /// </summary>
        /// <param name="retInfo"></param>
        /// <param name="initWf"></param>
        /// <param name="currWf"></param>
        private static void CheckIsActiveNode(RetInfo retInfo, WorkFlow initWf, WorkFlow currWf)
        {
            if (currWf == null)
            {
                retInfo.Msg = string.Format(WfErrorCode.Error_1004, initWf.BusinessId, initWf.NodeCode);
                throw new NullReferenceException(retInfo.Msg);
            }
            else if (currWf.EmployeeId != initWf.EmployeeId)
            {
                retInfo.Msg = string.Format(WfErrorCode.Error_1008, currWf.TemplateId, initWf.BusinessId, initWf.NodeCode, initWf.EmployeeId);
                throw new Exception(retInfo.Msg);
            }
            else if (currWf.NodeStatu == Convert.ToInt32(NodeActionStatus.PAUSE))
            {
                retInfo.Msg = string.Format(WfErrorCode.Error_1002, initWf.BusinessId, initWf.NodeCode);
                throw new Exception(retInfo.Msg);
            }
            else if (currWf.NodeStatu == Convert.ToInt32(NodeActionStatus.OVER))
            {
                retInfo.Msg = string.Format(WfErrorCode.Error_1005, initWf.BusinessId, initWf.NodeCode);
                throw new Exception(retInfo.Msg);
            }
            else if (currWf.NodeStatu == Convert.ToInt32(NodeActionStatus.COLSED))
            {
                retInfo.Msg = string.Format(WfErrorCode.Error_1001, initWf.BusinessId, initWf.NodeCode);
                throw new Exception(retInfo.Msg);
            }
        }

    }
}
