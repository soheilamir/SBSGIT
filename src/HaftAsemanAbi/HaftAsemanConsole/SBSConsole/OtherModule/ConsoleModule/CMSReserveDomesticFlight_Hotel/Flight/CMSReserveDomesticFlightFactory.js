
'use strict'
angular.module('CMSReserveDomesticFlightModule').factory('internalFlightModelFactory', [function () {
    var internalFlightModelFactory = function (Flight) {
        var _flight = this;
        if (!Flight) {
            _flight.Source = {};
            _flight.Destination = {};
            _flight.JourneyType = {};
            _flight.DepartingDate = null;
            _flight.ReturningDate = null;
            _flight.Adult = { Id: '0', Number: '0' };
            _flight.Child = { Id: '0', Number: '0' };
            _flight.Infant = { Id: '0', Number: '0' };
            _flight.DomesticAirline = { Id: '0', D_AirlineName: 'ALL', AirlineATAName: 'ALL' };
        }
        else
            _flight = Flight;
    };
    return internalFlightModelFactory;
}]);
angular.module('CMSReserveDomesticFlightModule').factory('DomesticFlightBookingServiceModelFactory', [function () {
    var dfbsModelFactory = function (dfbs) {
        var _dfbs = this;
        if (!dfbs) {
            _dfbs.AirLine = null;
            _dfbs.Name = null;
            _dfbs.Origin = null;
            _dfbs.CharCode = null;
            _dfbs.Destination = null;
            _dfbs.DestinationIATACODE = null;
            _dfbs.DepartureDateShamsi = null;
            _dfbs.DepartureDateMiladi = null;
            _dfbs.DepartureTime = null;
            _dfbs.ArrivalTime = null;
            _dfbs.PlaneType = null;
            _dfbs.PlaneTypeCode = null;
            _dfbs.FlightNo = null;
            _dfbs.ClassFareList = [];
            _dfbs.LogoImg = null;
            _dfbs.selected = false;
        }
        else
            _dfbs = dfbs;
    };
    return dfbsModelFactory;
}]);
angular.module('CMSReserveDomesticFlightModule').factory('AllInfoDomesticFlightModelFactory', [function () {
    var AllInfoDomesticFlightModelFactory = function (dfbs) {
        var _dfbs = this;
        if (!dfbs) {
            _dfbs.Source = null;
            _dfbs.Destination = null;
            _dfbs.DepartingDate = null;
            _dfbs.ReturningDate = null;
            _dfbs.Adult = null;
            _dfbs.Child = null;
            _dfbs.Infant = null;

            _dfbs.D_AirLine = null;
            _dfbs.D_Name = null;
            _dfbs.D_DepartureTime = null;
            _dfbs.D_ArrivalTime = null;
            _dfbs.D_PlaneType = null;
            _dfbs.D_FlightNo = null;
            _dfbs.D_FlightClass = null;
            _dfbs.D_AdultFare = null;
            _dfbs.D_ChildFare = null;
            _dfbs.D_InfantFare = null;

            _dfbs.D_AirlineClassPathFeeId = null;

            _dfbs.D_LogoImg = null;

            _dfbs.R_AirLine = null;
            _dfbs.R_Name = null;
            _dfbs.R_DepartureTime = null;
            _dfbs.R_ArrivalTime = null;
            _dfbs.R_PlaneType = null;
            _dfbs.R_FlightNo = null;
            _dfbs.R_FlightClass = null;
            _dfbs.R_AdultFare = null;
            _dfbs.R_ChildFare = null;
            _dfbs.R_InfantFare = null;

            _dfbs.R_AirlineClassPathFeeId = null;

            _dfbs.R_LogoImg = null;
        }
        else
            _dfbs = dfbs;
    };
    return AllInfoDomesticFlightModelFactory;
}]);
angular.module('CMSReserveDomesticFlightModule').factory('FlightPassengerModelFactory', [function () {
    var FlightPassengerModelFactory = function (passenger) {
        var _passenger = this;
        if (!passenger) {
            _passenger.Id = 0;
            _passenger.Name_Fa = null;
            _passenger.LastName_Fa = null;
            _passenger.Name_En = null;
            _passenger.LastName_En = null;
            _passenger.Tel = null;
            _passenger.NationalCode = null;
            _passenger.BD = null;
        }
        else
            _passenger = passenger;
    };
    return FlightPassengerModelFactory;
}]);
angular.module('CMSReserveDomesticFlightModule').factory('ReserveFlightModelFactory', [function () {
    var ReserveFlightModelFactory = function (rfm) {
        var _rfm = this;
        if (!rfm) {
            _rfm.Source = {};
            _rfm.Target = {};

            _rfm.D_Airline = null;
            _rfm.D_FlightClass = null;
            _rfm.D_FlightNo = null;
            _rfm.D_AirlineClassPathFeeId = null;
            _rfm.D_Day = null;
            _rfm.D_Month = null;
            _rfm.D_Date = null;

            _rfm.R_Airline = null;
            _rfm.R_FlightClass = null;
            _rfm.R_FlightNo = null;
            _rfm.R_AirlineClassPathFeeId = null;
            _rfm.R_Day = null;
            _rfm.R_Month = null;
            _rfm.R_Date = null;

            _rfm.No = null;
            _rfm.lstAdult = [];
            _rfm.lstChild = [];
            _rfm.lstInfant = [];
        }
        else
            _rfm = rfm;
    };
    return ReserveFlightModelFactory;
}]);
angular.module('CMSReserveDomesticFlightModule').factory('FlightTicketDataWithOrderIdModelFactory', [function () {
    var FlightTicketDataWithOrderIdModelFactory = function (model) {
        var _model = this;
        if (!model) {
            _model.RegistrarFullName = null;
            _model.DepatringDate = null;
            _model.PNR = null;
            _model.Source = {};
            _model.Destination = {};
            _model.TakeOffTime = null;
            _model.LandingTime = null;
            _model.AirplaneName = null;
            _model.FlightNumber = null;
            _model.AdultFee = null;
            _model.ChildFee = null;
            _model.InfantFee = null;
            _model.Airline = {};
            _model.FlightClass = null;
            _model.RegisterDate = null;
            _model.PassengerS = [];
        }
        else
            _model = model;
    };
    return FlightTicketDataWithOrderIdModelFactory;
}]);

