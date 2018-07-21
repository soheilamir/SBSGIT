
'use strict'
angular.module('airlineClassPathServicesModule').directive('airlineClassPathService', [function () {
    return {
        replace: true,
        scope: {
        },
        controller: "airlineClassPathServicesCtrl",
        templateUrl: "/HaftAsemanConsole/SBSConsole/OtherModule/ConsoleModule/CMSServicesBaseInfo/AirlineClassPathServices/airlineClassPathServicesTmpl.html",
    }

}])