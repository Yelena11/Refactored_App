(function ($) {
    //validate date
    $.fn.isDate = function () {
        var currVal = this.val();
        if (currVal == '')
            return false;

        //Declare Regex  
        var rxDatePattern = /^(\d{1,2})(\/|-)(\d{1,2})(\/|-)(\d{4})$/;
        var dtArray = currVal.match(rxDatePattern);

        if (dtArray == null)
            return false;

        //Checks for mm/dd/yyyy format.
        dtMonth = dtArray[1];
        dtDay = dtArray[3];
        dtYear = dtArray[5];

        if (dtMonth < 1 || dtMonth > 12)
            return false;
        else if (dtDay < 1 || dtDay > 31)
            return false;
        else if ((dtMonth == 4 || dtMonth == 6 || dtMonth == 9 || dtMonth == 11) && dtDay == 31)
            return false;
        else if (dtMonth == 2) {
            var isleap = (dtYear % 4 == 0 && (dtYear % 100 != 0 || dtYear % 400 == 0));
            if (dtDay > 29 || (dtDay == 29 && !isleap))
                return false;
        }
        return true;
    }

    //maxlength for IE8 -  maxlength propery for the textarea
    $.fn.maxInputLength = function (ta, maxLength) {
        if (ta.val().length >= maxLength) {
            ta.val(ta.val().substring(0, maxLength));
        }
    }


    //message
    $.fn.greenify = function () {
        this.css("color", "green"); return this;
    };

    //trim left white space
    $.ltrim = function (str) {
        return str.replace(/^\s+/, "");
    };

    //trim right white space
    $.rtrim = function (str) {
        return str.replace(/\s+$/, "");
    };

//trim white space right and left
    $.fn.trimVal = function () {
        var str = this.val();
        str = str.replace(/\s+$/, "");
        str = str.replace(/^\s+/, "");
        this.val(str);
        return str;
    };



    //allow to enter only number 
    $.fn.number = function (event) {
        if (event.keyCode == 46 || event.keyCode == 8 || event.keyCode == 9
            || event.keyCode == 27 || event.keyCode == 13
            || (event.keyCode == 65 && event.ctrlKey === true)
            || (event.keyCode >= 35 && event.keyCode <= 39)) {
            return;
        } else {
            // If it's not a number stop the keypress
            if (event.shiftKey || (event.keyCode < 48 || event.keyCode > 57) && (event.keyCode < 96 || event.keyCode > 105)) {
                event.preventDefault();
            }
        }
    };

    //perform email validation
    $.fn.email = function () {
        var regex = /^([a-zA-Z0-9_\.\-\+])+\@(([a-zA-Z0-9\-])+\.)+([a-zA-Z0-9]{2,4})+$/;
        var demail = this.val();
        if (!regex.test(demail)) {
            return false;
        }
    };


}(jQuery));
