
'use strict'
angular.module('RunningServicesModule').directive('hotelTmpl', ['$rootScope', function ($rootScope, orderManagerServices) {
    return {
        replace: true,
        require: '^runningServices',
        scope: {
            hotelPackList: '=',
            hotelPackItem: '=',
            hotelPackIndex: '=',
        },
        templateUrl: '/HaftAsemanView/SBS/SBSOtherModules/ViewProfile/Services/RunningServices/ServiceTmpl/runHotelTmpl.html',
        link: function (scope, ele, attr, ctrl) {
            //#region variable content

            //#endregion
            //#region Event content
            scope.EditHotelPackage = function (orderHotelItem) {
                ctrl.EditHotelInOrder(orderHotelItem);
            };
            scope.DeleteHotelPackageInOrder = function (hotelIndex) {
                ctrl.DeleteHotelPackageInOrder(hotelIndex);
            };
            //#endregion
        },
    };
}]);