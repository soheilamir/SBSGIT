
'use strict'
angular.module('domesticFlightReserveModule').directive('passengerFlight', [function () {
    return {
        replace: true,
        controller: "passengerFlightCtrl",
        scope: {
            lstAdult: "=",
            lstChild: "=",
            lstInfant: "=",
        },
        templateUrl: "/HaftAsemanConsole/SBSConsole/OtherModule/ConsoleModule/CMSReserveDomesticFlight_Hotel/Flight/PassengerContent/passengerSectionTmpl.html",
        link: function (scope, ele, attr, ctrl) {
        },
    }
}]);