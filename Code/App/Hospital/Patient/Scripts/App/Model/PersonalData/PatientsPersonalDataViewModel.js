function PatientPersonalDataViewModel(data) {
    var self = this;

    this.Info = new PatientsModel(data.Info);

    this.PatientsDieseases = ko.observableArray([]);

    if (data.PatientsDieseases != null) {
        data.PatientsDieseases.forEach(function (item) {
            self.PatientsDieseases.push(new PatientsDieseasesModel(item));
        });
    };

    this.DieseasesTypes = ko.observableArray([]);

    if (data.DieseasesTypes != null) {
        data.DieseasesTypes.forEach(function (item) {
            self.DieseasesTypes.push(new DieseasesModel(item));
        });
    };

    //this.PatientLocalizations = new PatientLocalizations(data.PatientLocalizations);

    this.DieseasesDescriptionMaxLength = ko.observable(data.DieseasesDescriptionMaxLength);

};