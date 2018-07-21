
'use strict'
angular.module('teamsServiceModule').directive('detailTeamsService', ['$rootScope', function ($rootScope) {
    return {
        scope: {
        },
        controller: "teamsServiceCtrl",
        templateUrl: "/HaftAsemanView/SBS/SBSOtherModules/ViewWeb/TeamsPageService/detailTeamsServiceTmpl.html",
        link: function (scope, ele, attr) {

        },
    };
}]);