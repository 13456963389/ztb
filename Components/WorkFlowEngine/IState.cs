#region 
/////////////////////
//  author  :   zhouze
////////////////////
#endregion
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZtbSoft.Models;

namespace Components.WorkFlowEngine
{
    public interface IState
    {
        void Start(IContext context);

        void Next(IContext context);

        void Prev(IContext context);

        void End(IContext context);

        void Stop(IContext context);

        void Pause(IContext context);

        void Thaw(IContext context);
    }
}
