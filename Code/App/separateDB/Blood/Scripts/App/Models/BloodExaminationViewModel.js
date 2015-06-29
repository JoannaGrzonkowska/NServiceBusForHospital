function BloodExaminationViewModel(data) {
    var self = this;

    this.PatientDieseaseId = ko.observable(data.PatientDieseaseId);

    this.BloodComment = new
        BloodExaminationCommentViewModel(data.BloodComment);
    this.examinationDescriptionBlood = ko.observable();

};