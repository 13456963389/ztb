using Components.WorkFlowEngine.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZtbSoft.Models;

namespace Components.WorkFlowEngine
{
    public abstract class WfEngine
    {

        /// <summary>
        /// 创建
        /// </summary>
        /// <param name="wf"></param>
        /// <returns></returns>
        public virtual RetInfo Create(WorkFlow wf)
        {
            return new Assembler().Create<IContext>().Start(wf).RetInfo;
        }

        /// <summary>
        /// 提交下一步
        /// </summary>
        /// <returns></returns>
        public virtual RetInfo GoNext(WorkFlow wf)
        {
            return new Assembler().Create<IContext>().Next(wf).RetInfo;
        }

        /// <summary>
        /// 退回上一步
        /// </summary>
        /// <returns></returns>
        public virtual RetInfo GoPrev(WorkFlow wf)
        {
            return new Assembler().Create<IContext>().Prev(wf).RetInfo;
        }

        
    }
}
