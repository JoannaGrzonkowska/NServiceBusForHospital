function LabExaminationViewModel(data) {
    var self = this;

    this.PatientInfo = new PatientsModel(data.PatientInfo);
    this.LabComment = new
        LabExaminationCommentViewModel(data.LabComment);
    this.examinationDescriptionLab= ko.observable();

};