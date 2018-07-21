
'use strict'
angular.module('airlineClassesServicesModule').directive('airlineClassesService', [function () {
    return {
        replace: true,
        scope: {
        },
        controller: "airlineClassesServicesCtrl",
        templateUrl: "/HaftAsemanConsole/SBSConsole/OtherModule/ConsoleModule/CMSServicesBaseInfo/airlineClassesServices/airlineClassesServicesTmpl.html",
    }

}])