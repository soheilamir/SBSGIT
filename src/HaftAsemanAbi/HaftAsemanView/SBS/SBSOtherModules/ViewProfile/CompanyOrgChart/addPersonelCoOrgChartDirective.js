
'use strict'
angular.module('addPersonelCoOrgChartModule').directive('addCompanyPersonelOrgChartService', [function () {
    return {
        replace: true,
        controller: 'addPersonelCoOrgChartCtrl',
        templateUrl: "/HaftAsemanView/SBS/SBSOtherModules/ViewProfile/CompanyOrgChart/addPersonelCoOrgChartTmpl.html",
    };
}]);