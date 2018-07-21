
'use strict'
angular.module('coEmployeeModule').directive('companyEmployeeService', [function () {
    return {
        replace: true,
        controller: 'coEmployeeCtrl',
        templateUrl: "/HaftAsemanView/SBS/SBSOtherModules/ViewProfile/CompanyEmployee/coEmployeeTmpl.html",
    };
}]);