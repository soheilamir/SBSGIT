/// <reference path="D:\SBSProject\SBSWebProject_95-11-30\src\HaftAsemanAbi\scripts/angular.js" />

'use strict'
angular.module('homeServiceModule').controller('homeServiceCtrl', ['$scope', '$rootScope', '$location', function ($scope, $rootScope, $location) {
    $scope.GoToPage = function () {
        $location.path('/haft-aseman-abi/travel-agency/booking/domestic/domestic-flight-booking-service');
    };

}]).directive("coSwiper", [function () {
    return {
        restrict: "A",
        link: function (scope, element, attrs) {
            swiperAbout = new Swiper('.swiper-coView-container', {
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
    }
}]);