function USGExaminationViewModel(data) {
    var self = this;

    this.PatientDieseaseId = ko.observable(data.PatientDieseaseId);

    this.PatientInfo = new PatientsModel(data.PatientInfo);
    this.USGComment = new
        USGExaminationCommentViewModel(data.USGComment);
    this.examinationDescriptionUSG = ko.observable();

};