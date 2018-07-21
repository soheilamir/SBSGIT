
'use strict'
angular.module('airlineSubClassesServicesModule').controller('airlineSubClassesServicesCtrl', ['$scope', '$rootScope', '$http', 'ngProgressFactory', 'CMSServicesBaseInfoFactory', 'AirlineClassesModelFactory', function ($scope, $rootScope, $http, ngProgressFactory, CMSServicesBaseInfoFactory, AirlineClassesModelFactory) {
    //#region Global variable
    $scope.AirlineSubClasses = new AirlineClassesModelFactory();
    $scope.progressbar = ngProgressFactory.createInstance();
    $scope.progressbar.setColor("#3F92D6");
    $scope.progressbar.start();
    $scope.dataAirlineS = [];
    $scope.ShowBttnSave = true;
    $scope.showGrid = true;
    $scope.yContent = true;
    CMSServicesBaseInfoFactory.BaseInfoObj.GetData('airline/getAirlinesData').then(function (result) {
        $scope.dataAirlineS = result.data;
        $scope.progressbar.complete();
    });
    $scope.SaveData = function (airlineItem, AirlineClasses) {
    };
    $scope.UpdateData = function (airlineItem, AirlineClasses) {
    };
    $scope.DeleteData = function () {
    };
    //#endregion
}]);