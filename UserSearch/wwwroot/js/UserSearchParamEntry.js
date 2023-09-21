function CheckIfSearchFieldPresent(FieldName) {

    var flgPresent = false;
    var col = [];

    if (UserSearchParam) {

        for (var i = 0; i < UserSearchParam.length; i++) {
            for (var key in UserSearchParam[i]) {
                if (col.indexOf(key) === -1) {
                    col.push(key);
                }
            }
        }

        for (var i = 0; i < UserSearchParam.length; i++) {

            if (UserSearchParam[i][col[0]] == FieldName) {
                flgPresent = true;
                break;
            }

        }
    }

    return flgPresent;
}

function BuildUserSearchParamTable() {

    var row = '';
    var col = [];
    SearchParamCount = UserSearchParam.length;

    if (SearchParamCount == 0) {
        ShowEmptyParamRow();
        return;
    }

    if (UserSearchParam) {

        document.getElementById('tblParamstblBody').innerHTML = '';

        for (var i = 0; i < UserSearchParam.length; i++) {
            for (var key in UserSearchParam[i]) {
                if (col.indexOf(key) === -1) {
                    col.push(key);
                }
            }
        }

        for (var i = 0; i < UserSearchParam.length; i++) {
            row += '<tr>'
            for (var j = 0; j < col.length; j++) {
                row += '<td>' + UserSearchParam[i][col[j]] + '</td>'
            }
            row += '<td><input type="button" class="btn btn-danger" id="btnParamDelete" onclick="HandleDelete(this)" value="Delete"></td>'
            row += '</tr>'
        }
        document.getElementById('tblParamstblBody').innerHTML = row;
        document.getElementById("btnParamSave").disabled = (SearchParamCount < 3);
    }

}

function ShowEmptyParamRow() {

    var row = '';

    SearchParamCount = UserSearchParam.length;

    if (SearchParamCount == 0) {

        document.getElementById('tblParamstblBody').innerHTML = ''
        row = '';
        row += '<tr>'
        row += '<td colspan=5>No Search Parameters to Display.</td>'
        row += '</tr>'
        document.getElementById('tblParamstblBody').innerHTML = row;
        document.getElementById("btnParamSave").disabled = (SearchParamCount < 3);
    }
    else {
        document.getElementById("btnParamSave").disabled = (SearchParamCount < 3);
    }
}

function HandleDelete(ctl) {

    var result = confirm("Are you sure to delete the current row?");

    if (result) {

        // Identify the fieldname from the current deleting row.
        var FieldName = ctl.parentNode.parentNode.cells[0].textContent;

        // Remove the current table row.
        $(ctl).parents("tr").remove();

        // Remove the json array of the field.
        $(UserSearchParam).each(function (index) {
            if (UserSearchParam[index].FieldName == FieldName) {
                UserSearchParam.splice(index, 1);
                return false;
            }
        });

        SearchParamCount = UserSearchParam.length;

        if (SearchParamCount == 0) {
            ShowEmptyParamRow()
        };

        document.getElementById("btnParamSave").disabled = (SearchParamCount < 3);
    }

    SearchParamCount = UserSearchParam.length;
}