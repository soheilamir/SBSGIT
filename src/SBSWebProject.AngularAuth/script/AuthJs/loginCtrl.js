
'use strict'
angular.module('LoginAuthModule').controller('loginAuthCtrl', ['$scope', '$rootScope', 'AuthManager', '$location', function ($scope, $rootScope, AuthManager, $location) {
    //variable content
    $scope.auth = {
        userName: "",
        password: "",
        useRefreshTokens: false
    };
    $scope.userName = AuthManager.objAuth.authentication.userName;
    $scope.isAuth = AuthManager.objAuth.authentication.isAuth;
    //  ///////////////// Event content
    $scope.login = function () {
        AuthManager.objAuth.login($scope.auth).then(function (response) {
            $scope.userName = AuthManager.objAuth.authentication.userName;
            $scope.isAuth = AuthManager.objAuth.authentication.isAuth;
            $location.path('/success');
        },
         function (err) {
             $scope.message = err.error_description;
         });
    };
}]);