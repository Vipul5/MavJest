$(document).ready(function () {
    console.log("ready!");
    GetSeatingArrangement();
    GetTodaysActivityForStudent(1);
});

function GetSeatingArrangement() {
    $.ajax({
        url: 'https://localhost:7102/api/activity/gettodaysseatingplan',
        type: 'GET',
        dataType: 'json',
        async: true,
        success(response) {
            console.log(response);
        },
        error(jqXHR, status, errorThrown) {
            alert(status);
        },

    });
}

function GetTodaysActivityForStudent(studentId) {
    debugger;
    $.ajax({
        url: 'https://localhost:7102/api/activity/gettodaysactivity/',
        type: 'GET',
        dataType: 'json',
        data: { studentId: studentId },
        async: true,
        success(response) {
            console.log(response);
        },
        error(jqXHR, status, errorThrown) {
            alert(status);
        },

    });
}