function LabData(idPacjenta, idBadania) {
    var self = this;

    self.IdPacjenta = ko.observable(idPacjenta);
    self.IdBadania = ko.observable(idBadania);
    self.Wynik = ko.observable();
    self.Opis = ko.observable();

};
