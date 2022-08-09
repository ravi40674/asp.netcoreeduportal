$(document).ready(function () {
    $("#RoleID").select2();

    var view = $("input[name='chkView']");
    var add = $("input[name='chkAdd']");
    var edit = $("input[name='chkEdit']");
    var del = $("input[name='chkDelete']");
    var details = $("input[name='chkDetail']");
    //var approval = $("input[name='chkApproval']");
    if (view.length == view.filter(":checked").length)
        $("#chkViewAll").prop('checked', true)
    if (add.length == add.filter(":checked").length)
        $("#chkAddAll").prop('checked', true);
    if (edit.length == edit.filter(":checked").length)
        $("#chkEditAll").prop('checked', true);
    if (del.length == del.filter(":checked").length)
        $("#chkDeleteAll").prop('checked', true);
    if (details.length == details.filter(":checked").length)
        $("#chkDetailAll").prop('checked', true);
    //if (approval.length == approval.filter(":checked").length)
    //    $("#chkApprovalAll").prop('checked', true);
    setTimeout(function () {
        if ((view.length == view.filter(":checked").length) && (add.length == add.filter(":checked").length) && (edit.length == edit.filter(":checked").length) && (del.length == del.filter(":checked").length) && (details.length == details.filter(":checked").length)) {
            $("INPUT[name='chkSelectAll']").prop('checked', true);
            $("INPUT[name='chkMain']").prop('checked', true);
            $("INPUT[name='chkSubMain']").prop('checked', true);
            $("INPUT[name='chkAll']").prop('checked', true);
            $("#chkViewAll").prop('checked', true);
            $("#chkAddAll").prop('checked', true);
            $("#chkEditAll").prop('checked', true);
            $("#chkDeleteAll").prop('checked', true);
            $("#chkDetailAll").prop('checked', true);
        //    $("#chkApprovalAll").prop('checked', true);
        }
    }, 100);
    $("#chkSelectAll")
});

function getPrivileges(id) {
    document.forms[1].submit();
    $("#RoleID").val() == 0;
}