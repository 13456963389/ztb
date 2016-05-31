using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;

namespace ZtbSoft.Components
{

    public class clsEnmu
    {
        /// <summary>
        /// 得到枚举 值和描述
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public ArrayList GetEnumObj(Type type)
        {
            ArrayList list = new ArrayList();

            FieldInfo[] fields = type.GetFields();

            for (int i = 1; i < fields.Length; i++)
            {
                FieldInfo item = fields[i];
                int id = (int)Enum.Parse(type, item.Name);
                string name = string.Empty;
                object[] objs = item.GetCustomAttributes(typeof(DescriptionAttribute), false);
                if (objs == null || objs.Length == 0)
                {
                    name = item.Name;
                }
                else
                {
                    DescriptionAttribute da = (DescriptionAttribute)objs[0];
                    name = da.Description;
                }

                Hashtable hash = new Hashtable();
                hash.Add("Id", id);
                hash.Add("Name", name);
                list.Add(hash);
            }
            return list;
        }
    }

    /// <summary>
    /// 项目状态
    /// </summary>
    public enum enum_ProjectStata
    {
        /// <summary>
        /// 编制中
        /// </summary>
        [Description("编制中")]
        BZZ = 1,
        /// <summary>
        /// 进行中
        /// </summary>
        [Description("进行中")]
        JXZ = 1,
        /// <summary>
        /// 已完结
        /// </summary>
        [Description("已完结")]
        YWJ = 2,
        /// <summary>
        /// 已归档
        /// </summary>
        [Description("已归档")]
        YGD = 3,
    }

    /// <summary>
    /// 附件类型
    /// </summary>
    public enum enum_FileType
    {
        /// <summary>
        /// 代理合同
        /// </summary>
        [Description("代理合同")]
        DLHT = 1,
        /// <summary>
        /// 资格预审文件
        /// </summary>
        [Description("资格预审文件")]
        ZGYSWJ = 2,
        /// <summary>
        /// 招标文件
        /// </summary>
        [Description("招标文件")]
        ZBWJ = 3,
        /// <summary>
        /// 投标文件
        /// </summary>
        [Description("投标文件")]
        TBWJ = 4,
        /// <summary>
        /// 中标通知书
        /// </summary>
        [Description("中标通知书")]
        ZBTZS = 5,
        /// <summary>
        /// 中标合同
        /// </summary>
        [Description("中标合同")]
        ZBHT = 6,
        /// <summary>
        /// 备案文件
        /// </summary>
        [Description("备案文件")]
        BAWJ = 7,
    }

    /// <summary>
    /// 审核状态
    /// </summary>
    public enum enum_CheckType
    {
        /// <summary>
        /// 未提交
        /// </summary>
        [Description("未提交")]
        WeiTijiao = 0,
        /// <summary>
        /// 已提交
        /// </summary>
        [Description("已提交")]
        YiTijiao = 1,
        /// <summary>
        /// 退回
        /// </summary>
        [Description("退回")]
        Tuihui = 2,
        /// <summary>
        /// 审核通过
        /// </summary>
        [Description("审核通过")]
        TongGuo = 3
    }

    /// <summary>
    /// 模版类型
    /// </summary>
    public enum enum_TemplateType
    {
        /// <summary>
        /// 工作流模版
        /// </summary>
        [Description("工作流模版")]
        WorkFlowTemp = 1,
        /// <summary>
        /// 资格预审公告模版
        /// </summary>
        [Description("资格预审公告模版")]
        YsNoticeTemp = 2,
        /// <summary>
        /// 招标公告模版
        /// </summary>
        [Description("招标公告模版")]
        ZbNoticeTemp = 3,
        /// <summary>
        /// 预中标公示模版
        /// </summary>
        [Description("预中标公示模版")]
        YzbNoticeTemp = 4,
        /// <summary>
        /// 中标通知书模版
        /// </summary>
        [Description("中标通知书模版")]
        ZbBookTemp = 5
    }

    /// <summary>
    /// 企业类型
    /// </summary>
    public enum enum_UnitType
    {
        /// <summary>
        /// 代理结构
        /// </summary>
        [Description("代理结构")]
        DlUnit = 1,
        /// <summary>
        /// 投标单位
        /// </summary>
        [Description("投标单位")]
        TbUnit = 2,
        /// <summary>
        /// 招标人
        /// </summary>
        [Description("招标人")]
        ZbUnit = 3
    }

