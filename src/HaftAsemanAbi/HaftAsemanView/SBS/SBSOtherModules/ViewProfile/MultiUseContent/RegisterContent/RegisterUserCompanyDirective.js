
'use strict'
angular.module('multiUseModule').directive('regUserCo', [function () {
    return {
        replace: true,
        controller: "RegisterUserCoCtrl",
        scope: {
            showBottom: "=",
            isModal: "=",
            acceptedLst: "=",
            isCo: "=",
        },
        templateUrl: "/HaftAsemanView/SBS/SBSOtherModules/ViewProfile/MultiUseContent/RegisterContent/regUserCoTmpl.html",
        link: function (scope, ele, attr) {
        },
    }
}]);