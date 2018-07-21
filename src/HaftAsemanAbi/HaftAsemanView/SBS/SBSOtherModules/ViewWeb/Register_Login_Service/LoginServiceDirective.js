
'use strict'
angular.module('loginServiceModule').directive('loginService', ['$rootScope', function ($rootScope) {
    return {
        scope: {
        },
        controller: "loginServiceCtrl",
        templateUrl: "/HaftAsemanView/SBS/SBSOtherModules/ViewWeb/Register_Login_Service/loginServiceTmpl.html",
        link: function (scope, ele, attr) {

        },
    };
}]);