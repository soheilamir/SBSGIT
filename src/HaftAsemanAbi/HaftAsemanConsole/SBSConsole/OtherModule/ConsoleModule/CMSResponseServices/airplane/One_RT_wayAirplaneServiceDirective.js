
'use strict'
angular.module('ResAirplaneServices').directive('oneRtWayAirplaneService', [function () {
    return {
        replace: true,
        scope: {
        },
        controller: "ResAirplaneCtrl",
        templateUrl: "/HaftAsemanConsole/SBSConsole/OtherModule/ConsoleModule/CMSResponseServices/airplane/One_RT_wayTmpl.html",
    }

}])