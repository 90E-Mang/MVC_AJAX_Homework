$(function () {

    loadData();

});

function loadData() {

    $.getJSON("/api/Depts", function (data) {
        let html = "";
        $.each(data, function (index, item) {
            html += '<tr>';
            html += '<td>' + item.DEPTNO + '</td>';
            html += '<td>' + item.DNAME + '</td>';
            html += '<td>' + item.LOC + '</td>';
            html += '<td><a href="#" onclick="return getDeptbyDeptno(' + item.DEPTNO + ')">Edit</a> | <a href="#" onclick="Delete(' + item.DEPTNO + ')">Delete</a></td>';
            html += '</tr>';
        })
        $('.tbody').html(html);

    })
}


function Add() {    
    let res = validate();
    if (res == false) {
        return false;
    }   
    let deptobj = {
        DEPTNO: $("#DeptNo").val(),
        DNAME: $("#Dname").val(),
        LOC: $("#Loc").val(),
    }    
    console.log(deptobj);
    $.ajax(
        {
            url: "/api/Depts",
            data: JSON.stringify(deptobj), //자동으로 객체 매핑 진행
            type: 'POST',
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (result) {
                loadData();
                console.log(result);               
                $('#myModal').modal('hide'); //hide로 다시 숨겨놓기
            },
            error: function (errmsg) {
                alert(errmsg.responseText);
            }


        }
    );
}

function searchByDeptno() {
    let Deptno = $("#txtdeptno").val();
    if (Deptno.trim() == "") {
        console.log("데이터 재전송");
        loadData();
    } else {
        $.getJSON("/api/Depts/" + Deptno, function (data) {
            $(".tbody").empty();
            console.log(data);
            let html = "";
            html += '<tr>';
            html += '<td>' + data.DEPTNO + '</td>';
            html += '<td>' + data.DNAME + '</td>';
            html += '<td>' + data.LOC + '</td>';
            html += '<td><a href="#" onclick="return getDeptbyDeptno(' + data.DEPTNO + ')">Edit</a> | <a href="#" onclick="Delete(' + data.DEPTNO + ')">Delete</a></td>';
            html += '</tr>';
            $('#btnUpdate').show();
            $('#btnAdd').hide();
            $('.tbody').html(html);
        })
    }
}


function getDeptbyDeptno(Deptno) {
    $.getJSON("api/Depts/" + Deptno, function (data) {
        $("#DeptNo").attr("disabled", true);
        $("#DeptNo").val(data.DEPTNO);
        $("#Dname").val(data.DNAME);
        $("#Loc").val(data.LOC);

        $('#myModal').modal('show');
        $("#btnUpdate").show();
        $("#btnAdd").hide();
    }).fail(
        function (errmsg) {
            alert(errmsg.responseText);
        }
    )
}


function Update() {
    let res = validate();
    if (res == false) {
        return false;
    }

    let deptobj = {
        DEPTNO: $("#DeptNo").val(),
        DNAME: $("#Dname").val(),
        LOC: $("#Loc").val(),
    }
    console.log(deptobj);
    $.ajax(
        {
            url: "/api/Depts",
            data: JSON.stringify(deptobj),
            type: 'PUT',
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (result) {
                //$("#btnAdd").show();
                //$("#btnUpdate").hide();
                loadData();
                console.log(result);
                $('#myModal').modal('hide'); //hide로 다시 숨겨놓기
                clearTextBox();
            },
            error: function (errmsg) {
                alert(errmsg.responseText);
            }
        }
    );
}

function Delete(Deptno) {
    let answer = confirm("정말 삭제 하시겠습니까?");//true or fals

    if (answer) {
        $.ajax(
            {
                url: "/api/Depts/" + Deptno,
                type: 'DELETE',
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (result) {
                    loadData(); //비동기 조회 함수 호출(갱신)
                },
                error: function (errmsg) {
                    alert(errmsg.responseText);
                }
            }
        );
    }
}



function clearTextBox() {
    $("#DeptNo").attr("disabled", false);
    $('#btnUpdate').hide();
    $('#btnAdd').show();
    $('#DeptNo').val("");
    $('#Dname').val("");
    $('#Loc').val("");

    $('#DeptNo').css('border-color', 'lightgrey');
    $('#Dname').css('border-color', 'lightgrey');
    $('#Loc').css('border-color', 'lightgrey');
}
//Valdidation using jquery  
function validate() {
    var isValid = true;
    if ($('#DeptNo').val().trim() == "") {
        $('#DeptNo').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#DeptNo').css('border-color', 'lightgrey');
    }
    if ($('#Dname').val().trim() == "") {
        $('#Dname').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#Dname').css('border-color', 'lightgrey');
    }
    if ($('#Loc').val().trim() == "") {
        $('#Loc').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#Loc').css('border-color', 'lightgrey');
    }
    return isValid;
}