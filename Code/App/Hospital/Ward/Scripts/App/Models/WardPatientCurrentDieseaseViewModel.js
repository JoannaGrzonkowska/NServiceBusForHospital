function WardPatientCurrentDieseaseViewModel(data) {
    var self = this;
    this.DieseaseDescription = ko.observable(data.DieseaseDescription);
    this.DieseaseName = ko.observable(data.DieseaseName);
};