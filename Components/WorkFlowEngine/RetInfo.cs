using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Components.WorkFlowEngine
{
    public abstract class RetInfo
    {

        public bool Success { get; set; }
        
        public string Msg { get; set; }

        public int ErrorCode { get; set; }

        public string RetTrace { get; set; }

        public int RetInt { get; set; }
    }
}
