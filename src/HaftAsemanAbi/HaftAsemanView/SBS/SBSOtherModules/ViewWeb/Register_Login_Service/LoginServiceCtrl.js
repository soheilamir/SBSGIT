
'use strict'
angular.module('loginServiceModule').controller('loginServiceCtrl', ['$scope', '$rootScope', 'AuthManager', '$window', 'LoginModelFactory', '$http', function ($scope, $rootScope, AuthManager, $window, LoginModelFactory, $http) {
    //variable content
    if (AuthManager.objAuth.authentication.isAuth)
        //$window.location.href = 'http://localhost:24258/UserProfile.html#/sbs/user-profile/profile';
        $window.location.href = 'http://localhost:24258/CompanyProfile.html#/sbs/company-profile/company-page';
    else {
        $scope.auth = new LoginModelFactory();
        //  ///////////////// Event content
        $scope.login = function () {
            AuthManager.objAuth.login($scope.auth).then(function (response) {
                // $window.location.href = 'http://localhost:24258/UserProfile.html#/sbs/user-profile/profile';
                $window.location.href = 'http://localhost:24258/CompanyProfile.html#/sbs/company-profile/company-page';
            });
        };
    }
}]);