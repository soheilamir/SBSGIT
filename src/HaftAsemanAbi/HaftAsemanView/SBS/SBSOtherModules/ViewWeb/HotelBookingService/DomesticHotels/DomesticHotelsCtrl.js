
'use strict'
angular.module('flightBookingServiceModule').controller('DomesticHotelCtrl', ['$scope', '$rootScope', 'DomesticHotelBookingServiceModelFactory', 'DomesticHotelBookingServiceFactory', '$window', function ($scope, $rootScope, DomesticHotelBookingServiceModelFactory, DomesticHotelBookingServiceFactory, $window) {
    //#region set default & variable Hotel
    $scope.Math = window.Math;
    $scope.HotelModel = new DomesticHotelBookingServiceModelFactory();
    $scope.LsthotelData = [];
    $scope.LsthotelData = DomesticHotelBookingServiceFactory.HotelData.FillHotel();
    angular.forEach($scope.LsthotelData, function (itemHotel, index) {
        itemHotel.minPrice = Math.min.apply(Math, itemHotel.HotelRoomS.map(function (item) { return item.ActiveNightPriceItem.Price; }))
    });
    //#endregion
    //#region Method Content
    //#endregion
}]);