
'use strict'
angular.module('multiUseModule').directive('unRegUserCo', [function () {
    return {
        replace: true,
        controller: "RegisterUserCoCtrl",
        scope: {
            unAcceptLst: "=",
            isCo: "=",
        },
        templateUrl: "/HaftAsemanView/SBS/SBSOtherModules/ViewProfile/MultiUseContent/RegisterContent/unRegUserCoTmpl.html",
        link: function (scope, ele, attr) {
        },
    }
}]);