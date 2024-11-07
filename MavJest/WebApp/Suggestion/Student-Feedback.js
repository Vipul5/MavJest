$(document).ready(function() {
    const urlParams = new URLSearchParams(window.location.search);
    const id = urlParams.get('id');
    // Make the GET request when the page loads
    $.get("https://localhost:9002/api/Academic/summary?id=" + id, function(data) {
        // Find the select element
        $("#academic-summary-text").html(data);
    }).fail(function(ex) {
        console.log(ex);
        console.log("Error fetching data from server");
    });

    $.getJSON("https://localhost:9002/api/Academic/profile?id=" + id, function(data) {
        // Find the select element
        $("#academic-english-title").html(data.englishSummary.title);
        $("#academic-english-feedback").html(data.englishSummary.summary);
        
        $("#academic-hindi-title").html(data.hindiSummary.title);
        $("#academic-hindi-feedback").html(data.hindiSummary.summary);
        
        $("#academic-math-title").html(data.mathSummary.title);
        $("#academic-math-feedback").html(data.mathSummary.summary);
    }).fail(function(ex) {
        console.log(ex);
        console.log("Error fetching data from server");
    });
    
    $.get("https://localhost:9002/api/Activity/summary?id=" + id, function(data) {
        // Find the select element
        $("#activity-summary-text").html(data);
    }).fail(function(ex) {
        console.log(ex);
        console.log("Error fetching data from server");
    });
    
    $.get("https://localhost:9002/api/Activity/participation?id=" + id, function(data) {
        // Find the select element
        $("#participation-summary-text").html(data);
    }).fail(function(ex) {
        console.log(ex);
        console.log("Error fetching data from server");
    });
    
    $.get("https://localhost:9002/api/Behaviour/title?id=" + id, function(data) {
        // Find the select element
        $("#behavior-title").html(data);
    }).fail(function(ex) {
        console.log(ex);
        console.log("Error fetching data from server");
    });
    
    $.get("https://localhost:9002/api/Behaviour/summary?id=" + id, function(data) {
        // Find the select element
        $("#behavior-summary-text").html(data);
    }).fail(function(ex) {
        console.log(ex);
        console.log("Error fetching data from server");
    });

    $.getJSON("http://localhost:8001/api/student/" + id, function(data) {
        $("#student_name").html(data.name);
        $("#student_image").attr("src", "../images/" + data.image);
    }).fail(function() {
        console.log("Error fetching data from server");
    });

    $.getJSON("http://localhost:8001/api/AcademicHistory/" + id, function(data) {
        setTimeout(function(){
            $("#academic_overall_score").html(data.overallScore);
            $("#academic_english_score").html(data.englishScore);
            $("#academic_hindi_score").html(data.hindiScore);
            $("#academic_math_score").html(data.mathScore);
        }, 2000);
    }).fail(function() {
        console.log("Error fetching data from server");
    });
    
    $.getJSON("https://localhost:9002/api/Behaviour/profile?id=" + id, function(data) {
        $("#behavior-profile-class").html(data.classBehavior ?? '');
        $("#behavior-profile-social").html(data.socialBehavior ?? '');
        $("#behavior-profile-participant").html(data.engagement ?? '');
    }).fail(function() {
        console.log("Error fetching data from server");
    });
});