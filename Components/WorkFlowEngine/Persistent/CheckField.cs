using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZtbSoft.Models;

namespace Components.WorkFlowEngine.Persistent
{
    internal abstract class CheckField
    {
        internal abstract CheckField CheckBusinessId(WorkFlow wf);

        internal abstract CheckField CheckTemplateId(WorkFlow wf);

        internal abstract CheckField CheckNodeCode(WorkFlow wf);
    }
}
