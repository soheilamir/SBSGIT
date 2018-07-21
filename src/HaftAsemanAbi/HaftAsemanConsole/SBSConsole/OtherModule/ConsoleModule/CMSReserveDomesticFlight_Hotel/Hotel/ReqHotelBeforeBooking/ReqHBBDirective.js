
'use strict'
angular.module('ReqHBBServiceMadule').directive("reqHBBServices", [function () {
    return {
        replace: true,
        controller: "ReqHBBServiceCtrl",
        templateUrl: "/HaftAsemanConsole/SBSConsole/OtherModule/ConsoleModule/CMSReserveDomesticFlight_Hotel/Hotel/ReqHotelBeforeBooking/ReqHBBTmpl.html",
        link: function (scope, ele, attr) {
        },
    };
}]);