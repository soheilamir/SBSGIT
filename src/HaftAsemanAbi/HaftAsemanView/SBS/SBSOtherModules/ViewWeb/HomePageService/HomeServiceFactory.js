
'use strict'
angular.module('homeServiceModule').factory('homeServiceModelFactory', [function () {

}]);
angular.module('homeServiceModule').factory('internalFlightModelFactory', [function () {

}]);
angular.module('homeServiceModule').factory('homeServiceFactory', ['$http', '$rootScope', function ($http, $rootScope) {
    var homefactory = {
    };
   
    return { homefactory: homefactory }
}]);