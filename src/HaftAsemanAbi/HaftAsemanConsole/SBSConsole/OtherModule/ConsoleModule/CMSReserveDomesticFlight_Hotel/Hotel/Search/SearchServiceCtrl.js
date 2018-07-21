
'use strict'
angular.module('SearchHotelModule').controller('SearchHotelCtrl', ['$scope', '$location', function ($scope, $location) {
    //#region variable
    //#endregion
    //#region Method
    $scope.SearchInternalHotel = function () {
        $location.path('/haft-aseman-abi/CMS-Console/travel-agency/booking/domestic/domestic-hotel-booking-service');
    };
    //#endregion
}]);