    /// <summary>
    /// 资格审查状态
    /// </summary>
    public enum enum_ResultStatu
    {
        /// <summary>
        /// 待确认
        /// </summary>
        [Description("待确认")]
        DaiQueRen = 0,
        /// <summary>
        /// 通过
        /// </summary>
        [Description("通过")]
        TongGuo = 1,
        /// <summary>
        /// 未通过
        /// </summary>
        [Description("未通过")]
        WeiTongGuo2,
    }

    /// <summary>
    /// 名次
    /// </summary>
    public enum enum_Ranking
    {
        /// <summary>
        /// 无名次
        /// </summary>
        [Description("无名次")]
        Zero = 0,
        /// <summary>
        /// 第一名
        /// </summary>
        [Description("第一名")]
        One = 1,
        /// <summary>
        /// 第二名
        /// </summary>
        [Description("第二名")]
        Two = 2,
        /// <summary>
        /// 第三名
        /// </summary>
        [Description("第三名")]
        Three = 3,
    }

    /// <summary>
    /// 公告类型
    /// </summary>
    public enum enum_NoticeType
    {
        /// <summary>
        /// 资格预审公告
        /// </summary>
        [Description("资格预审公告")]
        Zgysgg = 1,
        /// <summary>
        /// 招标公告
        /// </summary>
        [Description("招标公告")]
        Zbgg = 2,
        /// <summary>
        /// 预中标公示
        /// </summary>
        [Description("预中标公示")]
        Yzbgs = 3,
        /// <summary>
        /// 中标公示
        /// </summary>
        [Description("中标公示")]
        Zbgs = 4,
    }

    /// <summary>
    /// 公用状态枚举
    /// </summary>
    public enum enum_PubcliState
    {
        /// <summary>
        /// 有效
        /// </summary>
        [Description("有效")]
        effective = 1,
        /// <summary>
        /// 无效
        /// </summary>
        [Description("无效")]
        invalid = 0,
        /// <summary>
        /// 待审
        /// </summary>
        [Description("待审")]
        pending = 2
    }
    /// <summary>
    /// 是否
    /// </summary>
    public enum enum_IsYesNo
    {
        /// <summary>
        /// 否
        /// </summary>
        [Description("否")]
        No = 0,
        /// <summary>
        /// 是
        /// </summary>
        [Description("是")]
        yes = 1
    }

    /// <summary>
    /// 年卡类型状态
    /// </summary>
    public enum enum_CardTypeState
    {
        /// <summary>
        /// 无效
        /// </summary>
        [Description("无效")]
        wx = 0,
        /// <summary>
        /// 有效
        /// </summary>
        [Description("有效")]
        yx = 1
    }

    /// <summary>
    /// 年卡销售状态
    /// </summary>
    public enum enum_CardBusinessState
    {
        /// <summary>
        /// 初始化
        /// </summary>
        [Description("初始化")]
        csh = 0,
        /// <summary>
        /// 已提交
        /// </summary>
        [Description("已提交")]
        ytj = 1,
        /// <summary>
        /// 待支付
        /// </summary>
        [Description("待支付")]
        dzf = 2,
        /// <summary>
        /// 已完成
        /// </summary>
        [Description("已完成")]
        ywc = 3
    }

    /// <summary>
    /// 学历
    /// </summary>
    public enum enum_Education
    {
        /// <summary>
        /// 小学及以下
        /// </summary>
        [Description("小学及以下")]
        primary = 1,
        /// <summary>
        /// 初中
        /// </summary>
        [Description("初中")]
        middle = 2,
        /// <summary>
        /// 高中
        /// </summary>
        [Description("高中")]
        high = 3,
        /// <summary>
        /// 专科
        /// </summary>
        [Description("专科")]
        specialty = 4,
        /// <summary>
        /// 本科
        /// </summary>
        [Description("本科")]
        undergraduate = 5,
        /// <summary>
        /// 研究生
        /// </summary>
        [Description("研究生")]
        graduate = 6,
        /// <summary>
        /// 博士及以上
        /// </summary>
        [Description("博士及以上")]
        doctor = 7
    }

