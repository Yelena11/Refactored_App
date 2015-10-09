(function ($) {
    $.fn.spanToFindDropdownList = function (ddl) {
        var spanVal = this.text();
        var ddl = $(ddl.selector + " option");
        if (spanVal != "") {
            ddl.filter(function () {
                return $(this).text() == spanVal;
            }).attr('selected', 'selected');
        }
        else
            ddl.prop('selectedIndex', 0);
    }

    $.fn.dropdownTextToSpan = function (ddl) {
        var spanVal = this.text();
        var ddl = $(ddl.selector + " option:selected").text();
        if (ddl != 'Select') {
            this.text(ddl);
        }
    }

    $.fn.dropdownValueToSpan = function (ddl) {
        var spanVal = this.text();
        var ddl = $(ddl.selector + " option:selected").val();
        if (ddl != 'Select') {
            this.text(ddl);
        }
    }

}(jQuery));
