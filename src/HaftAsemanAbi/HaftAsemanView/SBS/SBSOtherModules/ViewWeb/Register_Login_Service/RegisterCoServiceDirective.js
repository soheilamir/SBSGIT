
'use strict'
angular.module('regServiceModule').directive('registerCoService', ['$rootScope', function ($rootScope) {
    return {
        scope: {
        },
        controller: "regCoServiceCtrl",
        templateUrl: "/HaftAsemanView/SBS/SBSOtherModules/ViewWeb/Register_Login_Service/registerCoServiceTmpl.html",
        link: function (scope, ele, attr) {

        },
    };
}]);