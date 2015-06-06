function AlergyTypeModel(data) {
    var self = this;

    this.Id = ko.observable(data.Id);
    this.Name = ko.observable(data.Name);
    this.ImagePath = ko.observable(data.ImagePath);

};