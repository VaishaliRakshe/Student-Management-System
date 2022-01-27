$(document.body).on("click", "#btnSubmit", function() {
    var dto = {};
    var id = $("#id").val();
    dto.Name = $("#Name").val();
    dto.IdCardNo = $("#idCard_No").val();
    dto.FatherName = $("#Father_Name").val();
    dto.MotherName = $("#Mother_Name").val();
    dto.Department = $("#Department").val();
    dto.PhoneNo = $("#Phone_No").val();
    dto.Semester = $("#Semester").val();
    dto.Amount = $("#Amount").val();

    if (id == "" || id == 0 || id == null) {
        $.ajax({
            url: "/StudentRegistration/FeeSave",
            data: dto,
            type: "POST",
            success: function(e) {
                if (e > 0) {
                    toastr.success("Save Success", "Success!!!");
                    refresh();
                } else {
                    toastr.warning("Save Fail", "Warning!!!");
                }
            },
            error: function (request, status, error) {
                var response = jQuery.parseJSON(request.responseText);
                toastr.error(response.message, "Error");
            }
        });
    }
});

function refresh() {
    $("#Amount").val("");
}

