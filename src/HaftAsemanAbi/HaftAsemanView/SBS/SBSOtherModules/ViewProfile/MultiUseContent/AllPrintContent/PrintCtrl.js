'use strict'
angular.module('multiUseModule').controller('printServicesCtrl', ['$scope', '$rootScope', function ($scope, $rootScope) {
    //#region Properties
    /// flight content
    $scope.LstInfoFlightTickets = ["1", "2"];
    $scope.lstCondition = ["1", "2"];
    /// hotel content
    $scope.LstInfoHotelsVoucher = ["1", "2"];
    $scope.pos = 'l';
    //#endregion
}]);