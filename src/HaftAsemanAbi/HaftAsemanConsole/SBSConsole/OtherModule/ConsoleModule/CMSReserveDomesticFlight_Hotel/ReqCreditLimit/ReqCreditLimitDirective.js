
'use strict'
angular.module('ReqCreditLimitServiceMadule').directive("reqCreditLimitServices", [function () {
    return {
        replace: true,
        controller: "ReqCreditLimitServiceCtrl",
        templateUrl: "/HaftAsemanConsole/SBSConsole/OtherModule/ConsoleModule/CMSReserveDomesticFlight_Hotel/ReqCreditLimit/ReqCreditLimitTmpl.html",
        link: function (scope, ele, attr) {
        },
    };
}]);