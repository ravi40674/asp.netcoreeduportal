function AddProductDetailRow(table) {
    $.ajax({
        url: "Invoice/_ProductItemDetail",
        dataType: 'html',
        success: function (data) {
            $("#tblProductDetail tbody").append(data);
        }
    });

}


function RemoveProductDetail(element) {
    $(element).parents("tr").remove();
    return false;
}

function LoadProductDetailControls() {

    var firstRow = $("#tblProductDetail tbody").find("tr:first");
    if (firstRow.length > 0) {
        var removeicon = firstRow.find("a[class=remove]");
        if (removeicon != null) {
            removeicon.remove();
        }
    }

    $('.productDetailFromDate').datetimepicker({
        format: 'DD/MM/YYYY',
        maxDate: new Date(),
        viewMode: 'years',
        format: 'MM/YYYY',
        widgetPositioning: {
            horizontal: 'left',
            vertical: 'bottom'
        }
    });

    $('.productDetailToDate').datetimepicker({
        format: 'DD/MM/YYYY',
        maxDate: new Date(),
        viewMode: 'years',
        format: 'MM/YYYY',
        widgetPositioning: {
            horizontal: 'left',
            vertical: 'bottom'
        }
    });

    $(".productDetailFromDate").on("dp.change", function (e) {
        $('.productDetailToDate').data("DateTimePicker").minDate(e.date);
    });

    $(".productDetailToDate").on("dp.change", function (e) {
        $('.productDetailFromDate').data("DateTimePicker").maxDate(e.date);
    });
}
