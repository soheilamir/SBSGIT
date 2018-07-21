
'use strict'
angular.module('hotelBookingServiceModule').directive('setPassengerRoomServices', ['$rootScope', function ($rootScope) {
    return {
        scope: {
        },
        controller: "SetPassengerRoomCtrl",
        templateUrl: "/HaftAsemanView/SBS/SBSOtherModules/ViewWeb/HotelBookingService/SetPassengerOfRoom/SetPassengerRoomTmpl.html",
        link: function (scope, ele, attr) {
        },
    };
}]);