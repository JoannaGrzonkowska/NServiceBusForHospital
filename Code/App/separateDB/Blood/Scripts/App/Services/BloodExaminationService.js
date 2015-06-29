var BloodExaminationService = function (urls) {
    var self = this;
    self.urls = urls;

    self.sendToLab = function (data, handler) {
        $.ajaxSetup({ cache: false });
        $.post(self.urls.sendToLab, data, function (result) {
            handler(result);
            if (result.IsSuccess === false) {
                showError(result.Errors.join('\n'));
            }
        }, 'json').fail(function (response) {
            showErrorMessage(response);
        });
    }
};