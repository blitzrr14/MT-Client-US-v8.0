$(function () {
    $('form#Login').on("submit", function (e) {
        e.preventDefault();
        ajaxLoadModal('Authenticating...');
        
        setTimeout(function () {
            $.ajax({
                async: true,
                type: 'POST',
                url: '/Index/LogIn',
                data: $('form :input').serializeArray(),
                contentType: 'application/x-www-form-urlencoded; charset=UTF-8',
                dataType: 'html',
                cache: false,
                success: function (result) {
                    $('div#content-holder').html(result);
                    ajaxLoadModal();
                },
                error: function (jqXHR, textStatus, errorThrown) {
                    unExpectedError();
                }
            });
        }, 1000);
    });

    $('#Password').on("keyup", function () {
        if ($(this).val()) {
            $('#glyphEye').removeClass('fadeOn');
            $('#glyphEye').addClass('fadeOff');
        }
        else {
            $('#glyphEye').removeClass('fadeOff');
            $('#glyphEye').addClass('fadeOn');
        }
    });

    $('#glyphEye').mousedown(function () {
        $("#Password").attr('type', 'text');
    }).mouseup(function () {
        $("#Password").attr('type', 'password');
        $("#Password").focus();
    }).mouseout(function () {
        $("#Password").attr('type', 'password');
    });
});
