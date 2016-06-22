using DSM.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZtbSoft;
using ZtbSoft.Components;
using ZtbSoft.Models;

namespace Components.WorkFlowEngine.DBDAL
{
    public class WF_WorkFlowPersiDAL : WFDAL
    {

        /// <summary>
        /// 选签节点提交操作
        /// </summary>
        /// <param name="currWf"></param>
        /// <param name="currSlNodes"></param>
        /// <param name="nextNode"></param>
        /// <returns></returns>
        internal bool PickNodeMoveNext(WorkFlow currWf, List<WorkFlow> currSlNodes, WorkFlow nextNode)
        {
            using (SqlConnection conn = SqlHelper.GetConnection())
            {
                conn.Open();
                using (SqlTransaction trans = conn.BeginTransaction())
                {
                    try
                    {
                        #region 插入历史纪录
                        InsertCurrentNode_HistoryRecord(currWf, conn, trans, WFOperateState.AGREE);
                        currSlNodes?.ForEach(item =>
                        {
                            InsertWfAnyNodeSameLevel_HistroyRecord(item, conn, trans);
                        });
                        #endregion

                        #region 插入待办记录
                        InsertWfNextNode_BeDoneRecord(nextNode, conn, trans, WFOperateState.BEDONE);
                        UpdateCurrentNodeStateForOver_BeDone(currWf, conn, trans,WFOperateState.AGREE);
                        #endregion

                        #region 修改流程状态
                        UpdateWfCurrentNodeState(currWf, conn, trans, NodeActionStatus.OVER);
                        currSlNodes?.ForEach(item =>
                        {
                            UpdateWfAnyNodeSameLevel_Workflow_State(item, conn, trans);
                        });
                        UpdateWfNextNodeState(nextNode, conn, trans);

                        #endregion

                        trans.Commit();
                        return true;
                    }
                    catch (Exception ex)
                    {
                        trans.Rollback();
                        LogHelper<WF_WorkFlowPersiDAL>.WriteLog("选签节点提交操作,BusinessId:" + currWf.BusinessId, ex);
                        return false;
                    }
                }
            }
        }

        /// <summary>
        /// 修改平行节点状态 关闭
        /// </summary>
        /// <param name="item"></param>
        /// <param name="conn"></param>
        /// <param name="trans"></param>
        private void UpdateWfAnyNodeSameLevel_Workflow_State(WorkFlow item, SqlConnection conn, SqlTransaction trans)
        {
            #region params
            SqlParameter[] paramArray = new SqlParameter[]
                {
                                new SqlParameter("@BusinessId", item.BusinessId),
                                new SqlParameter("@TemplateId", item.TemplateId),
                                new SqlParameter("@NodeId", item.NodeId),
                                new SqlParameter("@NodeStatu", Convert.ToInt32(NodeActionStatus.COLSED))
                };
            #endregion
            SqlCommand updateComm = new SqlCommand(GetSqlStr.UPDATE_WF_APPOINT_NODE_STATUS, conn, trans);
            updateComm.Parameters.AddRange(paramArray);
            int idx = updateComm.ExecuteNonQuery();
            if (idx < 0)
                throw new Exception("修改平行节点流程状态出错");
        }

