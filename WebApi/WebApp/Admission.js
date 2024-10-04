$(document).ready(function () {
    console.log("ready!");
    GetSeatingArrangement();
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