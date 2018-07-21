
'use strict'
angular.module('headerMenuModule').directive('headerMenu', [function () {
    return {
        replace: true,
        scope: {
            innerMenu: '=',
        },
        controller: "headerMenuCtrl",
        templateUrl: "/HaftAsemanView/SBS/SBSOtherModules/ViewWeb/MenuService/HeaderMenuTmpl.html",
    };
}]);