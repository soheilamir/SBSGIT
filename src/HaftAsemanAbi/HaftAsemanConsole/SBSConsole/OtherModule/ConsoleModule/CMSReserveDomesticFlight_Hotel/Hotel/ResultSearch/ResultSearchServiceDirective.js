
'use strict'
angular.module('ResultSearchHotelModule').directive("dhbServices", [function () {
    return {
        replace: true,
        controller: "ResultSearchHotelServiceCtrl",
        templateUrl: "/HaftAsemanConsole/SBSConsole/OtherModule/ConsoleModule/CMSReserveDomesticFlight_Hotel/Hotel/ResultSearch/ResultSearchTmpl.html",
        link: function (scope, ele, attr) {
        },
    };
}]);