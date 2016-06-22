#region 
/////////////////////
//  author  :   zhouze
////////////////////
#endregion
using Components.WorkFlowEngine.Persistent;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZtbSoft.Models;

namespace Components.WorkFlowEngine.AnyInstaCycle
{
    internal class ActionState : IState
    {
        private AssemblStore aStore;

        public ActionState()
        {
            aStore = new AssemblStore();
        }

        public void End(IContext context)
        {
            try
            {

            }
            catch (Exception ex)
            {
                context.RetInfo.RetTrace = ex.Message + "\r\n" + ex.StackTrace;
                context.RetInfo.RetInt = -1;
            }
        }

        public void Next(IContext context)
        {
            try
            {
                aStore.Next(context.Wf, context.RetInfo);
            }
            catch (Exception ex)
            {
                context.RetInfo.RetTrace = ex.Message + "\r\n" + ex.StackTrace;
                context.RetInfo.RetInt = -1;
            }
        }

        public void Pause(IContext context)
        {
            try
            {

            }
            catch (Exception ex)
            {
                context.RetInfo.RetTrace = ex.Message + "\r\n" + ex.StackTrace;
                context.RetInfo.RetInt = -1;
            }
        }

        public void Prev(IContext context)
        {
            try
            {
                aStore.Prev(context.Wf, context.RetInfo);
            }
            catch (Exception ex)
            {
                context.RetInfo.RetTrace = ex.Message + "\r\n" + ex.StackTrace;
                context.RetInfo.RetInt = -1;
            }
        }
        
        public void Start(IContext context)
        {
            try
            {
                aStore.Start(context.Wf, context.RetInfo);
            }
            catch (Exception ex)
            {
                context.RetInfo.RetTrace = ex.Message + "\r\n" + ex.StackTrace;
                context.RetInfo.RetInt = -1;
            }
        }

        public void Stop(IContext context)
        {
            try
            {

            }
            catch (Exception ex)
            {
                context.RetInfo.RetTrace = ex.Message + "\r\n" + ex.StackTrace;
                context.RetInfo.RetInt = -1;
            }
        }

        public void Thaw(IContext context)
        {
            try
            {

            }
            catch (Exception ex)
            {
                context.RetInfo.RetTrace = ex.Message + "\r\n" + ex.StackTrace;
                context.RetInfo.RetInt = -1;
            }
        }
    }
}
