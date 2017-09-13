function getHeaderLinks() {
    ajaxLoadModal("Rendering tools");
    $.ajax({
        async: true,
        type: 'GET',
        url: '/Home/_headerLinks',
        contentType: 'application/x-www-form-urlencoded; charset=UTF-8',
        dataType: 'html',
        cache: false,
        success: function (result) {
            $('header').html(result);
        },
        error: function (jqXHR, textStatus, errorThrown) {
            unExpectedError();
        }
    });
}