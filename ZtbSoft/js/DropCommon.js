//采购申请单状态
var PurchaseBillState = [];
function onPurchaseBillState(e) {
    if (e.value == 0)
        return '<span class="mini-button-text  mini-button-icon icon-ypz" title="已配置">&nbsp;&nbsp;&nbsp;已配置</span>';
    if (e.value == 1)
        return '<span class="mini-button-text  mini-button-icon icon-ytj" title="已提交">&nbsp;&nbsp;&nbsp;已提交</span>';
    if (e.value == 2)
        return '<span class="mini-button-text  mini-button-icon icon-yfh" title="已发货">&nbsp;&nbsp;&nbsp;已发货</span>';
    if (e.value == 3)
        return '<span class="mini-button-text  mini-button-icon icon-yijie" title="已入库">&nbsp;&nbsp;&nbsp;已入库</span>';
    return "";
}

function onProjectStata(e) {
    if (e.value == 0)
        return '<span class="mini-button-text  mini-button-icon icon-ypz" title="编制中">&nbsp;&nbsp;&nbsp;编制中</span>';
    if (e.value == 1)
        return '<span class="mini-button-text  mini-button-icon icon-ytj" title="进行中">&nbsp;&nbsp;&nbsp;进行中</span>';
    if (e.value == 2)
        return '<span class="mini-button-text  mini-button-icon icon-yijie" title="已完结">&nbsp;&nbsp;&nbsp;已完结</span>';
    if (e.value == 3)
        return '<span class="mini-button-text  mini-button-icon icon-wangong" title="已归档">&nbsp;&nbsp;&nbsp;已归档</span>';
    return "";
}

function onCardBusinessState(e) {
    if (e.value == 0)
        return '<span class="mini-button-text  mini-button-icon icon-ypz" title="初始化">&nbsp;&nbsp;&nbsp;初始化</span>';
    if (e.value == 1)
        return '<span class="mini-button-text  mini-button-icon icon-ytj" title="已提交">&nbsp;&nbsp;&nbsp;已提交</span>';
    if (e.value == 2)
        return '<span class="mini-button-text  mini-button-icon icon-yfh" title="待支付">&nbsp;&nbsp;&nbsp;待支付</span>';
    if (e.value == 3)
        return '<span class="mini-button-text  mini-button-icon icon-yijie" title="完成">&nbsp;&nbsp;&nbsp;完成</span>';
    return "";
}

function onStorageOutState(e) {
    if (e.value == 1)
        return '<span class="mini-button-text  mini-button-icon icon-ypz" title="待确认">&nbsp;&nbsp;&nbsp;待确认</span>';
    if (e.value == 2)
        return '<span class="mini-button-text  mini-button-icon icon-remove" title="已退回">&nbsp;&nbsp;&nbsp;已退回</span>';
    if (e.value == 3)
        return '<span class="mini-button-text  mini-button-icon icon-yijie" title="已完成">&nbsp;&nbsp;&nbsp;已完成</span>';
    return "";
}


function onCardState(e) {
    if (e.value == 0)
        return '<span class="mini-button-text  mini-button-icon icon-ypz" title="正常">&nbsp;&nbsp;&nbsp;正常</span>';
    if (e.value == 1)
        return '<span class="mini-button-text  mini-button-icon icon-ytj" title="在售">&nbsp;&nbsp;&nbsp;在售</span>';
    if (e.value == 2)
        return '<span class="mini-button-text  mini-button-icon icon-yijie" title="已售">&nbsp;&nbsp;&nbsp;已售</span>';
    if (e.value == 3)
        return '<span class="mini-button-text  mini-button-icon icon-no" title="损坏">&nbsp;&nbsp;&nbsp;损坏</span>';
    if (e.value == 4)
        return '<span class="mini-button-text  mini-button-icon icon-xiche" title="丢失">&nbsp;&nbsp;&nbsp;丢失</span>';
    return "";
}

function onBusinessBillState(e) {

    //for (var i = 0, l = BusinessBillState.length; i < l; i++) {
    //    var g = BusinessBillState[i];
    //    if (g.Id == e.value) return g.Name;
    //}
    if (e.value == 1)
        return '<span class="mini-button-text  mini-button-icon icon-zaixiu" title="在修">&nbsp;&nbsp;&nbsp;在修</span>';
    if (e.value == 2)
        return '<span class="mini-button-text  mini-button-icon icon-wangong" title="完工">&nbsp;&nbsp;&nbsp;完工</span>';
    if (e.value == 3)
        return '<span class="mini-button-text  mini-button-icon icon-yijie" title="已结">&nbsp;&nbsp;&nbsp;已结</span>';
    if (e.value == 4)
        return '<span class="mini-button-text  mini-button-icon icon-guazhang" title="挂账">&nbsp;&nbsp;&nbsp;挂账</span>';
    if (e.value == 5)
        return '<span class="mini-button-text  mini-button-icon icon-dxz" title="待选择">&nbsp;&nbsp;&nbsp;待选择</span>';
    if (e.value == 6)
        return '<span class="mini-button-text  mini-button-icon icon-dzf" title="待支付">&nbsp;&nbsp;&nbsp;待支付</span>';
    return "";
}
function GetBusinessBillState() {
    //$.ajax({
    //    url: "/ajax/drop/BusinessBillStateDrop.ashx?method=GetList",
    //    async: false,
    //    success: function (text) {
    //        BusinessBillState = eval(text);
    //    },
    //    error: function () {

    //    }
    //});
}
//工单状态

