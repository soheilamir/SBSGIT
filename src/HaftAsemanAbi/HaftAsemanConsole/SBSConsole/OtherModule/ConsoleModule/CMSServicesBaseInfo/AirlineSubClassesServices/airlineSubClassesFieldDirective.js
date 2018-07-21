
'use strict'
angular.module('airlineSubClassesServicesModule').directive('airlineSubClassesField', ['$rootScope', function ($rootScope) {
    return {
        replace: true,
        scope: {
            airlineList: '=',
            airlineSubClassesModel: '=',
            yContent: '=',
        },
        require: "^airlineSubClassesService",
        templateUrl: "/HaftAsemanConsole/SBSConsole/OtherModule/ConsoleModule/CMSServicesBaseInfo/AirlineSubClassesServices/airlineSubClassesFieldTmpl.html",
        link: function (scope, ele, attr, ctrl) {
            scope.selectedAirline = function (selected) {
                if (selected) {
                    $rootScope.$broadcast("selectedAirlineSubCls", { result: selected.originalObject });
                } else {
                    $rootScope.$broadcast("selectedAirlineSubCls", { result: null });
                }
            }
        },
    }
}])