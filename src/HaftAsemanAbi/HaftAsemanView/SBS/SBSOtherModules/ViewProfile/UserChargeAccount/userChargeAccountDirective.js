
'use strict'
angular.module('userChargeAccountModule').directive("userChargeAccountServices", [function () {
    return {
        replace: true,
        controller: "userChargeAccountCtrl",
        templateUrl: "/HaftAsemanView/SBS/SBSOtherModules/ViewProfile/UserChargeAccount/userChargeAccountTmpl.html",
        link: function (scope, ele, attr) {
        },
    };
}]);