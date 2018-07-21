
'use strict'
angular.module('ResultSearchHotelModule').controller('ResultSearchHotelServiceCtrl', ['$scope', '$location', function ($scope, $location) {
    //#region variable
    //#endregion
    //#region Method
    $scope.ReserveInternalHotel = function () {
        $location.path('/haft-aseman-abi/CMS-Console/travel-agency/request-hotel-before-booking');
    };
    //#endregion
}]);