#region 
/////////////////////
//  author  :   zhouze
////////////////////
#endregion
using Components.WorkFlowEngine.AnyInstaCycle;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Components.WorkFlowEngine
{
    public class Assembler
    {
        static Dictionary<Type, Type> dictionary = new Dictionary<Type, Type>();

        static Assembler()
        {
            dictionary.Add(typeof(IContext), typeof(ConnectionContext));
            dictionary.Add(typeof(IState), typeof(ActionState));
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
