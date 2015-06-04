var LaboratoriumService = function (urls) {
    var self = this;
    self.urls = urls;

    self.wyslijWynikZLab = function (data, handler) {

        $.ajaxSetup({ cache: false });

        $.post("/Home/WyslijWynikZLab", data, function (result) {
            handler(result);
            if (result.IsSuccess === false) {
                alert(result.Errors.join('\n'));
            }
        }, 'json').fail(function (response) {
            alert(response);
        });
    }
};