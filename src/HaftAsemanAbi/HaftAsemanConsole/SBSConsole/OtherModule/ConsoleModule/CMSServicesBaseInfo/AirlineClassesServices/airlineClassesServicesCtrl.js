
'use strict'
angular.module('airlineClassesServicesModule').controller('airlineClassesServicesCtrl', ['$scope', '$rootScope', '$http', 'ngProgressFactory', 'CMSServicesBaseInfoFactory', 'AirlineClassesModelFactory', function ($scope, $rootScope, $http, ngProgressFactory, CMSServicesBaseInfoFactory, AirlineClassesModelFactory) {
    //#region Global variable
    $scope.AirlineClasses = new AirlineClassesModelFactory();
    $scope.progressbar = ngProgressFactory.createInstance();
    $scope.progressbar.setColor("#3F92D6");
    $scope.progressbar.start();
    $scope.dataAirlineS = [];
    $scope.ShowBttnSave = true;
    $scope.showGrid = true;
    $scope.yContent = true;
    $scope.$on('selectedAirline', function (e, data) {
        $scope.AirlineClasses.AirlineItem = data.result;
    });
    CMSServicesBaseInfoFactory.BaseInfoObj.GetData('airline/getAirlinesData').then(function (result) {
        $scope.dataAirlineS = result.data;
        $scope.progressbar.complete();
    });
    $scope.SaveData = function () {
    };
    $scope.UpdateData = function () {
    };
    $scope.DeleteData = function () {
    };
    //#endregion
}]);