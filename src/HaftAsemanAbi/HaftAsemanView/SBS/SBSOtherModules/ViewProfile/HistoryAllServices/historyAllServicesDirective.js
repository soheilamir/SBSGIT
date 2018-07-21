
'use strict'
angular.module('historyAllServicesModule').directive('historyServices', [function () {
    return {
        replace: true,
        scope: {
        },
        controller: "historyAllServicesCtrl",
        templateUrl: "/HaftAsemanView/SBS/SBSOtherModules/ViewProfile/HistoryAllServices/SearchHistoryServicesTmpl.html",
    }
}]);