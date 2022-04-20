$(document).ready(function () {
    loadData();
});

function loadData() {
    $.ajax(
        {
            url: "/Home/SelectAll",
            type: "GET",
            contentType: "application/json;charset=utf-8",
            dataType: "json",
            success: function (result) {
                console.log(result);

                let html = "";
                $.each(result, function (index, item) {
                    html += "<tr>";
                    html += "<td>" + item.Empno + "</td>";
                    html += "<td>" + item.Ename + "</td>";
                    html += "<td>" + item.Job + "</td>";
                    html += "<td>" + item.MGR + "</td>";
                    html += "<td>" + item.HireDate + "</td>";
                    html += "<td>" + item.Sal + "</td>";
                    html += "<td>" + item.Comm + "</td>";
                    html += "<td>" + item.Deptno + "</td>";
                    html += '<td><a href="#" onclick="return selectByEmpno(' + item.Empno + ')">Edit</a> | <a href="#" onclick="Delete(' + item.Empno + ')">Delete</a></td>';
                    html += "</tr>";
                });
                $('.tbody').html(html);
            },
            error: function (errmsg) {
                alert(errmsg.responseText);
            }
        }
    );
}

function selectByEmpno(empID) {
    $.ajax(
        {
            url: "/Home/SelectByEmpno/" + empID,
            type: "POST",
            contentType: "application/json;charset=utf-8",
            dataType: "json",
            success: function (result) {
                console.log(result);
                empno: $('#Empno').val(result.Empno);
                ename: $('#Ename').val(result.Ename);
                job: $('#Job').val(result.Job);
                mgr: $('#MGR').val(result.MGR);
                hiredate: $('#HireDate').val(result.HireDate);
                sal: $('#Sal').val(result.Sal);
                comm: $('#Comm').val(result.Comm);
                deptno: $('#Deptno').val(result.Deptno);

                $('#myModal').modal('show');
                $('#btnUpdate').show();
                $('#btnAdd').hide();
            },
            error: function (errmsg) {
                alert(errmsg.responseText);
            }
        }
    );
}
function Insert() {
    // 추가할 데이터 JSON으로 받아오기

    let empobj = {
        empno: $('#Empno').val(),
        ename: $('#Ename').val(),
        job: $('#Job').val(),
        mgr: $('#MGR').val(),
        hiredate: $('#HireDate').val(),
        sal: $('#Sal').val(),
        comm: $('#Comm').val(),
        deptno: $('#Deptno').val()
    };
    $.ajax(
        {
            url: "/Home/Insert",
            data: JSON.stringify(empobj),
            type: "POST",
            contentType: "application/json;charset=utf-8",
            dataType: "json",
            success: function (result) {
                loadData(); // 비동기 조회 함수 호출
                //console.log(result);
                $('#myModal').modal('hide');
            },
            error: function (errmsg) {
                alert(errmsg.responseText);
            }
        }
    );
}
function Update() {
    let res = validate();
    if (res == false) {
        return false;
    }
    let empobj = {
        empno: $('#Empno').val(),
        ename: $('#Ename').val(),
        job: $('#Job').val(),
        mgr: $('#MGR').val(),
        hiredate: $('#HireDate').val(),
        sal: $('#Sal').val(),
        comm: $('#Comm').val(),
        deptno: $('#Deptno').val()
    };
    $.ajax(
        {
            url: "/Home/Update",
            data: JSON.stringify(empobj),
            type: "POST",
            contentType: "application/json;charset=utf-8",
            dataType: "json",
            success: function (result) {
                loadData(); // 비동기 조회 함수 호출
                //console.log(result);
                $('#myModal').modal('hide');
                empno: $('#Empno').val("");
                ename: $('#Ename').val("");
                job: $('#Job').val("");
                mgr: $('#MGR').val("");
                hiredate: $('#HireDate').val("");
                sal: $('#Sal').val("");
                comm: $('#Comm').val("");
                deptno: $('#Deptno').val("");
            },
            error: function (errmsg) {
                alert(errmsg.responseText);
            }
        }
    );
}
function Delete(ID) {
    let answer = confirm("정말 삭제하시겠습니까?");
    if (answer) {
        $.ajax(
            {
                url: "/Home/Delete/" + ID,
                type: "POST",
                contentType: "application/json;charset=utf-8",
                dataType: "json",
                success: function (result) {
                    loadData(); // 비동기 조회 함수 호출
                },
                error: function (errmsg) {
                    alert(errmsg.responseText);
                }
            }
        );
    }
}
function clearTextBox() {
    empno: $('#Empno').val("");
    ename: $('#Ename').val("");
    job: $('#Job').val("");
    mgr: $('#MGR').val("");
    hiredate: $('#HireDate').val("");
    sal: $('#Sal').val("");
    comm: $('#Comm').val("");
    deptno: $('#Deptno').val("");
    $('#btnUpdate').hide();
    $('#btnAdd').show();
    $('#Empno').css('border-color', 'lightgrey');
    $('#Ename').css('border-color', 'lightgrey');
    $('#Job').css('border-color', 'lightgrey');
    $('#MGR').css('border-color', 'lightgrey');
    $('#HireDate').css('border-color', 'lightgrey');
    $('#Sal').css('border-color', 'lightgrey');
    $('#Comm').css('border-color', 'lightgrey');
    $('#Deptno').css('border-color', 'lightgrey');
}
//Valdidation using jquery  
function validate() {
    var isValid = true;
    if ($('#Empno').val().trim() == "") {
        $('#Empno').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#Empno').css('border-color', 'lightgrey');
    }
    if ($('#Ename').val().trim() == "") {
        $('#Ename').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#Ename').css('border-color', 'lightgrey');
    }
    if ($('#Job').val().trim() == "") {
        $('#Job').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#Job').css('border-color', 'lightgrey');
    }
    if ($('#MGR').val().trim() == "") {
        $('#MGR').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#MGR').css('border-color', 'lightgrey');
    }
    if ($('#HireDate').val().trim() == "") {
        $('#HireDate').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#HireDate').css('border-color', 'lightgrey');
    }
    if ($('#Sal').val().trim() == "") {
        $('#Sal').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#Sal').css('border-color', 'lightgrey');
    }
    if ($('#Comm').val().trim() == "") {
        $('#Comm').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#Comm').css('border-color', 'lightgrey');
    }
    if ($('#Deptno').val().trim() == "") {
        $('#Deptno').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#Deptno').css('border-color', 'lightgrey');
    }
    return isValid;
}