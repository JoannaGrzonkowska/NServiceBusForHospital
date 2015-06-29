function PatientsDieseasesModel(data) {
    var self = this;
        
    this.Id = ko.observable(data.Id);
    this.DieseaseName = ko.observable(data.DieseaseName);
    this.Description = ko.observable(data.Description);
        
    this.DieseasesExaminations = ko.observableArray([]);

    if (data.DieseasesExaminations != null) {
        data.DieseasesExaminations.forEach(function (item) {
            self.DieseasesExaminations.push(new ExaminationModel(item));
        });
    };

};