
'use strict'
angular.module('ArticleHotelContentModule').directive('artHotelContent', ['$rootScope', function ($rootScope) {
    return {
        replace: true,
        scope: {
            itemHotel: "=",
            lstHotel:"="
        },
        controller: "ArticleHotelContentCtrl",
        templateUrl: "/HaftAsemanView/SBS/SBSOtherModules/ViewWeb/HotelBookingService/DomesticHotels/ArticleHotelsContentTmpl.html",
        link: function (scope, ele, attr) {
        },
    };
}]);