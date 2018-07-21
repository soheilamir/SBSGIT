
'use strict'
angular.module('blogServiceModule').directive('detailBlogService', ['$rootScope', function ($rootScope) {
    return {
        scope: {
        },
        controller: "blogServiceCtrl",
        templateUrl: "/HaftAsemanView/SBS/SBSOtherModules/ViewWeb/BlogPageService/detailBlogServiceTmpl.html",
        link: function (scope, ele, attr) {

        }
    };
}]);