
'use strict'
angular.module('regServiceModule').directive('registerService', ['$rootScope', function ($rootScope) {
    return {
        scope: {
        },
        controller: "regServiceCtrl",
        templateUrl: "/HaftAsemanView/SBS/SBSOtherModules/ViewWeb/Register_Login_Service/registerServiceTmpl.html",
        link: function (scope, ele, attr) {

        },
    };
}]);