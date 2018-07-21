
'use strict'
angular.module('InsuranceServicesModule').directive('insuranceServices', [function () {
    return {
        replace: true,
        controller: 'InsuranceServicesCtrl',
        templateUrl: "/HaftAsemanConsole/SBSConsole/OtherModule/ConsoleModule/CMSReserveDomesticFlight_Hotel/Insurance/InsuranceTmpl.html",
    };
}]);