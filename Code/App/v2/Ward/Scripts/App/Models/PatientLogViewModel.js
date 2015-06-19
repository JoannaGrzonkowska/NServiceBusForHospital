function PatientLogViewModel(data) {
    var self = this;

    this.PatientId = ko.observable(data.PatientId);
    this.ExaminationName = ko.observable(data.ExaminationName);
    this.Comment = ko.observable(data.Comment);

};