var WF = {};
$.each("address|article|aside|audio|canvas|command|datalist|details|dialog|figure|figcaption|footer|header|hgroup|keygen|mark|meter|menu|nav|progress|ruby|section|time".split("|"), function (idx, val) {
    document.createElement(val);
});
$("html").removeClass("no-js");
if ($("html").attr("class") == "") {
    $("html").removeAttr("class");
}
WF.Browser = {};
WF.Component = {};
WF.Strings = {
    "Components": {
        "BalloonHelp": {
            "beginningOfPopup": {
                "en": "Beginning of popup",
                "es": "Comienzo de ventana emergente"
            },
            "endOfPopup": {
                "en": "End of popup",
                "es": "Fin de ventana emergente"
            }
        },
        "FAQ": {
            "imgOpen": {
                "en": "Collapse",
                "es": "Contraer"
            },
            "imgClosed": {
                "en": "Expand",
                "es": "Mostrar"
            }
        },
        "LightboxOverlay": {
            "closeDialog": {
                "en": "Close Dialog",
                "es": "Cierre di&aacute;logo"
            },
            "errorEncountered": {
                "en": "Error Encountered",
                "es": "Se ha encontrado un error"
            },
            "oneMomentPlease": {
                "en": "One moment, please...",
                "es": "Espere un momento, por favor..."
            },
            "plsWaitGettingInfo": {
                "en": "Please wait. We're getting your information.",
                "es": "Por favor espere. Estamos buscando su informaci&oacute;n."
            },
            "infoCurrUnavail": {
                "en": "This information is currently unavailable.",
                "es": "En este momento esta informaci&oacute;n no est&aacute; disponible."
            },
            "apologizeTryAgain": {
                "en": "We apologize for this inconvenience. Please try again later.",
                "es": "Lamentamos el inconveniente ocasionado. Vuelva a intentarlo m&aacute;s tarde."
            }
        },
        "MultimediaTranscript": {
            "more": {
                "en": "More",
                "es": "M&aacute;s "
            },
            "less": {
                "en": "Less",
                "es": "Menos"
            }
        },
        "ShowHide": {
            "imgOpen": {
                "en": "Hide",
                "es": "Cierre"
            },
            "imgClosed": {
                "en": "Show",
                "es": "Mostrar"
            }
        },
        "ShowMore": {
            "noMoreArticles": {
                "en": "All Articles Displayed",
                "es": "Todos los art&iacute;culos"
            }
        },
        "SocialShare": {
            "Share": {
                "en": "Share",
                "es": "Comparta"
            },
            "Disclosure": {
                "en": '<span class="hide" tabindex="0">Begin popup</span><h2>Share this page</h2>' + '<ul><li><a href="#facebook" class="c52fb">Facebook</a></li><li><a href="#twitter" class="c52twitter">Twitter</a></li>' + '<li><a href="#email" class="c52email">Email</a></li></ul>' + "<p>Choose a link above.  We provide these links to external websites for your convenience. " + 'Wells Fargo does not endorse and is not responsible for their content, links, privacy policies, or security policies.</p><span class="hide">End popup</span>',
                "es": '<span class="hide" tabindex="0" lang="en">Begin popup</span><h2>Comparta esta p&aacute;gina</h2>' + '<ul><li><a href="#facebook" class="c52fb">Facebook</a></li><li><a href="#twitter" class="c52twitter">Twitter</a></li></ul>' + "<p>Seleccione uno de los enlaces electr&oacute;nicos arriba. Para su conveniencia, le proporcionamos estos enlaces electr&oacute;nicos a sitios de Internet externos." + "Wells Fargo no avala ni se hace responsable por el contenido, los enlaces electr&oacute;nicos, las pol&iacute;ticas de privacidad o las pol&iacute;ticas de seguridad de esos " + 'sitios de Internet.</p><span class="hide" lang="en">End popup</span>'
            },
            "EmailInsert": {
                "en": "Hi,\n\nI thought you'd be interested in this page I found on wellsfargo.com: \n\n",
                "es": "Pens&eacute; que podr&iacute;a interesarle esta p&aacute;gina que encontr&eacute; en wellsfargo.com/spanish:"
            }
        }
    },
    "Shared": {
        "beginItemNo": {
            "en": "Begin item #",
            "es": "Comienzo del &iacute;tem #"
        },
        "beginningOfPopup": {
            "en": "Beginning of popup",
            "es": "Comienzo de ventana emergente"
        },
        "cancel": {
            "en": "Cancel",
            "es": "Cancele"
        },
        "close": {
            "en": "Close",
            "es": "Cierre"
        },
        "continue": {
            "en": "Continue",
            "es": "Contin&uacute;e"
        },
        "endItemNo": {
            "en": "End item #",
            "es": "Fin del &iacute;tem #"
        },
        "endOfPopup": {
            "en": "End of popup",
            "es": "Fin de ventana emergente"
        },
        "item": {
            "en": "item",
            "es": "&iacute;tem"
        },
        "next": {
            "en": "Next",
            "es": "Siguiente"
        },
        "popupBlocker": {
            "en": "You may have a popup blocker preventing this window from opening.",
            "es": "Un bloqueador de ventana emergente puede estar evitando que se abra esta ventana."
        },
        "prev": {
            "en": "Previous",
            "es": "Anterior"
        },
        "print": {
            "en": "Print",
            "es": "Imprima"
        },
        "WFHomePage": {
            "en": "Wells Fargo home page",
            "es": "P&aacute;gina principal de Wells Fargo"
        }
    }
};
(function ($) {
    $.fn.touchwipe = function (settings) {
        var config = {
            min_move_x: 20,
            min_move_y: 20,
            wipeLeft: function (e) { },
            wipeRight: function (e) { },
            wipeUp: function (e) { },
            wipeDown: function (e) { },
            preventDefaultEvents: false
        };
        if (settings) {
            $.extend(config, settings);
        }
        this.each(function () {
            var startX;
            var startY;
            var isMoving = false;

            function cancelTouch() {
                this.removeEventListener("touchmove", onTouchMove);
                startX = null;
                isMoving = false;
            }
            function onTouchMove(e) {
                if (config.preventDefaultEvents) {
                    e.preventDefault();
                }
                if (isMoving) {
                    var x = e.touches[0].pageX;
                    var y = e.touches[0].pageY;
                    var dx = startX - x;
                    var dy = startY - y;
                    if (Math.abs(dx) >= config.min_move_x) {
                        cancelTouch();
                        if (dx > 0) {
                            config.wipeLeft(e);
                        } else {
                            config.wipeRight(e);
                        }
                    } else {
                        if (Math.abs(dy) >= config.min_move_y) {
                            cancelTouch();
                            if (dy > 0) {
                                config.wipeUp(e);
                            } else {
                                config.wipeDown(e);
                            }
                        }
                    }
                }
            }
            function onTouchStart(e) {
                if (e.touches.length == 1) {
                    startX = e.touches[0].pageX;
                    startY = e.touches[0].pageY;
                    isMoving = true;
                    this.addEventListener("touchmove", onTouchMove, false);
                }
            }
            if ("ontouchstart" in document.documentElement) {
                this.addEventListener("touchstart", onTouchStart, false);
            }
        });
        return this;
    };
})(jQuery);
WF.Utils = {
    ajaxLog: function (err) {
        var url = "/as/common/jslog";
        if (location.href.search("isg-neo") != -1) {
            url = "jslog.php";
        }
        var query = {
            "errorString": err.message,
            "pageUrl": window.location.href
        };
        if (err.fileName) {
            query.jsFileUrl = err.fileName;
        } else {
            if (err.sourceURL) {
                query.jsFileUrl = err.sourceURL;
            }
        }
        if (err.stack) {
            var stack = WF.Utils.parseErrorStack(err.stack);
            if (stack[0]) {
                if (stack[0].name) {
                    query.errorFunctionName = stack[0].name;
                }
                if (stack[0].line) {
                    query.errorLineNumber = stack[0].line;
                }
                if (!query.jsFileUrl) {
                    query.jsFileUrl = stack[0].url;
                }
                if (stack[0].args) {
                    query.additionalInfo = "arguments: " + stack[0].args;
                }
            }
            if (stack[1] && stack[1].name) {
                query.callingFunctionName = stack[1].name;
            }
        } else {
            query.errorFunctionName = WF.Utils.getNameFromCallee(arguments.callee.caller);
            query.callingFunctionName = WF.Utils.getNameFromCallee(arguments.callee.caller.caller);
        }
        if (err.line) {
            query.errorLineNumber = err.line;
        }
        $.get(url, query);
    },
    generateUniqueId: function (elem) {
        var id = "";
        while (elem.tagName != "BODY") {
            id = ($(elem).prevAll().length + 1) + "_" + id;
            if (!elem.parentNode) {
                var arr = "0123456789abcdef".split("");
                for (var i = 0; i < 16; i++) {
                    id += arr[Math.floor(Math.random() * arr.length)];
                }
                break;
            }
            elem = elem.parentNode;
        }
        return "NID" + id.substr(0, id.length - 1);
    },
    getBrowserSupport: function () {
        ret = {};
        var input = $('<input id="WFtemp" />').get(0);
        ret.placeholder = ("placeholder" in input);
        $("#WFtemp").remove();
        ret.tel = false;
        var userAgent = navigator.userAgent;
        var mobileStrings = ["iPhone", "Android", "BlackBerry", "Mobile"];
        $.each(mobileStrings, function (idx, val) {
            if (new RegExp(val, "i").test(userAgent)) {
                ret.tel = true;
                return true;
            }
        });
        ret.touch = !!("ontouchstart" in window);
        ret.IE7mode = false;
        if ($("html").hasClass("ie7")) {
            ret.IE7mode = true;
        }
        if (document.documentMode != undefined && document.documentMode < 8) {
            ret.IE7mode = true;
        }
        ret.isIE = (userAgent.indexOf("MSIE") != -1);
        return ret;
    },
    getClist: function (elem) {
        if (elem.tagName.toUpperCase() == "BODY") {
            return "";
        }
        var clist = $(elem).data("cid") + "~" + $(elem).data("ctid");
        if (clist.search("undef") != -1) {
            return WF.Utils.getClist(elem.parentNode);
        }
        return clist;
    },
    getDimensions: function (elem) {
        return {
            "width": $(elem).width(),
            "height": $(elem).height()
        };
    },
    getNameFromCallee: function (callee) {
        var hope = callee.toString().match(/^function (\w*)\(/);
        if (hope && hope[1]) {
            return hope[1];
        }
        if (callee.toString().search(/^function ?\(/) != -1) {
            return "[anonymous function]";
        }
        return false;
    },
    getViewportSize: function () {
        return {
            "width": $(window).width(),
            "height": $(window).height()
        };
    },
    parseErrorStack: function (stack, errName) {
        var isChrome = (stack.search(/\n +at/) != -1);
        stack = stack.replace(/(\d+):\d+\)\n/g, "$1\n");
        var lines = stack.split(/\n(?: +at )?/);
        if (isChrome) {
            lines.shift();
        }
        var ret = [];
        for (var i = 0; i < lines.length; i++) {
            var item = {};
            if (isChrome) {
                var funcname = lines[i].split(/ /).shift();
            } else {
                var funcname = lines[i].split(/\@/).shift();
            }
            var match = funcname.match(/\((.*)\)$/);
            if (match) {
                item.args = match[1];
                funcname = funcname.substr(0, funcname.indexOf("("));
            }
            item.name = funcname;
            item.line = lines[i].split(/:/).pop();
            lines[i] = lines[i].replace(/:\d+$/, "");
            item.url = lines[i].split(/[\(@]/).pop();
            ret.push(item);
        }
        return ret;
    },
    removeHtmlTags: function (content) {
        if (content.indexOf("<") != -1) {
            content = content.slice(0, content.indexOf("<")) + content.slice(content.indexOf(">") + 1);
            content = arguments.callee(content);
        }
        return content;
    },
    serialize: function (obj) {
        switch (typeof obj) {
            case "string":
            case "number":
                return obj;
                break;
            case "boolean":
                return new Boolean(obj).toString();
                break;
            case "function":
                return "function";
                break;
            case "undefined":
                return "undefined";
                break;
            default:
                if (obj == null) {
                    return "null";
                }
                var ret = [];
                for (var key in obj) {
                    var val;
                    if (obj.hasOwnProperty(key)) {
                        val = encodeURIComponent(obj[key]);
                        ret.push(key + "=" + val);
                    }
                }
                return ret.join("&");
        }
    },
    stripTcm: function (str) {
        return str.replace(/(^|\~)tcm:/g, "$1");
    },
    trackVS: function (options, callback) {
        var stdOptions = {
            "log": 1,
            "pid": $("#shell").data("pid"),
            "pageUrl": window.location.href,
            "cb": new Date().valueOf()
        };
        var asyncMode = true;
        var trackInfo = stdOptions;
        $.extend(trackInfo, options);
        $.each(trackInfo, function (idx, val) {
            if (typeof val == "string") {
                trackInfo[idx] = WF.Utils.stripTcm(val);
            }
        });
        if (trackInfo.suppressAsync) {
            asyncMode = false;
        }
        delete trackInfo.suppressAsync;
        $.ajax({
            url: "/assets/images/global/s.gif",
            type: "GET",
            async: asyncMode,
            data: trackInfo,
            success: function () {
                if (callback != null) {
                    callback();
                }
            }
        });
    },
    ucfirst: function (str) {
        var first = str.substr(0, 1);
        var rest = str.substr(1);
        return first.toUpperCase() + rest.toLowerCase();
    },
    untaintAndParse: function (str) {
        if (str.substr(0, 100).search(/for *\(;;/) == -1) {
            WF.Utils.ajaxLog({
                "message": "Expected JSON result but got: " + str.substr(0, 100) + "..."
            });
            return str;
        }
        try {
            str = str.replace(/^\s*for *\(;;\) *;?\s*/, "");
            str = str.replace(/^\s*\/\*\s*\w+%\s+\{/, "{").replace(/\}\s+%\w+\s*\*\/\s*$/, "}");
            return jQuery.parseJSON(str);
        } catch (err) {
            WF.Utils.ajaxLog(err);
        }
    }
};
WF.OnLoads = {
   
    doAll: function (root) {
       
        if (typeof root == "undefined") {
            root = $("body");
        }
        $.each(WF.OnLoads, function (name, code) {
            if (name != "doAll" && typeof WF.OnLoads[name] == "function") {
                try {
                    WF.OnLoads[name](root);
                } catch (e) {
                    WF.Utils.ajaxLog(e);
                }
            }
        });
    },
    apply3rdPartyLinkTracking: function (root) {
        if (typeof root == "undefined") {
            root = $("body");
        }
        $(root).find("a[href^='http']").each(function () {
            if (this.href.search(/^https?:\/\/(www\.)?wellsfargo\.com\//) == -1) {
                var clist = WF.Utils.getClist(this);
                $(this).bind("click keypress", function (evt) {
                    if (evt.type == "keypress" && evt.keyCode != 13) {
                        return;
                    }
                    WF.Utils.trackVS({
                        "suppressAsync": true,
                        "event": "LinkActivated",
                        "eventType": evt.type,
                        "eventDescription": "outsideDomain",
                        "destinationUrl": this.href,
                        "linkText": $(this).text(),
                        "clist": clist
                    });
                    if (evt.type == "keypress") {
                        window.location.href = this.href;
                        evt.preventDefault();
                    }
                });
            }
        });
    },
    applyTelephoneStyling: function (root) {
        if (typeof root == "undefined") {
            root = $("body");
        }
        if (WF.Browser.supports.tel) {
            $(root).find(".c12").each(function () {
                var url = this.innerHTML.replace(/\D/g, "");
                if (url.length == 10) {
                    url = "1" + url;
                }
                this.innerHTML = '<a href="tel:+' + url + '">' + this.innerHTML + "</a>";
            });
        } else {
            $(root).find(".c12").each(function () {
                this.innerHTML = "<strong>" + this.innerHTML + "</strong>";
            });
        }
    },
    numberFootnotes: function (root) {
        if (typeof root == "undefined") {
            root = $("body");
        }
        $(root).find('.c20body[data-numbered="true"]').each(function () {
            var cid = $(this).data("cid");
            if (WF.Page.Components.Footnotes[cid]) {
                if ($(this).find(".c20no").size() === 0) {
                    $(this).prepend('<span class="c20no">' + WF.Page.Components.Footnotes[cid] + ".</span>");
                    $(this).attr("data-no", WF.Page.Components.Footnotes[cid]);
                }
            } else {
                WF.Page.Components.Footnotes.last++;
                WF.Page.Components.Footnotes[cid] = WF.Page.Components.Footnotes.last;
                if ($(this).find(".c20no").size() === 0) {
                    $(this).prepend('<span class="c20no">' + WF.Page.Components.Footnotes.last + ".</span>");
                    $(this).attr("data-no", WF.Page.Components.Footnotes.last);
                }
            }
        });
        $(root).find("sup.c20ref").each(function (key) {
            var footnote = $('.c20body[data-cid="' + $(this).attr("data-footnote") + '"]');
            if (footnote[0]) {
                $(this).html(footnote.attr("data-no"));
            }
        });
    },
    placeholderPolyfill: function (root) {
        if (typeof root == "undefined") {
            root = $("body");
        }
        if (!WF.Browser.supports.placeholder) {
            $(root).find("input[placeholder]").each(function () {
                if (!this.value) {
                    this.value = $(this).attr("placeholder");
                }
                $(this).focus(function () {
                    if (this.value == $(this).attr("placeholder")) {
                        this.value = "";
                    }
                }).blur(function () {
                    if (this.value.length < 1) {
                        this.value = $(this).attr("placeholder");
                    }
                });
            });
        }
    },
    preventFraming: function () {
        if (self != top) {
            if (top.location.hostname.search(/wellsfargo.com$/) != -1 && top.location.pathname.search(/\bDashboard\b/) != -1 && top.location.pathname.search(/\bCME\b/) != -1) {
                return true;
            }
            if (location.replace) {
                top.location.replace(window.location.href);
            } else {
                top.location = window.location.href;
            }
        }
    },
    setupPdfLink: function (e) {
        $('a[data-pdf="true"]').bind("click", function () {
            $(this).attr("data-win-options", "large");
            WF.Utils.childWindow(this);
            e.preventDefault();
        });
    },
    setupOtherServicesButton: function () {
        $("#btnOtherSvcs").click(function (evt) {
            evt.preventDefault();
            var url = $("#other_service").val();
            if (url) {
                location.href = url;
            }
        });
    },
    fixIECursorOnFatNav: function () {
        if ($("html").hasClass("lt-ie9")) {
            $("ul#fatnav").on("fatnavopen", function () {
                var focusedField;
                if ($("#userid").is(":focus")) {
                    focusedField = $("#userid");
                    focusedField.blur();
                    $(this).data("focusedField", focusedField);
                }
                if ($("#password").is(":focus")) {
                    focusedField = $("#password");
                    focusedField.blur();
                    $(this).data("focusedField", focusedField);
                }
            }).on("fatnavclose", function () {
                var focusedField = $(this).data("focusedField");
                if (focusedField) {
                    focusedField.focus();
                    $(this).data("focusedField", null);
                }
            });
        }
    },
    hideAccountsDropdownOnFatNav: function () {
        $("ul#fatnav").on("fatnavopen", function () {
            var focusedField;
            if ($("#destination").is(":focus")) {
                focusedField = $("#destination");
                focusedField.blur();
                $(this).data("focusedField", focusedField);
            }
        }).on("fatnavclose", function () {
            var focusedField = $(this).data("focusedField");
            if (focusedField) {
                focusedField.focus();
                $(this).data("focusedField", null);
            }
        });
    },
    preventMultipleSignOnFormSubmit: function () {
        $("#frmSignon").on("submit", function () {
            var _this = $(this);
            if (typeof _this.data("disabledOnSubmit") === "undefined") {
                _this.find("input[type=submit]").attr("disabled", true);
                _this.data("disabledOnSubmit", {
                    submitted: true
                });
                return true;
            } else {
                return false;
            }
        });
    },
    setupIPV6Measurement: function () {
        var rand = Math.random();
        var ipv6TestImgSpan = $("<span style='display:none;' />");
        var ipv6TestImg1 = $('<img id="1x1_ipv6test_1" src="https://images-r4.wellsfargomedia.com/s.gif?' + rand + '" class="ipv6TestImg" width="1" height="1" />');
        var ipv6TestImg2 = $('<img id="1x1_ipv6test_2" src="https://images-r6.wellsfargomedia.com/s.gif?' + rand + '" class="ipv6TestImg" width="1" height="1" />');
        var ipv6TestImg3 = $('<img id="1x1_ipv6test_3" src="https://images-ds.wellsfargomedia.com/s.gif?' + rand + '" class="ipv6TestImg" width="1" height="1" />');
        ipv6TestImgSpan.append(ipv6TestImg1).append(ipv6TestImg2).append(ipv6TestImg3).appendTo("body");
    }
};
function reloadRibbon() {
    
    WF = {};
}
$(document).ready(function () {

    WF.Browser.supports = WF.Utils.getBrowserSupport();
    WF.OnLoads.doAll();
});
WF.Page = {
    "lang": $("html").attr("lang") || "en",
    "Components": {
        getByType: function (type) {
            switch (type) {
                case "c29":
                case "BalloonHelp":
                    return this.BalloonHelps;
                    break;
                case "CTA":
                    return this.CTAs;
                    break;
                case "c58":
                case "FAQ":
                    return this.FAQs;
                    break;
                case "c28a":
                case "LightBox":
                    return this.LightBoxes;
                    break;
                case "c28b":
                case "Overlay":
                    return this.Overlays;
                    break;
                case "c16":
                case "ShowHide":
                    return this.ShowHides;
                    break;
                case "c26":
                case "Tip":
                    return this.Tips;
                    break;
                default:
                    return [];
            }
        },
        "BalloonHelps": [],
        "Carousels": [],
        "CTAs": [],
        "FAQs": [],
        "FatNav": false,
        "Footnotes": {
            "last": 0
        },
        "LightBoxes": [],
        "Overlays": [],
        "RibbonCarousels": [],
        "ShowHides": [],
        "Tips": []
    }
};
WF.Component.Carousel = function (el, options) {
    if (!el.id) {
        el.id = WF.Utils.generateUniqueId(el);
    }
    var self = this;
    var stdOptions = {
        "autostart": false,
        "autoloop": false,
        "frameRate": 8000,
        "loop": true,
        "paddles": "dynamic",
        "speed": 500,
        "componentType": "Carousel"
    };
    if (!options) {
        options = {};
    }
    for (var o in stdOptions) {
        if (typeof options[o] == "undefined") {
            options[o] = stdOptions[o];
        }
    }
    if (options.paddles == "dynamic") {
        if (WF.Browser.supports && WF.Browser.supports.touch) {
            options.paddles = "off";
        }
        if ($("html").hasClass("ie7")) {
            options.paddles = "on";
        }
    }
    options.width = $(el).width();
    options.padding = $(el).css("padding-left");
    var timer, curFrame, incomingFrame;
    this.elem = el;
    this.id = "Carousel_" + el.id;
    this.start = function () {
        timer = setInterval(function () {
            self.next(false, {
                "event": "LinkActivated",
                "eventType": "autoload",
                "eventDescription": evtDesc
            });
        }, options.frameRate);
    };
    this.stop = function () {
        clearInterval(timer);
    };
    this.pause = function () {
        this.stop();
    };
    this.next = function (human, track) {
        if (human) {
            clearInterval(timer);
        }
        var showing = curFrame;
        var opts = {
            dir: "right"
        };
        if (showing >= bodies.length) {
            if (!options.loop) {
                return;
            }
            showing = 1;
        } else {
            showing++;
        }
        if (track) {
            if (options.componentType == "Tip") {
                track.clist = WF.Utils.getClist(el);
                track.tipNumber = showing;
            } else {
                track.clist = WF.Utils.getClist(bodies[showing - 1]);
            }
            WF.Utils.trackVS(track);
        }
        this.showFrame(showing, opts);
        if (showing == 1 && !options.autoloop && !human) {
            clearInterval(timer);
        }
    };
    this.prev = function (human, track) {
        if (human) {
            clearInterval(timer);
        }
        var showing = curFrame;
        var opts = {
            dir: "left"
        };
        if (showing <= 1) {
            if (!options.loop) {
                return;
            }
            showing = bodies.length;
        } else {
            showing--;
        }
        if (track) {
            if (options.componentType == "Tip") {
                track.clist = WF.Utils.getClist(el);
                track.tipNumber = showing;
            } else {
                track.clist = WF.Utils.getClist(bodies[showing - 1]);
            }
            WF.Utils.trackVS(track);
        }
        this.showFrame(showing, opts);
    };
    this.copyFrame = function (from, to) {
        to.html(from.html());
        $.each(["cid", "ctid", "presentation"], function (i, val) {
            to.data(val, from.data(val));
        });
    };
    this.showFrame = function (num, opts) {
        if (num == curFrame) {
            return;
        }
        var incFrame = $(el).find(".carouselFrame.item" + num);
        self.copyFrame(incFrame, incomingFrame);
        var animOpts = {
            queue: false,
            left: 0
        };
        var plusWidth = options.width + "px";
        var minusWidth = "-" + options.width + "px";
        if (opts.dir == "left") {
            incomingFrame.css("left", minusWidth);
        } else {
            if (opts.dir == "right") {
                incomingFrame.css("left", plusWidth);
            } else {
                if (num > curFrame) {
                    incomingFrame.css("left", plusWidth);
                } else {
                    incomingFrame.css("left", minusWidth);
                }
            }
        }
        incomingFrame.show();
        $(el).find(".controls a").removeClass("current").removeAttr("tabindex");
        incomingFrame.animate(animOpts, options.speed, "swing", function () {
            incomingFrame.hide();
            $(el).find(".carouselFrame:visible").attr("aria-hidden", "true").hide();
            incFrame.attr("aria-hidden", "false").show();
            $(el).find(".controls a.show" + num).addClass("current").attr("tabindex", -1);
        });
        if (opts.stopAutoplay) {
            self.stop();
        }
        curFrame = num;
    };
    this.count = function () {
        return bodies.length;
    };
    var evtDesc;
    switch (options.componentType) {
        case "Marquee":
        case "MarqueeCarousel":
            evtDesc = "DisplayMarqueeCarouselItem";
            break;
        case "Small":
        case "SmallCarousel":
            evtDesc = "DisplaySmallCarouselItem";
            break;
        case "Tip":
        default:
            evtDesc = "DisplayTip";
    }
    var clist = WF.Utils.getClist(el);
    var bodies = $(el).find(".carouselFrame, .c26body");
    $.each(bodies, function (idx, body) {
        body = $(body);
        body.addClass("item" + (idx + 1));
    });
    if (bodies.length > 1) {
        incomingFrame = $('<div class="carouselFrame incomingFrame"/>');
        incomingFrame.attr("aria-hidden", "true");
        $(el).append(incomingFrame);
        var controls = $('<div class="controls"/>');
        for (var i = 1; i <= bodies.length; i++) {
            $(bodies[i - 1]).prepend($('<span class="hidden">' + WF.Strings.Shared.beginItemNo[WF.Page.lang] + i + "</span>"));
            $(bodies[i - 1]).append($('<span class="hidden">' + WF.Strings.Shared.endItemNo[WF.Page.lang] + i + "</span>"));
            var dot = $('<a href="#' + el.id + "_frame" + i + '" class="show' + i + '">&bull;<span class="hidden">' + WF.Strings.Shared.item[WF.Page.lang] + " " + i + "</span></a>");
            dot.bind("click keypress", function (evt) {
                var num = this.className.match(/show(\d+)/)[1];
                if (evt.type == "keypress" && evt.keyCode != 13) {
                    return;
                }
                WF.Utils.trackVS({
                    "event": "LinkActivated",
                    "eventType": evt.type,
                    "eventDescription": evtDesc,
                    "clist": clist,
                    "tipNumber": num,
                    "elementActivated": "Bottom"
                });
                if (evt.type == "keypress") {
                    evt.preventDefault();
                    self.showFrame(this.className.replace(/\D/g, ""), {
                        stopAutoplay: true
                    });
                }
            });
            $(controls).append(dot);
            if (i == 1) {
                $(controls).find(".show" + i).addClass("current").attr("tabindex", -1);
            }
            $(controls).find(".show" + i).click(function (evt) {
                evt.preventDefault();
                self.showFrame(this.className.replace(/\D/g, ""), {
                    stopAutoplay: true
                });
            });
            $(bodies[i - 1]).attr("aria-hidden", "true").hide();
            if ($.fn.touchwipe) {
                $(bodies[i - 1]).touchwipe({
                    wipeLeft: function (evt) {
                        evt.preventDefault();
                        self.next(true);
                    },
                    wipeRight: function (evt) {
                        evt.preventDefault();
                        self.prev(true);
                    }
                });
            }
        }
        $(el).append(controls);
        if (options.paddles != "off") {
            var paddles = $('<div id="constructingPaddles">'),
                paddle1 = $('<div class="paddles"/>'),
                paddle2 = $('<div class="paddles"/>');
            paddles.append(paddle1);
            paddles.append(paddle2);
            var tabIndex = "";
            if (options.paddles == "on") {
                paddles.find(".paddles").addClass("alwaysOn");
            } else {
                tabIndex = ' tabindex="-1"';
                setInterval(function () {
                    if (paddle1.find("a.left").css("left") == "-27px") {
                        paddle1.css("visibility", "hidden").attr("aria-hidden", "true");
                        paddle2.css("visibility", "hidden").attr("aria-hidden", "true");
                    } else {
                        paddle1.css("visibility", "visible").attr("aria-hidden", "false");
                        paddle2.css("visibility", "visible").attr("aria-hidden", "false");
                    }
                }, 10);
            }

            paddle1.append('<a href="#' + el.id + '_prevFrame" id="leftArrow" class="left"' + tabIndex + '><img src="../Images/chevron-large-left-grey.png" alt="' + WF.Strings.Shared.prev[WF.Page.lang] + '" /></a>');
            paddle2.append('<a href="#' + el.id + '_nextFrame" id="rightArrow" class="right"' + tabIndex + '><img src="../Images/chevron-large-right-grey.png" alt="' + WF.Strings.Shared.next[WF.Page.lang] + '" /></a>');
            paddles.find("a").mouseover(function () {
                var img = $(this).find("img").get(0);
                img.src = img.src.replace(/grey/, "blue");
            }).mouseout(function () {
                var img = $(this).find("img").get(0);
                img.src = img.src.replace(/blue/, "grey");
            });
            paddles.find(".left").data("vsObj", {
                "event": "LinkActivated",
                "eventDescription": evtDesc,
                "clist": clist,
                "elementActivated": "LeftPaddle"
            });
            paddles.find(".left").click(function (evt) {
                evt.preventDefault();
                self.prev(true, $.extend($(this).data("vsObj"), {
                    eventType: evt.type
                }));
            });
            paddles.find(".left").bind("click keypress", function (evt) {
                if (evt.type == "keypress" && evt.keyCode != 13) {
                    return;
                }
                if (evt.type == "keypress") {
                    evt.preventDefault();
                    self.prev(true, $.extend($(this).data("vsObj"), {
                        eventType: evt.type
                    }));
                }
            });
            paddles.find(".right").data("vsObj", {
                "event": "LinkActivated",
                "eventDescription": evtDesc,
                "clist": clist,
                "elementActivated": "RightPaddle"
            });
            paddles.find(".right").click(function (evt) {
                evt.preventDefault();
                self.next(true, $.extend($(this).data("vsObj"), {
                    eventType: evt.type
                }));
            });
            paddles.find(".right").bind("click keypress", function (evt) {
                if (evt.type == "keypress" && evt.keyCode != 13) {
                    return;
                }
                if (evt.type == "keypress") {
                    evt.preventDefault();
                    self.next(true, $.extend($(this).data("vsObj"), {
                        eventType: evt.type
                    }));
                }
            });
            $(el).prepend(paddle1);
            $(el).append(paddle2);
        }
        $(el).find(".carouselFrame.item1").show();
        incomingFrame.hide();
        curFrame = 1;
        if (options.autostart) {
            this.start();
        }
    } else {
        $(bodies[0]).show();
    }
    if (options.componentType.substr(0, 5) == "Small") {
        clist = WF.Utils.getClist(bodies[0]);
    }
    WF.Utils.trackVS({
        "event": "PageLoad",
        "eventDescription": evtDesc,
        "clist": clist
    });
    if (options && options.componentType == "Tip") {
        WF.Page.Components.Tips.push(this);
    }
    WF.Page.Components.Carousels.push(this);
    return this;
};
WF.OnLoads.setupCarousels = function (root) {
    if (typeof root == "undefined") {
        root = $("body");
    }
    $(root).find(".c26").each(function () {
        new WF.Component.Carousel(this, {
            componentType: "Tip",
            autostart: true
        });
    });
    $(root).find(".c3wrapper").each(function () {
        new WF.Component.Carousel(this, {
            componentType: "Marquee",
            paddles: "off",
            autostart: true,
            speed: 800
        });
    });
    $(root).find(".c64main").each(function () {
        new WF.Component.Carousel(this, {
            componentType: "Small",
            paddles: "on",
            autostart: true
        });
    });
};
WF.Component.CTA = function (el) {
    if (!el.id) {
        el.id = WF.Utils.generateUniqueId(el);
    }
    this.elem = el;
    this.id = "CTA_" + el.id;
    var clist = WF.Utils.getClist(el);
    $(el).bind("click keypress", function (evt) {
        if (evt.type == "keypress" && evt.keyCode != 13) {
            return;
        }
        WF.Utils.trackVS({
            "event": "LinkActivated",
            "eventType": evt.type,
            "eventDescription": "CTAText",
            "destinationUrl": this.href,
            "linkText": $(this).text(),
            "clist": clist,
            "presentation": $(this).data("presentation"),
            "suppressAsync": true
        });
        if (evt.type === "keypress" && typeof (this.href) !== "undefined") {
            evt.preventDefault();
            window.location.href = this.href;
        }
    });
    WF.Page.Components.CTAs.push(this);
    return this;
};
WF.OnLoads.setupCTAs = function (root) {
    if (typeof root == "undefined") {
        root = $("body");
    }
    $(root).find(".c7, .c13, .c22").each(function () {
        new WF.Component.CTA(this);
    });
};
WF.Component.FatNav = function (el) {
    var _this = this,
        navSelected = null,
        timer, isDisplaying = false,
        hoverShowDelay = 300,
        clickShowDelay = 0,
        triggerHideDelay = 250,
        popupHideDelay = 150,
        showSpeed = 250,
        hideSpeed = 250,
        linkEl = null;
    this.el = el;
    this.position = function () {
        navSelected.css("left", _this.el.offset().left - 10 + "px");
        navSelected.css("top", (linkEl.offset().top + linkEl.outerHeight() - 1) + "px");
    };
    this.show = function (anchor, e) {
        var tallestDiv = 0;
        var firstDivClass = "navItemLeft";
        _this.canceltimer();
        _this.el.find("a.selected").removeClass("selected");
        linkEl = anchor;
        navSelected = $("#" + linkEl.attr("data-navitem"));
        linkEl.addClass("selected");
        linkEl.attr("aria-selected", "true");
        $("div.navItem").addClass("hide");
        _this.position();
        navSelected.removeClass("hide");
        navSelected.attr("aria-hidden", "false");
        $("div.navItem").each(function () {
            if ($(this).hasClass("hide")) {
                $(this).css("display", "none");
            }
        });
        var delay;
        if (e.type == "mouseover") {
            delay = (isDisplaying) ? 0 : hoverShowDelay;
        } else {
            delay = clickShowDelay;
        }
        _this.settimer(function () {
            if (!navSelected) {
                navSelected = $("#" + linkEl.attr("data-navitem"));
            }
            if (e.type == "mouseover") {
                navSelected.filter(":not(:animated)").animate({
                    height: "show",
                    opacity: "show"
                }, showSpeed);
            } else {
                navSelected.filter(":not(:animated)").animate({
                    height: "toggle",
                    opacity: "toggle"
                }, showSpeed, function () {
                    if (e.type == "keypress" && linkEl.next("div").css("display") == "block") {
                        navSelected.find("span.beginmarker").focus();
                    }
                    if (linkEl.next("div").css("display") == "none") {
                        linkEl.removeClass("selected");
                        linkEl.removeAttr("aria-selected");
                        $("div.navItem").attr("aria-hidden", "true");
                        $("div.navItem").css("display", "none");
                    }
                });
            }
            navSelected.children("div").each(function (idx) {
                if (idx == 0 && this.className) {
                    firstDivClass = this.className;
                }
                if ($(this).innerHeight() > tallestDiv) {
                    tallestDiv = $(this).innerHeight();
                }
            });
            navSelected.find("." + firstDivClass).first().css("height", tallestDiv + "px");
            isDisplaying = true;
            $(_this.el).trigger("fatnavopen");
        }, delay);
    };
    this.hide = function () {
        _this.el.find("a.selected").removeAttr("aria-selected");
        _this.el.find("a.navLevel1").removeClass("selected");
        if (navSelected != null) {
            navSelected.addClass("hide").attr("aria-hidden", "true");
            navSelected.animate({
                height: "hide",
                opacity: "hide"
            }, hideSpeed, function () {
                $(".navItem").css("display", "none");
                navSelected = null;
            });
        }
        isDisplaying = false;
        $(_this.el).trigger("fatnavclose");
    };
    this.settimer = function (todo, time) {
        timer = window.setTimeout(todo, time);
    };
    this.canceltimer = function () {
        if (timer) {
            window.clearTimeout(timer);
            timer = null;
        }
    };
    this.setup = function () {
        $("div.navItem").each(function () {
            var temp;
            temp = $(this).detach();
            _this.el.find("a.navLevel1").each(function () {
                if (temp.attr("id") == $(this).attr("data-navitem")) {
                    temp.insertAfter($(this));
                }
            });
        });
        if (WF.Browser.supports.touch) {
            _this.el.find("a.navLevel1").click(function (e) {
                e.preventDefault();
            });
            _this.el.find("a.navLevel1").bind("touchstart", function (e) {
                _this.show($(this), e);
            });
            $(document).bind("touchstart", function (e) {
                if ($(e.target).is("#" + _this.el.attr("id") + " *")) {
                    return true;
                } else {
                    _this.hide();
                }
            });
        } else {
            _this.el.find("a.navLevel1").click(function (e) {
                _this.show($(this), e);
                e.preventDefault();
            });
            _this.el.find("a.navLevel1").bind("mouseover", function (e) {
                _this.show($(this), e);
            });
            _this.el.find("a.navLevel1").bind("mouseout", function (e) {
                _this.canceltimer();
                _this.settimer(_this.hide, triggerHideDelay);
            });
            _this.el.keypress(function (e) {
                var target = $(e.target);
                if (target.is("a.navLevel1") == true && e.keyCode == 13) {
                    _this.show($(target), e);
                    e.preventDefault();
                }
                if (e.keyCode == 27) {
                    _this.el.find("a.selected").focus();
                    _this.hide();
                }
            });
            _this.el.find("div.navItem").bind("mouseover", function (e) {
                _this.canceltimer();
            });
            _this.el.find("div.navItem").bind("mouseout", function (e) {
                _this.settimer(_this.hide, popupHideDelay);
            });
            _this.el.find("li a").first().bind("keypress", function (e) {
                if (e.shiftKey === true && e.keyCode == 9) {
                    _this.hide();
                }
            });
            _this.el.find("li div.navItem").last().find("span.endmarker").bind("keypress", function (e) {
                if (e.keyCode == 9) {
                    _this.hide();
                }
            });
        }
    };
    $(window).resize(function () {
        if (navSelected != null) {
            _this.position();
        }
    });
    WF.Page.Components.FatNav = this;
    this.setup();
    return this;
};
WF.OnLoads.setupFatNav = function (root) {
    if (typeof root == "undefined") {
        root = $("body");
    }
    if (WF.Page.Components.FatNav) {
        return;
    }
    if ($(root).find("#fatnav").length > 0) {
        new WF.Component.FatNav($("#fatnav"));
    }
};
WF.Component.RibbonCarousel = function (el, options) {
   
    if (!el.id) {
        el.id = WF.Utils.generateUniqueId(el);
    }
    var self = this;
    var stdOptions = {
        "autostart": false,
        "autoloop": false,
        "frameRate": 8000,
        "loop": true,
        "paddles": "on",
        "speed": 500,
        "Tip": false
    };
    if (!options) {
        options = {};
    }
    for (var o in stdOptions) {
        if (typeof options[o] == "undefined") {
            options[o] = stdOptions[o];
        }
    }
    options.width = $(el).width();
    options.padding = $(el).css("padding-left");
    var curFrame, incomingFrame, incomingChevron, visibleChevron, wrapLength;
    var onlySixFrames = false;
    this.elem = el;
    this.id = "RibbonCarousel_" + el.id;
    this.next = function () {
        var showing = curFrame;
        if (showing >= wrapLength) {
            showing = 1;
        } else {
            showing++;
        }
        if (onlySixFrames) {
            ribbon.find("li:first").replaceWith(ribbon.find("li:nth-child(2)").clone(true));
        }
        ribbon.css("left", (parseInt(ribbon.css("left"), 10) + 162) + "px").find("li:first").appendTo(ribbon);
        this.showFrame(showing, "right");
    };
    this.prev = function () {
        var showing = curFrame;
        if (showing <= 1) {
            showing = wrapLength;
        } else {
            showing--;
        }
        if (onlySixFrames) {
            ribbon.find("li:last").replaceWith(ribbon.find("li:nth-child(6)").clone(true));
        }
        ribbon.css("left", (parseInt(ribbon.css("left"), 10) - 162) + "px").find("li:last").prependTo(ribbon);
        this.showFrame(showing, "left");
    };
    this.copyFrame = function (from, to) {
        to.html(from.html());
        $.each(["cid", "ctid", "presentation"], function (i, val) {
            to.data(val, from.data(val));
        });
    };
    this.shiftTo = function (num, dir) {
        var diff = num - curFrame;
        if (Math.abs(diff) > 3) {
            if (diff < 0) {
                diff += ribbonItems.length;
            } else {
                diff -= ribbonItems.length;
            }
        }
        if (!dir) {
            if (diff < 0) {
                dir = "left";
            } else {
                dir = "right";
            }
        }
        diff = Math.abs(diff);
        for (var i = 0; i < diff; i++) {
            if (dir == "right") {
                if (onlySixFrames) {
                    ribbon.find("li:first").replaceWith(ribbon.find("li:nth-child(2)").clone(true));
                }
                ribbon.css("left", (parseInt(ribbon.css("left"), 10) + 162) + "px").find("li:first").appendTo(ribbon);
            } else {
                if (onlySixFrames) {
                    ribbon.find("li:last").replaceWith(ribbon.find("li:nth-child(6)").clone(true));
                }
                ribbon.css("left", (parseInt(ribbon.css("left"), 10) - 162) + "px").find("li:last").prependTo(ribbon);
            }
        }
        this.showFrame(num, dir);
    };
    this.showFrame = function (num, dir) {
        if (num == curFrame) {
            return;
        }
        var incFrame = $(el).find(".carouselFrame.item" + num);
        self.copyFrame(incFrame, incomingFrame);
        self.copyFrame($("ul.c63controls li.show" + num), incomingChevron);
        var animOpts = {
            queue: false,
            left: 0
        };
        var plusWidth = options.width + "px";
        var minusWidth = "-" + options.width + "px";
        if (dir == "left") {
            incomingFrame.css("left", minusWidth);
        } else {
            if (dir == "right") {
                incomingFrame.css("left", plusWidth);
            } else {
                if (num > curFrame) {
                    dir = "right";
                    incomingFrame.css("left", plusWidth);
                } else {
                    dir = "left";
                    incomingFrame.css("left", minusWidth);
                }
            }
        }
        var chevronWidth = visibleChevron.width() + "px";
        if (dir == "left") {
            chevronWidth = "-" + chevronWidth;
        }
        incomingChevron.css("left", chevronWidth);
        incomingFrame.show();
        incomingFrame.animate(animOpts, options.speed, "swing", function () {
            incomingFrame.hide();
            $(el).find(".carouselFrame:visible").attr("aria-hidden", "true").hide();
            incFrame.attr("aria-hidden", "false").show();
        });
        incomingChevron.animate(animOpts, options.speed, "swing", function () {
            self.copyFrame(incomingChevron, visibleChevron);
            incomingChevron.hide();
        });
        curFrame = num;
        ribbon.animate({
            "left": "-10px"
        }, options.speed);
    };
    this.count = function () {
        return bodies.length;
    };
    this.retrieveClist = function () {
        var visibleCarouselFrame = $(el).find(".item" + curFrame);
        return $(visibleCarouselFrame).data("cid") + "~" + $(visibleCarouselFrame).data("ctid");
    };
    var evtDesc = "DisplayRibbonCarouselItem";
    if (options && options.Tip) {
        evtDesc = "DisplayTip";
    }
    var bodies = $(el).find(".carouselFrame");
    $.each(bodies, function (idx, body) {
        if (!body.id) {
            body.id = WF.Utils.generateUniqueId(body);
        }
        body = $(body);
        body.addClass("item" + (idx + 1)).attr("aria-hidden", true);
    });
    if (bodies.length > 1) {
        incomingFrame = $('<div class="carouselFrame incomingFrame"/>');
        $(el).append(incomingFrame);
        chevron = $('<div class="chevron"/>');
        visibleChevron = $('<div class="visibleChevron"/>');
        chevron.append(visibleChevron);
        incomingChevron = $('<div class="incomingChevron"/>');
        chevron.append(incomingChevron);
        $(el).append(chevron);
        var ribbon = $(this.elem).find("ul.c63controls");
        var ribbonItems = ribbon.find("li");
        if (ribbonItems.length != bodies.length) {
            var only = (ribbonItems.length > bodies.length) ? "only " : "";
            alert("There are " + ribbonItems.length + " items in the top ribbon (ul.c63controls), but " + only + bodies.length + " carouselFrame divs!");
            return false;
        }
        if (bodies.length == 6) {
            onlySixFrames = true;
            wrapLength = 6;
            bodies.splice(3, 0, $(bodies[3]).clone(true).get(0));
        } else {
            wrapLength = bodies.length;
        }
        for (var i = 1; i <= ribbonItems.length; i++) {
            if (!ribbonItems[i - 1].id) {
                ribbonItems[i - 1].id = WF.Utils.generateUniqueId(ribbonItems[i - 1]);
            }
            $(bodies[i - 1]).attr("aria-labelledby", ribbonItems[i - 1].id);
            $(ribbonItems[i - 1]).attr({
                "aria-expanded": false,
                "aria-selected": false
            }).addClass("show" + i).bind("click", function (evt) {
                var target = evt.target;
                if (target.tagName != "LI") {
                    target = $(target).parent("li").get(0);
                }
                var x = target.className.match(/show(\d+)\b/)[1];
                var dir = null;
                var rItems = ribbon.find("li");
                if (rItems.index(target) == 0) {
                    dir = "left";
                } else {
                    if (rItems.index(target) == rItems.length - 1) {
                        dir = "right";
                    }
                }
                self.shiftTo(x, dir);
                ribbon.find("li").removeAttr("tabindex").attr({
                    "aria-expanded": false,
                    "aria-selected": false
                });
                if (!WF.Browser.supports.isIE) {
                    $(this).attr({
                        "tabindex": 0,
                        "aria-expanded": true,
                        "aria-selected": true
                    }).focus();
                }
                WF.Utils.trackVS({
                    "event": "LinkActivated",
                    "eventType": evt.type,
                    "eventDescription": evtDesc,
                    "clist": self.retrieveClist(),
                    "elementActivated": "RibbonItem"
                });
            }).bind("keydown", function (evt) {
                if (evt.keyCode == 39) {
                    self.next();
                    if (!WF.Browser.supports.IE7mode) {
                        $(this).next().attr({
                            "tabindex": 0,
                            "aria-expanded": true,
                            "aria-selected": true
                        }).focus();
                    }
                    $(this).removeAttr("tabindex").attr({
                        "aria-expanded": false,
                        "aria-selected": false
                    });
                } else {
                    if (evt.keyCode == 37) {
                        self.prev();
                        if (!WF.Browser.supports.IE7mode) {
                            $(this).prev().attr({
                                "tabindex": 0,
                                "aria-expanded": true,
                                "aria-selected": true
                            }).focus();
                        }
                        $(this).removeAttr("tabindex").attr({
                            "aria-expanded": false,
                            "aria-selected": false
                        });
                    }
                }
            }).bind("keypress", function (evt) {
                if ($.inArray(evt.keyCode, [13, 37, 39]) == -1) {
                    return;
                }
                WF.Utils.trackVS({
                    "event": "LinkActivated",
                    "eventType": evt.type,
                    "eventDescription": evtDesc,
                    "clist": self.retrieveClist(),
                    "elementActivated": "RibbonItem"
                });
            });
        }
        if (onlySixFrames) {
            ribbon.find(":nth-child(4)").before(ribbon.find(":nth-child(4)").clone(true));
        }
        if (!WF.Browser.supports.IE7mode) {
            $(ribbonItems[0]).attr({
                "tabindex": 0,
                "aria-expanded": true,
                "aria-selected": true
            });
        }
        for (var i = 1; i <= bodies.length; i++) {
            $(bodies[i - 1]).prepend($('<span class="hidden">' + WF.Strings.Shared.beginItemNo[WF.Page.lang] + i + "</span>"));
            $(bodies[i - 1]).append($('<span class="hidden">' + WF.Strings.Shared.endItemNo[WF.Page.lang] + i + "</span>"));
            $(bodies[i - 1]).hide();
            if ($.fn.touchwipe) {
                $(bodies[i - 1]).touchwipe({
                    wipeLeft: function (evt) {
                        evt.preventDefault();
                        self.next(true);
                    },
                    wipeRight: function (evt) {
                        evt.preventDefault();
                        self.prev(true);
                    }
                });
            }
        }
        var leftPaddle = $('<div class="bothPaddles prevPaddle"/>');
        var rightPaddle = $('<div class="bothPaddles nextPaddle"/>');
        var leftLink = $('<a href="#' + el.id + '_prevFrame" id="leftArrow" class="paddle prevPaddle"><img src="../Images/chevron-large-left-grey.png" alt="' + WF.Strings.Shared.prev[WF.Page.lang] + '" /></a>');
        var rightLink = $('<a href="#' + el.id + '_nextFrame" id="rightArrow" class="paddle nextPaddle"><img src="../Images/chevron-large-right-grey.png" alt="' + WF.Strings.Shared.next[WF.Page.lang] + '" /></a>');
        leftLink.mouseover(function () {
            var img = $(this).find("img").get(0);
            img.src = img.src.replace(/grey/, "blue");
        }).mouseout(function () {
            var img = $(this).find("img").get(0);
            img.src = img.src.replace(/blue/, "grey");
        }).click(function (evt) {
            evt.preventDefault();
            self.prev();
        }).bind("click keypress", function (evt) {
            if (evt.type == "keypress" && evt.keyCode != 13) {
                return;
            }
            ribbon.find("li").removeAttr("tabindex").attr({
                "aria-expanded": false,
                "aria-selected": false
            });
            if (!WF.Browser.supports.IE7mode) {
                ribbon.find(".show" + curFrame).attr({
                    "tabindex": 0,
                    "aria-expanded": true,
                    "aria-selected": true
                });
            }
            WF.Utils.trackVS({
                "event": "LinkActivated",
                "eventType": evt.type,
                "eventDescription": evtDesc,
                "clist": self.retrieveClist(),
                "elementActivated": "LeftPaddle"
            });
            if (evt.type == "keypress") {
                evt.preventDefault();
                self.prev();
            }
        });
        rightLink.mouseover(function () {
            var img = $(this).find("img").get(0);
            img.src = img.src.replace(/grey/, "blue");
        }).mouseout(function () {
            var img = $(this).find("img").get(0);
            img.src = img.src.replace(/blue/, "grey");
        }).click(function (evt) {
            evt.preventDefault();
            self.next();
        }).bind("click keypress", function (evt) {
            if (evt.type == "keypress" && evt.keyCode != 13) {
                return;
            }
            ribbon.find("li").removeAttr("tabindex").attr({
                "aria-expanded": false,
                "aria-selected": false
            });
            if (!WF.Browser.supports.IE7mode) {
                ribbon.find(".show" + curFrame).attr({
                    "tabindex": 0,
                    "aria-expanded": true,
                    "aria-selected": true
                });
            }
            WF.Utils.trackVS({
                "event": "LinkActivated",
                "eventType": evt.type,
                "eventDescription": evtDesc,
                "clist": self.retrieveClist(),
                "elementActivated": "RightPaddle"
            });
            if (evt.type == "keypress") {
                evt.preventDefault();
                self.next();
            }
        });
        ribbon.before(leftLink);
        ribbon.after(rightLink);
        for (var i = 0; i < 3; i++) {
            ribbon.find("li:last").prependTo(ribbon);
        }
        self.copyFrame($(ribbonItems[0]), visibleChevron);
        $(el).find(".carouselFrame.item1").show();
        incomingFrame.hide();
        curFrame = 1;
        if ($.fn.touchwipe) {
            ribbon.touchwipe({
                wipeLeft: function (evt) {
                    evt.preventDefault();
                    self.next();
                },
                wipeRight: function (evt) {
                    evt.preventDefault();
                    self.prev();
                }
            });
        }
    } else {
        $(bodies[0]).show();
    }
    WF.Utils.trackVS({
        "event": "PageLoad",
        "eventDescription": evtDesc,
        "clist": self.retrieveClist()
    });
    if (options && options.Tip) {
        WF.Page.Components.Tips.push(this);
    }
    WF.Page.Components.RibbonCarousels.push(this);
    return this;
};
WF.OnLoads.setupRibbonCarousels = function (root) {
   
    if (typeof root == "undefined") {
        root = $("body");
    }
    $(root).find(".c63").each(function () {
        new WF.Component.RibbonCarousel(this);
    });
};
$(document).ready(function () {
   
    if (typeof window.WFonDocReady == "function") {
        window.WFonDocReady();
    }
    if ($("html").hasClass("lt-ie9")) {
        $("body").addClass("not_a_real_class").removeClass("not_a_real_class");
    }
});
(function () {
    var presetSec = 3000;
    var irequestTimeOut = 600;

    function createRequest() {
        var req;
        if (window.XMLHttpRequest) {
            req = new XMLHttpRequest();
        } else {
            req = false;
        }
        if (!req) {
            try {
                req = new ActiveXObject("MSXML.XMLHTTP");
            } catch (olderMS) {
                try {
                    req = new ActiveXObject("Microsoft.XMLHTTP");
                } catch (e) { }
            }
        }
        return req;
    }
    function setTasClick(collection) {
        var total = collection.length,
            temp = null,
            i = 0;
        for (i = 0; i < total; i++) {
            if (collection[i].tagName == "IMG" && collection[i].className.indexOf("tasDefault") == -1) {
                temp = collection[i].parentNode;
            } else {
                if (collection[i].tagName == "A") {
                    temp = collection[i];
                }
            }
            if (temp != null && temp.tagName == "A") {
                temp.onclick = function (e) {
                    trackTASClick(this);
                    return false;
                };
            }
        }
    }
    function trackInsights() {
        var curr = new Date(),
            time = curr.valueOf(),
            trackInfo = "?Log=1&Program=EventReporting&Event=IADefaultOffer&Page=" + window.location.pathname + window.location.search + "&CB=" + time,
            req = new createRequest(),
            timer = setTimeout(function () {
                req.abort();
            }, irequestTimeOut);
        for (var name in tasInfo.data) {
            data += "&" + name + "=" + tasInfo.data[name];
        }
        req.onreadystatechange = function () { };
        req.open("GET", "/assets/images/global/s.gif" + trackInfo, true);
        req.send(null);
    }
    function logTAS() {
        var timer = null,
            req = createRequest(),
            data = "",
            d = new Date(),
            pageUrl = window.location.href;
        timer = setTimeout(function () {
            req.abort();
        }, irequestTimeOut);
        for (var name in tasInfo.data) {
            data += "&" + name + "=" + tasInfo.data[name];
        }
        req.onreadystatechange = function () { };
        req.open("POST", tasInfo.Url, true);
        req.setRequestHeader("Content-Type", "application/x-www-form-urlencoded");
        req.send("RequestType=Logging&pageURL=" + escape(pageUrl) + "&pageID=" + tasInfo.pageID + "&tz=" + (0 - d.getTimezoneOffset()) + "&r=" + document.referrer + data + "&App_ID=" + tasInfo.App_ID);
    }
    function findTasAds() {
        var allImageTags = document.getElementsByTagName("img"),
            noOfImages = allImageTags.length,
            adList = [],
            noOfContainers = 0,
            i = 0,
            defaultAdList = [];
        if (typeof (tasInfo) != "undefined") {
            for (i = 0; i < noOfImages; i++) {
                if (allImageTags[i].className.indexOf("tasAd") != -1) {
                    adList.push(allImageTags[i]);
                }
            }
            noOfContainers = adList.length;
            if (noOfContainers > 0) {
                for (i = 0; i < noOfContainers; i++) {
                    if (adList[i].className.indexOf("tasDefault") != -1) {
                        defaultAdList.push(adList[i]);
                    }
                }
                if (defaultAdList.length == adList.length) {
                    trackInsights();
                }
                if (adList.length > 0) {
                    setTasClick(adList);
                }
            } else {
                logTAS();
            }
        }
    }
    function trackTASClick(newLink, containerId) {
        var newLocation = "",
            newLocationPath = "",
            relativeUrl = false,
            COID = "",
            req = createRequest(),
            slotId = "";
        if (typeof (newLink) === "object") {
            COID = newLink.className.slice(newLink.className.indexOf("tasRendered") + 11);
            newLocationPath = newLink.href;
        } else {
            if (typeof (newLink) === "string") {
                COID = typeof (containerId) == "undefined" ? "NULL" : containerId;
                newLocationPath = newLink;
            }
        }
        slotId = newLink.getElementsByTagName("IMG")[0].id;
        if (newLocationPath.charAt(0) == "/") {
            relativeUrl = true;
        } else {
            if (newLocationPath.indexOf(location.host) > -1) {
                newLocationPath = newLocationPath.substring(newLocationPath.indexOf("//") + 2 + location.host.length);
            }
        }
        newLocation = newLocationPath;
        req.onreadystatechange = function () {
            if (req.readyState == 4) {
                location.href = newLocation;
            }
        };
        req.open("POST", tasInfo.Url);
        req.setRequestHeader("Content-Type", "application/x-www-form-urlencoded");
        req.send("pageURL=https://www.wellsfargo.com/Clickthrough&RequestType=Click&COID=" + COID + "&App_ID=" + tasInfo.App_ID + "&ids=" + slotId + "&pageID=" + tasInfo.pageID);
    }
    findTasAds();


}());