//是否
var IsYesNo = [];
//绑定数据
function onIsYesNo(e) {

    for (var i = 0, l = IsYesNo.length; i < l; i++) {
        var g = IsYesNo[i];
        if (g.Id == e.value) return g.Name;
    }
    return "";
}
function GetIsYesNo() {
    $.ajax({
        url: "/ajax/drop/IsYesNoDrop.ashx?method=GetList",
        async: false,
        success: function (text) {
            IsYesNo = eval(text);
        },
        error: function () {

        }
    });
}
//是否


//性别
var IsSex = [];
//绑定数据
function onIsSex(e) {

    for (var i = 0; i < IsSex.length; i++) {
        var g = IsSex[i];
        if (g.Id == e.value) return g.Name;
    }
    return "";
}
function GetIsSex() {
    $.ajax({
        url: "/ajax/drop/SexDrop.ashx?method=GetList",
        async: false,
        success: function (text) {
            IsSex = eval(text);
        },
        error: function () {

        }
    });
}
//性别


//年龄
var IsAge = []
function onIsAge(e) {

    for (var i = 0, l = IsAge.length; i < l; i++) {
        var g = IsAge[i];
        if (g.Id == e.value) return g.Name;
    }
    return "";
}
function GetIsAge() {
    $.ajax({
        url: "/ajax/drop/AgeDrop.ashx?method=GetList",
        async: false,
        success: function (text) {
            IsAge = eval(text);
        },
        error: function () {

        }
    });
}
///年龄

//施工组别
var IsWorkGroupCode = [];
function onIsWorkGroupCode(e) {

    for (var i = 0, l = IsWorkGroupCode.length; i < l; i++) {
        var g = IsWorkGroupCode[i];
        if (g.WorkGroupId == e.value) return g.WorkGroupName;
    }
    return "";
}
function GetIsWorkGroupCode() {
    $.ajax({
        url: "/ajax/drop/WorkGroupDrop.ashx?method=GetList",
        async: false,
        success: function (text) {
            IsWorkGroupCode = eval(text);
        },
        error: function () {

        }
    });
}
//施工组别



//罚单类型
//定义
var TicketType = [];
//绑定数据
function onTicketType(e) {

    for (var i = 0, l = TicketType.length; i < l; i++) {
        var g = TicketType[i];
        if (g.TicketTypeId == e.value) return g.TicketTypeName;
    }
    return "";
}
function GetTicketType() {
    $.ajax({
        url: "/ajax/drop/TicketTypeDrop.ashx?method=GetList",
        async: false,
        success: function (text) {
            TicketType = eval(text);
        },
        error: function () {

        }
    });

}


var State = [];
//状态
function onState(e) {

    for (var i = 0, l = State.length; i < l; i++) {
        var g = State[i];
        if (g.Id == e.value) return g.Name;
    }
    return "";
}
function GetState() {
    $.ajax({
        url: "/ajax/drop/StateDrop.ashx?method=GetList",
        async: false,
        success: function (text) {
            State = eval(text);
        },
        error: function () {

        }
    });
}

var EmployeeDrop = [];
//员工
function onEmployee(e) {

    for (var i = 0, l = EmployeeDrop.length; i < l; i++) {
        var g = EmployeeDrop[i];
        if (g.EmployeeId == e.value) return g.EmployeeName;
    }
    return "";
}
function GetEmployee() {
    $.ajax({
        url: "/ajax/drop/EmployeeDrop.ashx?method=GetList",
        async: false,
        success: function (text) {
            EmployeeDrop = eval(text);
        },
        error: function () {

        }
    });
}

var Point = [];
//员工
function onPoint(e) {

    for (var i = 0, l = Point.length; i < l; i++) {
        var g = Point[i];
        if (g.PointId == e.value) return g.B_name;
    }
    return "";
}
function GetPoint() {
    $.ajax({
        url: "/ajax/Special/drop/PointDrop.ashx?method=GetAllList",
        async: false,
        success: function (text) {
            Point = eval(text);
        },
        error: function () {

        }
    });
}
//大客户类型
var CustomerType = []
function onCustomerType(e) {
    for (var i = 0, l = CustomerType.length; i < l; i++) {
        var g = CustomerType[i];
        if (g.Id == e.value) return g.Name;
    }
    return "";
}
function GetCustomerType() {
    $.ajax({
        url: "/ajax/drop/CustomerTypeDrop.ashx?method=GetList",
        async: false,
        success: function (text) {
            CustomerType = eval(text);
        },
        error: function () {

        }
    });
}
