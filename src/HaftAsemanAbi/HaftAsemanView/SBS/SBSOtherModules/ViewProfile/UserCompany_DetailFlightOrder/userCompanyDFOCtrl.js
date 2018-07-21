
'use strict'
angular.module('userCompanyDFOModule').controller('userCompanyDFOCtrl', ['$scope', '$rootScope', '$location', function ($scope, $rootScope, $location) {
    // fill in rootScope for peyment

    $scope.objReserveFlight = $rootScope.baseData.objReserveFlight;
    $scope.DomesticFlightInfo = $rootScope.baseData.DomesticFlightInfo;
    $scope.$on('print', function () {
        $location.path('/sbs/profile/sbs-services/print/flight/flgiht-ticket');
    });
}]);