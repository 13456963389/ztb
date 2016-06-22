using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Components.WorkFlowEngine
{
    public abstract class RetInfo
    {
        /// <summary>
        /// 是否成功
        /// </summary>
        public bool Success { get; set; }
        
        /// <summary>
        /// 返回消息
        /// </summary>
        public string Msg { get; set; }

        /// <summary>
        /// 错误代码
        /// </summary>
        public int ErrorCode { get; set; }

        /// <summary>
        /// 异常堆栈
        /// </summary>
        public string RetTrace { get; set; }

        /// <summary>
        /// 返回编号 大于0 成功； 小于0 失败
        /// </summary>
        public int RetInt { get; set; }
    }
}
