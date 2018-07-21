
'use strict'
angular.module('domesticFlightReserveModule').directive('flightContent', [function () {
    return {
        replace: true,
        require: '^domesticFlightReserveService',
        scope: {
            flightObj: "=",
        },
        templateUrl: "/HaftAsemanView/SBS/SBSOtherModules/ViewProfile/DomesticFlightReserve/flightContentTmpl.html",
        link: function (scope, ele, attr, ctrl) {
        },
    }

}]);