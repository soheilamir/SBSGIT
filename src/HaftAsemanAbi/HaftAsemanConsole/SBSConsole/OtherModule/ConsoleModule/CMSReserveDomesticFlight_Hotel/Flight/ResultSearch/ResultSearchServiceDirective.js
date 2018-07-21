
'use strict'
angular.module('ResultSearchFlightModule').directive("dfbServices", [function () {
    return {
        replace: true,
        controller: "ResultSearchFlightServiceCtrl",
        templateUrl: "/HaftAsemanConsole/SBSConsole/OtherModule/ConsoleModule/CMSReserveDomesticFlight_Hotel/Flight/ResultSearch/ResultSearchTmpl.html",
        link: function (scope, ele, attr) {
        },
    };
}]);