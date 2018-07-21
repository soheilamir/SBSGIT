
'use strict'
angular.module('CMSServicesBaseInfoHotelModule', [
    'FacilitiesCategoryModule',
    'FacilitiesModule',
    'PublicPlaceModule',
    'BaseInfoHotelModule',
]).factory('langModel', [function () {
    var langModel = function (language) {
        var _language = this;
        if (!language) {
            _language.Id = null;
            _language.LanguageName = null;
            _language.ISO6391 = null;
            _language.ISO6392 = null;
        }
        else
            _language = language;
    };
    return langModel;
}]).factory('cityModel', [function () {
    var cityModel = function (city) {
        var _city = this;
        if (!city) {
            _city.Id = null;
            _city.CityName = null;
            _city.CharCode = null;
        }
        else
            _city = city;
    };
    return cityModel;
}]).factory("BaseInfoFactory", ['$http', '$rootScope', '$q', function ($http, $rootScope, $q) {
    var LanguageFactory = {
        GetData: function (method) {
            return $http({
                method: $rootScope.baseData.Get,
                url: $rootScope.baseData.G_URI_API + "api/V1/" + method,
                headers: { 'Content-Type': 'application/json' }
            });
        },
        //SaveData: function (method, model) {
        //    return $http({
        //        method: $rootScope.baseData.Post,
        //        url: $rootScope.baseData.G_URI_API + "api/V1/" + method,
        //        data: JSON.stringify(model),
        //        headers: { 'Content-Type': 'application/json' }
        //    });
        //},
        //UpdateData: function (method, model) {
        //    return $http({
        //        method: $rootScope.baseData.Post,
        //        url: $rootScope.baseData.G_URI_API + "api/V1/" + method,
        //        data: JSON.stringify(model),
        //        headers: { 'Content-Type': 'application/json' }
        //    });
        //},
        //DeleteData: function (method, model) {
        //    return $http({
        //        method: $rootScope.baseData.Post,
        //        url: $rootScope.baseData.G_URI_API + "api/V1/" + method,
        //        data: JSON.stringify(model),
        //        headers: { 'Content-Type': 'application/json' }
        //    });
        //},
    };
    return { LanguageFactory: LanguageFactory }
}]);