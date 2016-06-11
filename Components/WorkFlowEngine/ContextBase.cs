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
using Components.WorkFlowEngine.Model;
using ZtbSoft.Models;

namespace Components.WorkFlowEngine
{
    public abstract class ContextBase : IContext
    {
        public RetInfo RetInfo { get; set; }

        public virtual IState State { get; set; }

        public virtual WorkFlow Wf { get; set; }

        /// <summary>
        /// 流程结束,自动结束所有流程，默认填入
        /// </summary>
        /// <returns></returns>
        public IContext End(WorkFlow wf) { Wf = wf; State.End(this); return this; }

        /// <summary>
        /// 下一步
        /// </summary>
        /// <returns></returns>
        public IContext Next(WorkFlow wf) { Wf = wf; State.Next(this); return this; }

        /// <summary>
        /// 流程暂停/冻结
        /// </summary>
        /// <returns></returns>
        public IContext Pause(WorkFlow wf) { Wf = wf; State.Pause(this); return this; }

        /// <summary>
        /// 上一步
        /// </summary>
        /// <returns></returns>
        public IContext Prev(WorkFlow wf) { Wf = wf; State.Prev(this); return this; }

        /// <summary>
        /// 流程开始
        /// </summary>
        /// <returns></returns>
        public IContext Start(WorkFlow wf) { Wf = wf; State.Start(this); return this; }

        /// <summary>
        /// 流程终止，结束所在流程，但剩余流程不再补齐
        /// </summary>
        /// <returns></returns>
        public IContext Stop(WorkFlow wf) { Wf = wf; State.Stop(this); return this; }

        /// <summary>
        /// 流程解冻
        /// </summary>
        /// <returns></returns>
        public IContext Thaw(WorkFlow wf) { Wf = wf; State.Thaw(this); return this; }
    }
}
