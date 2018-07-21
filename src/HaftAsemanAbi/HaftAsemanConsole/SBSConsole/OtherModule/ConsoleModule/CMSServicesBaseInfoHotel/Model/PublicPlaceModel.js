
'use strict'
angular.module('PublicPlaceModule').factory('publicPlaceModel', ['cityModel', function (cityModel) {
    var publicPlaceModel = function (publicPlace) {
        var _publicPlace = this;
        if (!publicPlace) {
            _publicPlace.Id = null;
            _publicPlace.CityItem = new cityModel();
        }
        else
            _publicPlace = publicPlace;
    };
    return publicPlaceModel;
}]);
angular.module('PublicPlaceModule').factory('publicPlaceNameByLangModel', ['publicPlaceModel', 'langModel', function (publicPlaceModel, langModel) {
    var publicPlaceNameByLangModel = function (publicPlaceNameByLang) {
        var _publicPlaceNameByLang = this;
        if (!publicPlaceNameByLang) {
            _publicPlaceNameByLang.Id = null;
            _publicPlaceNameByLang.LanguagesItem = new langModel();
            _publicPlaceNameByLang.CityPublicPlaceItem = new publicPlaceModel();
            _publicPlaceNameByLang.Name = null;
        }
        else
            _publicPlaceNameByLang = publicPlaceNameByLang;
    };
    return publicPlaceNameByLangModel;
}]);