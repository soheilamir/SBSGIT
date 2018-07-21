
'use strict'
angular.module('HotelServicesModule').directive('modalFillResidenceHotel', ['$rootScope', 'apartmentModelFactory', 'roomModelFactory', function ($rootScope, apartmentModelFactory, roomModelFactory) {
    return {
        require: '^hotelService',
        scope: {
            roomSelected: "=",
            apartmentSelected: "=",
            showModal: "="
        },
        templateUrl: '/HaftAsemanView/SBS/SBSOtherModules/ViewProfile/Services/hotel/fillResidenceHotelTmpl.html',
        link: function (scope, ele, attr, ctrl) {
            //#region variable content
            scope.baseData = $rootScope.ProfileDefaultData; // set base data for flight
            scope.newRoom = new roomModelFactory();
            scope.newApartment = new apartmentModelFactory();
            //#endregion
            //#region Event content
            scope.cancel = function () {
                ctrl.cancelModal();
            };
            scope.AddRoomItem = function () {
                ctrl.AddRoomInHotel(scope.newRoom);
                scope.newRoom = new roomModelFactory();
                ctrl.cancelModal();
            };
            scope.AddApartmentItem = function () {
                ctrl.AddAppartmentInHotel(scope.newApartment);
                scope.newApartment = new apartmentModelFactory();
                ctrl.cancelModal();
            };
            //#endregion
        },
    };
}]);