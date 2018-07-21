
'use strict'
angular.module('ArticleHotelItemModule').directive('artHotelItem', ['$rootScope', function ($rootScope) {
    return {
        replace: true,
        scope: {
            itemHotel: "=",
        },
        controller: "ArticleHotelItemCtrl",
        templateUrl: "/HaftAsemanView/SBS/SBSOtherModules/ViewProfile/DomesticHotelReserve/ArticleHotelInfo/ArticleHotelInfoTmpl.html",
        link: function (scope, ele, attr) {
        },
    };
}]);