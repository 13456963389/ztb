using Components.WorkFlowEngine.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZtbSoft.Models;

namespace Components.WorkFlowEngine
{
    public abstract class WfEngine
    {

        public virtual RetInfo Create(WorkFlow wf)
        {
            var context = new Assembler().Create<IContext>().Start(wf);
            return context.RetInfo;
        }
        
    }
}
