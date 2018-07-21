
'use strict'
//#region Model Factory content
angular.module('HotelServicesModule').factory('hotelsModelFactory', [function () {
    var hotelsModelFactory = function (Package) {
        var _package = this;
        if (!Package) {
            _package.edited = false;
            _package.delete = false;
            _package.selected = false;
            _package.hidden = false;
            _package.status = null;
            _package.addInOrder = false;
            _package.orderId = null;
            _package.id = null;
            _package.hotelsName = [];
            _package.hotelType = null;
            _package.to = {};
            _package.rate = null;
            _package.checkIn = null;
            _package.checkOut = null;
            _package.roomList = [];
            _package.apartmentList = [];
            _package.description = null;
            _package.recommendedHotels = [];

        }
        else
            _package = Package;
    };
    return hotelsModelFactory;
}]);
angular.module('HotelServicesModule').factory('roomModelFactory', [function () {
    var roomModelFactory = function (room) {
        var _room = this;
        if (!room) {
            _room.edited = false;
            _room.selected = false;
            _room.id = null;
            _room.RoomType = {};
            _room.adult = null;
            _room.child = null;
            _room.featureList = [];
        }
        else
            _room = room;
    };
    return roomModelFactory;
}]);
angular.module('HotelServicesModule').factory('apartmentModelFactory', [function () {
    var apartmentModelFactory = function (apartment) {
        var _apartment = this;
        if (!apartment) {
            _apartment.edited = false;
            _apartment.selected = false;
            _apartment.id = null;
            _apartment.RoomCnt = null;
            _apartment.adult = null;
            _apartment.child = null;
            _apartment.featureList = [];
        }
        else
            _apartment = apartment;
    };
    return apartmentModelFactory;
}]);
//#endregion
//#region Manager Factory content
angular.module('HotelServicesModule').factory('HotelPackageManagerFactory', ['GeneratId', '$q', '$rootScope', 'roomModelFactory', 'apartmentModelFactory', function (GeneratId, $q, $rootScope, roomModelFactory, apartmentModelFactory) {
    var objHotelPackage = {
        AddHotelPackage: function (newHotel) {
            var packEntity = newHotel;
            if (packEntity.id == null) {
                packEntity.id = '__hp:trackID' + GeneratId.G_randId(12);
                this.lstPackage.push(packEntity);
                $rootScope.$broadcast('lsthotel', { hotellist: this.lstPackage });
            }
            else
                this.UpdateHotelPackage(packEntity);
        },
        UpdateHotelPackage: function (packEntity) {
            var hotelPackage = {};
            for (var i in this.lstPackage) {
                if (this.lstPackage[i].id === packEntity.id) {
                    this.lstPackage[i] = packEntity;
                    this.lstPackage[i].edited = false;
                    this.lstPackage[i].selected = false;
                    hotelPackage = this.lstPackage[i];
                };
            };
            $rootScope.$broadcast('order-h-edited', { val: true, hotelPackageItem: hotelPackage });
        },
        EditedFromOrderList: function (newPackEntity) {
            var packEntity = newPackEntity;
            this.lstPackage = [];
            this.lstPackage.push(packEntity);
        },
        DeleteHotelPackage: function (packIndex) {
            this.lstPackage.splice(packIndex, 1);
            this.lastPackageIndexOf = null;
            $rootScope.$broadcast('lsthotel', { hotellist: this.lstPackage });
        },
        //#region apartment and rooms content
        AddRoomInPackage: function (newRoom) {
            this.GetSelectedPack().then(function (data) {
                var hotel = data, room = newRoom;
                if (room.id == null) {
                    room.id = 'room__hp:trackID' + GeneratId.G_randId(8);
                    hotel.roomList.push(room);
                }
            });
        },
        DeleteRoomInPackage: function (roomIndex, packageIndex) {
            this.lstPackage[packageIndex].roomList.splice(roomIndex, 1);
        },
        AddApartmentInPackage: function (newApartment) {
            this.GetSelectedPack().then(function (data) {
                var hotel = data, apartment = newApartment;
                if (apartment.id == null) {
                    apartment.id = 'apartment__hp:trackID' + GeneratId.G_randId(8);
                    hotel.apartmentList.push(apartment);
                }
            });
        },
        DeleteApartmentInPackage: function (apartmentIndex, packageIndex) {
            this.lstPackage[packageIndex].apartmentList.splice(apartmentIndex, 1);
        },
        //#endregion
        SendListPackage: function () {
            return this.lstPackage;
        },
        HotelPackageLength: function () {
            return this.lstPackage.length;
        },
        SelectedHotelInPackage: function (packIndex, isEdited) {
            if (this.lastPackageIndexOf != null) {
                this.lstPackage[this.lastPackageIndexOf].selected = false;
                if (isEdited)
                    this.lstPackage[this.lastPackageIndexOf].edited = false;
                this.lstPackage[packIndex].selected = true;
                if (isEdited)
                    this.lstPackage[packIndex].edited = true;
                this.lastPackageIndexOf = packIndex;
            }
            else {
                this.lstPackage[packIndex].selected = true;
                if (isEdited)
                    this.lstPackage[packIndex].edited = true;
                this.lastPackageIndexOf = packIndex;
            }

        },
        GetSelectedPack: function () {
            var deferred = $q.defer();
            deferred.resolve(this.lstPackage[this.lastPackageIndexOf]);
            return deferred.promise;
        },
    };
    objHotelPackage.lstPackage = [];
    ///Private Event
    objHotelPackage.lastPackageIndexOf = null;

    return { objHotelPackage: objHotelPackage };
}]);
//#endregion
angular.module('HotelServicesModule').factory('FillhotelsNameFactory', ['$http', '$q', '$rootScope', function ($http, $q, $rootScope) {
    var objHotelList = {
        transformChip: function (chip) {
            if (angular.isObject(chip)) {
                return chip;
            }
            return { name: chip, type: 'new' }
        },
        querySearch: function (query, hotels) {
            var results = query ? hotels.filter(createFilterFor(query)) : [];
            return results;
        },
        GetHotels: function () {
            var deferred = $q.defer();
            $http({
                method: 'GET',
                url: $rootScope.baseData.G_URI_SBS_Services + 'baseData/lstHotels',
                headers: { 'Content-Type': 'application/json' }
            })
          .success(function (data) {
              objHotelList.lstHotels = data
              deferred.resolve(objHotelList.lstHotels);
          }).error(function (data) {
              objHotelList.lstHotels = [{ Id: 1, Name: "Error" }, ];
          });
            return deferred.promise;
        },
    };
    var createFilterFor = function (query) {
        var lowercaseQuery = angular.lowercase(query);
        return function filterFn(hotel) {
            return (hotel.name.toLowerCase().indexOf(lowercaseQuery) === 0);
        };
    };
    //#region set AIRLINE properties objects & Method
    objHotelList.lstHotels = [];
    //#endregion
    return { objHotelList: objHotelList };
}]);
//#endregion