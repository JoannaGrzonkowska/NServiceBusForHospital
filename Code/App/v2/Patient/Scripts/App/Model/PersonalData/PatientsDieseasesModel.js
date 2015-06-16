function PatientsDieseasesModel(data) {
    var self = this;
        
    this.DieseaseName = ko.observable(data.DieseaseName);
    this.Description = ko.observable(data.Description);
};