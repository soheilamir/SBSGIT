
'use strict'
angular.module('regServiceModule').controller('regServiceCtrl', ['$scope', '$rootScope', 'NewUserModelFactory', 'Reg_Login_ServiceManagerFactory', '$location', function ($scope, $rootScope, NewUserModelFactory, Reg_Login_ServiceManagerFactory, $location) {
    //#region variable content
    $scope.nUser = new NewUserModelFactory();
    //#endregion
    //#Event content
    $scope.RegisterNewUsers = function (newUser) {
        Reg_Login_ServiceManagerFactory._Reg_log_Manager.SaveNewUser(newUser).then(function (result) {
        });
    };
    $scope.GoToRegCo = function () {
        $location.path('/haft-aseman-abi/travel-agency/company/sbs-register-company');
    };
    //#endregion
}]);