        /// <summary>
        /// 平行节点插入历史纪录
        /// </summary>
        /// <param name="item"></param>
        /// <param name="conn"></param>
        /// <param name="trans"></param>
        private void InsertWfAnyNodeSameLevel_HistroyRecord(WorkFlow item, SqlConnection conn, SqlTransaction trans)
        {
            #region params
            WorkFlowOHist workFlowOHist = new WorkFlowOHist
            {
                BusinessBillId = item.BusinessId,
                NodeActionStatus = Convert.ToInt32(NodeActionStatus.COLSED),
                NodeCode = item.NodeCode,
                NodeId = item.NodeId,
                OperateState = Convert.ToInt32(WFOperateState.GIVEUP),
                OperateTime = DateTime.Now,
                OperateTime_order = DateTime.Now.Ticks,
                TemplateId = item.TemplateId,
                UserId = -1,
                WFActiveStatus = Convert.ToInt32(WFActiveStatus.DOING),
                WFGUID = Guid.NewGuid().ToString()
            };
            SqlParameter[] paramArray = new SqlParameter[]
            {
                            new SqlParameter("@TemplateId", ToDBValue(workFlowOHist.TemplateId)),
                            new SqlParameter("@UserId", ToDBValue(workFlowOHist.UserId)),
                            new SqlParameter("@NodeId", ToDBValue(workFlowOHist.NodeId)),
                            new SqlParameter("@NodeCode", ToDBValue(workFlowOHist.NodeCode)),
                            new SqlParameter("@OperateTime", ToDBValue(workFlowOHist.OperateTime)),
                            new SqlParameter("@OperateTime_order", ToDBValue(workFlowOHist.OperateTime_order)),
                            new SqlParameter("@BusinessBillId", ToDBValue(workFlowOHist.BusinessBillId)),
                            new SqlParameter("@OperateState", ToDBValue(workFlowOHist.OperateState)),
                            new SqlParameter("@NodeActionStatus", ToDBValue(workFlowOHist.NodeActionStatus)),
                            new SqlParameter("@WFActiveStatus", ToDBValue(workFlowOHist.WFActiveStatus)),
                            new SqlParameter("@WFGUID", ToDBValue(workFlowOHist.WFGUID))
            };
            #endregion
            string uspCmd = "UP_WorkFlowOHist_INSERT";
            SqlCommand insertComm = new SqlCommand(uspCmd, conn, trans);
            insertComm.Parameters.AddRange(paramArray);
            insertComm.CommandType = CommandType.StoredProcedure;
            int idx = insertComm.ExecuteNonQuery();
            if (idx < 0)
                throw new Exception("插入历史纪录出错");
        }

        /// <summary>
        /// 虚节点提交
        /// </summary>
        /// <param name="wfCurr"></param>
        /// <returns></returns>
        internal bool VirtualNodeMoveNext(WorkFlow currWf)
        {
            using (SqlConnection conn = SqlHelper.GetConnection())
            {
                conn.Open();
                using (SqlTransaction trans = conn.BeginTransaction())
                {
                    try
                    {
                        #region 插入历史纪录
                        InsertCurrentNode_HistoryRecord(currWf, conn, trans, WFOperateState.AGREE);
                        #endregion

                        #region 插入待办记录
                        UpdateCurrentNodeStateForOver_BeDone(currWf, conn, trans, WFOperateState.AGREE);
                        #endregion

                        #region 修改流程状态
                        UpdateWfCurrentNodeState(currWf, conn, trans, NodeActionStatus.OVER);
                        #endregion

                        trans.Commit();
                        return true;
                    }
                    catch (Exception ex)
                    {
                        trans.Rollback();
                        LogHelper<WF_WorkFlowPersiDAL>.WriteLog("虚节点提交,BusinessId:" + currWf.BusinessId, ex);
                        return false;
                    }
                }
            }
        }

        /// <summary>
        /// 交互节点提交
        /// </summary>
        /// <param name="currWf"></param>
        /// <param name="nextNodes"></param>
        /// <param name="unReviewViNodes"></param>
        /// <returns></returns>
        internal bool ActionNodeMoveNext(List<WorkFlow> currWfList, List<WorkFlow> nextNodes, List<WorkFlow> unReviewViNodes, List<WorkFlow> parentNodesList)
        {
            using (SqlConnection conn = SqlHelper.GetConnection())
            {
                conn.Open();
                using (SqlTransaction trans = conn.BeginTransaction())
                {
                    try
                    {
                        #region 插入历史纪录
                        currWfList?.ForEach(currWf =>
                        {
                            InsertCurrentNode_HistoryRecord(currWf, conn, trans, WFOperateState.AGREE);
                        });
                        unReviewViNodes?.ForEach(item =>
                        {
                            InsertWfAnyNodeSameLevel_HistroyRecord(item, conn, trans);
                        });
                        #endregion

                        #region 插入待办记录
                        nextNodes?.ForEach(nextNode =>
                        {
                            InsertWfNextNode_BeDoneRecord(nextNode, conn, trans, WFOperateState.BEDONE);
                        });
                        currWfList?.ForEach(currWf =>
                        {
                            UpdateCurrentNodeStateForOver_BeDone(currWf, conn, trans, WFOperateState.AGREE);
                        });
                        #endregion

                        #region 修改流程状态
                        currWfList?.ForEach(currWf =>
                        {
                            UpdateWfCurrentNodeState(currWf, conn, trans, NodeActionStatus.OVER);
                        });
                        nextNodes?.ForEach(nextNode =>
                        {
                            UpdateWfNextNodeState(nextNode, conn, trans);
                        });
                        unReviewViNodes?.ForEach(item =>
                        {
                            UpdateWfAnyNodeSameLevel_Workflow_State(item, conn, trans);
                        });
                        parentNodesList?.ForEach(item =>
                        {
                            UpdateWfNextNodeState(item, conn, trans);
                        });
                        #endregion

                        trans.Commit();
                        return true;
                    }
                    catch (Exception ex)
                    {
                        trans.Rollback();
                        LogHelper<WF_WorkFlowPersiDAL>.WriteLog("交互节点提交操作", ex);
                        return false;
                    }
                }
            }
        }

