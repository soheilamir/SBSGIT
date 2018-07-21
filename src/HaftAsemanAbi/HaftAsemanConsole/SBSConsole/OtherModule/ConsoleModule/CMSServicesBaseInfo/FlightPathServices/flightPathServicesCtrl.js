
'use strict'
angular.module('flightPathServicesModule').controller('flightPathServicesCtrl', ['$scope', '$rootScope', '$http', 'ngProgressFactory', 'CMSServicesBaseInfoFactory', 'FlightPathModelFactory', function ($scope, $rootScope, $http, ngProgressFactory, CMSServicesBaseInfoFactory, FlightPathModelFactory) {
    //#region Global variable
    $scope.FlightPath = new FlightPathModelFactory();
    $scope.progressbar = ngProgressFactory.createInstance();
    $scope.progressbar.setColor("#3F92D6");
    $scope.progressbar.start();
    $scope.CountryS = [];
    $scope.ShowBttnSave = true;
    $scope.showGrid = true;
    $scope.yContent = false;
    CMSServicesBaseInfoFactory.BaseInfoObj.GetData('GetCountriesByLangIso').then(function (result) {
        $scope.CountryS = result.data;
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