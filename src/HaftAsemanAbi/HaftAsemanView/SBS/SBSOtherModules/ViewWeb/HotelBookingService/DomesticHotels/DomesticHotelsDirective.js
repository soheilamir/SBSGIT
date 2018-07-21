
'use strict'
angular.module('hotelBookingServiceModule').directive('dhbServices', ['$rootScope', function ($rootScope) {
    return {
        scope: {
        },
        controller: "DomesticHotelCtrl",
        templateUrl: "/HaftAsemanView/SBS/SBSOtherModules/ViewWeb/HotelBookingService/DomesticHotels/DomesticHotelsTmpl.html",
        link: function (scope, ele, attr) {
        },
    };
}]);