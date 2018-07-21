
'use strict'
angular.module('historyAllServicesModule').directive('showDetailHistoryServices', [function () {
    return {
        replace: true,
        scope: {
        },
        controller: "historyAllServicesCtrl",
        templateUrl: "/HaftAsemanView/SBS/SBSOtherModules/ViewProfile/HistoryAllServices/ShowDetailHistoryOfServicesTmpl.html",
    }
}]);