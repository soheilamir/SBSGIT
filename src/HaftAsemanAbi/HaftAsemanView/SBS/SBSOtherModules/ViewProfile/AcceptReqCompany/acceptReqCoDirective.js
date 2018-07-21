
'use strict'
angular.module('acceptReqCoModule').directive('acceptReqCoServices', [function () {
    return {
        replace: true,
        controller: 'acceptReqCoCtrl',
        templateUrl: "/HaftAsemanView/SBS/SBSOtherModules/ViewProfile/AcceptReqCompany/acceptReqCoTmpl.html",
    };
}]);