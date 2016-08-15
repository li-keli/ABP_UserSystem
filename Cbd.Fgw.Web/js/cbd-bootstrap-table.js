;/**
  * bootstrap-table数据表格封装插件
  * 李科笠 - 2016年7月22日 10:25:23
  * 
  * 用法：
  * $('容器选择器').bTable({
        url: '路径',
        ... 其他配置
    },
    [
        {
            field: 'id',
            title: '编号'
        },
        ... 其他列数据
    ]);
 */
(function ($) {
    $.fn.bTable = function (opt, columns) {
        var that = $(this);
        //表格配置设置
        var def = {
            url: '',                                //请求后台的URL（*）
            method: 'get',                          //请求方式（*）
            striped: true,                          //是否显示行间隔色
            cache: false,                           //是否使用缓存，默认为true，所以一般情况下需要设置一下这个属性（*）
            pagination: true,                       //是否显示分页（*）
            sortable: false,                        //是否启用排序
            sortOrder: "asc",                       //排序方式
            queryParams: function (params) {        //传递参数（*）
                var temp = {
                    limit: params.limit,
                    offset: params.offset
                };
                return temp;
            },
            sidePagination: "server",               //分页方式：client客户端分页，server服务端分页（*）
            pageNumber: 1,                          //初始化加载第一页，默认第一页
            pageSize: 10,                           //每页的记录行数（*）
            pageList: [10, 25, 50, 100],            //可供选择的每页的行数（*）
            strictSearch: true,
            clickToSelect: true,                    //是否启用点击选中行
            uniqueId: "id",                         //每一行的唯一标识，一般为主键列
            cardView: false,                        //是否显示详细视图
            detailView: false,                      //是否显示父子表
            columns: []                             //列配置
        }
        opt = $.extend({}, def, opt);

        //格式化单元格内容
        var formatterColumn = function (obj) {
            var columndef = {
                field: 'id',
                title: '无',
                align: 'center',
                valign: 'middle',
                sortable: true,
                formatter: function (value, row, index) {
                    return value;
                }
            };
            return $.extend({}, columndef, obj);
        };

        var bTableColumns = [];
        for (var i = 0; i < columns.length; i++) {
            bTableColumns[i] = (formatterColumn(columns[i]));
        }
        opt.columns = bTableColumns;
        that.bootstrapTable(opt);

        return this;
    };
})(jQuery);