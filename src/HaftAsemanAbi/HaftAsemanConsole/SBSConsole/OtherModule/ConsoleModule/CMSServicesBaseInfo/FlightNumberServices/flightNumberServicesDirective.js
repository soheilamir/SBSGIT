
'use strict'
angular.module('flightNumberServicesModule').directive('flightNumberService', [function () {
    return {
        replace: true,
        scope: {
        },
        controller: "flightNumberServicesCtrl",
        templateUrl: "/HaftAsemanConsole/SBSConsole/OtherModule/ConsoleModule/CMSServicesBaseInfo/FlightNumberServices/flightNumberServicesTmpl.html",
    }

}])