        /// <summary>
        /// 会签节点提交
        /// </summary>
        /// <param name="currWf"></param>
        /// <param name="nextNode"></param>
        /// <returns></returns>
        internal bool SignNodeMoveNext(WorkFlow currWf, WorkFlow nextNode)
        {
            using (SqlConnection conn = SqlHelper.GetConnection())
            {
                conn.Open();
                using (SqlTransaction trans = conn.BeginTransaction())
                {
                    try
                    {
                        #region 插入历史纪录
                        InsertCurrentNode_HistoryRecord(currWf, conn, trans, WFOperateState.AGREE);
                        #endregion

                        #region 插入待办记录
                        if (nextNode != null)
                        {
                            InsertWfNextNode_BeDoneRecord(nextNode, conn, trans, WFOperateState.BEDONE);
                        }
                        UpdateCurrentNodeStateForOver_BeDone(currWf, conn, trans, WFOperateState.AGREE);
                        #endregion

                        #region 修改流程状态
                        UpdateWfCurrentNodeState(currWf, conn, trans, NodeActionStatus.OVER);
                        if (nextNode != null)
                        {
                            UpdateWfNextNodeState(nextNode, conn, trans);
                        }
                        #endregion

                        trans.Commit();
                        return true;
                    }
                    catch (Exception ex)
                    {
                        trans.Rollback();
                        LogHelper<WF_WorkFlowPersiDAL>.WriteLog("会签节点提交,BusinessId:" + currWf.BusinessId, ex);
                        return false;
                    }
                }
            }
        }

        /// <summary>
        /// 插入当前节点历史纪录
        /// </summary>
        /// <param name="currWf"></param>
        /// <param name="conn"></param>
        /// <param name="trans"></param>
        /// <param name="paramArray"></param>
        /// <param name="uspCmd"></param>
        /// <param name="insertComm"></param>
        private void InsertCurrentNode_HistoryRecord(WorkFlow currWf, SqlConnection conn, SqlTransaction trans, WFOperateState wfOperateState)
        {
            #region params
            WorkFlowOHist workFlowOHist = new WorkFlowOHist
            {
                BusinessBillId = currWf.BusinessId,
                NodeActionStatus = Convert.ToInt32(NodeActionStatus.OVER),
                NodeCode = currWf.NodeCode,
                NodeId = currWf.NodeId,
                OperateState = Convert.ToInt32(wfOperateState),
                OperateTime = DateTime.Now,
                OperateTime_order = DateTime.Now.Ticks,
                TemplateId = currWf.TemplateId,
                UserId = currWf.EmployeeId,
                WFActiveStatus = Convert.ToInt32(WFActiveStatus.DOING),
                WFGUID = Guid.NewGuid().ToString()
            };
            SqlParameter[] paramArray = new SqlParameter[]
            {
                            new SqlParameter("@TemplateId", ToDBValue(workFlowOHist.TemplateId)),
                            new SqlParameter("@UserId", ToDBValue(workFlowOHist.UserId)),
                            new SqlParameter("@NodeId", ToDBValue(workFlowOHist.NodeId)),
                            new SqlParameter("@NodeCode", ToDBValue(workFlowOHist.NodeCode)),
                            new SqlParameter("@OperateTime", ToDBValue(workFlowOHist.OperateTime)),
                            new SqlParameter("@OperateTime_order", ToDBValue(workFlowOHist.OperateTime_order)),
                            new SqlParameter("@BusinessBillId", ToDBValue(workFlowOHist.BusinessBillId)),
                            new SqlParameter("@OperateState", ToDBValue(workFlowOHist.OperateState)),
                            new SqlParameter("@NodeActionStatus", ToDBValue(workFlowOHist.NodeActionStatus)),
                            new SqlParameter("@WFActiveStatus", ToDBValue(workFlowOHist.WFActiveStatus)),
                            new SqlParameter("@WFGUID", ToDBValue(workFlowOHist.WFGUID))
            };
            #endregion
            string uspCmd = "UP_WorkFlowOHist_INSERT";
            SqlCommand insertComm = new SqlCommand(uspCmd, conn, trans);
            insertComm.Parameters.AddRange(paramArray);
            insertComm.CommandType = CommandType.StoredProcedure;
            int idx = insertComm.ExecuteNonQuery();
            if (idx < 0)
                throw new Exception("插入历史纪录出错");
        }

