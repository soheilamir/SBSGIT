
'use strict'
angular.module('headerMenuModule').directive('innerMenu', [function () {
    return {
        replace: true,
        require: '^baseMenu',
        scope: {
        },
        templateUrl: "/HaftAsemanView/SBS/SBSOtherModules/ViewWeb/MenuService/InnerMenuTmpl.html",
        link: function (scope, ele, attr, ctrl) {
        }
    };
}]);