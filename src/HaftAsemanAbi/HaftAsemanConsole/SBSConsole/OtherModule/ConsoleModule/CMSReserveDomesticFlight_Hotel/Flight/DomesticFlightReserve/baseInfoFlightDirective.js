
'use strict'
angular.module('domesticFlightReserveModule').directive('baseInfoFlight', [function () {
    return {
        replace: true,
        require: '^domesticFlightReserveService',
        scope: {
            source: "=",
            destination: "=",
            departingDate: "=",
            returningDate: "=",
            adult: "=",
            child: "=",
            infant: "=",
        },
        templateUrl: "/HaftAsemanConsole/SBSConsole/OtherModule/ConsoleModule/CMSReserveDomesticFlight_Hotel/Flight/DomesticFlightReserve/baseInfoFlightTmpl.html",
        link: function (scope, ele, attr, ctrl) {
        },
    }

}]);