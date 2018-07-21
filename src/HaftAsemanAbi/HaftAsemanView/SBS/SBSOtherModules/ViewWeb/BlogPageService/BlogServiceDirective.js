
'use strict'
angular.module('blogServiceModule').directive('blogService', ['$rootScope', function ($rootScope) {
    return {
        scope: {
        },
        controller: "blogServiceCtrl",
        templateUrl: "/HaftAsemanView/SBS/SBSOtherModules/ViewWeb/BlogPageService/blogServiceTmpl.html",
        link: function (scope, ele, attr) {

        },
    };
}]);