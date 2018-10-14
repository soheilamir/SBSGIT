
'use strict'
angular.module('AllSecHotelModule').directive('externalHV', [function () {
    return {
        replace: true,
        require: '^hotelViewSec',
        templateUrl: "/HaftAsemanView/SBS/SBSOtherModules/ViewWeb/Hotel_Page_Services/HDirectives/ExternalHotelViewTmpl.html",
        link: function (scope, ele, attr, ctrl) {
        },
    };
}]).directive('hotelCitySwiper', [function () {
    return {
        replace: true,
        restrict: 'A',
        link: function (scope, element, attrs) {
            swiperAbout = new Swiper('.swiper-hotel-city-container', {
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