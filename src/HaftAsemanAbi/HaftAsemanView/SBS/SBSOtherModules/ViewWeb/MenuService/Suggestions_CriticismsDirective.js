
'use strict'
angular.module('headerMenuModule').directive('suggestionsCriticism', [function () {
    return {
        replace: true,
        require: '^baseMenu',
        scope: {
        },
        templateUrl: "/HaftAsemanView/SBS/SBSOtherModules/ViewWeb/MenuService/Suggestions_CriticismsTmpl.html",
        link: function (scope, ele, attr, ctrl) {
            scope.HideSection_2 = function () {
                ctrl.HideSection_2();
            };
        }
    };
}]);