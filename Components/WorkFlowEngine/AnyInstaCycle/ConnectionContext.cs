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
    internal class ConnectionContext : ContextBase
    {
        public ConnectionContext()
        {
            State = (new Assembler()).Create<IState>();
            RetInfo = (new Assembler()).Create<RetInfo>();
        }


    }
}
