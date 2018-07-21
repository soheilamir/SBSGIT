
'use strict'
angular.module('DetailOrderingHotelServiceMadule').directive("detailOrderingHotelServices", [function () {
    return {
        replace: true,
        controller: "DetailOrderingHotelServiceCtrl",
        templateUrl: "/HaftAsemanConsole/SBSConsole/OtherModule/ConsoleModule/CMSReserveDomesticFlight_Hotel/Hotel/DetailOrderingHotel/DetailOrderingHotelTmpl.html",
        link: function (scope, ele, attr) {
        },
    };
}]);