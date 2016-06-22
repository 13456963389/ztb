using Components.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZtbSoft.Models;

namespace Components.WorkFlowEngine.Persistent.RealSpecific
{
    internal class CheckFieldForWorkFlow : CheckField
    {
        internal override CheckField CheckBusinessId(WorkFlow wf)
        {
            if (wf == null)
                throw new NullReferenceException(string.Format(WfErrorCode.Error_2000, "BusinessId"));
            if (wf.BusinessId == null)
                throw new Exception(string.Format(WfErrorCode.Error_2001, "BusinessId"));
            if (wf.BusinessId <= 0)
                throw new Exception(string.Format(WfErrorCode.Error_2003, "BusinessId"));
            return this;
        }

        internal override CheckField CheckEmployeeId(WorkFlow wf)
        {
            if (wf == null)
                throw new NullReferenceException(string.Format(WfErrorCode.Error_2000, "EmployeeId"));
            if (wf.BusinessId == null)
                throw new Exception(string.Format(WfErrorCode.Error_2001, "EmployeeId"));
            if (wf.BusinessId <= 0)
                throw new Exception(string.Format(WfErrorCode.Error_2003, "EmployeeId"));
            return this;
        }

        internal override CheckField CheckNodeCode(WorkFlow wf)
        {
            if (wf == null)
                throw new NullReferenceException(string.Format(WfErrorCode.Error_2000, "NodeCode"));
            if (wf.NodeCode == null)
                throw new Exception(string.Format(WfErrorCode.Error_2001, "NodeCode"));
            if (string.IsNullOrEmpty(wf.NodeCode))
                throw new Exception(string.Format(WfErrorCode.Error_2002, "NodeCode"));
            return this;
        }

        internal override CheckField CheckNodeId(WorkFlow wf)
        {
            if (wf == null)
                throw new NullReferenceException(string.Format(WfErrorCode.Error_2000, "NodeId"));
            if (wf.NodeId <= 0)
                throw new Exception(string.Format(WfErrorCode.Error_2003, "NodeId"));
            return this;
        }

        internal override CheckField CheckPCode(WorkFlow wf)
        {
            if (wf == null)
                throw new NullReferenceException(string.Format(WfErrorCode.Error_2000, "PCode"));
            if (wf.PCode == null)
                throw new Exception(string.Format(WfErrorCode.Error_2001, "PCode"));
            if (string.IsNullOrEmpty(wf.PCode))
                throw new Exception(string.Format(WfErrorCode.Error_2002, "PCode"));
            return this;
        }

        internal override CheckField CheckQjNodeCode(WorkFlow wf)
        {
            if (wf == null)
                throw new NullReferenceException(string.Format(WfErrorCode.Error_2000, "QjNodeCode"));
            if (wf.QjNodeCode == null)
                throw new Exception(string.Format(WfErrorCode.Error_2001, "QjNodeCode"));
            if (string.IsNullOrEmpty(wf.QjNodeCode))
                throw new Exception(string.Format(WfErrorCode.Error_2002, "QjNodeCode"));
            return this;
        }

        internal override CheckField CheckTemplateId(WorkFlow wf)
        {
            if (wf == null)
                throw new NullReferenceException(string.Format(WfErrorCode.Error_2000, "TemplateId"));
            if (wf.TemplateId <= 0)
                throw new Exception(string.Format(WfErrorCode.Error_2003, "TemplateId"));
            return this;
        }
    }
}
