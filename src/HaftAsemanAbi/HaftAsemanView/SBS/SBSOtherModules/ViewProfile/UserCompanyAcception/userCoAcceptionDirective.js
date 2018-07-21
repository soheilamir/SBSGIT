
'use strict'
angular.module('userCoAcceptionModule').directive('acceptionUserService', [function () {
    return {
        replace: true,
        controller: 'userCoAcceptionCtrl',
        templateUrl: "/HaftAsemanView/SBS/SBSOtherModules/ViewProfile/UserCompanyAcception/userCoAcceptionTmpl.html",
    };
}]);