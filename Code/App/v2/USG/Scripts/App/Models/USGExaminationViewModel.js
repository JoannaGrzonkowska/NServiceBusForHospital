function USGExaminationViewModel(data) {
    var self = this;

    this.PatientInfo = new PatientsModel(data.PatientInfo);
    this.USGComment = new
        USGExaminationCommentViewModel(data.USGComment);
    this.examinationDescriptionUSG = ko.observable();

};