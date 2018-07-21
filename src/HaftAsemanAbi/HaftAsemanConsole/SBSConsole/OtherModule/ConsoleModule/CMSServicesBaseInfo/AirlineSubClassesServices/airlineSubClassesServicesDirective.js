
'use strict'
angular.module('airlineSubClassesServicesModule').directive('airlineSubClassesService', [function () {
    return {
        replace: true,
        scope: {
        },
        controller: "airlineSubClassesServicesCtrl",
        templateUrl: "/HaftAsemanConsole/SBSConsole/OtherModule/ConsoleModule/CMSServicesBaseInfo/AirlineSubClassesServices/airlineSubClassesServicesTmpl.html",
    }

}])