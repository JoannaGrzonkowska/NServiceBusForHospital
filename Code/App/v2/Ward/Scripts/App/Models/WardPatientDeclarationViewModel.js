function WardPatientDeclarationViewModel(data) {
    var self = this;

    this.PatientInfo = new PatientsModel(data.PatientInfo);

    this.DieseaseLogs = ko.observableArray([]);
    this.DieseaseLogs.push(new DieseaseLogs(data));
};