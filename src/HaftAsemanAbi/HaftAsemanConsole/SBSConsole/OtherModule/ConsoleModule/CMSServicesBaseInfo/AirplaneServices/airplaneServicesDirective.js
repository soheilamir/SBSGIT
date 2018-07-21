
'use strict'
angular.module('airplaneServicesModule').directive('airplaneService', [function () {
    return {
        replace: true,
        scope: {
        },
        controller: "airplaneServicesCtrl",
        templateUrl: "/HaftAsemanConsole/SBSConsole/OtherModule/ConsoleModule/CMSServicesBaseInfo/AirplaneServices/airplaneServicesTmpl.html",
    }

}])