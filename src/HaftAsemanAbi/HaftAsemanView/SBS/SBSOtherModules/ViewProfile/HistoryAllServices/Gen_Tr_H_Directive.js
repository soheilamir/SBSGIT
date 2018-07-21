
'use strict'
angular.module('historyAllServicesModule').directive('genTrH', [function () {
    return {
        replace: true,
        require: "^showDetailHistoryServices",
        scope: {
            selectedLstInfoHotelsVoucher: "=",
            pos: "=",
        },
        templateUrl: "/HaftAsemanView/SBS/SBSOtherModules/ViewProfile/HistoryAllServices/Gen_Tr_HTmpl.html",
    }
}]);