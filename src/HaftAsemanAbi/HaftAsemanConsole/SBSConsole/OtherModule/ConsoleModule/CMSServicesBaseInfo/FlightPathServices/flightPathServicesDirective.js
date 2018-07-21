
'use strict'
angular.module('flightPathServicesModule').directive('flightPathService', [function () {
    return {
        replace: true,
        scope: {
        },
        controller: "flightPathServicesCtrl",
        templateUrl: "/HaftAsemanConsole/SBSConsole/OtherModule/ConsoleModule/CMSServicesBaseInfo/FlightPathServices/flightPathServicesTmpl.html",
    }

}])