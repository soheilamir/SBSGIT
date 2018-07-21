
'use strict'
angular.module('coOrgChartModule').directive('companyOrgChartService', [function () {
    return {
        replace: true,
        controller: 'coOrgChartCtrl',
        templateUrl: "/HaftAsemanView/SBS/SBSOtherModules/ViewProfile/CompanyOrgChart/coOrgChartTmpl.html",
    };
}]);