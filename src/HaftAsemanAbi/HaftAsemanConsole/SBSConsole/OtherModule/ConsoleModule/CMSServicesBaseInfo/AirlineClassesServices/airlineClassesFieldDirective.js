
'use strict'
angular.module('airlineClassesServicesModule').directive('airlineClassesField', ['$rootScope', function ($rootScope) {
    return {
        replace: true,
        scope: {
            airlineList: '=',
            airlineClassesModel: '=',
            yContent: '=',
        },
        require: "^airlineClassesService",
        templateUrl: "/HaftAsemanConsole/SBSConsole/OtherModule/ConsoleModule/CMSServicesBaseInfo/AirlineClassesServices/airlineClassesFieldTmpl.html",
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