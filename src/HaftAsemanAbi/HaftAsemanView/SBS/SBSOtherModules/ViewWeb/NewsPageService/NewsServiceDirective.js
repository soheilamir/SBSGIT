
'use strict'
angular.module('newsServiceModule').directive('newsService', ['$rootScope', function ($rootScope) {
    return {
        scope: {
        },
        controller: "newsServiceCtrl",
        templateUrl: "/HaftAsemanView/SBS/SBSOtherModules/ViewWeb/NewsPageService/NewsServiceTmpl.html",
        link: function (scope, ele, attr) {

        },
    };
}]).directive("newsBannerSwiperDirective", [function () {
    return {
        restrict: "A",
        link: function (scope, element, attrs) {
           var swiperNewsBanner = new Swiper('.swiper-newsBanner-container', {
                pagination: '.newsBanner-pagination',
                paginationClickable: true,
                nextButton: '.swiper-button-next',
                prevButton: '.swiper-button-prev',
                effect: 'fade',
               autoplay:5000

            });
        },
    };
}]);