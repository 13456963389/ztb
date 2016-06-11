/*
 * creater:张成仪
 * 说明：工作流对应操作
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZtbSoft.Models;
using Components.WorkFlowEngine;
using Components.Properties;
using ZtbSoft.Components;

namespace Components.CommonHelper
{
    public class WorkFlowHelper : WfEngine
    {
        /// <summary>
        /// 创建流程
        /// </summary>
        /// <param name="templateId">模版ID</param>
        /// <param name="businessId">业务ID</param>
        /// <param name="userId">创建人ID</param>
        /// <param name="msg">消息</param>
        /// <returns>工作流ID（0、为失败）</returns>
        public int Create(int templateId, int businessId, int userId, out string msg)
        {
            RetInfo retInfo = Create(new WorkFlow
            {
                TemplateId = templateId,
                BusinessId = businessId,
                EmployeeId = userId
            });
            msg = string.Format("创建流程:{0}", retInfo.Msg);
            return retInfo.RetInt;
        }

        /// <summary>
        /// 流程提交
        /// </summary>
        /// <param name="businessId">主流程业务ID</param>
        /// <param name="nodeId">节点ID</param>
        /// <param name="userId">提交人ID</param>
        /// <param name="msg">消息</param>
        /// <returns></returns>
        public bool Submit(int businessId, string nodeCode, int userId, out string msg)
        {
            bool bl = false;
            msg = "提交成功！";
            return bl;
        }

        /// <summary>
        /// 流程退回
        /// </summary>
        /// <param name="businessId">主流程业务ID</param>
        /// <param name="nodeId">节点ID</param>
        /// <param name="userId">提交人ID</param>
        /// <param name="msg">消息</param>
        /// <returns></returns>
        public bool Return(int businessId, string nodeCode, int userId, out string msg)
        {
            bool bl = false;
            msg = "提交成功！";
            return bl;
        }

        /// <summary>
        /// 冻结流程
        /// </summary>
        /// <param name="businessId">主流程业务ID</param>
        /// <param name="userId">提交人ID</param>
        /// <param name="msg">消息</param>
        /// <returns></returns>
        public bool Stop(int businessId, int userId, out string msg)
        {
            bool bl = false;
            msg = "提交成功！";
            return bl;
        }

        /// <summary>
        /// 解冻流程
        /// </summary>
        /// <param name="businessId">主流程业务ID</param>
        /// <param name="userId">提交人ID</param>
        /// <param name="msg">消息</param>
        /// <returns></returns>
        public bool Star(int businessId, int userId, out string msg)
        {
            bool bl = false;
            msg = "提交成功！";
            return bl;
        }

        /// <summary>
        /// 获取主流程树对象
        /// </summary>
        /// <param name="businessId"></param>
        /// <returns></returns>
        public List<WorkFlow> GetMainWorkFlowList(int businessId)
        {
            var list = new List<WorkFlow>();
            return list;
        }

        /// <summary>
        /// 获取流程树对象
        /// </summary>
        /// <param name="businessId"></param>
        /// <param name="parentNodeId">父节点ID</param>
        /// <returns></returns>
        public List<WorkFlow> GetWorkFlowInfo(int businessId, int parentNodeCode)
        {
            var list = new List<WorkFlow>();
            return list;
        }

        /// <summary>
        /// 获取项目主流程进度
        /// </summary>
        /// <param name="businessId"></param>
        /// <returns></returns>
        public WorkFlow GetIngMainNode(int businessId)
        {
            var model = new WorkFlow();
            return model;
        }

        /// <summary>
        /// 批量获取主流程进度
        /// </summary>
        /// <param name="businessIdList">项目列表</param>
        /// <returns></returns>
        public List<WorkFlow> GetAllIngMainNode(List<int> businessIdList)
        {
            var list = new List<WorkFlow>();
            return list;
        }
    }
}
