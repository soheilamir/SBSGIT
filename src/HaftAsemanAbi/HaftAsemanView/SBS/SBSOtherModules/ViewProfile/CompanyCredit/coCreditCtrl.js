
'use strict'
angular.module('coCreditModule').controller('coCreditCtrl', ['$scope', '$rootScope', '$http', 'i18nService', '$interval', '$timeout',
    function ($scope, $rootScope, $http, i18nService, $interval, $timeout) {
        //#region properties
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
                { name: 'TransactionNumber', displayName: 'شماره تراکنش', enableColumnMenu: false, minWidth: 120, width: 180 },
                { name: 'TransactionDate', displayName: 'تاریخ تراکنش', enableColumnMenu: false, minWidth: 120, width: 180 },
                { name: 'TransactionPrice', displayName: 'مبلغ تراکنش', enableColumnMenu: false, minWidth: 120, width: 180 },
                { name: 'CreditBalance', displayName: 'مانده اعتبار', enableColumnMenu: false, minWidth: 120, width: 180 },
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
        //#endregion
        //#region Method

        //#endregion
    }]);