

'use strict'
angular.module('CmsFrameworkModule').controller('CmsFrameworkCtrl', ['$scope', '$rootScope', function ($scope, $rootScope) {
    //#region Global variable
    $scope.lstReq = ['1', '2', '3'];
    $scope.menuObj = {
        active: true,
    }
    //#endregion
    $scope.toggelMenu = function () {
        $scope.menuObj.active = !$scope.menuObj.active;
    };

}]);