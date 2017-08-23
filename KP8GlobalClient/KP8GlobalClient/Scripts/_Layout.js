$(function () {    
    $('#MLFSI').removeClass('fadeOn');
    $('#MLFSI').addClass('fadeOff');
});

function setModalLoader() {    
    if ($('#ajxload').hasClass('ajxLoadOff')) {
        $('#ajxload').removeClass('ajxLoadOff');
        $('#ajxload').addClass('ajxLoadOn');
    }
    else {
        $('#ajxload').removeClass('ajxLoadOn');
        $('#ajxload').addClass('ajxLoadOff');
    }
}