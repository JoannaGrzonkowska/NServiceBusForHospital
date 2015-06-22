var DirectorService = function (urls) {
    var self = this;
    self.urls = urls;

    self.sendMessageService = function (data, handler) {
        $.ajaxSetup({ cache: false });
        $.post(self.urls.sendMessageService, data, function (result) {
            handler(result);
            if (result.IsSuccess === false) {
                showError(result.Errors.join('\n'));
            }
        }, 'json').fail(function (response) {
            showErrorMessage(response);
        });
    }
};