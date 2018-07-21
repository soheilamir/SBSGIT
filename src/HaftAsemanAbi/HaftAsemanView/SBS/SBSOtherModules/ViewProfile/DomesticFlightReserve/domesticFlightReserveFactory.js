'use strict'
angular.module('domesticFlightReserveModule').factory('AllInfoDomesticFlightModelFactory', [function () {
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