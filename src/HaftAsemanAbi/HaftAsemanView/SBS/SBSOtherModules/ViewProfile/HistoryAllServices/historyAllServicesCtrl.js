/// <reference path="E:\7BlueSkyProject\SBS(2016_New)\LastProject\SBSWebProject_04-11-95\SBSWebProject_04-11-95\src\HaftAsemanAbi\scripts/jquery-2.1.4.js" />
/// <reference path="E:\7BlueSkyProject\SBS(2016_New)\LastProject\SBSWebProject_04-11-95\SBSWebProject_04-11-95\src\HaftAsemanAbi\scripts/angular.js" />

'use strict'
angular.module('historyAllServicesModule').controller('historyAllServicesCtrl', ['$scope', '$rootScope', '$compile', function ($scope, $rootScope, $compile) {
    //#region properties
    /// flight content
    $scope.lstFlightTicketPassengers = ["1", "2", "3"];
    $scope.lstCondition = ["1", "2"];
    $scope.lstFlightTicketsOfPassenger = [["1"], ["1", "2"], ["1", "2"]], $scope.lastIndexShow_F = null;
    $scope.selectedLstInfoFlightTickets = [];
    ////// hotel content
    $scope.lstHotelRooms = ["1", "2"];
    $scope.selectedLstInfoHotelsVoucher = [];
    $scope.lstHotelsVoucherOfPassenger = [["1"], ["1", "2"]],
    $scope.lastIndexShow_H = null;
    $scope.pos = 'l';
    //#endregion
    $scope.ShowTicketPassenger = function (index, lst) {
        angular.copy(lst, $scope.selectedLstInfoFlightTickets);
        this.elm = angular.element($("#_tr_F_" + index + ""));
        if ($scope.lastIndexShow_F != null) {
            angular.element($("#_gen_tr_F_" + $scope.lastIndexShow_F + "")).remove();
            angular.element($("#_tr_F_" + $scope.lastIndexShow_F + "")).children().first().html("+");
        }
        if ($scope.lastIndexShow_F == index) {
            angular.element($("#_gen_tr_F_" + index + "")).remove();
            angular.element(this.elm).children().first().html("+");
            $scope.lastIndexShow_F = null;
        }
        else {
            angular.element(this.elm).after(FillBodyFlightHTML(index));
            angular.element(this.elm).children().first().html("-");
            $scope.lastIndexShow_F = index;
        }
        $compile(angular.element("#_gen_tr_F_" + index + ""))($scope);
    }
    $scope.ShowHotelsVoucher = function (index, lst) {
        angular.copy(lst, $scope.selectedLstInfoHotelsVoucher);
        this.elm = angular.element($("#_tr_H_" + index + ""));
        if ($scope.lastIndexShow_H != null) {
            angular.element($("#_gen_tr_H_" + $scope.lastIndexShow_H + "")).remove();
            angular.element($("#_tr_H_" + $scope.lastIndexShow_H + "")).children().first().html("+");
        }
        if ($scope.lastIndexShow_H == index) {
            angular.element($("#_gen_tr_H_" + index + "")).remove();
            angular.element(this.elm).children().first().html("+");
            $scope.lastIndexShow_H = null;
        }
        else {
            angular.element(this.elm).after(FillBodyHotelHTML(index));
            angular.element(this.elm).children().first().html("-");
            $scope.lastIndexShow_H = index;
        }
        $compile(angular.element("#_gen_tr_H_" + index + ""))($scope);
    };
    //#region private Method
    var FillBodyFlightHTML = function (index) {
        return "<gen-tr-f id=\"_gen_tr_F_" + index + "\" lst-condition='lstCondition' selected-lst-info-flight-tickets='selectedLstInfoFlightTickets'></gen-tr-f";
    }
    var FillBodyHotelHTML = function (index) {
        return "<gen-tr-h id=\"_gen_tr_H_" + index + "\" selected-lst-info-hotels-voucher='selectedLstInfoHotelsVoucher' pos='pos'></gen-tr-h>";
    }
    //#endregion
}]);