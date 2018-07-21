
'use strict'
angular.module('homeServiceModule').directive('homeService', ['$rootScope', function ($rootScope) {
    return {
        scope: {
        },
        controller: "homeServiceCtrl",
        templateUrl: "/HaftAsemanView/SBS/SBSOtherModules/ViewWeb/HomePageService/homeServiceTmpl.html",
        link: function (scope, ele, attr) {
        },
    };
}]);