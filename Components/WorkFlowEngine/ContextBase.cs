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

namespace Components.WorkFlowEngine
{
    public abstract class ContextBase : IContext
    {
        public virtual IState State { get; set; }
        /// <summary>
        /// 业务id
        /// </summary>
        public virtual int BusinessBillId { get; set; }
        /// <summary>
        /// 流程id
        /// </summary>
        public virtual int TemplateId { get; set; }
        /// <summary>
        /// 节点编号
        /// </summary>
        public virtual int NodeCode { get; set; }

        /// <summary>
        /// 流程结束
        /// </summary>
        /// <returns></returns>
        public IContext End() { State.End(this); return this; }

        /// <summary>
        /// 下一步
        /// </summary>
        /// <returns></returns>
        public IContext Next() { State.Next(this); return this; }

        /// <summary>
        /// 流程暂停/冻结
        /// </summary>
        /// <returns></returns>
        public IContext Pause() { State.Pause(this); return this; }

        /// <summary>
        /// 上一步
        /// </summary>
        /// <returns></returns>
        public IContext Prev() { State.Prev(this); return this; }

        /// <summary>
        /// 流程开始
        /// </summary>
        /// <returns></returns>
        public IContext Start() { State.Start(this); return this; }

        /// <summary>
        /// 流程终止
        /// </summary>
        /// <returns></returns>
        public IContext Stop() { State.Stop(this); return this; }

        /// <summary>
        /// 流程解冻
        /// </summary>
        /// <returns></returns>
        public IContext Thaw() { State.Thaw(this); return this; }
    }
}
