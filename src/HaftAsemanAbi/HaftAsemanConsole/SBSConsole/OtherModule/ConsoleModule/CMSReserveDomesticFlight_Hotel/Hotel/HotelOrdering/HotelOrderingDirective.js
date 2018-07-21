
'use strict'
angular.module('HotelOrderingModule').directive('hotelOrderingServices', [function () {
    return {
        replace: true,
        controller: 'HotelOrderingCtrl',
        templateUrl: "/HaftAsemanConsole/SBSConsole/OtherModule/ConsoleModule/CMSReserveDomesticFlight_Hotel/Hotel/HotelOrdering/HotelOrderingTmpl.html",
    };
}]);