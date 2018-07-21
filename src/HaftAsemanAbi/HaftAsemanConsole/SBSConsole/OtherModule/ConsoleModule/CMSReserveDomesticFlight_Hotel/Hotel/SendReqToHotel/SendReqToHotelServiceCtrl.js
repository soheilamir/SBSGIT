
'use strict'
angular.module('SendReqToHotelServiceMadule').controller('SendReqToHotelServiceCtrl', ['$scope', '$rootScope', '$location', function ($scope, $rootScope, $location) {
    //#region variable
    //#endregion
    //#region Method
    $scope.ConfirmationHotel = function () {
        $rootScope.Status = "در انتضار پرداخت";
        $location.path('/haft-aseman-abi/CMS-Console/travel-agency/detail-ordering-hotel');
    }
    //#endregion
}]);