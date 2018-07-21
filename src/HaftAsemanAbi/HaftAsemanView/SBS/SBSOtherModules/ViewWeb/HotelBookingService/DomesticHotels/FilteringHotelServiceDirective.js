
'use strict'
angular.module('hotelBookingServiceModule').directive('filteringHotelServices', ['$rootScope', function ($rootScope) {
    return {
        scope: {
        },
        replace: true,
        require: '^dhbServices',
        templateUrl: "/HaftAsemanView/SBS/SBSOtherModules/ViewWeb/HotelBookingService/DomesticHotels/FilteringHotelTmpl.html",
        link: function (scope, ele, attr, ctrl) {

        },
    };
}]);