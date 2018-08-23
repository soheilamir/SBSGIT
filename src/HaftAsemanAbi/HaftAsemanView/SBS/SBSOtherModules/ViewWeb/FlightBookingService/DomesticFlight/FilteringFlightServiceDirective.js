
'use strict'
angular.module('flightBookingServiceModule').directive('filteringFlightServices', ['$rootScope', function ($rootScope) {
    return {
        scope: {
        },
        replace: true,
        require: '^dfbServices',
        templateUrl: "/HaftAsemanView/SBS/SBSOtherModules/ViewWeb/FlightBookingService/DomesticFlight/FilteringFlightTmpl.html",
        link: function (scope, ele, attr, ctrl) {


        },
    };
}]);