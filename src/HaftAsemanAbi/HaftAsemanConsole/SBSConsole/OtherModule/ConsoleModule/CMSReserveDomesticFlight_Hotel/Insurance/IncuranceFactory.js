
'use strict'
angular.module('InsuranceServicesModule').factory('ModelFactory', [function () {
    var ModelFactory = function (u) {
        var _u = this;
        if (!u) {
            _u.Source = {};
        }
        else
            _u = u;
    };
    return ModelFactory;
}]);
angular.module('InsuranceServicesModule').factory('ServiceFactory', ['$http', '$rootScope', function ($http, $rootScope) {
    var factory = {
        fn: function () {
        },
    };
    factory.BaseUrI = $rootScope.baseData.G_URI_API;
    factory.methodGET = 'GET';
    factory.methodPOST = 'POST';
    //#region Private Event
    var GetInternalFlightData = function () {
        return $http({
            method: factory.methodPOST,
            url: factory.BaseUrI + 'api/V1/domestic/ticket/getdata',
            data: JSON.stringify(),
            headers: { 'Content-Type': 'application/json' }
        });
    };
    //#rendegion
    return { factory: factory }
}]);
