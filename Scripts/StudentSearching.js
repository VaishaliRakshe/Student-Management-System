
$(document.body).on("click", "#SearchBtn", function () {
    var vm = {};
    //var id = $("#ProductId").val();
    //vm.ProductName = $("#ProductName").val();
    vm.PhoneNumber = $("#Search").val();
    //vm.Image = $("#Image").val();


    $.ajax({
        url: "/StudentRegistration/Search",
        data: vm,
        type: "POST",
        success: function (e) {

            alert(e);
        }
    });
});


$(document).on("click", "#btnReport", function () {

    $.ajax({
        url: "/StudentRegistration/GetReport",
        type: "POST",
        contentType: "application/json; charset=utf-8",
        success: function (data) {
            if (data != "" && data != null) {
                setTimeout(function () {
                    $("#pdf").attr("href", data);
                    var reportBox = $("#pdf").fancybox({
                        'frameWidth': 850,
                        'frameHeight': 495,
                        'overlayShow': true,
                        'hideOnContentClick': false,
                        'type': 'iframe',
                        helpers: {
                            // prevents closing when clicking OUTSIDE fancybox
                            overlay: { closeClick: false }
                        }
                    }).trigger('click');
                }, 1000);
            }
        }
    });
});


$(document).on("click", "#btnStudentReport", function () {

    var studentId = $("#id").val();

    $.ajax({
        url: "/StudentRegistration/StudentDitailsReport?studentId=" + studentId,
        type: "POST",
        contentType: "application/json; charset=utf-8",
        success: function (data) {
            if (data != "" && data != null) {
                setTimeout(function () {
                    $("#pdf").attr("href", data);
                    var reportBox = $("#pdf").fancybox({
                        'frameWidth': 850,
                        'frameHeight': 495,
                        'overlayShow': true,
                        'hideOnContentClick': false,
                        'type': 'iframe',
                        helpers: {
                            // prevents closing when clicking OUTSIDE fancybox
                            overlay: { closeClick: false }
                        }
                    }).trigger('click');
                }, 1000);
            }
        }
    });
});

//$(document).ready(function() {
//    $('#LoadDataTable').DataTable({
//        "ajax": {
//            "url": "/StudentRegistration/TableDataLoad",
//            "type": "GET",
//            "datatype": "json"
//        },
//        "columns": [
//            { "data": "Semester", "autoWidth": true },
//            { "data": "Amount", "autoWidth": true }
//        ]
//});
//});

