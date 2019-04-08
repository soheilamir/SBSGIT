
'use strict'
angular.module('contactServiceModule').directive('callContent', ['$rootScope', function ($rootScope) {
    return {
        replace: true,
        scope: {
            showFoter: "=",
        },
        require: '^contactService',
        templateUrl: "/HaftAsemanView/SBS/SBSOtherModules/ViewWeb/ContactPageService/callContentTmpl.html",
        link: function (scope, ele, attr, ctrl) {
            var swipercall = new Swiper('.swiper-call-container', {
                spaceBetween: 30,
                centeredSlides: true,
                autoplay: {
                    delay: 4500,
                    disableOnInteraction: false,
                },
                pagination: {
                    el: '.call-pagination',
                    clickable: true,
                },
                speed: 2000,
                effect: 'fade',
            });
        },
    };
}])