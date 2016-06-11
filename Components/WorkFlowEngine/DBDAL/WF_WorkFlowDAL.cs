using Components.Properties;
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
                new SqlParameter("@NodeType", NodeTypeStatus.NAMEDES))?.Rows[0]);
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
                new SqlParameter("@NodeType", NodeTypeStatus.START),
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
