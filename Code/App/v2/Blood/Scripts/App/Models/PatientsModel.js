function PatientsModel(data) {
    var self = this;

    this.Id = ko.observable(data.Id);
    this.Name = ko.observable(data.Name);
    this.Age = ko.observable(data.Age);

};