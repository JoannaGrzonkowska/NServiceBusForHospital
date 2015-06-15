function WardPatientDeclarationViewModel(data) {
    var self = this;

    this.PatientInfo = new PatientsModel(data.PatientInfo);
    this.CurrentDiesease = new
        WardPatientCurrentDieseaseViewModel(data.CurrentDiesease);

};