
'use strict'
angular.module('newsServiceModule').directive('detailNewsService', ['$rootScope', function ($rootScope) {
    return {
        scope: {
        },
        controller: "newsServiceCtrl",
        templateUrl: "/HaftAsemanView/SBS/SBSOtherModules/ViewWeb/NewsPageService/detailNewsServiceTmpl.html",
        link: function (scope, ele, attr) {

        }
    };
}]);