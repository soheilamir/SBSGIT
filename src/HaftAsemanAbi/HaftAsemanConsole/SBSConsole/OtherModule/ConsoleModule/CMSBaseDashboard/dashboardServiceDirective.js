
'use strict'
angular.module('dashboardModule').directive("dashboardService", [function () {
    return {
        replace: true,
        controller: "dashboardServiceCtrl",
        templateUrl: "/HaftAsemanConsole/SBSConsole/OtherModule/ConsoleModule/CMSBaseDashboard/dashboardTmpl.html",
        link: function (scope, ele, attr) {
        },
    };
}]);