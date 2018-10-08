
'use strict'
angular.module('AllDirectiveModule').directive('flightSearchBooking', [function () {
    return {
        replace: true,
        scope: {
        },
        templateUrl: "/HaftAsemanView/SBS/SBSOtherModules/ViewWeb/AllDirective/flightSearchBookingTmpl.html",
        link: function (scope, ele, attr) {
        }
    };
}]);