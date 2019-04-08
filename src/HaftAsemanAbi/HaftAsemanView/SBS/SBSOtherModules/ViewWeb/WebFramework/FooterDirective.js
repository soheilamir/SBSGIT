
'use strict'
angular.module('webFrameworkModule').directive('footerContent', ['$rootScope', function ($rootScope) {
    return {
        replace: true,
        scope: {
        },
        controller: "webframeworkCtrl",
        templateUrl: "/HaftAsemanView/SBS/SBSOtherModules/ViewWeb/WebFramework/FooterTmpl.html",
        link: function (scope, ele, attr) {
        }
    };
}]);