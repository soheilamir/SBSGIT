
'use strict'
angular.module('domesticFlightReserveModule').directive('domesticFlightReserveService', [function () {
    return {
        replace: true,
        scope: {
        },
        controller: "domesticFlightReserveCtrl",
        templateUrl: "/HaftAsemanConsole/SBSConsole/OtherModule/ConsoleModule/CMSReserveDomesticFlight_Hotel/Flight/DomesticFlightReserve/domesticFlightReserveTmpl.html",
    }

}]);