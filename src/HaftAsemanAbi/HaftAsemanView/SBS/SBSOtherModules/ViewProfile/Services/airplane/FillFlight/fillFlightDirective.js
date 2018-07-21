/// <reference path="D:\Amir Folders\Projects\7BlueSkyProject\SBS(2016_New)\HaftAsemanAbi\HaftAsemanAbi\HaftAsemanAbi\scripts/angular.js" />

'use strict'
angular.module('AirplaneServicesModule').directive('fillFlight', ['$rootScope', 'flightModelFactory', 'airlineManagerFactory', function ($rootScope, flightModelFactory, airlineManagerFactory) {
    return {
        replace: true,
        require: '^airplaneService',
        scope: {
        },
        templateUrl: '/HaftAsemanView/SBS/SBSOtherModules/ViewProfile/Services/airplane/FillFlight/fillFlightTmpl.html',
        link: function (scope, ele, attr, ctrl) {
            //#region variable
            scope._f = true; scope._h = false; // for callender directive
            scope.baseData = $rootScope.ProfileDefaultData; // set base data for flight
            scope.newFlight = new flightModelFactory(); /// initial scope.newFlight
            //#endregion
            /// airline content
            scope.selectedItem = null;
            scope.searchText = null;
            scope.selectedAirlines = [];
            airlineManagerFactory.objAirline.GetAirline().then(function (data) {
                if (data.length > 0)
                    scope.airlines = data;
                else {
                    scope.airlines = [
                                        { id: 1, name: "Qatar Airways", type: "" },
                                        { id: 2, name: "Singapore Airlines", type: "" },
                                        { id: 3, name: "Cathay Pacific Airways", type: "" },
                                        { id: 4, name: "Turkish Airlines", type: "" },
                                        { id: 5, name: "Emirates", type: "" },
                    ]
                };
            }); /// Get airline list for autocomplete
            scope.querySearch = function (query) {
                return airlineManagerFactory.objAirline.querySearch(query, scope.airlines);
            };
            /// end airline content
            //#region Event content
            scope.$on('set-flight', function (e, data) {
                scope.newFlight = new flightModelFactory();
                angular.copy(data.flight, scope.newFlight);
                angular.copy(scope.newFlight.airlineList, scope.selectedAirlines);///show airline in airline chips content
            });
            scope.CreateFlightInPackage = function (IsMulti) {
                angular.copy(scope.selectedAirlines, scope.newFlight.airlineList);
                if (!scope.newFlight.edited)
                    ctrl.CreateFlightInPackage(scope.newFlight, IsMulti);
                else
                    ctrl.EditFlightInPackage(scope.newFlight);
                scope.newFlight = new flightModelFactory();
                scope.selectedAirlines = [];

            };
            scope.AddMultiFlightInPackage = function (IsMulti) {
                angular.copy(scope.selectedAirlines, scope.newFlight.airlineList);
                if (!scope.newFlight.edited)
                    ctrl.CreateFlightInPackage(scope.newFlight, IsMulti);
                else
                    ctrl.EditFlightInPackage(scope.newFlight);
                scope.newFlight = new flightModelFactory();
                scope.newFlight.journeyType = { id: '3', name: 'چند سفره' },
                scope.selectedAirlines = [];
            };
            //#endregion
        },
    };
}]);