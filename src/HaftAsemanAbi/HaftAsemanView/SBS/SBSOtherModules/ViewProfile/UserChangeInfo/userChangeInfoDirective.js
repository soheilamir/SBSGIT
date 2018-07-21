
'use strict'
angular.module('userChangeInfoModule').directive("changeUserInfoServices", [function () {
    return {
        replace: true,
        controller: "userChangeInfoCtrl",
        templateUrl: "/HaftAsemanView/SBS/SBSOtherModules/ViewProfile/UserChangeInfo/userChangeInfoTmpl.html",
        link: function (scope, ele, attr) {
        },
    };
}]);