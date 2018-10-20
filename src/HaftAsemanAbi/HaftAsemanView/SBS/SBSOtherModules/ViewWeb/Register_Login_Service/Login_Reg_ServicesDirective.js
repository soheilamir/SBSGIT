
'use strict'
angular.module('Login_Reg_ServiceModule').directive('loginRegService', [function () {
    return {
        replace: true,
        controller: "LoginRegCtrl",
        templateUrl: "/HaftAsemanView/SBS/SBSOtherModules/ViewWeb/Register_Login_Service/Login_Reg_ServicesTmpl.html",
    };
}]);