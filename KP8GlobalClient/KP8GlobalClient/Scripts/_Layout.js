$(function () {    
    $('#MLFSI').removeClass('fadeOn');
    $('#MLFSI').addClass('fadeOff');
});

function ajaxLoadModal(msg) {
    if (typeof msg != 'string') {
        if ($('#ajxload').hasClass('ajxLoadOff')) {
            $('#ajxload').removeClass('ajxLoadOff');
            $('#ajxload').addClass('ajxLoadOn');
        }
        else {
            $('#ajxload').removeClass('ajxLoadOn');
            $('#ajxload').addClass('ajxLoadOff');
        }
    }
    else {
        document.getElementById("ajxMsg").innerHTML = (msg == "" ? "Please Wait..." : (msg + '...'));
        if ($('#ajxload').hasClass('ajxLoadOff')) {
            $('#ajxload').removeClass('ajxLoadOff');
            $('#ajxload').addClass('ajxLoadOn');
        }
    }
}

function msgBox(msg) {
    $('#msgModal').removeClass('hidden');
    document.getElementById('msgContainer').innerHTML = msg;
}

function hideModals() {
    ajaxLoadModal('Loading...');
    ajaxLoadModal();
    $('#msgModal').addClass('hidden')
}

var errorRetries = 0;

function unExpectedError() {
    if (errorRetries < 2)
        msgBox('Something went wrong, <br /> Please try again...');
    else if (errorRetries < 5)
        msgBox('Something went wrong, <br /> Please check your network connection and try again...');
    else
        msgBox('Something went wrong, If problem persists and you have network connection, kindly contact admin...');
    errorRetries++;
}