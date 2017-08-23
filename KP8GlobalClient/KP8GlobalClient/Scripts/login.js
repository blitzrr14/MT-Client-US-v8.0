$(document).ready(function () {
    //for hide forms//
    $('#_senderInfo').hide();
    $('#_benefiInfo').hide();
    $('#_amountInfo').hide();
    $('#_payoutInfo').hide();
    //$('#fordaeye').hide();
    //for Login design//
    $('#popup1').show('slow');
    $('#user').focus();
    $('#kptn').focus();
    //for Button Next//
    $('.btnNext').click(function () {
        $('#_branchInfo').hide();
        $('#_senderInfo').show();
    });
    $('.btnNextni').click(function () {
        $('#_branchInfo').hide();
        $('#_senderInfo').hide();
        $('#_benefiInfo').show();
    });
    $('.btnNextnixa').click(function () {
        $('#_branchInfo').hide();
        $('#_senderInfo').hide();
        $('#_benefiInfo').hide();
        $('#_amountInfo').show();
    });
    $('.btnNextnixani').click(function () {
        $('#_branchInfo').hide();
        $('#_senderInfo').hide();
        $('#_benefiInfo').hide();
        $('#_amountInfo').hide();
        $('#_payoutInfo').show();
    });
    //for Button Prev//
    $('.btnPrev1').click(function () {
        $('#_senderInfo').hide();
        $('#_benefiInfo').hide();
        $('#_payoutInfo').hide();
        $('#_branchInfo').show();
    });
    $('.btnPrev2').click(function () {
        $('#_benefiInfo').hide();
        $('#_amountInfo').hide();
        $('#_payoutInfo').hide();
        $('#_senderInfo').show();
    });
    $('.btnPrev3').click(function () {
        $('#_benefiInfo').show();
        $('#_amountInfo').hide();
        $('#_payoutInfo').hide();
    });
    $('.btnPrev4').click(function () {
        $('#_amountInfo').show();
        $('#_payoutInfo').hide();
    });
    //for searching kptn//
    $('#kptnSearch').click(function () {
        if ($('#kptn').val().trim() == "") {
            alert('Please input kptn first..');
        }else if ($('#kptn').val().trim() != "") {
            $.ajax({
                url: "/SendoutCancel/SearchKptn",
                data: { kptn: $('#kptn').val() },
                type: "post",
                datatype: "json",
                success: function (data) {
                    if (data["response"] == "0") {
                        alert(data["message"]);
                        $('#tXDate').empty(data["transactionDate"]);
                        $('#sDName').empty(data["senderName"]);
                        $('#rVName').empty(data["receiverName"]);
                        $('#psWord').empty(data["password"])
                    }
                    else {
                        $('#tXDate').text(data["transactionDate"]);
                        $('#sDName').text(data["senderName"]);
                        $('#rVName').text(data["receiverName"]);
                        $('#psWord').text(data["password"]);
                    }
                },
                error: function (data) {
                    alert("Error ni xa...");
                }
            });
        }
    });
    //Getting all data after searching kptn
    $("tr#info td").dblclick(function (e) {
        $('#paneltwo').show();
        $('.forSendFormClick').click(function (e) {
            $.ajax({
                url: "/SendoutCancel/SearchKptn",
                data: { kptn: $("#kptn").val() },
                type: "post",
                datatype: "json",
                success: function (data) {
                    $("#IR").val(data["irNumber"]);
                    $("#cancelReason").val(data["cancelReason"]);
                    $("#branch").val(data["branch"]);
                    $("#controlNo").val(data["controlNo"]);
                    $("#operatoR").val(data["operatoR"]);
                    $("#reason").val(data["reason"]);
                    $("#Senderidtype").val(data["Senderidtype"]);
                    $("#Senderidno").val(data["Senderidno"]);
                    $("#SenderexpiryDate").val(data["SenderexpiryDate"]);
                    $("#SenderfirstName").val(data["SenderfirstName"]);
                    $("#SendermiddleName").val(data["SendermiddleName"]);
                    $("#SenderlastName").val(data["SenderlastName"]);
                    $("#Senderstreet").val(data["Senderstreet"])
                    $("#Sendercountry").val(data["Sendercountry"])
                    $("#Senderprovince").val(data["Senderprovince"])
                    $("#Senderbday").val(data["Senderbday"])
                    $("#Sendergender").val(data["Sendergender"])
                    $("#Sendercontactno").val(data["Sendercontactno"])
                    $("#Sendersourceoffund").val(data["Sendersourceoffund"])
                    $("#BfirstName").val(data["BfirstName"])
                    $("#BmiddleName").val(data["BmiddleName"])
                    $("#BlastName").val(data["BlastName"])
                    $("#Bstreet").val(data["Bstreet"])
                    $("#Bcountry").val(data["Bcountry"])
                    $("#Bprovince").val(data["Bprovince"])
                    $("#Bbday").val(data["Bbday"])
                    $("#Bgender").val(data["Bgender"])
                    $("#Bcontactno").val(data["Bcontactno"])
                    $("#Brelationtosender").val(data["Brelationtosender"])
                }
            });
        });
    });
    //error message hide//
    //$('#user').keypress(function () {
    //    $('#errorMsg').hide();
    //});
    //$('#password').keypress(function () {
    //    $('#errorMsg').hide();
    //});

    $('#password').on('keyup', function () {
        if ($(this).val()) {
            $('#fordaeye').removeClass('fadeOn');
            $('#fordaeye').addClass('fadeOff');
        }
        else {
            $('#fordaeye').removeClass('fadeOff');
            $('#fordaeye').addClass('fadeOn');
        }
    });
    $('#fordaeye').mousedown(function () {
        $("#password").attr('type', 'text');
                }).mouseup(function () {
        $("#password").attr('type', 'password');
                }).mouseout(function () {
        $("#password").attr('type', 'password');
    });
});


