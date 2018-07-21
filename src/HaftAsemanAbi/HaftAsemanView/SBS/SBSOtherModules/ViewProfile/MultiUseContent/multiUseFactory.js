angular.module('multiUseModule').factory('FlightPassengerModelFactory', [function () {
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
angular.module('multiUseModule').factory('ReserveFlightModelFactory', [function () {
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
angular.module('multiUseModule').factory('FlightTicketDataWithOrderIdModelFactory', [function () {
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
angular.module('multiUseModule').factory('ManageFlightPassengerFactory', ['$http', '$rootScope', 'FlightPassengerModelFactory', function ($http, $rootScope, FlightPassengerModelFactory) {

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
    passengerFactory.BaseUrI = $rootScope.baseData.G_URI_SBS_Services;
    passengerFactory.methodGET = 'GET';
    passengerFactory.methodPOST = 'POST';
    passengerFactory.lstAdult = [];
    passengerFactory.lstChild = [];
    passengerFactory.lstInfant = [];
    return { passengerFactory: passengerFactory }
}]);
angular.module('multiUseModule').factory('ManageDomesticFlightReserveProcessFactory', ['$http', '$rootScope', function ($http, $rootScope) {
    var DomesticFlightReserveProcessFactory = {
        ReserveFlight: function (objReserveFlight) {
            return ReserveDomesticFlight(objReserveFlight);
        },
        TicketDataWithOrderId: function (orderId) {
            return GetTicketDataWithOrderId(orderId);
        },
    };
    //#region Private Event
    DomesticFlightReserveProcessFactory.BaseUrI = $rootScope.baseData.G_URI_SBS_Services;
    DomesticFlightReserveProcessFactory.methodGET = 'GET';
    DomesticFlightReserveProcessFactory.methodPOST = 'POST';
    var ReserveDomesticFlight = function (objReserveFlight) {
        return $http({
            method: DomesticFlightReserveProcessFactory.methodPOST,
            //url: DomesticFlightReserveProcessFactory.BaseUrI + 'api/V1/domestic/ticket/pnr/reserve',
            url: "http://localhost:15609/" + 'api/flight/reserve',
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