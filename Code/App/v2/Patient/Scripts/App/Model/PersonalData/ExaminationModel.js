function ExaminationModel(data) {
    var self = this;

    this.Id = ko.observable(data.Id);
    this.PatientDieseaseId = ko.observable(data.PatientDieseaseId);
    this.Comment = ko.observable(data.Comment);
    this.When = ko.observable(data.When);
    this.ExaminationType = ko.observable(data.ExaminationType);
    this.LogType = ko.observable(data.LogType);
};