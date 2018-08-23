
'use strict'
angular.module('headerMenuModule').directive('baseMenu', [function () {
    return {
        replace: true,
        scope: {
        },
        controller: "headerMenuCtrl",
        templateUrl: "/HaftAsemanView/SBS/SBSOtherModules/ViewWeb/MenuService/HeaderMenuTmpl.html",
    };
}]);