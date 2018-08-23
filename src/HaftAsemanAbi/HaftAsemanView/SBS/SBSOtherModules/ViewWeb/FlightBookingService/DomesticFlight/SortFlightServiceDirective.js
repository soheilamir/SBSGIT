
'use strict'
angular.module('flightBookingServiceModule').directive('sortFlightServices', ['$rootScope', function ($rootScope) {
    return {
        scope: {
        },
        replace: true,
        require: '^dfbServices',
        templateUrl: "/HaftAsemanView/SBS/SBSOtherModules/ViewWeb/FlightBookingService/DomesticFlight/SortFlightTmpl.html",
        link: function (scope, ele, attr, ctrl) {


        },
    };
}]);