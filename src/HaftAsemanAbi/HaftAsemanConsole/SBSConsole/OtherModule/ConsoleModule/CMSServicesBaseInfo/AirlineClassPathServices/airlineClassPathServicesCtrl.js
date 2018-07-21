
'use strict'
angular.module('airlineClassPathServicesModule').controller('airlineClassPathServicesCtrl', ['$scope', '$rootScope', '$http', 'ngProgressFactory', 'CMSServicesBaseInfoFactory', 'AirlineClassPathModelFactory', function ($scope, $rootScope, $http, ngProgressFactory, CMSServicesBaseInfoFactory, AirlineClassPathModelFactory) {
    //#region Global variable
    $scope.AirlineClassPath = new AirlineClassPathModelFactory();
    $scope.progressbar = ngProgressFactory.createInstance();
    $scope.progressbar.setColor("#3F92D6");
    $scope.progressbar.start();
    $scope.dataAirlineS = [];
    $scope.AirlineClassesS = [];
    $scope.AirlineSubClasseS = [];
    $scope.FlightPathS = [];
    $scope.FlightConditionS = [];
    $scope.AirClsPathFeeS = [];
    $scope.ShowBttnSave = true;
    $scope.showGrid = true;
    $scope.yContent = true;
    $scope.$on('selectedAirline', function (e, data) {
        $scope.AirlineClasses.AirlineItem = data.result;
    });
    $scope.SaveData = function () {
    };
    $scope.UpdateData = function () {
    };
    $scope.DeleteData = function () {
    };
    //#endregion
}]);