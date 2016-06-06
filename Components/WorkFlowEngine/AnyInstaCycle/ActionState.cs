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

namespace Components.WorkFlowEngine.AnyInstaCycle
{
    public class ActionState : IState
    {
        public void End(IContext context)
        {
            throw new NotImplementedException();
        }

        public void Next(IContext context)
        {
            throw new NotImplementedException();
        }

        public void Pause(IContext context)
        {
            throw new NotImplementedException();
        }

        public void Prev(IContext context)
        {
            throw new NotImplementedException();
        }

        public void Start(IContext context)
        {
            
        }

        public void Stop(IContext context)
        {
            throw new NotImplementedException();
        }

        public void Thaw(IContext context)
        {
            throw new NotImplementedException();
        }
    }
}
