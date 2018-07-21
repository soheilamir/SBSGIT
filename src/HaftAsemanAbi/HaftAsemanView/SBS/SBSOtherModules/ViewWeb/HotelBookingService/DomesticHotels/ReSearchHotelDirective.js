
'use strict'
angular.module('hotelBookingServiceModule').directive('reSearchHotelServices', ['$rootScope', function ($rootScope) {
    return {
        replace:true,
        scope: {
        },
        controller: "DomesticHotelCtrl",
        templateUrl: "/HaftAsemanView/SBS/SBSOtherModules/ViewWeb/HotelBookingService/DomesticHotels/ReSearchHotelTmpl.html",
        link: function (scope, ele, attr) {
        },
    };
}]);