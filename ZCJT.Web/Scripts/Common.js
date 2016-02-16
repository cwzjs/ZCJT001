//生成唯一的GUID
function GetGuid() {
    var s4 = function () {
        return (((1 + Math.random()) * 0x10000) | 0).toString(16).substring(1);
    };
    return s4() + s4() + s4() + "-" + s4();
}

//自动调整datagrid宽度
$(function () {
    $(window).resize(function () {
        $('#List').datagrid('resize', {
            width: $(window).width() - 10,
            height: $(window).height() - 35
        }).datagrid('resize', {
            width: $(window).width() - 10,
            height: $(window).height() - 35
        });
    });

});

function SetGridWidthSub(w) {
    return $(window).width() - w;
}
function SetGridHeightSub(h) {
    return $(window).height() - h
}


//键盘键Enter、Alt+R键控制查询和重置
function controlQueryAndResetByKey(q, r) {
    if (q != "" || r != "") {
        document.onkeydown = function (e) {
            var ev = e || window.event;
            if (undefined != ev.altKey) {
                if (ev.altKey == true && ev.keyCode == 81) {//Alt+Q-查询
                    if (q != "") {
                        document.getElementById(q).click();
                    }
                }
                else if (ev.altKey == true && ev.keyCode == 82) {//Alt+R-重置
                    if (r != "") {
                        document.getElementById(r).click();
                    }
                }
            }
        }
    }
}
