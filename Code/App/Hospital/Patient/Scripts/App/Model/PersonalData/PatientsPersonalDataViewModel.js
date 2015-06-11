function PatientPersonalDataViewModel(data) {
    var self = this;

    this.Info = new PatientsModel(data.Info);

    this.PatientDieseases = ko.observableArray([]);

    if (data.PatientDieseases != null) {
        data.PatientDieseases.forEach(function (item) {
            self.PatientDieseases.push(new PatientsDieseasesModel(item));
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