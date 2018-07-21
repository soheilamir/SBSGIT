
'use strict'
angular.module('homeServiceModule').factory('homeServiceModelFactory', [function () {
    var homeServiceModelFactory = function (hpage) {
        var _hpage = this;
        if (!hpage) {
            _hpage.banner = null;
        }
        else
            _hpage = hpage;
    };
    return homeServiceModelFactory;
}]);
angular.module('homeServiceModule').factory('internalFlightModelFactory', [function () {
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
angular.module('homeServiceModule').factory('homeServiceFactory', ['$http', '$rootScope', function ($http, $rootScope) {
    var homefactory = {
        FillingHomePage: function (kind) {
            return GetHomeData(kind);
        },
        InternalFlight: function (searchDataItem) {
            return GetInternalFlightData(searchDataItem);
        },
    };
    homefactory.BaseUrI = $rootScope.baseData.G_URI_SBS_Services;
    homefactory.methodGET = 'GET';
    homefactory.methodPOST = 'POST';
    //#region Private Event
    var GetHomeData = function (kind) {
        return $http({
            method: homefactory.methodGET,
            url: homefactory.BaseUrI + 'api/V1/GetPageInfo/' + kind + '/HomePage',
            headers: { 'Content-Type': 'application/json' }
        });
    };
    var GetInternalFlightData = function (searchDataItem) {
        return $http({
            method: "GET",
            url: homefactory.BaseUrI + 'api/V1/domestic/ticket/getdata',
            //url: "http://api.hiholiday.ir/v4/Flight/OneWay/f16d76bd-b3cc-47bf-8c48-4c660c90e972/THR/MHD/1397-1-20/1/5/1",
            data: JSON.stringify(searchDataItem),
            //headers: { 'Content-Type': 'text/html', 'Authorization': 'Basic YmVlcDpib29w' }
            headers: { 'Content-Type': 'application/json' }
        });
    };
    //#rendegion
    return { homefactory: homefactory }
}]);