/// <reference path="D:\SBS\New\SBSWebProject\src\HaftAsemanAbi\scripts/angular.js" />


'use strict'
angular.module('ArticleHotelContentModule').controller('ArticleHotelContentCtrl', ['$scope', '$rootScope', 'DomesticHotelBookingServiceModelFactory', 'ReqHotelBookingServiceModelFactory', 'DomesticHotelBookingServiceFactory', '$window', 'localStorageService', function ($scope, $rootScope, DomesticHotelBookingServiceModelFactory, ReqHotelBookingServiceModelFactory, DomesticHotelBookingServiceFactory, $window, localStorageService) {

    //#region Hotel Booking Global Val Section
    $scope.ReqHotel = new ReqHotelBookingServiceModelFactory();
    $scope.settings = {
        default: function () {
            var date = null;
            date.setHours(1);
            date.setMinutes(2);
            return date;
        }
    };
    //#endregion
    //#region Hotel Booking Method Section

    $scope.ChangePriceRooms = function (hotel, selectedRoom) {
        angular.forEach($scope.lstHotel, function (itemHotel, index) {
            itemHotel.selected = false;
        });
        hotel.selected = true;
        angular.forEach($scope.lstHotel, function (itemHotel, index) {
            if (!itemHotel.selected) {
                angular.forEach(itemHotel.HotelRoomS, function (itemRoom, index) {
                    itemRoom.ReqRoomCount = null;
                    itemRoom.selected = false;
                });
                itemHotel.TotalPrice = null;
            }
            else {
                selectedRoom.selected = true;
            }

        });
        $scope.itemHotel.TotalPrice = hotel.HotelRoomS.reduce(function (totalCost, HotelRoom) {
            return totalCost + HotelRoom.ReqRoomCount * HotelRoom.ActiveNightPriceItem.Price;
        }, 0);
        $scope.itemHotel.TotalPrice;

    };
    $scope.ReserveInternalHotel = function (hotel) {
        $scope.ReqHotel.Id = 1;
        angular.copy(hotel, $scope.ReqHotel.HotelItem);
        localStorageService.set('ReqHotel', { DomesticHotelModelData: $scope.ReqHotel });
    };
    //#endregion

}]);