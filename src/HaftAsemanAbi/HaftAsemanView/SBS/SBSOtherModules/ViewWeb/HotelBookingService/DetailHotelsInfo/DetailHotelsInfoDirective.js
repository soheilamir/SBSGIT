
'use strict'
angular.module('hotelBookingServiceModule').directive('detailHotelsInfoServices', ['$rootScope', function ($rootScope) {
    return {
        scope: {
        },
        controller: "DetailHotelsInfoCtrl",
        templateUrl: "/HaftAsemanView/SBS/SBSOtherModules/ViewWeb/HotelBookingService/DetailHotelsInfo/DetailHotelsInfoTmpl.html",
        link: function (scope, ele, attr) {
        },
    };
}]);