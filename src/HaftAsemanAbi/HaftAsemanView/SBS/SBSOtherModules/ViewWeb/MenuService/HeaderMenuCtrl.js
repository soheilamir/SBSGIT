
'use strict'
angular.module('headerMenuModule').controller('headerMenuCtrl', ['$scope', '$rootScope', function ($scope, $rootScope) {
    $scope.ShowSection_1 = false;
    $scope.ShowSection_2 = false;
    this.HideSection = function () {
        $scope.ShowSection_1 = false;
    };
    this.HideSection_2 = function () {
        $scope.ShowSection_2 = false;
    };
}]);