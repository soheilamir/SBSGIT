
'use strict'
angular.module('PublicPlaceModule').factory("PublicPlaceFactory", ['$http', '$rootScope', '$q', function ($http, $rootScope, $q) {
    var BaseObjFactory = {
        GetData: function (method) {
            return $http({
                method: $rootScope.baseData.Get,
                url: $rootScope.baseData.G_URI_API + "api/V1/" + method,
                headers: { 'Content-Type': 'application/json' }
            });
        },
        SaveData: function () {
        },
        UpdateData: function () {
        },
        DeleteData: function () {
        },
    };
    return { BaseObjFactory: BaseObjFactory }
}]);