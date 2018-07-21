
'use strict'
angular.module('multiUseModule').directive('checkoutTicketService', [function () {
    return {
        replace: true,
        controller: "checkoutTicketCtrl",
        scope: {
        },
        templateUrl: "/HaftAsemanView/SBS/SBSOtherModules/ViewProfile/MultiUseContent/CheckoutInfoTicket/CheckoutInfoTicketTmpl.html",
        link: function (scope, ele, attr, ctrl) {
        },
    }
}]);