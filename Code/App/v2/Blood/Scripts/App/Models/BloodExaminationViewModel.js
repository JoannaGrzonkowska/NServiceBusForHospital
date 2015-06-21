function BloodExaminationViewModel(data) {
    var self = this;

    this.PatientDieseaseId = ko.observable(data.PatientDieseaseId);

    this.PatientInfo = new PatientsModel(data.PatientInfo);
    this.BloodComment = new
        BloodExaminationCommentViewModel(data.BloodComment);
    this.examinationDescriptionBlood = ko.observable();

};