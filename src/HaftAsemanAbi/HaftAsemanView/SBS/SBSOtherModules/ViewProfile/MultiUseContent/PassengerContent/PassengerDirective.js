
'use strict'
angular.module('domesticFlightReserveModule').directive('passengerFlight', [function () {
    return {
        replace: true,
        //require: '^domesticFlightReserveService',
        controller: "passengerFlightCtrl",
        scope: {
            lstAdult: "=",
            lstChild: "=",
            lstInfant: "=",
        },
        templateUrl: "/HaftAsemanView/SBS/SBSOtherModules/ViewProfile/MultiUseContent/PassengerContent/passengerSectionTmpl.html",
        link: function (scope, ele, attr, ctrl) {
        },
    }
}]);