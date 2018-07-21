
'use strict'
angular.module('PassengerVocherHotelServiceMadule').directive("vocherHotelServices", [function () {
    return {
        replace: true,
        controller: "VocherHotelServiceCtrl",
        templateUrl: "/HaftAsemanConsole/SBSConsole/OtherModule/ConsoleModule/CMSReserveDomesticFlight_Hotel/Hotel/PassengerVocherHotel/PassengerVocherHotelTmpl.html",
        link: function (scope, ele, attr) {
        },
    };
}]);