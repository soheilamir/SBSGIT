
'use strict'
angular.module('webFrameworkModule').directive('sbswebFramework', ['$rootScope', function ($rootScope) {
    return {
        transclude: true,
        scope: {
            altTitle: '@',
            srcUrl: '@',
        },
        controller: "webframeworkCtrl",
        templateUrl: "/HaftAsemanView/SBS/SBSOtherModules/ViewWeb/WebFramework/webFrameworkTmpl.html",
    };
}]);