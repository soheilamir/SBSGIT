
'use strict'
angular.module('historyAllServicesModule').directive('genTrF', [function () {
    return {
        replace: true,
        require: "^showDetailHistoryServices",
        scope: {
            lstCondition: "=",
            selectedLstInfoFlightTickets: "=",
        },
        templateUrl: "/HaftAsemanView/SBS/SBSOtherModules/ViewProfile/HistoryAllServices/Gen_Tr_FTmpl.html",
    }
}]);