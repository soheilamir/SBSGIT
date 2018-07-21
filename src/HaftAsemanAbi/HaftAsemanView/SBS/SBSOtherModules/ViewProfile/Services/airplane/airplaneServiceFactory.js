
'use strict'
//#region Model Factory content
angular.module('AirplaneServicesModule').factory('flightModelFactory', [function () {
    var flightModelFactory = function (Flight) {
        var _flight = this;
        if (!Flight) {
            _flight.selected = false;
            _flight.edited = false;
            _flight.delete = false;
            _flight.IsMulti = true;
            _flight.id = null;
            _flight.ticketType = {};
            _flight.journeyType = {};
            _flight.cabinClass = {};
            _flight.departingDate = null;
            _flight.returningDate = "-----";
            _flight.preferredTime = {};
            _flight.selectedFlexibleDate = null;
            _flight.from = {};
            _flight.to = {};
            _flight.airlineList = [];
            _flight.flightRecomend = [];
        }
        else
            _flight = Flight;
    };
    return flightModelFactory;
}]);
angular.module('AirplaneServicesModule').factory('flightPackageModelFactory', ['PackageConditionModelFactory', function (PackageConditionModelFactory) {
    var flightPackageModelFactory = function (Package) {
        var _package = this;
        if (!Package) {
            _package.edited = false;
            _package.selected = false;
            _package.delete = false;
            _package.hidden = false;
            _package.status = null;
            _package.addInOrder = false;
            _package.orderId = null;
            _package.id = null;
            _package.cntCust = null;
            _package.condition = new PackageConditionModelFactory();
            _package.TPrice = null;
            _package.showPackage = false;
            _package.lstFlight = [];
            _package.countPassenger = null;
        }
        else
            _package = Package;
    };
    return flightPackageModelFactory;
}]);
angular.module('AirplaneServicesModule').factory('PackageConditionModelFactory', [function () {
    var PackageConditionModelFactory = function (PackageCondition) {
        var _condition = this;
        if (!PackageCondition) {
            _condition.conditionList = [];
        }
        else
            _condition = PackageCondition;
    };
    return PackageConditionModelFactory;
}]);
angular.module('AirplaneServicesModule').factory('ConditionParamModelFactory', [function () {
    var ConditionParamModelFactory = function (PackageParam) {
        var _param = this;
        if (!PackageParam) {
            _param.key = null;
            _param.val = null;
        }
        else
            _param = PackageParam;
    };
    return ConditionParamModelFactory;
}]);
//#endregion
//#region Manager Factory content
angular.module('AirplaneServicesModule').factory('airlineManagerFactory', ['$http', '$q', '$rootScope', function ($http, $q, $rootScope) {
    var objAirline = {
        querySearch: function (query, airlines) {
            var results = query ? airlines.filter(createFilterFor(query)) : [];
            return results;
        },
        GetAirline: function () {
            var deferred = $q.defer();
            $http({
                method: 'GET',
                url: $rootScope.baseData.G_URI_SBS_Services + 'baseData/lstAirline',
                headers: { 'Content-Type': 'application/json' }
            })
          .success(function (data) {
              objAirline.lstAirline = data
              deferred.resolve(objAirline.lstAirline);
          }).error(function (data) {
              objAirline.lstAirline = [{ Id: 1, Name: "Error" }, ];
          });
            return deferred.promise;
        },
    };
    var createFilterFor = function (query) {
        var lowercaseQuery = angular.lowercase(query);
        return function filterFn(airline) {
            return (airline.name.toLowerCase().indexOf(lowercaseQuery) === 0);
        };
    };
    //#region set AIRLINE properties objects & Method
    objAirline.lstAirline = [];
    //#endregion
    return { objAirline: objAirline };
}]);
angular.module('AirplaneServicesModule').factory('flightManagerFactory', ['GeneratId', '$q', 'flightModelFactory', 'flightPackageManagerFactory', '$rootScope', function (GeneratId, $q, flightModelFactory, flightPackageManagerFactory, $rootScope) {
    var objFlight = {
        AddFlightToPackage: function (_flight, IsMulti) {
            var flightEntity = _flight;
            flightEntity.IsMulti = IsMulti;
            if (!flightEntity.IsMulti) {
                flightPackageManagerFactory.objFlightPackage.multiSelected = false;
                flightPackageManagerFactory.objFlightPackage.AddFlightPackage();
                flightPackageManagerFactory.objFlightPackage.GetLastPack().then(function (data) {
                    var pack = data;
                    if (flightEntity.id == null) {
                        flightEntity.id = '__f:trakID' + GeneratId.G_randId(8);
                        pack.lstFlight.push(flightEntity);
                    }
                });
            }
            else if (flightEntity.IsMulti) {
                if (!flightPackageManagerFactory.objFlightPackage.multiSelected) {
                    flightPackageManagerFactory.objFlightPackage.AddFlightPackage();
                    flightPackageManagerFactory.objFlightPackage.multiSelected = true;
                }
                flightPackageManagerFactory.objFlightPackage.GetLastPack().then(function (data) {
                    var pack = data;
                    if (flightEntity.id == null) {
                        flightEntity.id = '__f:trakID' + GeneratId.G_randId(8);
                        pack.lstFlight.push(flightEntity);
                    }
                });
            }
        },
        UpdateFlightToPackage: function (_flight) {
            flightPackageManagerFactory.objFlightPackage.GetSelectedPack().then(function (data) {
                var selectedPack = data;
                for (var i in selectedPack.lstFlight) {
                    if (selectedPack.lstFlight[i].id === _flight.id) {
                        selectedPack.lstFlight[i] = _flight;
                        selectedPack.lstFlight[i].edited = false;
                        selectedPack.edited = false;
                        selectedPack.lstFlight[i].selected = false;
                        selectedPack.selected = false;
                    };
                };
                $rootScope.$broadcast('order-f-edited', { val: true, flightPackageItem: selectedPack });
            });
        },
        SelectedFlightInPackage: function (packIndex, flightIndex) {
            var lastPackageIndexOf = flightPackageManagerFactory.objFlightPackage.lastestPackageIndexOf;
            if (this.lastFlightIndexOf != null) {
                flightPackageManagerFactory.objFlightPackage.lstPackage[lastPackageIndexOf].lstFlight[this.lastFlightIndexOf].selected = false;
                flightPackageManagerFactory.objFlightPackage.lstPackage[lastPackageIndexOf].lstFlight[this.lastFlightIndexOf].edited = false;
                flightPackageManagerFactory.objFlightPackage.lstPackage[packIndex].lstFlight[flightIndex].selected = true;
                flightPackageManagerFactory.objFlightPackage.lstPackage[packIndex].lstFlight[flightIndex].edited = true;
                this.lastFlightIndexOf = flightIndex;
            }
            else {
                flightPackageManagerFactory.objFlightPackage.lstPackage[packIndex].lstFlight[flightIndex].selected = true;
                flightPackageManagerFactory.objFlightPackage.lstPackage[packIndex].lstFlight[flightIndex].edited = true;
                this.lastFlightIndexOf = flightIndex;
            }
        },
    };
    objFlight.lastFlightIndexOf = null;
    ///Private Event
    return { objFlight: objFlight };
}]);
angular.module('AirplaneServicesModule').factory('flightPackageManagerFactory', ['GeneratId', '$rootScope', 'flightPackageModelFactory', '$q', function (GeneratId, $rootScope, flightPackageModelFactory, $q) {
    var objFlightPackage = {
        AddFlightPackage: function () {
            var packEntity = new flightPackageModelFactory();
            packEntity.id = '__fp:trackID' + GeneratId.G_randId(10);
            this.lstPackage.push(packEntity);
            $rootScope.$broadcast('lstflight', { flightlist: this.lstPackage });
        },
        EditedFromOrderList: function (newPackEntity) {
            var packEntity = newPackEntity;
            this.lstPackage = [];
            this.lstPackage.push(packEntity);
        },
        DeletePackage: function (itemIndex) {
            this.lstPackage.splice(itemIndex, 1);
            $rootScope.$broadcast('lstflight', { flightlist: this.lstPackage });
        },
        DeleteFlightInPackage: function (itemFlightIndex, PackIndex) {
            this.lstPackage[PackIndex].lstFlight.splice(itemFlightIndex, 1);
        },
        SendListPackage: function () {
            return this.lstPackage;
        },
        FlightPackageLength: function () {
            return this.lstPackage.length;
        },
        SelectedPackage: function (packIndex) {
            if (this.lastPackageIndexOf != null) {
                this.lstPackage[this.lastPackageIndexOf].selected = false;
                this.lstPackage[this.lastPackageIndexOf].edited = false;
                this.lstPackage[packIndex].selected = true;
                this.lstPackage[packIndex].edited = true;
                this.lastestPackageIndexOf = this.lastPackageIndexOf;
                this.lastPackageIndexOf = packIndex;
            }
            else {
                this.lstPackage[packIndex].selected = true;
                this.lstPackage[packIndex].edited = true;
                this.lastPackageIndexOf = packIndex;
            }
        },
        GetSelectedPack: function () {
            var deferred = $q.defer();
            deferred.resolve(this.lstPackage[this.lastPackageIndexOf]);
            return deferred.promise;
        },
        GetLastPack: function () {
            var deferred = $q.defer();
            deferred.resolve(this.lstPackage[this.lstPackage.length - 1]);
            return deferred.promise;
        },
    };
    objFlightPackage.lstPackage = [];
    objFlightPackage.lastestPackageIndexOf = null;
    objFlightPackage.lastPackageIndexOf = null;
    objFlightPackage.multiSelected = false;
    ///Private Event


    return { objFlightPackage: objFlightPackage };
}]);
//#endregion