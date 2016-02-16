
/**
 * from表单序列化成JSON对象
 */
(function ($) {
    $.fn.serializeJSON = function () {
        var serializeObj = {};
        var array = this.serializeArray();
        debugger;
        //var str = this.serialize();
        $(array).each(function () {
            if (serializeObj[this.name]) {
                if ($.isArray(serializeObj[this.name])) {
                    serializeObj[this.name].push(this.value);
                } else {
                    serializeObj[this.name] = [serializeObj[this.name], this.value];
                }
            } else {
                serializeObj[this.name] = this.value;
            }
        });
        return serializeObj;
    }
})(jQuery);
