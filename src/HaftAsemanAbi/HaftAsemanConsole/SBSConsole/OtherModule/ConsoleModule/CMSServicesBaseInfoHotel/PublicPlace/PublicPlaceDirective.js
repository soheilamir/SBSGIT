
'use strict'
angular.module('PublicPlaceModule').directive('cityPublicPlaceConfigService', ['$rootScope', function ($rootScope) {
    return {
        replace: true,
        scope: {
        },
        controller: "PublicPlaceCtrl",
        templateUrl: "/HaftAsemanConsole/SBSConsole/OtherModule/ConsoleModule/CMSServicesBaseInfoHotel/PublicPlace/PublicPlaceTmpl.html",
        link: function (scope, ele, attr, ctrl) {
        },
    }

}])