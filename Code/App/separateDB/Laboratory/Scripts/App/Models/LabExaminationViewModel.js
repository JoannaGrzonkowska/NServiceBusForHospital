function LabExaminationViewModel(data) {
    var self = this;

    this.PatientDieseaseId = ko.observable(data.PatientDieseaseId);

    this.LabComment = new
        LabExaminationCommentViewModel(data.LabComment);
    this.examinationDescriptionLab= ko.observable();

};