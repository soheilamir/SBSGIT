
'use strict'
angular.module('SendReqToHotelServiceMadule').directive("sendReqToHotelServices", [function () {
    return {
        replace: true,
        controller: "SendReqToHotelServiceCtrl",
        templateUrl: "/HaftAsemanConsole/SBSConsole/OtherModule/ConsoleModule/CMSReserveDomesticFlight_Hotel/Hotel/SendReqToHotel/SendReqToHotelTmpl.html",
        link: function (scope, ele, attr) {
        },
    };
}]);