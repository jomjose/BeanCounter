var common = function () {
    commonMethods = {};

    commonMethods.initialize = function () {
        commonMethods.setEvents();
    };

    commonMethods.ajax = function (url, data, success) {
        $.ajax({
            type: 'POST',
            url: url,
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            data: data,
            success: success
        }); 
    };

    commonMethods.setEvents = function () {

        //Enable sidebar toggle
        $("[data-toggle='offcanvas']").click(function (e) {
            e.preventDefault();

            //If window is small enough, enable sidebar push menu
            if ($(window).width() <= 992) {
                $('.row-offcanvas').toggleClass('active');
                $('.left-side').removeClass("collapse-left");
                $(".right-side").removeClass("strech");
                $('.row-offcanvas').toggleClass("relative");
            } else {
                //Else, enable content streching
                $('.left-side').toggleClass("collapse-left");
                $(".right-side").toggleClass("strech");
            }
        });
    };
    return commonMethods;
}();
$(function () {
    common.initialize();
});