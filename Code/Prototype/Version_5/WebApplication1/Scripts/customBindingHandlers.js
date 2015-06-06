ko.bindingHandlers.localizedDateTime = {
    update: function (element, valueAccessor) {
        var value = ko.utils.unwrapObservable(valueAccessor());
        var date = moment(value);

        element.innerHTML = date.format('YYYY-MM-DD HH:mm');

        //TODO use localized datetime
        //element.innerHTML = date.format('L LT');
    }
};

ko.bindingHandlers.localizedDate = {
    update: function (element, valueAccessor) {
        var value = ko.utils.unwrapObservable(valueAccessor());
        var date = moment(value);

        element.innerHTML = date.format('YYYY-MM-DD');

        //TODO use localized datetime
        //element.innerHTML = date.format('L LT');
    }
};

ko.bindingHandlers.localizedTime = {
    update: function (element, valueAccessor) {
        var value = ko.utils.unwrapObservable(valueAccessor());
        var date = moment(value);

        element.innerHTML = date.format('HH:mm');

        //TODO use localized datetime
        //element.innerHTML = date.format('L LT');
    }
};


