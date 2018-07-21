/// <reference path="D:\Amir Folders\Projects\7BlueSkyProject\SBS(2016_New)\HaftAsemanAbi\HaftAsemanAbi\HaftAsemanAbi\scripts/angular.js" />

'use strict'
angular.module('HotelServicesModule').directive('fillHotel', ['$rootScope', 'FillhotelsNameFactory', 'hotelsModelFactory', function ($rootScope, FillhotelsNameFactory, hotelsModelFactory) {
    return {
        replace: true,
        require: '^hotelService',
        scope: {
        },
        templateUrl: '/HaftAsemanView/SBS/SBSOtherModules/ViewProfile/Services/hotel/FillHotel/fillHotelTmpl.html',
        link: function (scope, ele, attr, ctrl) {
            //#region variable
            scope._f = false; scope._h = true; // for callender directive
            scope.baseData = $rootScope.ProfileDefaultData; // set base data for flight
            scope.newHotel = new hotelsModelFactory();/// initial scope.newFlight
            //#endregion
            /// hotels content
            scope.selectedItem = null;
            scope.searchText = null;
            scope.selectedHotels = [];
            FillhotelsNameFactory.objHotelList.GetHotels().then(function (data) {
                if (data.length > 0 || data === null)
                    scope.hotels = data;
                else {
                    scope.hotels = [
                                        { id: 1, name: "Rosewood Abu Dhabi", type: "" },
                                        { id: 2, name: "Jumeirah at Etihad Towers ", type: "" },
                                        { id: 3, name: "Millennium Corniche Hotel Abu Dhabi", type: "" },
                                        { id: 4, name: "Dusit Thani Abu Dhabi", type: "" },
                                        { id: 5, name: "Radisson Blu Hotel, Abu Dhabi Yas Island", type: "" },
                    ]
                };
            }); /// Get hotels name list for autocomplete
            scope.queryHotelsSearch = function (query) {
                return FillhotelsNameFactory.objHotelList.querySearch(query, scope.hotels);
            };
            scope.transformChip = function (chip) {
                return FillhotelsNameFactory.objHotelList.transformChip(chip);
            };
            /// end hotels name content
            //#region Event content
            scope.$on('set-hotel', function (e, data) {
                scope.newHotel = new hotelsModelFactory();
                angular.copy(data.hotel, scope.newHotel);
                angular.copy(scope.newHotel.hotelsName, scope.selectedHotels);///show airline in airline chips content
            });
            scope.AddHotelToPackage = function () {
                angular.copy(scope.selectedHotels, scope.newHotel.hotelsName);
                ctrl.CreateHotelPackage(scope.newHotel);
                scope.newHotel = new hotelsModelFactory();
                scope.selectedHotels = [];
            };
            //#endregion
        },
    };
}]);