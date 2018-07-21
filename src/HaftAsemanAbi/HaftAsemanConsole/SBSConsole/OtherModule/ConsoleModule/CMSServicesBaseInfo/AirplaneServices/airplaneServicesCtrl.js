
'use strict'
angular.module('airplaneServicesModule').controller('airplaneServicesCtrl', ['$scope', '$rootScope','$http', 'ngProgressFactory', 'CMSServicesBaseInfoFactory', 'AirplaneModelFactory', function ($scope, $rootScope, $http, ngProgressFactory, CMSServicesBaseInfoFactory, AirplaneModelFactory) {
    //#region Global variable
    $scope.Airplane = new AirplaneModelFactory();
    $scope.progressbar = ngProgressFactory.createInstance();
    $scope.progressbar.setColor("#3F92D6");
    $scope.progressbar.start();
    $scope.ShowBttnSave = true;
    $scope.showGrid = true;
    $scope.yContent = true;
    CMSServicesBaseInfoFactory.BaseInfoObj.GetData('').then(function (result) {
        $rootScope.$broadcast("grid", { gridList: result.data });
    });
    $scope.SaveData = function () {
    };
    $scope.UpdateData = function () {
    };
    $scope.DeleteData = function () {
    };
    //#endregion
}]);