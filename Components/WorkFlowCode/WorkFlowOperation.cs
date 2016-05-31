/*
 * 工作流操作
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZtbSoft.Models;

namespace Components.WorkFlowCode
{
    public class WorkFlowOperation
    {
        /// <summary>
        /// 复制流程模版
        /// </summary>
        /// <param name="businessId">业务ID</param>
        /// <param name="templateId">流程模版ID</param>
        /// <param name="msg"></param>
        /// <returns></returns>
        private int CopyWorkFlowTemplate(int businessId, int templateId, out string msg)
        {
            int r = 0;
            msg = "复制成功";
            return r;
        }

        /// <summary>
        /// 初始化流程
        /// </summary>
        /// <param name="workFlowId"></param>
        /// <param name="msg"></param>
        /// <returns></returns>
        private bool InitWorkFlow(int workFlowId, out string msg)
        {
            bool bl = false;
            msg = "初始化成功！";
            return bl;
        }

        /// <summary>
        /// 获取下一步节点列表
        /// </summary>
        /// <param name="businessId">业务ID</param>
        /// <param name="node">节点信息</param>
        /// <param name="msg">消息</param>
        /// <returns>节点列表</returns>
        private List<WorkFlow> GetNextNodes(int businessId, WorkFlow node, out string msg)
        {
            var list = new List<WorkFlow>();
            msg = "获取成功";
            return list;
        }

        /// <summary>
        /// 获取退回节点
        /// </summary>
        /// <param name="businessId">业务ID</param>
        /// <param name="node">节点信息</param>
        /// <param name="msg">消息</param>
        /// <returns>节点信息</returns>
        private WorkFlow GetReturnNode(int businessId, WorkFlow node, out string msg)
        {
            var model = new WorkFlow();
            msg = "获取成功";
            return model;
        }
    }
}
