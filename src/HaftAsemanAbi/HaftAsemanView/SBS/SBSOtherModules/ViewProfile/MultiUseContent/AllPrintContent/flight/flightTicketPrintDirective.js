
'use strict'
angular.module('multiUseModule').directive('flightTicketPrintServices', [function () {
    return {
        replace: true,
        controller: "printServicesCtrl",
        scope: {
        },
        templateUrl: "/HaftAsemanView/SBS/SBSOtherModules/ViewProfile/MultiUseContent/AllPrintContent/flight/flightTicketPrintTmpl.html",
        link: function (scope, ele, attr) {
        },
    }
}]);
