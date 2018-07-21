
'use strict'
angular.module('CMSServicesBaseInfoModule').factory("CMSServicesBaseInfoFactory", ['$http', '$rootScope', '$q', function ($http, $rootScope, $q) {
    var BaseInfoObj = {
        GetData: function (method) {
            return $http({
                method: $rootScope.baseData.Get,
                url: $rootScope.baseData.G_URI_API + "api/V1/" + method,
                headers: { 'Content-Type': 'application/json' }
            });
        },
    };
    return { BaseInfoObj: BaseInfoObj }
}]);