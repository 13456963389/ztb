using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZtbSoft.Models;

namespace Components.WorkFlowEngine.Persistent.NodeStateOperate
{
    internal abstract class INodeStateOperate
    {
        private ReadStore rs;
        private PersistentStore ps;

        internal ReadStore Rs
        {
            get
            {
                return rs;
            }
            set
            {
                rs = value;
            }
        }

        internal PersistentStore Ps
        {
            get
            {
                return ps;
            }
            set
            {
                ps = value;
            }
        }

        public INodeStateOperate()
        {
            Rs = new ReadStore();
            Ps = new PersistentStore();
        }

        public abstract void MoveNext<T>(T wf, RetInfo retInfo);

        public abstract void MovePrev<T>(T wf, RetInfo retInfo);
    }
}
