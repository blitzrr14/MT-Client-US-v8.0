$(function () {

    $('form#Login').on("submit", function (e) {
        ajaxLoadModal('Authenticating...');
        e.preventDefault();
        //$('form#Login').validate();

        if ($(this).valid())
        {
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
        }
        else
        {
            ajaxLoadModal();
        }
    });

    $('#Password').on("keyup", function () {
        if ($(this).val()) {
            $('#glyphEye').removeClass('fadeOut');
            $('#glyphEye').addClass('fadeIn');
        }
        else {
            $('#glyphEye').removeClass('fadeIn');
            $('#glyphEye').addClass('fadeOut');
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
