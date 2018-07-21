
'use strict'
angular.module('ResAirplaneServices').directive('multiWayAirplaneService', [function () {
    return {
        replace: true,
        scope: {
        },
        controller: "ResAirplaneCtrl",
        templateUrl: "/HaftAsemanConsole/SBSConsole/OtherModule/ConsoleModule/CMSResponseServices/airplane/MultiwayTmpl.html",
    }

}])