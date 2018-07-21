
'use strict'
angular.module('UserCompanyPaymentReqModule').directive('userCompanyPaymentReqService', [function () {
    return {
        replace: true,
        controller: 'UserCompanyPaymentReqCtrl',
        templateUrl: "/HaftAsemanView/SBS/SBSOtherModules/ViewProfile/UserCompanyPaymentReq/userCompanyPaymentReqTmpl.html",
    };
}]);