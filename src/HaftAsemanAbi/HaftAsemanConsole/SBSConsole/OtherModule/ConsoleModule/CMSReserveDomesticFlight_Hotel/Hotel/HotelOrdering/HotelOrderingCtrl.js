
'use strict'
angular.module('HotelOrderingModule').controller('HotelOrderingCtrl', ['$scope', '$rootScope', '$http', 'i18nService', '$interval', '$timeout', '$location', function (
    $scope, $rootScope, $http, i18nService, $timeout, $interval, $location) {
    //#region Global Properties
    $scope._h = true;
    $scope.ShowBttn = false;
    $scope.selectedStatus = null;
    $scope.lstOrderHotelStatus = [];
    $scope.langs = i18nService.getAllLangs();
    $scope.lang = 'fa';
    $scope.gridOptions = {
        enableSelectAll: true,
        enableFiltering: true,
        enableSorting: true,
        enableGridMenu: true,
        fastWatch: true,
        columnDefs: [
            { name: 'seq', field: 'name', displayName: 'کد', enableColumnMenu: false, minWidth: 30, width: 35, enableFiltering: false, cellTemplate: '<div class="ui-grid-cell-contents">{{grid.renderContainers.body.visibleRowCache.indexOf(row)+1}}</div>' },
            { name: 'OrderNumber', displayName: 'شماره سفارش', enableColumnMenu: false, minWidth: 120, width: 180 },
            { name: 'OrderDate', displayName: 'تاریخ سفارش', enableColumnMenu: false, minWidth: 120, width: 180 },
            { name: 'OrderStatus', displayName: 'وضعیت سفارش', enableColumnMenu: false, minWidth: 120, width: 180 },
            { name: 'Users', displayName: 'نام مشتری', enableColumnMenu: false, minWidth: 120, width: 180 },
            { name: 'CheckIn', displayName: 'تاریخ ورود', enableColumnMenu: false, minWidth: 120, width: 180 },
            { name: 'CheckOut', displayName: 'تاریخ خروج', enableColumnMenu: false, minWidth: 120, width: 180 },
        ],
        onRegisterApi: function (gridApi) {
            $scope.gridApi = gridApi;
            $scope.gridApi.core.on.columnVisibilityChanged($scope, function (changedColumn) {
                $scope.columnChanged = { name: changedColumn.colDef.name, visible: changedColumn.colDef.visible };
            });
            $scope.gridApi.selection.on.rowSelectionChanged($scope, function (row) {
                if (row.isSelected) {
                    $scope.mySelectedRows = $scope.gridApi.selection.getSelectedRows();
                    $scope.selectedStatus = $scope.mySelectedRows[0].OrderStatus;
                    $scope.ShowBttn = true;
                }
                else {
                    $scope.selectedStatus = null;
                    $scope.ShowBttn = false;
                }
            });
            $scope.gridApi.selection.on.rowSelectionChangedBatch($scope, function (rows) {
            });

            // call resize every 500 ms for 5 s after modal finishes opening - usually only necessary on a bootstrap modal
            $interval(function () {
                $scope.gridApi.core.handleWindowResize();
            }, 1);
        },
    };
    $scope.gridOptions.multiSelect = false;
    $scope.gridOptions.data = [{
        Id: 1,
        OrderNumber: "h2424323423",
        OrderDate: "1396/03/3",
        OrderStatus: "در انتضار تایید هتل",
        Users: "امیر سهیل",
        CheckIn: "1396/03/14",
        CheckOut: "1396/03/15",
    },
    {
        Id: 1,
        OrderNumber: "h2424323423",
        OrderDate: "1396/03/3",
        OrderStatus: "در انتضار پرداخت",
        Users: "امیر سهیل",
        CheckIn: "1396/03/14",
        CheckOut: "1396/03/15",
    },
    {
        Id: 1,
        OrderNumber: "h2424323423",
        OrderDate: "1396/03/3",
        OrderStatus: "گرفتن واچر",
        Users: "امیر سهیل",
        CheckIn: "1396/03/14",
        CheckOut: "1396/03/15",
    }];
    //#endregion
    $scope.ShowDetailHistoryHotelOrder = function () {
        if ($scope.selectedStatus === "در انتضار تایید هتل")
            $location.path('/haft-aseman-abi/CMS-Console/travel-agency/send-req-hotel');
        if ($scope.selectedStatus === "در انتضار پرداخت") {
            $rootScope.Status = $scope.selectedStatus;
            $location.path('/haft-aseman-abi/CMS-Console/travel-agency/detail-ordering-hotel');
        }
        if ($scope.selectedStatus === "گرفتن واچر") {
            $rootScope.Status = $scope.selectedStatus;
            $location.path('/haft-aseman-abi/CMS-Console/travel-agency/detail-ordering-hotel');
        }
    };
}]);