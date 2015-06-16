function BloodExaminationViewModel(data) {
    var self = this;

    this.PatientInfo = new PatientsModel(data.PatientInfo);
    this.BloodComment = new
        BloodExaminationCommentViewModel(data.BloodComment);
    this.examinationDescriptionBlood = ko.observable();

};