////////// 
/////// All Manager Factory Content
angular.module('CMSReserveDomesticFlightModule').factory('FlightServiceFactory', ['$http', '$rootScope', function ($http, $rootScope) {
    var flightfactory = {
        InternalFlight: function (searchDataItem) {
            return GetInternalFlightData(searchDataItem);
        },
    };
    flightfactory.BaseUrI = $rootScope.baseData.G_URI_API;
    flightfactory.methodGET = 'GET';
    flightfactory.methodPOST = 'POST';
    //#region Private Event
    var GetInternalFlightData = function (searchDataItem) {
        return $http({
            method: flightfactory.methodPOST,
            url: flightfactory.BaseUrI + 'api/V1/domestic/ticket/getdata',
            data: JSON.stringify(searchDataItem),
            headers: { 'Content-Type': 'application/json' }
        });
    };
    //#rendegion
    return { flightfactory: flightfactory }
}]);

angular.module('CMSReserveDomesticFlightModule').factory('DomesticFlightBookingServiceFactory', ['$http', '$rootScope', function ($http, $rootScope) {
    var dfbsFactory = {
        UnSelectedItem: function (lst) {
            angular.forEach(lst, function (item, index) {
                item.selected = false;
                angular.forEach(item.ClassFareList, function (c_f_item, index) {
                    c_f_item.selected = false;
                });
            });
        },
    };
    //#region Private Event
    //#rendegion

    return { dfbsFactory: dfbsFactory }
}]);
angular.module('CMSReserveDomesticFlightModule').factory('ManageFlightPassengerFactory', ['$http', '$rootScope', 'FlightPassengerModelFactory', function ($http, $rootScope, FlightPassengerModelFactory) {

    var passengerFactory = {
        AddPassengerToList: function (item, cnt) {
            if (cnt == 0) {
                var passengerEntity = new FlightPassengerModelFactory();
                if (item === 'adult') {
                    //passengerEntity.Id = passengerFactory.lstAdult.length + 1;
                    passengerFactory.lstAdult.push(passengerEntity);
                }
                else if (item === 'child') {
                    //passengerEntity.Id = passengerFactory.lstChild.length + 1;
                    passengerFactory.lstChild.push(passengerEntity);
                }
                else {
                    //passengerEntity.Id = passengerFactory.lstInfant.length + 1;
                    passengerFactory.lstInfant.push(passengerEntity);
                }
            }
            else {
                for (var i = 0; i < cnt; i++) {
                    var passengerEntity = new FlightPassengerModelFactory();
                    if (item === 'adult') {
                        //passengerEntity.Id = passengerFactory.lstAdult.length + 1;
                        passengerFactory.lstAdult.push(passengerEntity);
                    }
                    else if (item === 'child') {
                        //passengerEntity.Id = passengerFactory.lstChild.length + 1;
                        passengerFactory.lstChild.push(passengerEntity);
                    }
                    else {
                        //passengerEntity.Id = passengerFactory.lstInfant.length + 1;
                        passengerFactory.lstInfant.push(passengerEntity);
                    }
                }
            }
        },
        SavePassengerList: function (lstAdult, lstChild, lstInfant) {
            var passengers = {
                adultList: lstAdult,
                childList: lstChild,
                infantList: lstInfant
            };
            return $http({
                method: passengerFactory.methodPOST,
                url: passengerFactory.BaseUrI + 'api/V1/domestic/SavePassenger',
                data: { PassengersList: passengers },
                headers: { 'Content-Type': 'application/json' }
            });
        },
        UpdatePassengerList: function () {
        },
    };
    passengerFactory.BaseUrI = $rootScope.baseData.G_URI_API;
    passengerFactory.methodGET = 'GET';
    passengerFactory.methodPOST = 'POST';
    passengerFactory.lstAdult = [];
    passengerFactory.lstChild = [];
    passengerFactory.lstInfant = [];
    return { passengerFactory: passengerFactory }
}]);
angular.module('CMSReserveDomesticFlightModule').factory('ManageDomesticFlightReserveProcessFactory', ['$http', '$rootScope', function ($http, $rootScope) {
    var DomesticFlightReserveProcessFactory = {
        ReserveFlight: function (objReserveFlight) {
            return ReserveDomesticFlight(objReserveFlight);
        },
        TicketDataWithOrderId: function (orderId) {
            return GetTicketDataWithOrderId(orderId);
        },
    };
    //#region Private Event
    DomesticFlightReserveProcessFactory.BaseUrI = $rootScope.baseData.G_URI_API;
    DomesticFlightReserveProcessFactory.methodGET = 'GET';
    DomesticFlightReserveProcessFactory.methodPOST = 'POST';
    var ReserveDomesticFlight = function (objReserveFlight) {
        return $http({
            method: DomesticFlightReserveProcessFactory.methodPOST,
            url: DomesticFlightReserveProcessFactory.BaseUrI + 'api/V1/domestic/ticket/pnr/reserve',
            data: JSON.stringify(objReserveFlight),
            headers: { 'Content-Type': 'application/json' }
        });
    };
    var GetTicketDataWithOrderId = function (orderId) {
        return $http({
            method: DomesticFlightReserveProcessFactory.methodGET,
            url: DomesticFlightReserveProcessFactory.BaseUrI + 'api/V1/domestic/ticket/' + orderId + '/GetSavedTicketByOrder',
            headers: { 'Content-Type': 'application/json' }
        });
    };
    //#endregion
    return { DomesticFlightReserveProcessFactory: DomesticFlightReserveProcessFactory }
}]);