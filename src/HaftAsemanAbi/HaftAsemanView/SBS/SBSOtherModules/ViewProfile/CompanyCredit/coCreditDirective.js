
'use strict'
angular.module('coCreditModule').directive('companyCreditService', [function () {
    return {
        replace: true,
        controller: 'coCreditCtrl',
        templateUrl: "/HaftAsemanView/SBS/SBSOtherModules/ViewProfile/CompanyCredit/coCreditTmpl.html",
    };
}]);