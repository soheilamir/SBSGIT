
'use strict'
angular.module('FacilitiesCategoryModule').factory("FacilitiesCategoryFactory", ['$http', '$rootScope', '$q', function ($http, $rootScope, $q) {
    var BaseObjFactory = {
        GetData: function (method) {
            return $http({
                method: $rootScope.baseData.Get,
                url: $rootScope.baseData.G_URI_API + "api/V1/" + method,
                headers: { 'Content-Type': 'application/json' }
            });
        },
        SaveData: function (method, model) {
            return $http({
                method: $rootScope.baseData.Post,
                url: $rootScope.baseData.G_URI_API + "api/V1/" + method,
                data: JSON.stringify(model),
                headers: { 'Content-Type': 'application/json' }
            });
        },
        UpdateData: function (method, model) {
            return $http({
                method: $rootScope.baseData.Post,
                url: $rootScope.baseData.G_URI_API + "api/V1/" + method,
                data: JSON.stringify(model),
                headers: { 'Content-Type': 'application/json' }
            });
        },
        DeleteData: function (method, model) {
            return $http({
                method: $rootScope.baseData.Post,
                url: $rootScope.baseData.G_URI_API + "api/V1/" + method,
                data: JSON.stringify(model),
                headers: { 'Content-Type': 'application/json' }
            });
        },
    };
    return { BaseObjFactory: BaseObjFactory }
}]);