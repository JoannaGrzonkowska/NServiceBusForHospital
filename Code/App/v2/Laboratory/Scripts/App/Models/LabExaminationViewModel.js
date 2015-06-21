function LabExaminationViewModel(data) {
    var self = this;

    this.PatientDieseaseId = ko.observable(data.PatientDieseaseId);

    this.PatientInfo = new PatientsModel(data.PatientInfo);
    this.LabComment = new
        LabExaminationCommentViewModel(data.LabComment);
    this.examinationDescriptionLab= ko.observable();

};