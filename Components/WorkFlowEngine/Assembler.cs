#region 
/////////////////////
//  author  :   zhouze
////////////////////
#endregion
using Components.WorkFlowEngine.AnyInstaCycle;
using Components.WorkFlowEngine.Model;
using Components.WorkFlowEngine.Persistent;
using Components.WorkFlowEngine.Persistent.RealSpecific;
using System;
using System.Collections.Generic;

namespace Components.WorkFlowEngine
{
    public class Assembler
    {
        static Dictionary<Type, Type> dictionary = new Dictionary<Type, Type>();

        static Assembler()
        {
            dictionary.Add(typeof(IContext), typeof(ConnectionContext));
            dictionary.Add(typeof(IState), typeof(ActionState));
            dictionary.Add(typeof(CheckField), typeof(CheckFieldForWorkFlow));
            dictionary.Add(typeof(RetInfo), typeof(RetInfoEntity));
        }

        public object Create(Type type)
        {
            if (type == null || !dictionary.ContainsKey(type))
                throw new NullReferenceException();
            return Activator.CreateInstance(dictionary[type]);
        }

        public T Create<T>()
        {
            return (T)Create(typeof(T));
        }
    }
}
