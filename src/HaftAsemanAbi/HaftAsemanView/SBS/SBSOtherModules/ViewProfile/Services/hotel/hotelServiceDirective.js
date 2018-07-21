

'use strict'
angular.module('HotelServicesModule').directive('hotelService', [function () {
    return {
        replace: true,
        scope: {
        },
        templateUrl: "/HaftAsemanView/SBS/SBSOtherModules/ViewProfile/Services/hotel/hotelServiceTmpl.html",
        controller: "hotelServiceCtrl",
    };
}]);