        /// <summary>
        /// 修改当前结点待办记录状态，改为已完成
        /// </summary>
        /// <param name="currWf"></param>
        /// <param name="conn"></param>
        /// <param name="trans"></param>
        /// <param name="paramArray"></param>
        /// <param name="insertComm"></param>
        /// <param name="idx"></param>
        /// <param name="updateComm"></param>
        private void UpdateCurrentNodeStateForOver_BeDone(WorkFlow currWf, SqlConnection conn, SqlTransaction trans, WFOperateState wfOperateState)
        {
            string sqlCmd = GetSqlStr.UPDATE_WF_NODE_STATE_DONE;
            #region params
            SqlParameter[] paramArray = new SqlParameter[]
            {
                            new SqlParameter("@UserId", currWf.EmployeeId),
                            new SqlParameter("@TemplateId", ToDBValue(currWf.TemplateId)),
                            new SqlParameter("@BusinessBillId", ToDBValue(currWf.BusinessId)),
                            new SqlParameter("@NodeId", ToDBValue(currWf.NodeId)),
                            new SqlParameter("@OperateState", Convert.ToInt32(wfOperateState)),
                            new SqlParameter("@OperateDate", DateTime.Now),
                            new SqlParameter("@OperateDate_Order", DateTime.Now.Ticks)
            };
            #endregion
            SqlCommand updateComm = new SqlCommand(sqlCmd, conn, trans);
            updateComm.Parameters.AddRange(paramArray);
            int idx = updateComm.ExecuteNonQuery();
            if (idx < 0)
                throw new Exception("修改当前结点待办到通过状态出错");
        }

        /// <summary>
        /// 插入流程下一节点到待办表
        /// </summary>
        /// <param name="nextNode"></param>
        /// <param name="conn"></param>
        /// <param name="trans"></param>
        /// <param name="paramArray"></param>
        /// <param name="uspCmd"></param>
        /// <param name="insertComm"></param>
        /// <param name="idx"></param>
        private void InsertWfNextNode_BeDoneRecord(WorkFlow nextNode, SqlConnection conn, SqlTransaction trans, WFOperateState wfOperateState)
        {
            #region params
            WorkFlowBeDone workFlowBeDone = new WorkFlowBeDone
            {
                BusinessBillId = nextNode.BusinessId,
                NodeCode = nextNode.NodeCode,
                NodeId = nextNode.NodeId,
                OperateDate = DateTime.Now,
                OperateDate_Order = DateTime.Now.Ticks,
                OperateState = Convert.ToInt32(wfOperateState),
                TemplateId = nextNode.TemplateId,
                UserId = nextNode.EmployeeId
            };
            SqlParameter[] paramArray = new SqlParameter[]
            {
                                new SqlParameter("@UserId", ToDBValue(workFlowBeDone.UserId)),
                                new SqlParameter("@TemplateId", ToDBValue(workFlowBeDone.TemplateId)),
                                new SqlParameter("@BusinessBillId", ToDBValue(workFlowBeDone.BusinessBillId)),
                                new SqlParameter("@NodeId", ToDBValue(workFlowBeDone.NodeId)),
                                new SqlParameter("@NodeCode", ToDBValue(workFlowBeDone.NodeCode)),
                                new SqlParameter("@OperateState", ToDBValue(workFlowBeDone.OperateState)),
                                new SqlParameter("@OperateDate", ToDBValue(workFlowBeDone.OperateDate)),
                                new SqlParameter("@OperateDate_Order", ToDBValue(workFlowBeDone.OperateDate_Order)),
                                new SqlParameter("@OperateDesc", ToDBValue(workFlowBeDone.OperateDesc)),
                                new SqlParameter("@Remark", ToDBValue(workFlowBeDone.Remark)),
            };
            #endregion
            string uspCmd = "UP_WorkFlowBeDone_INSERT";
            SqlCommand insertComm = new SqlCommand(uspCmd, conn, trans);
            insertComm.Parameters.AddRange(paramArray);
            insertComm.CommandType = CommandType.StoredProcedure;
            int idx = insertComm.ExecuteNonQuery();
            if (idx < 0)
                throw new Exception("提交节点插入待办记录出错");
        }

