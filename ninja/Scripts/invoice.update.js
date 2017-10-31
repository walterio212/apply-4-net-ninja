$(document).ready(function () {
    $("#agregarDetalle").on("click", function () {
        $.ajax({
            url: urlAddDetail
        }).success(function (partialView) {
            $('#detallesBody').append(partialView);
        });
    });
});