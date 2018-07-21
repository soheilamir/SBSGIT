
'use strict'
angular.module('SearchFlightModule').directive("reDomesticFlightService", [function () {
    return {
        replace: true,
        controller: "SearchFlightCtrl",
        templateUrl: "/HaftAsemanConsole/SBSConsole/OtherModule/ConsoleModule/CMSReserveDomesticFlight_Hotel/Flight/Search/SearchTmpl.html",
        link: function (scope, ele, attr) {
        },
    };
}]);