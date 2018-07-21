
'use strict'
angular.module('DetailOrderingHotelServiceMadule').controller('DetailOrderingHotelServiceCtrl', ['$scope', '$rootScope', '$location', function ($scope, $rootScope, $location) {
    //#region variable
    $scope.ShowVocher = false;
    if ($rootScope.Status === "در انتضار پرداخت")
        $scope.ShowVocher = false;
    if ($rootScope.Status === "گرفتن واچر")
        $scope.ShowVocher = true;
    //#endregion
    //#region Method
    $scope.ReqCreditLimit = function () {
        $location.path('/haft-aseman-abi/CMS-Console/req-credit-limit');
    };
    $scope.GetVocherPassenger = function () {
        $location.path('/haft-aseman-abi/CMS-Console/travel-agency/passenger-vocher-hotel');
    };
    
    
    //#endregion
}]);