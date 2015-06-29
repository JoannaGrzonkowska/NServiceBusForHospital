function DirectorMessagesModel(data) {
    var self = this;

    this.Comment = ko.observable(data.Comment);
    this.When = ko.observable(data.When);
};