using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Components.WorkFlowEngine
{
    public interface IContext
    {
        IState State { get; set; }

        IContext Start();
        
        IContext End();

        IContext Next();

        IContext Prev();
        
        IContext Pause();

        IContext Thaw();

        IContext Stop();
    }
}
