
'use strict'
angular.module('hotelBookingServiceModule').directive('reSearchDateHotelServices', ['$rootScope', function ($rootScope) {
    return {
        replace:true,
        scope: {
        },
        controller: "DomesticHotelCtrl",
        templateUrl: "/HaftAsemanView/SBS/SBSOtherModules/ViewWeb/HotelBookingService/DomesticHotels/ReSearchDateHotelTmpl.html",
        link: function (scope, ele, attr) {
        },
    };
}]);