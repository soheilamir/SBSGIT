
'use strict'
angular.module('AirplaneServicesModule').directive('flightPackage', ['$rootScope', 'flightPackageModelFactory', 'flightPackageManagerFactory', function ($rootScope, flightPackageModelFactory, flightPackageManagerFactory) {
    return {
        replace: true,
        require: '^airplaneService',
        scope: {
            flightPackList: '=',
            flightPackItem: '=',
            flightPackIndex: '=',
        },
        templateUrl: '/HaftAsemanView/SBS/SBSOtherModules/ViewProfile/Services/airplane/FlightPackage/flightPackageTmpl.html',
        link: function (scope, ele, attr, ctrl) {
            //#region variable 
            $rootScope.$on('clear-f-services', function (e, data) {
                if (data.clear)
                    ctrl.ClearFlightPackage();
            });
            //#endregion
            //#region Event content
            scope.EditFlight = function (flightIndex, PackIndex) {
                ctrl.EditFlight_In_Package(flightIndex, PackIndex);
            };
            scope.DeleteFlight = function (flightIndex, PackIndex) {
                ctrl.DeleteFlight_In_Package(flightIndex, PackIndex);
            };
            scope.UndoFlight = function (flightIndex, PackIndex) {
                ctrl.UndoFlight_In_Package(flightIndex, PackIndex);
            };
            scope.CompletedDeleteFlight = function (flightIndex, PackIndex) {
                ctrl.CompletedDeleteFlight_In_Package(flightIndex, PackIndex);
            };
            scope.DeletePackage = function (flightPackIndex) {
                ctrl.DeletePackage(flightPackIndex);
            };
            //#endregion
        },
    };
}]);