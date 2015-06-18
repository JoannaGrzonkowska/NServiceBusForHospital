function RTGExaminationViewModel(data) {
    var self = this;

    this.PatientInfo = new PatientsModel(data.PatientInfo);
    this.RTGComment = new
        RTGExaminationCommentViewModel(data.RTGComment);
    this.examinationDescriptionRTG = ko.observable();

};