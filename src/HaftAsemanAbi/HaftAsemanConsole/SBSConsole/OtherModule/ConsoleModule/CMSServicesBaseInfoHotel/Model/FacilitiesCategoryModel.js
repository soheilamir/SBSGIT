
'use strict'
angular.module('FacilitiesCategoryModule').factory('facilitiesCategoryModel', [function () {
    var facilitiesCategoryModel = function (facilitiesCat) {
        var _facilitiesCat = this;
        if (!facilitiesCat) {
            _facilitiesCat.Id = null;
            _facilitiesCat.CategoryName = null;
        }
        else
            _facilitiesCat = facilitiesCat;
    };
    return facilitiesCategoryModel;
}]);