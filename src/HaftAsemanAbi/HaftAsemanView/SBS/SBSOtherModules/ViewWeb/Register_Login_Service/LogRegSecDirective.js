
'use strict'
angular.module('Login_Reg_ServiceModule').directive('loginRegBase', [function () {
    return {
        replace: true,
        require: '^?loginRegService',
        templateUrl: "/HaftAsemanView/SBS/SBSOtherModules/ViewWeb/Register_Login_Service/LogRegBaseTmpl.html",
        link: function (scope, element, attrs,ctrl) {
            var swiperlogreg = new Swiper('.swiper-logreg-container', {
                autoHeight: true, //enable auto height
                navigation: {
                    nextEl: '.swiper-button-next',
                    prevEl: '.swiper-button-prev',
                },
                speed: 2000,
            });
        },
    };
}]);