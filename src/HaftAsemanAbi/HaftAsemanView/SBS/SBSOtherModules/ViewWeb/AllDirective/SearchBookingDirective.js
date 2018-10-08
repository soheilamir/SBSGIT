
'use strict'
angular.module('AllDirectiveModule').directive('searchBooking', [function () {
    return {
        replace: true,
        scope: {
        },
        templateUrl: "/HaftAsemanView/SBS/SBSOtherModules/ViewWeb/AllDirective/SearchBookingTmpl.html",
        link: function (scope, ele, attr) {
        }
    };
}]);