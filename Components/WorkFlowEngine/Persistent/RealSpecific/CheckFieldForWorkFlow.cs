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
