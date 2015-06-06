function PatientInfoViewModel(data) {
    var self = this;

    this.Name = ko.observable(data.Name);
    this.Age = ko.observable(data.Age);

};