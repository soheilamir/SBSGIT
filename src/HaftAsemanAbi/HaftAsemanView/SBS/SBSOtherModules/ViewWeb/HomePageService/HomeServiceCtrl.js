/// <reference path="D:\SBSProject\SBSWebProject_95-11-30\src\HaftAsemanAbi\scripts/angular.js" />

'use strict'
angular.module('homeServiceModule').controller('homeServiceCtrl', ['$scope', '$rootScope', '$location', function ($scope, $rootScope, $location) {
    $scope.GoToPage = function () {
        $location.path('/haft-aseman-abi/travel-agency/booking/domestic/domestic-flight-booking-service');
    };

}]);