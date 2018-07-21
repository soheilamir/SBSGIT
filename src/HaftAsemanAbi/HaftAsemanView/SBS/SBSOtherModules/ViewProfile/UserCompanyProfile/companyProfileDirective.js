
'use strict'
angular.module('CompanyProfileModule').directive('companyProfileService', [function () {
    return {
        replace: true,
        controller: 'CompanyProfileCtrl',
        templateUrl: "/HaftAsemanView/SBS/SBSOtherModules/ViewProfile/UserCompanyProfile/companyProfileTmpl.html",
    };
}]);