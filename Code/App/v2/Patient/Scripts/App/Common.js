function showErrorMessage(response) {
    var message = "An error has occured.";
    if (typeof response !== 'undefined') {
        if (response.status == 406) {
            message = response.responseJSON;
        } else if (typeof response == 'string' || response instanceof String) {
            message = response;
        }
    }

    showError(message);
}

function showError(message) {
    $("#errorModal-content").text(message);
    $('#errorModal').modal('show');
}