function USGExaminationViewModel(data) {
    var self = this;

    this.PatientDieseaseId = ko.observable(data.PatientDieseaseId);

    this.USGComment = new
        USGExaminationCommentViewModel(data.USGComment);
    this.examinationDescriptionUSG = ko.observable();

};