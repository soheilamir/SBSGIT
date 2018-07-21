
'use strict'
angular.module('FacilitiesModule').factory('facilitiesModel', ['facilitiesCategoryModel', function (facilitiesCategoryModel) {
    var facilitiesModel = function (facilities) {
        var _facilities = this;
        if (!facilities) {
            _facilities.Id = null;
            _facilities.FacilitiesCategoryItem = new facilitiesCategoryModel();
        }
        else
            _facilities = facilities;
    };
    return facilitiesModel;
}]);
angular.module('FacilitiesModule').factory('facilitiesNameByLangModel', ['facilitiesModel', 'langModel', function (facilitiesModel, langModel) {
    var facilitiesNameByLangModel = function (facilitiesNameByLang) {
        var _facilitiesNameByLang = this;
        if (!facilitiesNameByLang) {
            _facilitiesNameByLang.Id = null;
            _facilitiesNameByLang.LanguagesItem = new langModel();
            _facilitiesNameByLang.FacilitiesItem = new facilitiesModel();
            _facilitiesNameByLang.Name = null;
        }
        else
            _facilitiesNameByLang = facilitiesNameByLang;
    };
    return facilitiesNameByLangModel;
}]);