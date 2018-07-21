
'use strict'
angular.module('coInfoModule').directive('companyInfoService', [function () {
    return {
        replace: true,
        controller: 'coInfoCtrl',
        templateUrl: "/HaftAsemanView/SBS/SBSOtherModules/ViewProfile/CompanyInfo/coInfoTmpl.html",
    };
}]);