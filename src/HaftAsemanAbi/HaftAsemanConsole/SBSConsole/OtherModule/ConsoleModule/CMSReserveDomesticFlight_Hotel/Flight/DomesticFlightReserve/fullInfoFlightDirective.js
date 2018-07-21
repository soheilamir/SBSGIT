
'use strict'
angular.module('domesticFlightReserveModule').directive('fullInfoFlight', [function () {
    return {
        replace: true,
        require: '^domesticFlightReserveService',
        scope: {
            allInfo: "=",
            domesticFlight: "="
        },
        templateUrl: "/HaftAsemanConsole/SBSConsole/OtherModule/ConsoleModule/CMSReserveDomesticFlight_Hotel/Flight/DomesticFlightReserve/fullInfoFlightTmpl.html",
        link: function (scope, ele, attr, ctrl) {
            scope.FlightReserve = function () {
                ctrl.FlightReserve();
            }
            scope.BackToFillPassengerFlight = function () {
                ctrl.BackToFillPassengerFlight(true, false);
            }
        },
    }

}]);