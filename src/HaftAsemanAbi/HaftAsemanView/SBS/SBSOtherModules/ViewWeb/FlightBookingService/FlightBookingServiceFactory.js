
'use strict'
angular.module('flightBookingServiceModule').factory('DomesticFlightBookingServiceModelFactory', [function () {
    var dfbsModelFactory = function (dfbs) {
        var _dfbs = this;
        if (!dfbs) {
            _dfbs.FlightID = null;
            _dfbs.AdtPrice = null;
            _dfbs.ChdPrice = null;
            _dfbs.InfPrice = null;
            _dfbs.Capacity = null;
            _dfbs.Airline = {};
            _dfbs.Aircraft = {};
            _dfbs.Departure = {};
            _dfbs.Arrival = {};
            _dfbs.DestinationIATACODE = null;
            _dfbs.PersianDepartureDate = null;
            _dfbs.DepartureDate = null;
            _dfbs.DepartureTime = null;
            _dfbs.ArrivalTime = null;
            _dfbs.FlightType = null;
            _dfbs.Reservable = null;
            _dfbs.FlightNo = null;
            _dfbs.SeatClassList = [];
            _dfbs.UpdTime = null;
            _dfbs.selected = false;
        }
        else
            _dfbs = dfbs;
    };
    return dfbsModelFactory;
}]);
angular.module('flightBookingServiceModule').factory('DomesticFlightBookingServiceFactory', ['$http', '$rootScope', function ($http, $rootScope) {
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