$(function () {
    $.ajax({
        async: true,
        type: 'GET',
        url: '/Index/LogIn',
        contentType: 'application/x-www-form-urlencoded; charset=UTF-8',
        dataType: 'html',
        cache: false,
        success: function (result) {
            $('div#content-holder').html(result);
            setModalLoader()
        },
        error: function (errMsg) {
            alert(errMsg);
            setModalLoader()
        }
    });
});