        /// <summary>
        /// 修改流程的当前结点状态-Workflow
        /// </summary>
        /// <param name="currWf"></param>
        /// <param name="conn"></param>
        /// <param name="trans"></param>
        /// <param name="paramArray"></param>
        /// <param name="idx"></param>
        /// <param name="updateComm"></param>
        private static void UpdateWfCurrentNodeState(WorkFlow currWf, SqlConnection conn, SqlTransaction trans, NodeActionStatus nodeActionStatus)
        {
            #region params
            SqlParameter[] paramArray = new SqlParameter[]
                {
                                new SqlParameter("@BusinessId", currWf.BusinessId),
                                new SqlParameter("@TemplateId", currWf.TemplateId),
                                new SqlParameter("@NodeId", currWf.NodeId),
                                new SqlParameter("@NodeStatu", Convert.ToInt32(nodeActionStatus))
                };
            #endregion
            SqlCommand updateComm = new SqlCommand(GetSqlStr.UPDATE_WF_APPOINT_NODE_STATUS, conn, trans);
            updateComm.Parameters.AddRange(paramArray);
            int idx = updateComm.ExecuteNonQuery();
            if (idx < 0)
                throw new Exception("修改当前节点流程状态出错");
        }

        /// <summary>
        /// 修改流程下一节点状态-Workflow
        /// </summary>
        /// <param name="nextNode"></param>
        /// <param name="conn"></param>
        /// <param name="trans"></param>
        /// <param name="paramArray"></param>
        /// <param name="idx"></param>
        /// <param name="updateComm"></param>
        private static void UpdateWfNextNodeState(WorkFlow nextNode, SqlConnection conn, SqlTransaction trans)
        {
            #region params
            SqlParameter[] paramArray = new SqlParameter[]
                {
                    new SqlParameter("@BusinessId", nextNode.BusinessId),
                    new SqlParameter("@TemplateId", nextNode.TemplateId),
                    new SqlParameter("@NodeId", nextNode.NodeId),
                    new SqlParameter("@NodeStatu", Convert.ToInt32(NodeActionStatus.DOING))
                };
            #endregion
            SqlCommand updateComm = new SqlCommand(GetSqlStr.UPDATE_WF_APPOINT_NODE_STATUS, conn, trans);
            updateComm.Parameters.AddRange(paramArray);
            int idx = updateComm.ExecuteNonQuery();
            if (idx < 0)
                throw new Exception("修改下一节点流程状态出错");
        }

        /// <summary>
        /// 交互节点退回
        /// </summary>
        /// <param name="wfCurr"></param>
        /// <param name="wfPrev"></param>
        /// <returns></returns>
        internal bool ActionNodeMovePrev(WorkFlow wfCurr, WorkFlow wfPrev)
        {
            using (SqlConnection conn = SqlHelper.GetConnection())
            {
                conn.Open();
                using (SqlTransaction trans = conn.BeginTransaction())
                {
                    try
                    {
                        #region 插入历史纪录
                        InsertCurrentNode_HistoryRecord(wfCurr, conn, trans, WFOperateState.DISAGREE);
                        #endregion

                        #region 插入待办记录
                        UpdateCurrentNodeStateForOver_BeDone(wfCurr, conn, trans, WFOperateState.DISAGREE);
                        InsertWfNextNode_BeDoneRecord(wfPrev, conn, trans, WFOperateState.BEDONE);
                        #endregion

                        #region 修改流程状态
                        UpdateWfCurrentNodeState(wfCurr, conn, trans, NodeActionStatus.INIT);
                        UpdateWfCurrentNodeState(wfPrev, conn, trans, NodeActionStatus.DOING);
                        #endregion

                        trans.Commit();
                        return true;
                    }
                    catch (Exception ex)
                    {
                        trans.Rollback();
                        LogHelper<WF_WorkFlowPersiDAL>.WriteLog("虚节点提交,BusinessId:" + wfCurr.BusinessId, ex);
                        return false;
                    }
                }
            }
        }
    }
}
