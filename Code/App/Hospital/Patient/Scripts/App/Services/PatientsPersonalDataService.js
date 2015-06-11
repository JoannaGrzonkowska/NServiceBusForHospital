var PatientPersonalDataService = function (urls) {
    var self = this;
    self.urls = urls;

    self.getPersonalData = function (handler) {
        $.ajaxSetup({ cache: false });
        $.getJSON("/PatientPersonalData/GetPersonalData", function (result) {
            var mappedData = new PatientPersonalDataViewModel(result);
            handler(mappedData);
        }).fail(function (response) {
            showErrorMessage(response);
        });
    };

    self.getDieseases = function (handler) {
        $.ajaxSetup({ cache: false });
        $.getJSON(self.urls.getDieseases, function (result) {
            var mappedData = $.map(result, function (item) {
                return new PatientsDieseasesModel(item);
            });
            handler(mappedData);
        }).fail(function (response) {
            showErrorMessage(response);
        });
    };

    self.addDiesease = function (data, handler) {
        $.ajaxSetup({ cache: false });
        $.post(self.urls.addDiesease, data, function (result) {
            handler(result);
            if (result.IsSuccess === false) {
                showError(result.Errors.join('\n'));
            }
        }, 'json').fail(function (response) {
            showErrorMessage(response);
        });
    }
};