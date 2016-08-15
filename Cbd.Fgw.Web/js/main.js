/**
 * 给错误提示框添加内容
 * @param {} info 
 * @returns {} 
 */
function adderror(info) {
    var $info = $(info).text();
    if ($info == '') {
        return '';
    }
    return $info + " <br />";
}

(function ($) {
    $.sys = {
        create: function (opt) {
            parent.layer.open($.extend({}, {
                type: 2,
                title: '创建',
                area: ['600px', "500px"],
                content: "",
                success: function (layero, index) {
                    parent.layer.iframeAuto(index);
                },
                end: function () {
                }
            }, opt));
        },

        detail: function (opt) {
            parent.layer.open($.extend({}, {
                type: 2,
                title: '查看',
                area: ['600px', "500px"],
                content: "",
                success: function (layero, index) {
                    parent.layer.iframeAuto(index);
                },
                end: function () {
                }
            }, opt));
        },

        edit: function (opt) {
            parent.layer.open($.extend({}, {
                type: 2,
                title: '编辑',
                area: ['600px', "500px"],
                content: "",
                success: function (layero, index) {
                    parent.layer.iframeAuto(index);
                },
                end: function () {
                }
            }, opt));
        },

        del: function (title, postfunc) {
            parent.layer.confirm(title, {
                btn: ['删除', '取消']
            }, function (index) {
                postfunc();
                parent.layer.close(index);
            }, function () { });
        },

        otherWindow: function (opt) {
            parent.layer.open($.extend({}, {
                type: 2,
                title: '窗口',
                area: ['600px', "500px"],
                content: "",
                success: function (layero, index) {
                    parent.layer.iframeAuto(index);
                },
                end: function () {
                }
            }, opt));
        },

        showError: function (info) {
            parent.layer.alert(info, { icon: 2 });
        },

        alertClose: function (option) {
            var index = parent.layer.getFrameIndex(window.name);
            parent.layer.alert(option);
            parent.layer.close(index);
        }
    };
})(jQuery);

(function () {
    abp.event.on('abp.notifications.received', function (userNotification) {
        abp.notifications.showUiNotifyForUserNotification(userNotification);
    });
})();