function BuildSearchParamInputControls() {
    var row = '';

    if (SearchParamCount == 0) {
        ShowEmptySearchParamRow();
        return;
    }

    var ControlTypes = { "TextBox": "TextBox", "NumericTextBox": "NumericTextBox", "DropdownList": "DropdownList", "DateTime": "DateTime" };

    if (UserSearchParam) {

        $(UserSearchParam).each(function (index) {

            row += "<tr>"
            row += "<td>" + UserSearchParam[index].FieldName + "</td>"

            switch (UserSearchParam[index].ControlType) {
                case ControlTypes.TextBox:
                    row += "<td><input type='text' class='form-control' id=" + UserSearchParam[index].FieldName + "></td>"
                    break;
                case ControlTypes.NumericTextBox:
                    row += "<td><input type='number' value=0.00 min=0.00 max=9.99 step=0.01 class='form-control' id=" + UserSearchParam[index].FieldName + "></td>"
                    break;
                case ControlTypes.DropdownList:
                    row += "<td>" + GetDropDownOptions(UserSearchParam[index].FieldName) + "</td>"
                    break;
                case ControlTypes.DateTime:
                    row += "<td><input type='date' class='form-control' id=" + UserSearchParam[index].FieldName + "></td>"
                    break;
                default:
                    row += "<td><input type='text' class='form-control' id=" + UserSearchParam[index].FieldName + "></td>"
                    break;
            }
            row += "</tr>"
        });

        document.getElementById('tblParamSearchBody').innerHTML = row;
    }
}

function GetDropDownOptions(FieldName) {    

    var result = '';

    result += '<select class="form-control" id=' + FieldName + ' name=' + FieldName + '>'
    result += '<option value=""> --- Select ---</option>'

    if (FieldName == "UserName") {
        $(UserNameList).each(function (index) {
            result += '<option value = ' + UserNameList[index].value + ' > ' + UserNameList[index].text + ' </option>'
        });
    }
    else if (FieldName == 'Role') {
        $(RoleList).each(function (index) {
            result += '<option value = ' + RoleList[index].value + ' > ' + RoleList[index].text + ' </option>'
        });
    }
    else if (FieldName == 'Department') {
        $(DepartmentList).each(function (index) {
            result += '<option value = ' + DepartmentList[index].value + ' > ' + DepartmentList[index].text + ' </option>'
        });
    }

    result += '</select>'

    return result;
}

function BuildUserSearchResultTable() {

    var row = '';
    var col = [];

    if (UserSearchResult) {

        document.getElementById('tblUserDisplayBody').innerHTML = '';

        for (var i = 0; i < UserSearchResult.length; i++) {
            for (var key in UserSearchResult[i]) {
                if (col.indexOf(key) === -1) {
                    col.push(key);
                }
            }
        }

        for (var i = 0; i < UserSearchResult.length; i++) {
            row += '<tr>'
            for (var j = 0; j < col.length; j++) {
                row += '<td>' + UserSearchResult[i][col[j]] + '</td>'
            }
            row += '</tr>'
        }

        document.getElementById('tblUserDisplayBody').innerHTML = row;

    }
    else {
        ShowEmptySearchResultRow();
    }
}

function ShowEmptySearchParamRow() {

    var row = '';

    if (SearchParamCount == 0) {
        document.getElementById('tblParamSearchBody').innerHTML = ''
        row = '';
        row += '<tr>'
        row += '<td colspan=2>No Search Param to Display.</td>'
        row += '</tr>'
        document.getElementById('tblParamSearchBody').innerHTML = row;

        document.getElementById("btnSearch").disabled = true;
    }
}

function ShowEmptySearchResultRow() {

    var row = '';

    UserSearchResultCount = UserSearchResult.length;

    if (UserSearchResultCount == 0) {
        document.getElementById('tblUserDisplayBody').innerHTML = ''
        row = '';
        row += '<tr>'
        row += '<td colspan=11>No Search Results to Display.</td>'
        row += '</tr>'
        document.getElementById('tblUserDisplayBody').innerHTML = row;
    }
}