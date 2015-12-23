//分页插件
/**
2014-08-05 ch
**/
(function ($) {
    var ms = {
        init: function (obj, args) {
            return (function () {
                ms.fillHtml(obj, args);
                ms.bindEvent(obj, args);
            })();
        },
        //填充html
        fillHtml: function (obj, args) {
            return (function () {
                var pagehtml = $("<ul></ul>");
                obj.empty();
                //上一页
                if (args.current > 1) {
                    pagehtml.append('<li><a href="javascript:;" class="prevPage">上一页</a></li>');
                } else {
                    pagehtml.remove('.prevPage');
                    pagehtml.append('<li><a class="disabled">上一页</a></li>');
                }
                //中间页码
                if (args.current != 1 && args.current >= 4 && args.pageCount != 4) {
                    pagehtml.append('<li><a href="javascript:;">' + 1 + '</a></li>');
                }
                if (args.current - 2 > 2 && args.current <= args.pageCount && args.pageCount > 5) {
                    pagehtml.append('<li><a>...</a></li>');
                }
                var start = args.current - 2, end = args.current + 2;
                if ((start > 1 && args.current < 4) || args.current == 1) {
                    end++;
                }
                if (args.current > args.pageCount - 4 && args.current >= args.pageCount) {
                    start--;
                }
                for (; start <= end; start++) {
                    if (start <= args.pageCount && start >= 1) {
                        if (start != args.current) {
                            pagehtml.append('<li><a href="javascript:;">' + start + '</a></li>');
                        } else {
                            pagehtml.append('<li class="active"><a href="javascript:;">' + start + '</a></li>');
                        }
                    }
                }
                if (args.current + 2 < args.pageCount - 1 && args.current >= 1 && args.pageCount > 5) {
                    pagehtml.append('<li><a>...</a></li>');
                }
                if (args.current != args.pageCount && args.current < args.pageCount - 2 && args.pageCount != 4) {
                    pagehtml.append('<li><a href="javascript:;">' + args.pageCount + '</a></li>');
                }
                //下一页
                if (args.current < args.pageCount) {
                    pagehtml.append('<li><a href="javascript:;" class="nextPage">下一页</a></li>');
                } else {
                    pagehtml.remove('.nextPage');
                    pagehtml.append('<li><a class="disabled">下一页</a></li>');
                }

               var _html='<table border="0">\
                        <tr>\
                            <td><ul class="pagination pagination-sm">' + pagehtml.html() + '</ul></td>\
                            <td>&nbsp;&nbsp;共' + args.pageCount + '页，到第&nbsp;</td>\
                            <td><input type="text" id="gotopageindex" class="goPageNum" />&nbsp;&nbsp;页&nbsp;&nbsp;<input type="button" class="goPage" value="确定" /></td>\
                    </tr>\
                    </table>';

               obj.append(pagehtml.html());

                //obj.append('<span class="pagetotal">共' + start + '页，到第<input id="gotopageindex" type="text" />页 <a  href="javascript:;" class="gotopage">确定</a></span>');

            })();
        },
        //绑定事件
        bindEvent: function (obj, args) {
            return (function () {
                $("a.tcdNumber", obj).unbind("click").bind("click", function () {
                    var current = parseInt($(this).text());
                    ms.fillHtml(obj, { "current": current, "pageCount": args.pageCount });
                    if (typeof (args.backFn) == "function") {
                        args.backFn(current);
                    }
                });
                //obj.on("click", "a.tcdNumber", function () {
                //});
                //上一页
                //obj.on("click", "a.prevPage", function () {
                $("a.prevPage", obj).unbind("click").bind("click", function () {
                    var current = parseInt($("span.current", obj).text());
                    ms.fillHtml(obj, { "current": current - 1, "pageCount": args.pageCount });
                    if (typeof (args.backFn) == "function") {
                        args.backFn(current - 1);
                    }
                });
                //下一页
                //obj.on("click", "a.nextPage", function () {
                $("a.nextPage", obj).unbind("click").bind("click", function () {
                    var current = parseInt($("span.current", obj).text());
                    ms.fillHtml(obj, { "current": current + 1, "pageCount": args.pageCount });
                    if (typeof (args.backFn) == "function") {
                        args.backFn(current + 1);
                    }
                });
                //跳转
                //obj.on("click", "input.goPage", function () {
                $("input.goPag", obj).unbind("click").bind("click", function () {
                    debugger;
                    var current = parseInt($("#gotopageindex", obj).val());
                    if(isNaN(current))
                        current = 1;
                    if (current > args.pageCount)
                        current = args.pageCount;
                    ms.fillHtml(obj, { "current": current, "pageCount": args.pageCount });
                    if (typeof (args.backFn) == "function") {
                        args.backFn(current);
                    }
                });

            })();
        }
    }
    $.fn.createPage = function (options) {
        var args = $.extend({
            pageCount: 10,
            current: 1,
            backFn: function () { }
        }, options);
        ms.init(this, args);
    }
})(jQuery);
