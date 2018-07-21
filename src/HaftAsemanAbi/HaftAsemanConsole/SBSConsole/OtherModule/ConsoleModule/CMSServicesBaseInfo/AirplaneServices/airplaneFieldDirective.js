
'use strict'
angular.module('airplaneServicesModule').directive('airplaneField', [function () {
    return {
        replace: true,
        scope: {
            airplaneModel: '=',
            yContent: '=',
        },
        require: "^airplaneService",
        templateUrl: "/HaftAsemanConsole/SBSConsole/OtherModule/ConsoleModule/CMSServicesBaseInfo/AirplaneServices/airplaneFieldTmpl.html",
        link: function (scope, ele, attr, ctrl) {
        }
    }

}])