$(document).ready(function() {
    // Make the GET request when the page loads
    $.getJSON("https://localhost:8002/api/student", function(data) {
        // Find the select element
        var $select = $('#select-student');
        
        // Clear the current options (if any)
        $select.empty();
        
        // Populate the select with options from the JSON data
        $.each(data, function(index, student) {
            $select.append($('<option>', {
                value: student.id,  // Set the value to the student's ID
                text: student.name  // Set the text to the student's name
            }));
        });
    }).fail(function() {
        console.log("Error fetching data from server");
    });
});


function navigateToFeedback(event){
    event.preventDefault();

    const id = document.getElementById('select-student').value;
    window.location.href = 'Student-Feedback.html?id='+id;
}