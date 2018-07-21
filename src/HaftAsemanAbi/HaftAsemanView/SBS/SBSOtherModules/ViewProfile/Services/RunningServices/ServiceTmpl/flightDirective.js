
'use strict'
angular.module('RunningServicesModule').directive('flightTmpl', ['$rootScope', function ($rootScope, orderManagerServices) {
    return {
        replace: true,
        require: '^runningServices',
        scope: {
            flightPackList: '=',
            flightPackItem: '=',
            flightPackIndex: '=',
        },
        templateUrl: '/HaftAsemanView/SBS/SBSOtherModules/ViewProfile/Services/RunningServices/ServiceTmpl/runFlightTmpl.html',
        link: function (scope, ele, attr, ctrl) {
            //#region variable content

            //#endregion
            //#region Event content
            scope.EditFlightPackage = function (orderFlightItem) {
                ctrl.EditFlightInOrder(orderFlightItem);
            };
            scope.DeleteFlightPackageInOrder = function (flightIndex) {
                ctrl.DeleteFlightPackageInOrder(flightIndex);
            };
            //#endregion
        },
    };
}]);