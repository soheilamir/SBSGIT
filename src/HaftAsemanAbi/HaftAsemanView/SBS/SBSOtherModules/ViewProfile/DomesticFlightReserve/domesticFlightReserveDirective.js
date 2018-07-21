
'use strict'
angular.module('domesticFlightReserveModule').directive('domesticFlightReserveService', [function () {
    return {
        replace: true,
        scope: {
        },
        controller: "domesticFlightReserveCtrl",
        templateUrl: "/HaftAsemanView/SBS/SBSOtherModules/ViewProfile/DomesticFlightReserve/domesticFlightReserveTmpl.html",
    }

}]);