    /// <summary>
    /// 在职离职
    /// </summary>
    public enum enum_EmployeeState
    {
        /// <summary>
        /// 在职
        /// </summary>
        [Description("在职")]
        current = 1,
        /// <summary>
        /// 离职
        /// </summary>
        [Description("离职")]
        former = 2
    }
    /// <summary>
    /// 年龄段
    /// </summary>
    public enum enum_Age
    {
        /// <summary>
        /// 25岁以下
        /// </summary>
        [Description(" 25岁以下")]
        young = 1,
        /// <summary>
        /// 25岁-35岁
        /// </summary>
        [Description("25岁-35岁")]
        youth = 2,
        /// <summary>
        /// 35岁-45岁
        /// </summary>
        [Description(" 35岁-45岁")]
        middle = 3,
        /// <summary>
        /// 45岁以上
        /// </summary>
        [Description("45岁以上")]
        old = 4
    }

    public enum enum_CashSettleState
    {
        /// <summary>
        /// 成功
        /// </summary>
        [Description("修改成功")]
        SUCCESS = 1,
        /// <summary>
        /// 失败
        /// </summary>
        [Description("修改失败")]
        FAIL = 0,
        /// <summary>
        /// 未找到
        /// </summary>
        [Description("未找到数据")]
        UNSEL = -1
    }

    /// <summary>
    /// 入库单中是否付款
    /// </summary>
    public enum enum_StorageInState
    {
        /// <summary>
        /// 未付
        /// </summary>
        [Description("未付")]
        NoPay = 0,
        /// <summary>
        /// 已付
        /// </summary>
        [Description("已付")]
        IsPay = 1
    }

    /// <summary>
    /// 生成编号类型
    /// </summary>
    public enum enum_CodeType
    {
        /// <summary>
        /// 业务流水号
        /// </summary>
        YW,
        /// <summary>
        /// 支付流水号
        /// </summary>
        ZF,
        /// <summary>
        /// 采购订单编号
        /// </summary>
        DD,
        /// <summary>
        /// 出库单编号
        /// </summary>
        CK,
        /// <summary>
        /// 入库单编号
        /// </summary>
        RK,
        /// <summary>
        /// 返工单编号
        /// </summary>
        FG,
        /// <summary>
        /// 赔偿编号
        /// </summary>
        PC,
        /// <summary>
        /// 赔偿编号
        /// </summary>
        FD,
        /// <summary>
        /// 配件
        /// </summary>
        PJ,
        /// <summary>
        /// 物料
        /// </summary>
        WL,
        /// <summary>
        /// 服务
        /// </summary>
        FW

    }

    /// <summary>
    /// 性别
    /// </summary>
    public enum enum_Sex
    {
        /// <summary>
        ///男
        /// </summary>
        [Description("男")]
        boy = 0,
        /// <summary>
        /// 女
        /// </summary>
        [Description("女")]
        girl = 1

    }

    /// <summary>
    /// 权限Code
    /// </summary>
    public enum enum_PowerObjectCode
    {
        /// <summary>
        /// 地区代码表
        /// </summary>
        car_city,
        /// <summary>
        /// 区县代码表
        /// </summary>
        car_city_district,
        /// <summary>
        /// 省份代码表
        /// </summary>
        car_province,
        /// <summary>
        /// 员工信息
        /// </summary>
        Employee,
        /// <summary>
        /// 员工星级代码表
        /// </summary>
        EmployeeStar,
        /// <summary>
        /// 职别代码表
        /// </summary>
        JobLevel,
        /// <summary>
        /// 操作权限代码
        /// </summary>
        PowerDetail,
        /// <summary>
        /// 权限对象
        /// </summary>
        PowerObject,
        /// <summary>
        /// 角色信息
        /// </summary>
        Role,
        /// <summary>
        /// 角色权限
        /// </summary>
        RolePower,
        /// <summary>
        /// 报表
        /// </summary>
        report,
        /// <summary>
        /// 更新日志
        /// </summary>
        UpdateLog,
        UserInfo,
        UnitInfo,
        UnitBook,
        SysConfig,
        WorkFlowTemp,
        WorkFlow,
        Question,
        Qualification,
        ProjectInfo,
        Notice,
        FlowTemplate,
        FirstResult,
        ExpertInfo,
        ExpertExtract,
        Dict,
        CostManagement,
        SectionInfo,
        FileInfo,
        Zbwj,
        Zgyswj,
        Zbgg,
        Tbwj,
        CostManagementZGYS,
        CostManagementTBBZJ,
        CostManagementZBWJ,
        CostManagementZJ,
    }
}
