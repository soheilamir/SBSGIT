
'use strict'
angular.module('SearchHotelModule').directive("reDomesticHotelService", [function () {
    return {
        replace: true,
        controller: "SearchHotelCtrl",
        templateUrl: "/HaftAsemanConsole/SBSConsole/OtherModule/ConsoleModule/CMSReserveDomesticFlight_Hotel/Hotel/Search/SearchTmpl.html",
        link: function (scope, ele, attr) {
        },
    };
}]);