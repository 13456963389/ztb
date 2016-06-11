using Components.WorkFlowEngine.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZtbSoft.Models;

namespace Components.WorkFlowEngine
{
    public interface IContext
    {
        IState State { get; set; }

        RetInfo RetInfo { get; set; }

        WorkFlow Wf { get; set; }

        IContext Start(WorkFlow wf);

        IContext End(WorkFlow wf);

        IContext Next(WorkFlow wf);

        IContext Prev(WorkFlow wf);

        IContext Pause(WorkFlow wf);

        IContext Thaw(WorkFlow wf);

        IContext Stop(WorkFlow wf);
    }
}
