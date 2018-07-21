
'use strict'
angular.module('FacilitiesCategoryModule').directive('facilitiesCatConfigService', ['$rootScope', function ($rootScope) {
    return {
        replace: true,
        scope: {
        },
        controller: "FacilitiesCategoryCtrl",
        templateUrl: "/HaftAsemanConsole/SBSConsole/OtherModule/ConsoleModule/CMSServicesBaseInfoHotel/FacilitiesCategory/FacilitiesCategoryTmpl.html",
        link: function (scope, ele, attr, ctrl) {
        },
    }

}])