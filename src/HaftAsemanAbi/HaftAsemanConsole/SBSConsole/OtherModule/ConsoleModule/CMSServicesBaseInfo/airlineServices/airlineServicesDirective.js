
'use strict'
angular.module('airlineServicesModule').directive('airlineService', [function () {
    return {
        replace: true,
        scope: {
        },
        controller: "airlineServicesCtrl",
        templateUrl: "/HaftAsemanConsole/SBSConsole/OtherModule/ConsoleModule/CMSServicesBaseInfo/AirlineServices/airlineServicesTmpl.html",
    }

}])