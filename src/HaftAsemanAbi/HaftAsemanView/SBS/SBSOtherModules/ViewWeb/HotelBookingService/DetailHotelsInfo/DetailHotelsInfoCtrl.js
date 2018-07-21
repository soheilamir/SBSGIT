/// <reference path="D:\SBS\New\SBSWebProject_96-03-08\src\HaftAsemanAbi\scripts/jquery-1.6.4.min.js" />
/// <reference path="D:\SBS\New\SBSWebProject_96-03-08\src\HaftAsemanAbi\scripts/angular.js" />

'use strict'
angular.module('flightBookingServiceModule').controller('DetailHotelsInfoCtrl', ['$scope', '$rootScope', 'DomesticHotelBookingServiceModelFactory', 'DomesticHotelBookingServiceFactory', '$window', '$location', function ($scope, $rootScope, DomesticHotelBookingServiceModelFactory, DomesticHotelBookingServiceFactory, $window, $location) {
    //#region set default & variable
    $scope.time = {
        In: null,
        Out: null
    };
    //#endregion
    //#region Method
    $scope.ReserveInternalHotel = function () {
        $location.path('');
    };
    //#endregion
}]);