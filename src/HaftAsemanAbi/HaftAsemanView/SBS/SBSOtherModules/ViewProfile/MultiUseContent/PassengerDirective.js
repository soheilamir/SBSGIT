
'use strict'
angular.module('domesticFlightReserveModule').directive('passengerFlight', [function () {
    return {
        replace: true,
        require: '^domesticFlightReserveService',
        scope: {
            lstAdult: "=",
            lstChild: "=",
            lstInfant: "=",
        },
        templateUrl: "/HaftAsemanView/SBS/SBSOtherModules/ViewProfile/MultiUseContent/passengerSectionTmpl.html",
        link: function (scope, ele, attr, ctrl) {
        },
    }
}]);