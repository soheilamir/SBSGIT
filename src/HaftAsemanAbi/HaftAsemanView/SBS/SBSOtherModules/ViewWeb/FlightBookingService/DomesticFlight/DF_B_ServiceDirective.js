
'use strict'
angular.module('flightBookingServiceModule').directive('dfbServices', ['$rootScope', function ($rootScope) {
    return {
        scope: {
        },
        controller: "DomesticFlightCtrl",
        templateUrl: "/HaftAsemanView/SBS/SBSOtherModules/ViewWeb/FlightBookingService/DomesticFlight/dF_B_ServiceTmpl.html",
        link: function (scope, ele, attr) {
        },
    };
}]);