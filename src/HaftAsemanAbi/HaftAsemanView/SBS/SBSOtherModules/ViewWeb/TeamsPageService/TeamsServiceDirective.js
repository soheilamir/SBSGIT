
'use strict'
angular.module('teamsServiceModule').directive('teamsService', ['$rootScope', function ($rootScope) {
    return {
        scope: {
        },
        controller: "teamsServiceCtrl",
        templateUrl: "/HaftAsemanView/SBS/SBSOtherModules/ViewWeb/TeamsPageService/teamsServiceTmpl.html",
        link: function (scope, ele, attr) {

        },
    };
}]);