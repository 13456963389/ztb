using Components.Properties;
using DSM.DAL;
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
    public class WF_WorkFlowDAL : WFDAL
    {


        /// <summary>
        /// 检查是否模板被复制
        /// </summary>
        /// <param name="wf"></param>
        /// <returns></returns>
        public int CheckWorkFlowIsCopy(WorkFlow wf)
        {
            return Convert.ToInt32(SqlHelper.ExecuteScalar(
                GetSqlStr.CHECK_WF_ISCOPY_TEMPLATE,
                new SqlParameter("@BusinessId", wf.BusinessId),
                new SqlParameter("@TemplateId", wf.TemplateId)
            ) ?? 0);
        }

        /// <summary>
        /// 复制模板
        /// </summary>
        /// <returns></returns>
        public int CopyWfFromTemplate(WorkFlow wf)
        {
            return SqlHelper.ExecuteNonQuery(
                GetSqlStr.COPY_WF_FROM_TEMPLATE,
                new SqlParameter("@BusinessId", wf.BusinessId),
                new SqlParameter("@TemplateId", wf.TemplateId));
        }

        /// <summary>
        /// 模糊查询获取下一步节点集合
        /// </summary>
        /// <param name="wf"></param>
        /// <returns></returns>
        internal List<WorkFlow> GetNextVagueNodes(WorkFlow wf)
        {
            List<WorkFlow> wfList = new List<WorkFlow>();
            DataTable dt = SqlHelper.ExecuteDataTable(
                GetSqlStr.Get_WF_NEXT_VAGUE_NODES,
                new SqlParameter("@BusinessId", wf.BusinessId),
                new SqlParameter("@TemplateId", wf.TemplateId),
                new SqlParameter("@PCode", wf.PCode),
                new SqlParameter("@QjNodeCode", "%" + wf.NodeCode + "%"));
            if (dt == null)
                throw new NullReferenceException(string.Format(WfErrorCode.Error_3002, wf.TemplateId, wf.BusinessId, wf.NodeCode));
            foreach (var item in dt.Rows)
            {
                wfList.Add(new WorkFlow(item as DataRow));
            }
            return wfList;
        }

        /// <summary>
        /// 查看该业务流程历史数据条数
        /// </summary>
        /// <param name="wf"></param>
        /// <returns></returns>
        internal int GetWFHistoryCounts(WorkFlow wf)
        {
            return Convert.ToInt32(
                SqlHelper.ExecuteScalar(GetSqlStr.GET_WF_HISTORY_COUNTS,
                new SqlParameter("@BusinessId", wf.BusinessId),
                new SqlParameter("@TemplateId", wf.TemplateId)) ?? 0
            );
        }

        /// <summary>
        /// 获取当前节点所有平行节点集合
        /// </summary>
        /// <param name="wf"></param>
        /// <returns></returns>
        internal List<WorkFlow> GetCurrentSameLevelNodes(WorkFlow wf)
        {
            List<WorkFlow> retLists = new List<WorkFlow>();
            DataTable wfDt = SqlHelper.ExecuteDataTable(
                GetSqlStr.GET_WF_NODE_SAME_LEVEL_NODES,
                new SqlParameter("@BusinessId", wf.BusinessId),
                new SqlParameter("@TemplateId", wf.TemplateId),
                new SqlParameter("@PCode", wf.NodeCode),
                new SqlParameter("@QjNodeCode", wf.QjNodeCode)
            );
            foreach (var item in wfDt.Rows)
            {
                retLists.Add(new WorkFlow(item as DataRow));
            }
            return retLists;
        }

        /// <summary>
        /// 获取 流程名称节点
        /// </summary>
        /// <param name="wf"></param>
        /// <returns></returns>
        internal WorkFlow GetRootEntranceNode(WorkFlow wf)
        {
            return new WorkFlow(SqlHelper.ExecuteDataTable(
                GetSqlStr.GET_WF_ENTRANCE_ROOT_NODE,
                new SqlParameter("@BusinessId", wf.BusinessId),
                new SqlParameter("@TemplateId", wf.TemplateId),
                new SqlParameter("@NodeType", Convert.ToInt32(NodeTypeStatus.NAMEDES)))?.Rows[0]);
        }

        /// <summary>
        /// 获取当前节点子节点
        /// </summary>
        /// <param name="wf"></param>
        /// <returns></returns>
        internal List<WorkFlow> GetChildNodes(WorkFlow wf)
        {
            List<WorkFlow> retLists = new List<WorkFlow>();
            DataTable wfDt = SqlHelper.ExecuteDataTable(
                GetSqlStr.GET_WF_NODE_CHILD_NODES,
                new SqlParameter("@BusinessId", wf.BusinessId),
                new SqlParameter("@TemplateId", wf.TemplateId),
                new SqlParameter("@PCode", wf.NodeCode)
            );
            foreach (var item in wfDt.Rows)
            {
                retLists.Add(new WorkFlow(item as DataRow));
            }
            return retLists;
        }

        /// <summary>
        /// 检查节点是否是整个流程结束节点
        /// </summary>
        /// <param name="wf"></param>
        /// <returns></returns>
        internal bool CheckNodeIsRootEndNode(WorkFlow wf)
        {
            DataTable wfDt = SqlHelper.ExecuteDataTable(
                GetSqlStr.CHECK_WF_NODE_PARENT_TYPE,
                new SqlParameter("@BusinessId", wf.BusinessId),
                new SqlParameter("@TemplateId", wf.TemplateId),
                new SqlParameter("@PCode", wf.NodeCode)
            );
            if (wfDt != null && wfDt.Rows.Count > 0)
            {
                return Convert.ToInt32(wfDt.Rows[0]["NodeType"]) == Convert.ToInt32(NodeTypeStatus.NAMEDES);
            }
            return false;
        }

        /// <summary>
        /// 获取子流程父节点
        /// </summary>
        /// <param name="wf"></param>
        /// <returns></returns>
        internal WorkFlow GetChildNodeParentNode(WorkFlow wf)
        {
            DataTable wfDt = SqlHelper.ExecuteDataTable(
                GetSqlStr.CHECK_WF_NODE_PARENT_TYPE,
                new SqlParameter("@BusinessId", wf.BusinessId),
                new SqlParameter("@TemplateId", wf.TemplateId),
                new SqlParameter("@PCode", wf.NodeCode)
            );
            if (wfDt != null && wfDt.Rows.Count > 0)
            {
                return new WorkFlow(wfDt.Rows[0]);
            }
            return null;
        }

        /// <summary>
        /// 获取流程 入口节点
        /// </summary>
        /// <param name="wf"></param>
        /// <returns></returns>
        internal WorkFlow GetEntranceNode(WorkFlow wf)
        {
            return new WorkFlow(SqlHelper.ExecuteDataTable(
                GetSqlStr.GET_WF_ENTRANCE_NODE,
                new SqlParameter("@BusinessId", wf.BusinessId),
                new SqlParameter("@TemplateId", wf.TemplateId),
                new SqlParameter("@NodeType", Convert.ToInt32(NodeTypeStatus.START)),
                new SqlParameter("@PCode", wf.NodeCode))?.Rows[0]);
        }

        /// <summary>
        /// 获取当前待办节点
        /// </summary>
        /// <param name="wf"></param>
        /// <returns></returns>
        internal WorkFlow GetCurrentNode(WorkFlow wf)
        {
            return new WorkFlow(
                SqlHelper.ExecuteDataTable(
                    GetSqlStr.GET_WF_CURRENT_NODE,
                    new SqlParameter("@BusinessId", wf.BusinessId),
                    new SqlParameter("@NodeCode", wf.NodeCode),
                    new SqlParameter("@OperateState", Convert.ToInt32(WFOperateState.BEDONE))
                )?.Rows[0]
            );
        }

        /// <summary>
        /// 获取下一步节点集合
        /// </summary>
        /// <param name="wf"></param>
        /// <returns></returns>
        internal List<WorkFlow> GetNextNodes(WorkFlow wf)
        {
            List<WorkFlow> wfList = new List<WorkFlow>();
            DataTable dt = SqlHelper.ExecuteDataTable(
                GetSqlStr.Get_WF_NEXT_NODES,
                new SqlParameter("@BusinessId", wf.BusinessId),
                new SqlParameter("@TemplateId", wf.TemplateId),
                new SqlParameter("@QjNodeCode", wf.NodeCode));
            if (dt == null)
                throw new NullReferenceException(string.Format(WfErrorCode.Error_3002, wf.TemplateId, wf.BusinessId, wf.NodeCode));
            foreach (var item in dt.Rows)
            {
                wfList.Add(new WorkFlow(item as DataRow));
            }
            return wfList;
        }

        /// <summary>
        /// 流程开始->
        ///     操作历史
        ///     待办
        /// </summary>
        /// <param name="initWf"></param>
        /// <param name="currWf"></param>
        /// <param name="wfList"></param>
        /// <returns></returns>
        internal bool WfStartPreData(WorkFlow initWf, WorkFlow currWf, List<WorkFlow> wfList, List<WorkFlow> parentNodesList)
        {
            using (SqlConnection conn = SqlHelper.GetConnection())
            {
                conn.Open();
                using (SqlTransaction trans = conn.BeginTransaction())
                {
                    try
                    {
                        #region 插入历史纪录
                        #region params
                        WorkFlowOHist workFlowOHist = new WorkFlowOHist
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
                        #endregion

                        #region 插入待办记录
                        wfList.ForEach(item =>
                        {
                            #region params
                            WorkFlowBeDone workFlowBeDone = new WorkFlowBeDone
                            {
                                BusinessBillId = item.BusinessId,
                                NodeCode = item.NodeCode,
                                NodeId = item.NodeId,
                                OperateDate = DateTime.Now,
                                OperateDate_Order = DateTime.Now.Ticks,
                                OperateState = Convert.ToInt32(WFOperateState.BEDONE),
                                TemplateId = item.TemplateId,
                                UserId = item.EmployeeId
                            };
                            paramArray = new SqlParameter[]
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
                            uspCmd = "UP_WorkFlowBeDone_INSERT";
                            insertComm = new SqlCommand(uspCmd, conn, trans);
                            insertComm.Parameters.AddRange(paramArray);
                            insertComm.CommandType = CommandType.StoredProcedure;
                            idx = insertComm.ExecuteNonQuery();
                            if (idx < 0)
                                throw new Exception("插入待办记录出错");
                        });
                        #endregion

                        #region 修改流程状态
                        #region params
                        paramArray = new SqlParameter[]
                            {
                                new SqlParameter("@BusinessId", currWf.BusinessId),
                                new SqlParameter("@TemplateId", currWf.TemplateId),
                                new SqlParameter("@NodeId", currWf.NodeId),
                                new SqlParameter("@NodeStatu", Convert.ToInt32(NodeActionStatus.OVER))
                            };
                        #endregion
                        SqlCommand updateComm = new SqlCommand(GetSqlStr.UPDATE_WF_APPOINT_NODE_STATUS, conn, trans);
                        updateComm.Parameters.AddRange(paramArray);
                        idx = updateComm.ExecuteNonQuery();
                        if (idx < 0)
                            throw new Exception("修改流程状态出错");

                        parentNodesList?.ForEach(item =>
                        {
                            #region params
                            paramArray = new SqlParameter[]
                                {
                                new SqlParameter("@BusinessId", item.BusinessId),
                                new SqlParameter("@TemplateId", item.TemplateId),
                                new SqlParameter("@NodeId", item.NodeId),
                                new SqlParameter("@NodeStatu", Convert.ToInt32(NodeActionStatus.DOING))
                                };
                            #endregion
                            updateComm = new SqlCommand(GetSqlStr.UPDATE_WF_APPOINT_NODE_STATUS, conn, trans);
                            updateComm.Parameters.AddRange(paramArray);
                            idx = updateComm.ExecuteNonQuery();
                            if (idx < 0)
                                throw new Exception("修改流程状态出错");
                        });
                        #endregion

                        trans.Commit();
                        return true;
                    }
                    catch (Exception ex)
                    {
                        trans.Rollback();
                        LogHelper<WF_WorkFlowDAL>.WriteLog("流程开始节点操作,BusinessId:" + currWf.BusinessId, ex);
                        return false;
                    }
                }
            }
        }

        /// <summary>
        /// 获取上一级节点
        /// </summary>
        /// <param name="wf"></param>
        /// <returns></returns>
        internal WorkFlow GetPrevNode(WorkFlow wf)
        {
            return new WorkFlow(
                SqlHelper.ExecuteDataTable(
                    GetSqlStr.GET_WF_PREVOUS_NODE,
                    new SqlParameter("@BusinessId", wf.BusinessId),
                    new SqlParameter("@TemplateId", wf.TemplateId),
                    new SqlParameter("@NodeCode", wf.ThNodeCode)
                )?.Rows[0]
            );
        }
    }


}
