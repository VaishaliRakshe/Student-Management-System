

$(document.body).on("click", "#btnSubmit", function () {
    var dto = {};
    var id = $("#Id").val();
    dto.phoneNumber = $("#PhoneNumber").val();
    dto.message = $("#Description").val();
    dto.which = 1;
    var radioValue = $("input[name='SmsType']:checked").val();
    if (radioValue == "All") {
        dto.smsType = 1;
    } else if (radioValue == "Active") {
        dto.smsType = 2;
    } else if (radioValue == "DeActive") {
        dto.smsType = 3;
    } else if (radioValue == "DeActive") {
        dto.smsType = 4;
    }

    if (id == "" || id == 0 || id == null) {
        $.ajax({
            url: "/SmsSend/SmsSending",
            data: dto,
            type: "POST",
            success: function (e) {
                if (e > 0)
                {
                    toastr.success("Message Successfully Sent", "Success!!!");
                    refreshForm();
                }
                else
                {
                    toastr.warning("Sending Fail", "Warning!!!");
                }
            },
            error: function (request, status, error) {
                var response = jQuery.parseJSON(request.responseText);
                toastr.error(response.message, "Error");
            }
        });
    }
});

function refreshForm() {
    $("#Id").val("");
    $("#PhoneNumber").val("");
    $("#Description").val("");
}
