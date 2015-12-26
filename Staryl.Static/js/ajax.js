/**  
        * ajax 提交  
        * @ajax {
            type: post|get,
            url: 请求地址 不可为空, 
            param:请求参数 JSON格式 可以为空,
            async: 是否异步 true|false 可以为空 默认为true异步,
            datatype: 数据类型 json|text 默认json,
            callback: 成功回调函数,
            error:错误回调函数
        }
        * @return  
        */
function jsonAjax(ajax) {
    if (!ajax.url) {
        alert("错误的请求地址！");
    }
    var defaultInfo = {
        type: ajax.method || 'POST',
        url: ajax.url || "",
        param: ajax.param || {},
        async: ajax.async || true,
        datatype: ajax.datatype || "JSON",
        callback: ajax.callback || function (result) { },
        error: ajax.error || function (err) {
            alert(err)
        }
    };

    $.ajax({
        type: defaultInfo.type,
        url: defaultInfo.url,
        async: false,
        data: defaultInfo.param,
        dataType: defaultInfo.datatype,
        success: defaultInfo.callback,
        error: defaultInfo.error
    });
}
