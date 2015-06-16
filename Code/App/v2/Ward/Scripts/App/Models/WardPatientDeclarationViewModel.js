function WardPatientDeclarationViewModel(data) {
    var self = this;

    this.PatientInfo = new PatientsModel(data.PatientInfo);
    this.CurrentDiesease = new
        WardPatientCurrentDieseaseViewModel(data.CurrentDiesease);
    this.examinationDescriptionBlood = ko.observable();
    this.examinationDescriptionUSG = ko.observable();
    this.examinationDescriptionRTG = ko.observable();

};