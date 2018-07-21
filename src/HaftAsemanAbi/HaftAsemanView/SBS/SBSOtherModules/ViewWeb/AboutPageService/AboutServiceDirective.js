
'use strict'
var swiperAbout = [], swiperAwards = [];
angular.module('aboutServiceModule').directive('aboutService', ['$rootScope', function ($rootScope) {
    return {
        scope: {
        },
        controller: "aboutServiceCtrl",
        templateUrl: "/HaftAsemanView/SBS/SBSOtherModules/ViewWeb/AboutPageService/aboutServiceTmpl.html",
        link: function (scope, ele, attr) {

        },
    };
}]).directive("aboutSwiperDirective", [function () {
    return {
        restrict: "A",
        link: function (scope, element, attrs) {
            swiperAbout = new Swiper('.swiper-about-container', {
                pagination: '.about-pagination',
                slidesPerView: 'auto',
                paginationClickable: true,
            });
        },
    };
}]).directive("awardsSwiperDirective", [function () {
    return {
        restrict: "A",
        link: function (scope, element, attrs) {
            swiperAwards = new Swiper('.swiper-awards-container', {
                pagination: '.awards-pagination',
                slidesPerView: 'auto',
                paginationClickable: true,

            });
        },
    };
}]);