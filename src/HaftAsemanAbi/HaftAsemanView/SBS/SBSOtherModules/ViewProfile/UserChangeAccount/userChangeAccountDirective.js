
'use strict'
angular.module('userChangeAccountModule').directive("userChargeAccountServices", [function () {
    return {
        replace: true,
        controller: "userChangeAccountCtrl",
        templateUrl: "/HaftAsemanView/SBS/SBSOtherModules/ViewProfile/UserChangeAccount/userChangeAccountTmpl.html",
        link: function (scope, ele, attr) {
        },
    };
}]);