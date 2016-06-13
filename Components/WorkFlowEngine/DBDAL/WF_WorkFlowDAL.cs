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
using ZtbSoft.Models;

namespace Components.WorkFlowEngine.DBDAL
{
    public class WF_WorkFlowDAL
    {
        protected object ToDBValue(object value)
        {
            if (value == null)
            {
                return DBNull.Value;
            }
            else
            {
                return value;
            }
        }

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
                new SqlParameter("@PCode", wf.NodeCode));
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
        internal bool WfStartPreData(WorkFlow initWf, WorkFlow currWf, List<WorkFlow> wfList)
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

                        #endregion

                        trans.Commit();
                        return true;
                    }
                    catch (Exception)
                    {
                        trans.Rollback();
                        return false;
                    }
                }
            }
        }
    }

    internal static class GetSqlStr
    {

        internal static readonly string Get_WF_NEXT_NODES = @"SELECT * FROM dbo.WorkFlow
                WHERE BusinessId = @BusinessId AND TemplateId = @TemplateId AND PCode = @PCode ";

        internal static readonly string GET_WF_ENTRANCE_NODE = @"SELECT * FROM dbo.WorkFlow
                WHERE BusinessId = @BusinessId AND TemplateId = @TemplateId AND NodeType = @NodeType AND PCode = @PCode ";

        internal static readonly string GET_WF_ENTRANCE_ROOT_NODE = @"SELECT * FROM dbo.WorkFlow
                WHERE BusinessId = @BusinessId AND TemplateId = @TemplateId AND NodeType = @NodeType";

        internal static readonly string CHECK_WF_ISCOPY_TEMPLATE = @"SELECT COUNT(1) FROM dbo.WorkFlow
                WHERE BusinessId = @BusinessId AND TemplateId =@TemplateId";

        internal static readonly string COPY_WF_FROM_TEMPLATE = @"INSERT INTO WorkFlow
	                                                        (
                                                                NodeId ,
                                                                NodeCode ,
                                                                NodeName ,
                                                                NodeUrl ,
                                                                PCode ,
                                                                QjNodeCode ,
                                                                ThNodeCode ,
                                                                NodeStatu ,
                                                                NodeType ,
                                                                TemplateId ,
                                                                ProjectId,
                                                                EmployeeId ,
                                                                NodeShowUrl ,
                                                                BusinessId
	                                                        )			
                                                        SELECT NodeId,
                                                                NodeCode,
                                                                NodeName,
                                                                NodeUrl,
                                                                PCode,
                                                                QjNodeCode,
                                                                ThNodeCode,
                                                                NodeStatu,
                                                                NodeType,
                                                                TemplateId,
                                                                '-1',
                                                                EmployeeId,
                                                                NodeShowUrl,
                                                                @BusinessId
                                                        FROM WorkFlowTemp
                                                        WHERE TemplateId=@TemplateId ";
    }
}
