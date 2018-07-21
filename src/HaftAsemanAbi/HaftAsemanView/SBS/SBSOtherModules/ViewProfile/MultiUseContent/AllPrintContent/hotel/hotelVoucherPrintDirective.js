
'use strict'
angular.module('multiUseModule').directive('hotelVoucherPrintServices', [function () {
    return {
        replace: true,
        controller: "printServicesCtrl",
        scope: {
        },
        templateUrl: "/HaftAsemanView/SBS/SBSOtherModules/ViewProfile/MultiUseContent/AllPrintContent/hotel/hotelVoucherPrintTmpl.html",
        link: function (scope, ele, attr) {
        },
    }
}]);
