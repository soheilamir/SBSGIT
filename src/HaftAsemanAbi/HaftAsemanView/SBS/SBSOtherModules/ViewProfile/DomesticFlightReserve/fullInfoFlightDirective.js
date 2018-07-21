
'use strict'
angular.module('domesticFlightReserveModule').directive('fullInfoFlight', ['$rootScope', function ($rootScope) {
    return {
        replace: true,
        require: '^?domesticFlightReserveService',
        scope: {
            allInfo: "=",
            domesticFlight: "=",
            showContent: "=",
            showPrint: "=",
        },
        templateUrl: "/HaftAsemanView/SBS/SBSOtherModules/ViewProfile/DomesticFlightReserve/fullInfoFlightTmpl.html",
        link: function (scope, ele, attr, ctrl) {
            scope.FlightReserve = function () {
                ctrl.FlightReserve();
            }
            scope.BackToFillPassengerFlight = function () {
                ctrl.BackToFillPassengerFlight(true, false);
            }
            scope.PrintTicket = function () {
                $rootScope.$broadcast('print', {});
            }
        },
    }

}]);