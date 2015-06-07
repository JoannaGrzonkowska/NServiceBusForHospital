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

    self.getAlergies = function (handler) {    
        $.ajaxSetup({ cache: false });
        $.getJSON(self.urls.getAlergies, function (result) {
            var mappedData = $.map(result, function (item) {
                return new PatientAlergyModel(item);
            });
            handler(mappedData);
        }).fail(function (response) {
            showErrorMessage(response);
        });
    };

    self.addAlergy = function (data, handler) {      
        $.ajaxSetup({ cache: false });
        $.post(self.urls.addAlergy, data, function (result) {
            handler(result);
            if (result.IsSuccess === false) {
                showError(result.Errors.join('\n'));
            }
        }, 'json').fail(function (response) {
            showErrorMessage(response);
        });
    }
};