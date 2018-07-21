
'use strict'
angular.module('AirplaneServicesModule').controller('airlineServiceCtrl', ['$scope', '$rootScope', 'flightManagerFactory', 'flightPackageManagerFactory', function ($scope, $rootScope, flightManagerFactory, flightPackageManagerFactory) {
    //#region Global variable
    $scope.ShowFillFlight = true;
    $scope.lstPackage = flightPackageManagerFactory.objFlightPackage.SendListPackage();
    //#endregion
    //#region $broadcast content
    $rootScope.$broadcast('changeposition', { val: '_S' });
    $rootScope.$on('EditOrderFlight', function (e, data) {
        flightPackageManagerFactory.objFlightPackage.EditedFromOrderList(data.flightPackage);
        $scope.lstPackage = flightPackageManagerFactory.objFlightPackage.SendListPackage();
    });
    //#endregion
    //#region Event content
    $scope.ShowFillFlightContent = function () {
        $scope.ShowFillFlight = !$scope.ShowFillFlight;
        if ($scope.ShowFillFlight)
            $rootScope.$broadcast('changeposition', { val: '_S' });
        else
            $rootScope.$broadcast('changeposition', { val: 'R_S' });
    };
    //////////////////// Fill Flight Page Event Cotnent
    this.CreateFlightInPackage = function (newFlight, IsMulti) {
        flightManagerFactory.objFlight.AddFlightToPackage(newFlight, IsMulti);
    };
    this.EditFlightInPackage = function (newFlight) {
        flightManagerFactory.objFlight.UpdateFlightToPackage(newFlight);
    };
    //////////////////// Flight Package Page Event Cotnent
    this.EditFlight_In_Package = function (indexOfFlight, PackIndex) {
        flightPackageManagerFactory.objFlightPackage.SelectedPackage(PackIndex);
        flightManagerFactory.objFlight.SelectedFlightInPackage(PackIndex, indexOfFlight);
        $rootScope.$broadcast('set-flight', { flight: flightPackageManagerFactory.objFlightPackage.lstPackage[PackIndex].lstFlight[indexOfFlight] });
    };
    this.DeleteFlight_In_Package = function (indexOfFlight, PackIndex) {
        if (!flightPackageManagerFactory.objFlightPackage.lstPackage[PackIndex].lstFlight[indexOfFlight].IsMulti)
            flightPackageManagerFactory.objFlightPackage.lstPackage[PackIndex].delete = true;
        else if (flightPackageManagerFactory.objFlightPackage.lstPackage[PackIndex].lstFlight[indexOfFlight].IsMulti) {
            flightPackageManagerFactory.objFlightPackage.lstPackage[PackIndex].lstFlight[indexOfFlight].delete = true;
        }
    };
    this.UndoFlight_In_Package = function (indexOfFlight, PackIndex) {
        if (!flightPackageManagerFactory.objFlightPackage.lstPackage[PackIndex].lstFlight[indexOfFlight].IsMulti)
            flightPackageManagerFactory.objFlightPackage.lstPackage[PackIndex].delete = false;
        else if (flightPackageManagerFactory.objFlightPackage.lstPackage[PackIndex].lstFlight[indexOfFlight].IsMulti) {
            flightPackageManagerFactory.objFlightPackage.lstPackage[PackIndex].lstFlight[indexOfFlight].delete = false;
        }
    };
    this.CompletedDeleteFlight_In_Package = function (indexOfFlight, PackIndex) {
        flightPackageManagerFactory.objFlightPackage.DeleteFlightInPackage(indexOfFlight, PackIndex);
        if (flightPackageManagerFactory.objFlightPackage.lstPackage[PackIndex].lstFlight.length === 0)
            flightPackageManagerFactory.objFlightPackage.DeletePackage(PackIndex);
    };
    this.DeletePackage = function (indexOfPackage) {
        flightPackageManagerFactory.objFlightPackage.DeletePackage(indexOfPackage);
    };
    this.ClearFlightPackage = function () {
        $scope.lstPackage = [];
        flightPackageManagerFactory.objFlightPackage.lstPackage = [];
        $rootScope.$broadcast('ClearFlightList', { flightlist: $scope.lstPackage });
    };
    //#endregion
}]);