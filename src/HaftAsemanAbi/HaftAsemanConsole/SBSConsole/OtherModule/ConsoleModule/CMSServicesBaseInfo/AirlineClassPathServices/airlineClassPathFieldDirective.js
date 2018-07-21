
'use strict'
angular.module('airlineClassPathServicesModule').directive('airClsPathField', ['$rootScope', function ($rootScope) {
    return {
        replace: true,
        scope: {
            airlineList: '=',
            airClsS: '=',
            airSubClsS: '=',
            airFlightPathS: '=',
            airClsPathFeeS: '=',
            flightConditionS: '=',
            airClsPathModel: '=',
            yContent: '=',
        },
        require: "^airlineClassPathService",
        templateUrl: "/HaftAsemanConsole/SBSConsole/OtherModule/ConsoleModule/CMSServicesBaseInfo/AirlineClassPathServices/airlineClassPathFieldTmpl.html",
        link: function (scope, ele, attr, ctrl) {
            scope.selectedAirline = function (selected) {
                if (selected) {
                    $rootScope.$broadcast("selectedAirline", { result: selected.originalObject });
                } else {
                    $rootScope.$broadcast("selectedAirline", { result: null });
                }
            }
        },
    }

}])