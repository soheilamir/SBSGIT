
'use strict'
angular.module('flightBookingServiceModule').directive('modifySearchFlight', ['$rootScope', function ($rootScope) {
    return {
        scope: {
        },
        replace: true,
        require: '^dfbServices',
        templateUrl: "/HaftAsemanView/SBS/SBSOtherModules/ViewWeb/FlightBookingService/DomesticFlight/modifySearchFlightTmpl.html",
        link: function (scope, ele, attr, ctrl) {

        },
    };
}]);