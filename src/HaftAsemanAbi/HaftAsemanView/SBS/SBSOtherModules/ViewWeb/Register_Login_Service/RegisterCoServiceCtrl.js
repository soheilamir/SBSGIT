
'use strict'
angular.module('regServiceModule').controller('regCoServiceCtrl', ['$scope', '$rootScope', 'RegisterCompanyModel', 'Reg_Login_ServiceManagerFactory', function ($scope, $rootScope, RegisterCompanyModel, Reg_Login_ServiceManagerFactory) {
    //#region variable content
    $scope.nRegCo = new RegisterCompanyModel();
    //#endregion
    //#Event content
    $scope.RegisterCompany = function (newUser) {
        Reg_Login_ServiceManagerFactory._Reg_log_Manager.SaveNewUser(newUser).then(function (result) {
        });
    };
    //#endregion
}]);