'use strict'
angular.module('LoginAuthModule').controller('SuccessCtrl', ['$http', '$scope', '$location', 'AuthManager', function ($http, $scope, $location, AuthManager) {
    var BaseUrI = 'http://localhost:9983/';
    $http({
        method: 'GET',
        url: BaseUrI + 'api/V1/GetUser',
        headers: { 'Content-Type': 'application/json' }
    }).then(function (results) {
        $scope.result = results;
    });
    $scope.logOut= function() {
        AuthManager.objAuth.logOut();
        $location.path('/login');
    }
}]);