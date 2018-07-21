
'use strict'
angular.module('HotelServicesModule').directive('hotelPackage', ['$rootScope', function ($rootScope) {
    return {
        replace: true,
        require: '^hotelService',
        scope: {
            hotelPackList: '=',
            hotelPackItem: '=',
            hotelPackIndex: '=',
        },
        templateUrl: '/HaftAsemanView/SBS/SBSOtherModules/ViewProfile/Services/hotel/hotelPackage/hotelPackageTmpl.html',
        link: function (scope, ele, attr, ctrl) {
            //#region variable 
            $rootScope.$on('clear-h-services', function (e, data) {
                if (data.clear)
                    ctrl.ClearHotelPackage();
            });
            //#endregion
            //#region Event content
            scope.FillRoomsInPackage = function (roomSelected, apartmentSelected, hotelPackIndex) {
                $rootScope.$broadcast('showModal', { val: true });
                $rootScope.$broadcast('setShowContentResidentHotel', { R_S: roomSelected, A_S: apartmentSelected, hotelIndex: hotelPackIndex })
                //ctrl.AddRoomInPackage(hotelPackageIndex);
            };
            scope.FillApartmentInPackage = function (roomSelected, apartmentSelected, hotelPackIndex) {
                $rootScope.$broadcast('showModal', { val: true });
                $rootScope.$broadcast('setShowContentResidentHotel', { R_S: roomSelected, A_S: apartmentSelected, hotelIndex: hotelPackIndex })
                //ctrl.AddApartmentInPackage(hotelPackageIndex);
            };
            scope.DeleteHotelPackage = function (hotelPackIndex) {
                ctrl.DeleteHotelPackage(hotelPackIndex);
            };
            scope.EditHotelPackage = function (hotelPackIndex) {
                ctrl.EditedHotelPackage(hotelPackIndex);
            };
            scope.DeleteRooms = function (roomIndex, hotelPackIndex) {
                ctrl.DeleteRoomFromPackage(roomIndex, hotelPackIndex);
            };
            scope.DeleteApartment = function (apartmentIndex, hotelPackIndex) {
                ctrl.DeleteApartmentFromPackage(apartmentIndex, hotelPackIndex);
            };
            //#endregion
        },
    };
}]);