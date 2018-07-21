
'use strict'
angular.module('ReqCreditLimitServiceMadule').controller('ReqCreditLimitServiceCtrl', ['$scope', '$rootScope', '$location', function ($scope, $rootScope, $location) {
    //#region variable
    //#endregion
    //#region Method
    $scope.PeyOrderWithCredit = function () {
        $rootScope.Status = "گرفتن واچر";
        $location.path('/haft-aseman-abi/CMS-Console/travel-agency/detail-ordering-hotel');
    };
    //#endregion
}]);