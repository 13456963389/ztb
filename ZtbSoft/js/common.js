function getQueryString(name) {
    var reg = new RegExp("(^|&)" + name + "=([^&]*)(&|$)", "i");
    var r = window.location.search.substr(1).match(reg);
    if (r != null) return unescape(r[2]); return null;
}
//asLabel 文本、只读表单
function labelModel(form) {
    var fields = form.getFields();
    for (var i = 0, l = fields.length; i < l; i++) {
        var c = fields[i];
        if (c.setReadOnly) c.setReadOnly(true);     //只读
        if (c.setIsValid) c.setIsValid(true);      //去除错误提示
        if (c.addCls) c.addCls("asLabel");          //增加asLabel外观
    }
}
function formfocus(form) {
    for (var i = 0; i < form.el.length; i++) {
        var el = form.el[i];
        if (el.type == "text") {
            $(el).focus();
            return;
        }
    }
}
//关闭
function CloseWindow(action) {
    //关闭浮动页面，调用原页面的ondestroy
    if (window.CloseOwnerWindow) return window.CloseOwnerWindow(action);
    else window.close();
}
$(document).ajaxComplete(function (evt, request, settings) {
    var text = request.responseText;
    var data = mini.decode(text);
    if (data.error == -1) {
        mini.alert(data.message, "出错");
        return;
    }
    if (data.error == -3) {
        mini.alert(data.message, "权限");
        return;
    }
    //if (data.error == 1) {
    //    mini.alert(data.message, "提醒");
    //}
    if (data.error == -2 && settings.url.indexOf("menu.ashx") > -1) {
        top.location = "/login.html";
        return;
    }
    if (data.error == -2) {
        mini.alert(data.message, "登录", function (e) {
            top.location = "/login.html";
            return;
        });
    }
})

function html_Encode(str) {
    var s = "";
    if (str.length == 0) return "";
    s = str.replace(/&/g, "&amp;");
    s = s.replace(/</g, "&lt;");
    s = s.replace(/>/g, "&gt;");
    s = s.replace(/ /g, "&nbsp;");
    s = s.replace(/\'/g, "&#39;");
    s = s.replace(/\"/g, "&quot;");
    //s = s.replace(/\n/g, "<br>");
    return s;
}


function html_Decode(str) {
    var s = "";
    if (str.length == 0) return "";
    s = str.replace(/&amp;/g, "&");
    s = s.replace(/&lt;/g, "<");
    s = s.replace(/&gt;/g, ">");
    s = s.replace(/&nbsp;/g, " ");
    s = s.replace(/&#39;/g, "\'");
    s = s.replace(/&quot;/g, "\"");
    //s = s.replace(/<br>/g, "\n");
    return s;
}

/**
 *  字符串去两端空
 *  例:  " abc ".trimSpace(); 
 *      return "abc";
 */
String.prototype.trimSpace = function () {
    var that = this;
    return that.replace(/(^\s*)|(\s*$)/g, "");
}
