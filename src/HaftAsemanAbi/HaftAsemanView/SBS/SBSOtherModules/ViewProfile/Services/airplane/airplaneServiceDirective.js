
'use strict'
angular.module('AirplaneServicesModule').directive('airplaneService', [function () {
    return {
        replace: true,
        scope: {
        },
        templateUrl: "/HaftAsemanView/SBS/SBSOtherModules/ViewProfile/Services/airplane/airplaneServiceTmpl.html",
        controller: "airlineServiceCtrl",
    };
}]);