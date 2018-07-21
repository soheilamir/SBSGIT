

'use strict'
angular.module('HotelServicesModule').controller('hotelServiceCtrl', ['$scope', '$rootScope', 'HotelPackageManagerFactory', function ($scope, $rootScope, HotelPackageManagerFactory) {
    //#region Global variable
    $scope.ShowFillHotel = true;
    $scope.lstPackage = HotelPackageManagerFactory.objHotelPackage.SendListPackage();
    //#endregion
    //#region $broadcast content
    $scope.$on('showModal', function (e, data) {
        $scope.showModalContent = data.val;
    });
    $scope.$on('setShowContentResidentHotel', function (e, data) {
        $scope.roomSelected = data.R_S;
        $scope.apartmentSelected = data.A_S;
        $scope.hotelPackageIndex = data.hotelIndex;
    });
    $rootScope.$broadcast('changeposition', { val: '_S' });
    $rootScope.$on('EditOrderHotel', function (e, data) {
        HotelPackageManagerFactory.objHotelPackage.EditedFromOrderList(data.hotelPackage);
        $scope.lstPackage = HotelPackageManagerFactory.objHotelPackage.SendListPackage();
    });
    //#endregion
    //#region Event content
    $scope.ShowFillHotelContent = function () {
        $scope.ShowFillHotel = !$scope.ShowFillHotel;
        if ($scope.ShowFillHotel)
            $rootScope.$broadcast('changeposition', { val: '_S' });
        else
            $rootScope.$broadcast('changeposition', { val: 'R_S' });
    };
    this.cancelModal = function () {
        $scope.showModalContent = false;
    }
    this.AddRoomInHotel = function (newRoom) {
        HotelPackageManagerFactory.objHotelPackage.SelectedHotelInPackage($scope.hotelPackageIndex, false);
        HotelPackageManagerFactory.objHotelPackage.AddRoomInPackage(newRoom);
    };
    this.DeleteRoomFromPackage = function (roomIndex, hotelPackIndex) {
        HotelPackageManagerFactory.objHotelPackage.SelectedHotelInPackage(hotelPackIndex, false);
        HotelPackageManagerFactory.objHotelPackage.DeleteRoomInPackage(roomIndex, hotelPackIndex);
    };
    this.AddAppartmentInHotel = function (newApartment) {
        HotelPackageManagerFactory.objHotelPackage.SelectedHotelInPackage($scope.hotelPackageIndex, false);
        HotelPackageManagerFactory.objHotelPackage.AddApartmentInPackage(newApartment);
    };
    this.DeleteApartmentFromPackage = function (apartmentIndex, hotelPackIndex) {
        HotelPackageManagerFactory.objHotelPackage.SelectedHotelInPackage(hotelPackIndex, false);
        HotelPackageManagerFactory.objHotelPackage.DeleteApartmentInPackage(apartmentIndex, hotelPackIndex);
    };
    this.CreateHotelPackage = function (newHotel) {
        HotelPackageManagerFactory.objHotelPackage.AddHotelPackage(newHotel);
    };
    this.DeleteHotelPackage = function (hotelPackIndex) {
        HotelPackageManagerFactory.objHotelPackage.DeleteHotelPackage(hotelPackIndex);
    };
    this.EditedHotelPackage = function (hotelPackIndex) {
        HotelPackageManagerFactory.objHotelPackage.SelectedHotelInPackage(hotelPackIndex, true);
        $rootScope.$broadcast('set-hotel', { hotel: HotelPackageManagerFactory.objHotelPackage.lstPackage[hotelPackIndex] });
    };
    this.ClearHotelPackage = function () {
        $scope.lstPackage = [];
        HotelPackageManagerFactory.objHotelPackage.lstPackage = [];
        $rootScope.$broadcast('ClearHotelList', { hotellist: $scope.lstPackage });
    };
    //#endregion
}]);