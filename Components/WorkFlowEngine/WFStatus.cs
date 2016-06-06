using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Components.WorkFlowEngine
{
    public enum WFOperateState
    {
        [Description("同意")]
        AGREE = 1,

        [Description("不同意")]
        DISAGREE = 2
    }

    public enum WFActiveStatus
    {
        [Description("未开始")]
        UNSTART = 1,

        [Description("初始化")]
        INIT = 2,

        [Description("已暂停")]
        PAUSE = 3,

        [Description("进行中")]
        DOING = 4,

        [Description("已结束")]
        CLOSED = 5,

        [Description("已解冻")]
        Thaw = 6
    }

    public enum NodeActionStatus
    {
        [Description("完成")]
        OVER = 1,

        [Description("停止")]
        STOP = 2,

        [Description("冻结/暂停")]
        PAUSE = 3,

        [Description("进行中")]
        DOING = 4,

        [Description("关闭")]
        COLSED = 5,

        [Description("解冻")]
        Thaw = 6
    }

    [Flags]
    public enum NodeTypeStatus
    {

        [Description("开始节点")]
        START = 1,

        [Description("结束节点")]
        END = 2,

        [Description("交互节点")]
        Action = 3,

        [Description("虚节点")]
        VIRTUAL = 4,

        [Description("选签节点")]
        PICK = 5,

        [Description("会签节点")]
        SIGN = 6
    }

    public class OperateThisEnum
    {
        public T GetEnum<T>(string flag)
            where T : struct
        {
            if (typeof(T).IsEnum)
                return (T)Enum.Parse(typeof(T), flag);
            else
                throw new InvalidCastException("T不是一个struct&Enum类型");
        }

    }
}
