
'use strict'
angular.module('UserCompanyPaymentReqModule').controller('UserCompanyPaymentReqCtrl', ['$scope', '$rootScope', '$location', function ($scope, $rootScope, $location) {
    // fill in rootScope for peyment

    $scope.objReserveFlight = $rootScope.baseData.objReserveFlight;
    $scope.DomesticFlightInfo = $rootScope.baseData.DomesticFlightInfo;

    //#region Method
    $scope.OnlineBankPeyment = function () {
        $location.path('/sbs/profile/sbs-services/flight/detail/ordering');
    };
    $scope.CreditPeyment = function () {
        $location.path('/sbs/profile/sbs-services/flight/detail/ordering');
    };
    //#endregion
}]);