
'use strict'
angular.module('RunningServicesModule').directive('runningServices', [function () {
    return {
        replace: true,
        scope: {
        },
        controller: 'runningServicesCtrl',
        templateUrl: "/HaftAsemanView/SBS/SBSOtherModules/ViewProfile/Services/RunningServices/runningServicesTmpl.html",
        link: function (scope, ele, attr) {
        },
    }
}]);