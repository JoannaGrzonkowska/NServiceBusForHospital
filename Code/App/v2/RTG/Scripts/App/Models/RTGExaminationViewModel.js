function RTGExaminationViewModel(data) {
    var self = this;

    this.PatientDieseaseId = ko.observable(data.PatientDieseaseId);

    this.PatientInfo = new PatientsModel(data.PatientInfo);
    this.RTGComment = new
        RTGExaminationCommentViewModel(data.RTGComment);
    this.examinationDescriptionRTG = ko.observable();

};