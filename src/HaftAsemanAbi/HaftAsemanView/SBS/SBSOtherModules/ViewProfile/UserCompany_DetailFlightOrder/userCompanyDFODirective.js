
'use strict'
angular.module('userCompanyDFOModule').directive('userCompanyDfoService', [function () {
    return {
        replace: true,
        controller: 'userCompanyDFOCtrl',
        templateUrl: "/HaftAsemanView/SBS/SBSOtherModules/ViewProfile/UserCompany_DetailFlightOrder/userCompanyDFOTmpl.html",
    };
}]);