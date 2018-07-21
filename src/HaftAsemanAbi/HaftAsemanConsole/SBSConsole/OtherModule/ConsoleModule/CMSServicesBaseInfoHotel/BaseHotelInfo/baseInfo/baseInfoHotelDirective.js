
'use strict'
angular.module('BaseInfoHotelModule').directive('hotelBaseConfigService', ['$rootScope', function ($rootScope) {
    return {
        replace: true,
        scope: {
        },
        controller: "BaseInfoHotelCtrl",
        templateUrl: "/HaftAsemanConsole/SBSConsole/OtherModule/ConsoleModule/CMSServicesBaseInfoHotel/BaseHotelInfo/baseInfo/baseInfoHotelTmpl.html",
        link: function (scope, ele, attr, ctrl) {
        },
    }

}])