
'use strict'
angular.module('allPassengerModule').directive('passengerService', [function () {
    return {
        replace: true,
        controller: 'allPassengerCtrl',
        templateUrl: "/HaftAsemanView/SBS/SBSOtherModules/ViewProfile/AllPassenger/allPassengerTmpl.html",
    };
}]);