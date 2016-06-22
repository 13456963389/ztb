using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZtbSoft.Models;

namespace Components.WorkFlowEngine.DBDAL
{
    public abstract class WFDAL
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

        
    }


    internal static class GetSqlStr
    {
        /// <summary>
        /// 获取流程上一步节点
        /// </summary>
        internal static readonly string GET_WF_PREVOUS_NODE = @"SELECT * FROM dbo.WorkFlow
                WHERE BusinessId = @BusinessId AND TemplateId = @TemplateId AND NodeCode = @NodeCode ";

        /// <summary>
        /// 查看父节点
        /// </summary>
        internal static readonly string CHECK_WF_NODE_PARENT_TYPE = @"SELECT wf.* FROM  dbo.WorkFlow AS wf
                WHERE wf.NodeCode = (SELECT PCode FROM dbo.WorkFlow 
				                WHERE CaseId=@CaseId) AND wf.BusinessId =@BusinessId AND TemplateId=@TemplateId ";

        /// <summary>
        /// 修改当前结点状态为已通过
        /// </summary>
        internal static readonly string UPDATE_WF_NODE_STATE_DONE = @"UPDATE dbo.WorkFlowBeDone
                SET OperateState=@OperateState,OperateDate=@OperateDate,OperateDate_Order=@OperateDate_Order,UserId=@UserId
                WHERE NodeId=@NodeId AND BusinessBillId=@BusinessBillId AND TemplateId=@TemplateId ";

        /// <summary>
        /// 模糊查询获取下一步节点集合
        /// </summary>
        internal static readonly object Get_WF_NEXT_VAGUE_NODES = @"SELECT * FROM dbo.WorkFlow
                WHERE QjNodeCode LIKE @QjNodeCode AND BusinessId = @BusinessId AND TemplateId = @TemplateId AND PCode = @PCode ";

        /// <summary>
        /// 获取节点所有平行节点集合
        /// </summary>
        internal static readonly object GET_WF_NODE_SAME_LEVEL_NODES = @"SELECT * FROM dbo.WorkFlow
                WHERE QjNodeCode=@QjNodeCode AND BusinessId=@BusinessId AND TemplateId=@TemplateId AND PCode=@PCode ";

        /// <summary>
        /// 根据业务编号和节点code获取当前结点
        /// </summary>
        internal static readonly string GET_WF_CURRENT_NODE = @"SELECT wf.* FROM dbo.WorkFlowBeDone AS d
                LEFT JOIN dbo.WorkFlow AS wf ON d.TemplateId = wf.TemplateId AND d.NodeId = wf.NodeId AND wf.BusinessId=d.BusinessBillId
                WHERE OperateState=@OperateState AND d.NodeCode=@NodeCode AND BusinessBillId = @BusinessId";

        /// <summary>
        /// 获取流程节点下所有子节点
        /// </summary>
        public static readonly string GET_WF_NODE_CHILD_NODES = @"SELECT * FROM dbo.WorkFlow
                WHERE BusinessId=@BusinessId AND TemplateId=@TemplateId AND PCode=@PCode ";

        /// <summary>
        /// 根据业务编号和模板编号获取历史数据条数
        /// </summary>
        internal static readonly string GET_WF_HISTORY_COUNTS = @"SELECT COUNT(1) FROM dbo.WorkFlowOHist
                WHERE TemplateId = @TemplateId AND BusinessBillId = @BusinessId ";

        /// <summary>
        /// 修改指定节点状态
        /// </summary>
        internal static readonly string UPDATE_WF_APPOINT_NODE_STATUS = @"UPDATE dbo.WorkFlow
                SET NodeStatu = @NodeStatu,DoTime=GETDATE()
                WHERE BusinessId = @BusinessId AND TemplateId = @TemplateId AND NodeId = @NodeId ";

        /// <summary>
        /// 获取下一步所有节点集合
        /// </summary>
        internal static readonly string Get_WF_NEXT_NODES = @"SELECT * FROM dbo.WorkFlow
                WHERE BusinessId = @BusinessId AND TemplateId = @TemplateId AND QjNodeCode = @QjNodeCode ";

        /// <summary>
        /// 获取流程入口节点，即开始节点
        /// </summary>
        internal static readonly string GET_WF_ENTRANCE_NODE = @"SELECT * FROM dbo.WorkFlow
                WHERE BusinessId = @BusinessId AND TemplateId = @TemplateId AND NodeType = @NodeType AND PCode = @PCode ";

        /// <summary>
        /// 获取流程描述节点
        /// </summary>
        internal static readonly string GET_WF_ENTRANCE_ROOT_NODE = @"SELECT * FROM dbo.WorkFlow
                WHERE BusinessId = @BusinessId AND TemplateId = @TemplateId AND NodeType = @NodeType";

        /// <summary>
        /// 检查模板是否被复制
        /// </summary>
        internal static readonly string CHECK_WF_ISCOPY_TEMPLATE = @"SELECT COUNT(1) FROM dbo.WorkFlow
                WHERE BusinessId = @BusinessId AND TemplateId =@TemplateId";

        /// <summary>
        /// 插入模板流程
        /// </summary>
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
