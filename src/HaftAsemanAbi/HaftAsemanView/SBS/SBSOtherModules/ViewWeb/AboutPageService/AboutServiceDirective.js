
'use strict'

angular.module('aboutServiceModule').directive('aboutService', ['$rootScope', function ($rootScope) {
    return {
        scope: {
        },
        controller: "aboutServiceCtrl",
        templateUrl: "/HaftAsemanView/SBS/SBSOtherModules/ViewWeb/AboutPageService/aboutServiceTmpl.html",
        link: function (scope, ele, attr) {
            var swiperCo = new Swiper('.swiper-about-container', {
                autoplay: {
                    delay: 4500,
                    disableOnInteraction: false,
                },
                speed: 2000,
                effect: 'fade',
            });
        },
    };
}]);