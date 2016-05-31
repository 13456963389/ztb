// JavaScript Document
/*
开始做这个小demo的时候没想太多，只是想把功能实现就算了，
结果想了想，其实，有几个地方是可以再优化下的，不过，我懒得做了，
有空的可以自己去研究下

*/

function numtochinese(cont) {
    var num = parseFloat(cont, 10);
    cont = num + "";
    var before = null;
    var after = null;
    var result = "";
    var point = cont.indexOf(".");
    if (point == -1) {
        before = cont;
    } else {
        before = cont.substring(0, point);
        after = cont.substring(point + 1);
    }
    var temp = null;
    before = before.split("").reverse().join("");

    /*这里的代码可以删减的，不是从技术，而是思路*/
    for (var i = 1; i <= before.length; i++) {
        if (i == 1 || i == 5) {
            temp = i == 5 ? "万" : "元";
            result = result.concat(temp);
            temp = getChineseNum(before.charAt(i - 1));
            result = result.concat(temp == "零" ? "" : temp);
        } else {
            temp = before.charAt(i - 1);
            if (temp == "0") {
                result = result.concat("零");
                continue;
            } else {
                result = result.concat(getUnit(i).concat(getChineseNum(temp)));
            }
        }
    }
    result = result.split("").reverse().join("");

    var flag = true;
    while (flag) {
        if (result.indexOf("零零") != -1) {
            result = result.replace("零零", "零");
        } else {
            flag = false;
        }
    }

    if (result.indexOf("零万") != -1) {
        result = result.replace("零万", "万");
    }

    if (result.indexOf("零元") != -1) {
        result = result.replace("零元", "元");
    }

    if (after != null) {
        temp = getChineseNum(after.charAt(0));
        result = result.concat(temp == "零" ? "" : temp.concat("角"));
        temp = after.charAt(1);
        if (temp != null) {
            temp = getChineseNum(temp);
            result = result.concat(temp == "零" ? "" : temp.concat("分"));
        }
    }

    return result;
}


function getChineseNum(n) {
    switch (n) {
        case "1":
            return "壹";
            break;
        case "2":
            return "贰";
            break;
        case "3":
            return "叁";
            break;
        case "4":
            return "肆";
            break;
        case "5":
            return "伍";
            break;
        case "6":
            return "陆";
            break;
        case "7":
            return "柒";
            break;
        case "8":
            return "捌";
            break;
        case "9":
            return "玖";
            break;
        default:
            return "零";
            break;
    }
}

function getUnit(n) {
    switch (n) {
        case 1:
            return "元";
            break;
        case 2:
            return "拾";
            break;
        case 3:
            return "佰";
            break;
        case 4:
            return "仟";
            break;
        case 5:
            return "万";
            break;
        case 6:
            return "拾";
            break;
        case 7:
            return "佰";
            break;
        case 8:
            return "仟";
            break;
        default:
            return "亿";
            break;
    }
}


Date.prototype.toString= function(fmt)  
{
    var o = {
        "M+": this.getMonth() + 1,                 //月份   
        "d+": this.getDate(),                    //日   
        "h+": this.getHours(),                   //小时   
        "m+": this.getMinutes(),                 //分   
        "s+": this.getSeconds(),                 //秒   
        "q+": Math.floor((this.getMonth() + 3) / 3), //季度   
        "S": this.getMilliseconds()             //毫秒   
    };
    if (/(y+)/.test(fmt))
        fmt = fmt.replace(RegExp.$1, (this.getFullYear() + "").substr(4 - RegExp.$1.length));
    for (var k in o)
        if (new RegExp("(" + k + ")").test(fmt))
            fmt = fmt.replace(RegExp.$1, (RegExp.$1.length == 1) ? (o[k]) : (("00" + o[k]).substr(("" + o[k]).length)));
    return fmt;
};