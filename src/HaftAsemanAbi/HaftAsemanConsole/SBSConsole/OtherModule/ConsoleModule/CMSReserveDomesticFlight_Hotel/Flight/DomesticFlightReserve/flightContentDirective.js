
'use strict'
angular.module('domesticFlightReserveModule').directive('flightContent', [function () {
    return {
        replace: true,
        require: '^domesticFlightReserveService',
        scope: {
            flightObj: "=",
        },
        templateUrl: "/HaftAsemanConsole/SBSConsole/OtherModule/ConsoleModule/CMSReserveDomesticFlight_Hotel/Flight/DomesticFlightReserve/flightContentTmpl.html",
        link: function (scope, ele, attr, ctrl) {
        },
    }

}]);