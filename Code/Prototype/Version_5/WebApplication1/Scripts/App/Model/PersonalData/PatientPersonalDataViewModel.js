function PatientPersonalDataViewModel(data) {
    var self = this;

    this.Info = new PatientInfoViewModel(data.Info);

    this.PatientAlergies = ko.observableArray([]);

    if (data.PatientAlergies != null) {
        data.PatientAlergies.forEach(function (item) {
            self.PatientAlergies.push(new PatientAlergyViewModel(item));
        });
    };

    this.AlergyTypes = ko.observableArray([]);

    if (data.AlergyTypes != null) {
        data.AlergyTypes.forEach(function (item) {
            self.AlergyTypes.push(new AlergyTypeViewModel(item));
        });
    };

    this.PatientLocalizations = new PatientLocalizations(data.PatientLocalizations);

    this.AlergyDescriptionMaxLength = ko.observable(data.AlergyDescriptionMaxLength);

};