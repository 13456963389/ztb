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
        /// <summary>
        /// 同意
        /// </summary>
        [Description("同意")]
        AGREE = 1,

        /// <summary>
        /// 不同意
        /// </summary>
        [Description("不同意")]
        DISAGREE = 2,

        /// <summary>
        /// 放弃
        /// </summary>
        [Description("放弃")]
        GIVEUP = 3,

        /// <summary>
        /// 待办
        /// </summary>
        [Description("待办")]
        BEDONE = 4

    }

    /// <summary>
    /// 流程操作状态
    /// </summary>
    public enum WFActiveStatus
    {
        /// <summary>
        /// 未开始
        /// </summary>
        [Description("未开始")]
        UNSTART = 1,

        /// <summary>
        /// 初始化
        /// </summary>
        [Description("初始化")]
        INIT = 2,

        /// <summary>
        /// 已暂停
        /// </summary>
        [Description("已暂停")]
        PAUSE = 3,

        /// <summary>
        /// 进行中
        /// </summary>
        [Description("进行中")]
        DOING = 4,

        /// <summary>
        /// 已结束
        /// </summary>
        [Description("已结束")]
        CLOSED = 5,

        /// <summary>
        /// 已解冻
        /// </summary>
        [Description("已解冻")]
        Thaw = 6
    }

    /// <summary>
    /// 节点操作状态
    /// </summary>
    public enum NodeActionStatus
    {
        /// <summary>
        /// 未开始
        /// </summary>
        [Description("未开始")]
        UNSTART = 1,

        /// <summary>
        /// 初始化
        /// </summary>
        [Description("初始化")]
        INIT = 2,

        /// <summary>
        /// 完成
        /// </summary>
        [Description("完成")]
        OVER = 3,

        /// <summary>
        /// 停止
        /// </summary>
        [Description("停止")]
        STOP = 4,

        /// <summary>
        /// 冻结/暂停
        /// </summary>
        [Description("冻结/暂停")]
        PAUSE = 5,

        /// <summary>
        /// 进行中
        /// </summary>
        [Description("进行中")]
        DOING = 6,

        /// <summary>
        /// 关闭
        /// </summary>
        [Description("关闭")]
        COLSED = 7,

        /// <summary>
        /// 解冻
        /// </summary>
        [Description("解冻")]
        Thaw = 8
    }

    [Flags]
    public enum NodeTypeStatus
    {
        /// <summary>
        /// 开始节点
        /// </summary>
        [Description("开始节点")]
        START = 1,

        /// <summary>
        /// 结束节点
        /// </summary>
        [Description("结束节点")]
        END = 2,

        /// <summary>
        /// 交互节点
        /// </summary>
        [Description("交互节点")]
        ACTION = 3,

        /// <summary>
        /// 虚节点
        /// </summary>
        [Description("虚节点")]
        VIRTUAL = 4,

        /// <summary>
        /// 选签节点
        /// </summary>
        [Description("选签节点")]
        PICK = 5,

        /// <summary>
        /// 会签节点
        /// </summary>
        [Description("会签节点")]
        SIGN = 6,

        /// <summary>
        /// 流程名称节点
        /// </summary>
        [Description("流程名称节点")]
        NAMEDES = 7
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
