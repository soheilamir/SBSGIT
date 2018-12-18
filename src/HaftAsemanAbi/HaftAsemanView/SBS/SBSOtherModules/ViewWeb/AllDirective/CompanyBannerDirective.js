

'use strict'
angular.module('AllDirectiveModule').directive('coBannerSwiper', [function () {
    return {
        replace: true,
        scope: {
        },
        templateUrl: "/HaftAsemanView/SBS/SBSOtherModules/ViewWeb/AllDirective/CompanyBannerTmpl.html",
        link: function (scope, element, attrs) {
           var swiperCo = new Swiper('.swiper-coView-container', {
                autoHeight: true, //enable auto height
                spaceBetween: 30,
                centeredSlides: true,
                autoplay: {
                    delay: 4500,
                    disableOnInteraction: false,
                },
                pagination: {
                    el: '.co-pagination',
                    clickable: true,
                },
                speed: 2000,
                effect: 'fade',
            });
        },
    };
}]);