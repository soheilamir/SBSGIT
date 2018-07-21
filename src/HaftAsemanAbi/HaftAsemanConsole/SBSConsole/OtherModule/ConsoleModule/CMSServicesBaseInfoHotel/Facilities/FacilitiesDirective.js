
'use strict'
angular.module('FacilitiesModule').directive('facilitiesConfigService', ['$rootScope', function ($rootScope) {
    return {
        replace: true,
        scope: {
        },
        controller: "FacilitiesCtrl",
        templateUrl: "/HaftAsemanConsole/SBSConsole/OtherModule/ConsoleModule/CMSServicesBaseInfoHotel/Facilities/FacilitiesTmpl.html",
        link: function (scope, ele, attr, ctrl) {
        },
    }

}])