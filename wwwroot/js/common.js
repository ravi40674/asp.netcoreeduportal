function onlyNumbers(e) {
    var keynum;
    var keychar;
    var charcheck;
    var charCode = (e.which) ? e.which : e.keyCode;
    if (charCode == 8 || charCode == 9 || charCode == 13) {
        return true;
    }
    if (window.event) // IE
    {
        keynum = e.keyCode;
    }
    else if (e.which) // Netscape/Firefox/Opera
    {
        keynum = e.which;
    }
    keychar = String.fromCharCode(keynum);
    charcheck = /[0-9]/;
    return charcheck.test(keychar);
}

function initializeSingleCheckBox(id) {
    var isChecked = $('#' + id).is(':checked');
    $('#' + id).closest('tr').addClass(isChecked ? 'selected-row' : 'not-selected-row');
    $('#' + id).closest('tr').removeClass(isChecked ? 'not-selected-row' : 'selected-row');
    if (isChecked && $('.singleCheckBox').length == $('.selected-row').length)
        $('#allCheckBox').prop('checked', true);
    else
        $('#allCheckBox').prop('checked', false);
}
function initializeAllCheckBox() {
    var isChecked = $('#allCheckBox').is(':checked');
    $('.singleCheckBox').prop('checked', isChecked ? true : false);
    $('.singleCheckBox').closest('tr').addClass(isChecked ? 'selected-row' : 'not-selected-row');
    $('.singleCheckBox').closest('tr').removeClass(isChecked ? 'not-selected-row' : 'selected-row');
}

function populateDropdown(select, data, defaultDisplayLabel) {
    select.html('');    
    select.append($('<option></option>').val("").html(defaultDisplayLabel));
    $.each(data, function (id, option) {
        select.append($('<option></option>').val(option.value).html(option.name));
    });
    $(select).removeAttr("disabled");
}