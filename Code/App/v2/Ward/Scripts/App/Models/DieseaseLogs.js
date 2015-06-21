function DieseaseLogs(data) {
    var self = this;
    
    this.CurrentDiesease = new
        WardPatientCurrentDieseaseViewModel(data.CurrentDiesease);

    this.examinationDescriptionBlood = ko.observable();
    this.examinationDescriptionUSG = ko.observable();
    this.examinationDescriptionRTG = ko.observable();

    this.PatientLogs = ko.observableArray([]);


};