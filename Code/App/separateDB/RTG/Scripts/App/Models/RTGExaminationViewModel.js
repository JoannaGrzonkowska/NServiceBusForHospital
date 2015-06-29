function RTGExaminationViewModel(data) {
    var self = this;

    this.PatientDieseaseId = ko.observable(data.PatientDieseaseId);

    this.RTGComment = new
        RTGExaminationCommentViewModel(data.RTGComment);
    this.examinationDescriptionRTG = ko.observable();

};