
'use strict'
angular.module('flightBookingServiceModule').directive('filteringFlightServices', ['$rootScope', function ($rootScope) {
    return {
        scope: {
        },
        replace: true,
        require: '^dfbServices',
        templateUrl: "/HaftAsemanView/SBS/SBSOtherModules/ViewWeb/FlightBookingService/DomesticFlight/FilteringFlightTmpl.html",
        link: function (scope, ele, attr, ctrl) {
            $rootScope.Param = {};
            //Event Local
            scope.StepItem = function (item) {
                $rootScope.Param.step = item;
            };
            scope.TimeItem = function (item) {
                $rootScope.Param.time = item;
            };
            scope.ClassItem = function (item) {
                $rootScope.Param.class = item;
            };
            scope.AirlineItem = function (item) {
                $rootScope.Param.airline = item;
            };
            // Event Controller
            scope.ModifySearchFlight = function () {
                ctrl.ChangeFlight(true);
            };

        },
    };
}]).filter("dateFilter", dateFilter);
function dateFilter() {
    return function (input, start, end) {
        var inputDate = new Date(input),
            startDate = new Date(start),
            endDate = new Date(end),
            result = [];

        for (var i = 0, len = input.length; i < len; i++) {
            inputDate = new Date(input[i].DepartureDateTime);
            if (startDate < inputDate && inputDate < endDate) {
                result.push(input[i]);
            }
        }
        return result;
    };
};