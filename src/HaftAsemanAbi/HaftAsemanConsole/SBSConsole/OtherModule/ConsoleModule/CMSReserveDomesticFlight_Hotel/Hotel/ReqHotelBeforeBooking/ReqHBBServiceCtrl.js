
'use strict'
angular.module('ReqHBBServiceMadule').controller('ReqHBBServiceCtrl', ['$scope', '$location', function ($scope, $location) {
    //#region variable
    //#endregion
    //#region Method
    $scope.GetOrderingBookingHotel = function () {
        $location.path('/haft-aseman-abi/CMS-Console/travel-agency/send-req-hotel');
    };
    //#endregion

}]);