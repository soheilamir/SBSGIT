
'use strict'
angular.module('flightPathServicesModule').directive('flightPathField', ['$rootScope', function ($rootScope) {
    return {
        replace: true,
        scope: {
            flightPathModel: '=',
            countrys: '=',
            yContent: '=',
        },
        require: "^flightPathService",
        templateUrl: "/HaftAsemanConsole/SBSConsole/OtherModule/ConsoleModule/CMSServicesBaseInfo/FlightPathServices/flightPathFieldTmpl.html",
        link: function (scope, ele, attr, ctrl) {
            scope.StateS = [];
            scope.CityS = [];
        },
    }

}])