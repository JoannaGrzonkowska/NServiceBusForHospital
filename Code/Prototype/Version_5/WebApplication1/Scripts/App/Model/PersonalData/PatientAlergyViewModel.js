function PatientAlergyViewModel(data) {
    var self = this;

    this.AlergyId = ko.observable(data.AlergyId);
    this.AlergyName = ko.observable(data.AlergyName);
    this.Description = ko.observable(data.Description);
    this.WhenDiagnosed = ko.observable(data.WhenDiagnosed);

};