
'use strict'
angular.module('headerMenuModule').directive('lawRegulation', [function () {
    return {
        replace: true,
        require: '^baseMenu',
        scope: {
        },
        templateUrl: "/HaftAsemanView/SBS/SBSOtherModules/ViewWeb/MenuService/Laws_RegulationsTmpl.html",
        link: function (scope, ele, attr, ctrl) {
            scope.HideSection = function () {
                ctrl.HideSection();
            };
        }
    };
}]);