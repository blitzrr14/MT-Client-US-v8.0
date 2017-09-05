$(function () {    
    //equivalent to document.ready
    $('#uiBlocker').removeClass('blockerIn');
    $('#uiBlocker').addClass('blockerOut');
});

function ajaxLoadModal(msg) {
    if (typeof msg != 'string') {
        if ($('#uiBlocker').hasClass('blockerIn')) {
            $('#uiBlocker').removeClass('blockerIn');
            $('#uiBlocker').addClass('blockerOut');
        }
        else {
            $('#uiBlocker').removeClass('blockerOut');
            $('#uiBlocker').addClass('blockerIn');
        }
    }
    else {
        document.getElementById("ajxMsg").innerHTML = (msg == "" ? "Please Wait..." : (msg + '...'));
        if ($('#uiBlocker').hasClass('blockerOut')) {
            $('#uiBlocker').removeClass('blockerOut');
            $('#uiBlocker').addClass('blockerIn');
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