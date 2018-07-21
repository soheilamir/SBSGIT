
'use strict'
angular.module('FacilitiesCategoryModule').controller('FacilitiesCategoryCtrl', ['$scope', '$rootScope', 'i18nService', '$http', '$interval', '$q', 'ngProgressFactory', 'facilitiesCategoryModel', 'FacilitiesCategoryFactory', function ($scope, $rootScope, i18nService, $http, $interval, $q, ngProgressFactory, facilitiesCategoryModel, FacilitiesCategoryFactory) {
    //#region Global variable
    $scope.FacilitiesCategory = new facilitiesCategoryModel();
    $scope.ShowBttnSave = true;
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
          { name: 'CategoryName', displayName: 'نام دسته امکانات', enableColumnMenu: false, minWidth: 120, width: 180 },
        ],
        onRegisterApi: function (gridApi) {
            $scope.gridApi = gridApi;
            $scope.gridApi.core.on.columnVisibilityChanged($scope, function (changedColumn) {
                $scope.columnChanged = { name: changedColumn.colDef.name, visible: changedColumn.colDef.visible };
            });
            $scope.gridApi.selection.on.rowSelectionChanged($scope, function (row) {
                if (row.isSelected) {
                    $scope.mySelectedRows = $scope.gridApi.selection.getSelectedRows();
                    angular.copy($scope.mySelectedRows[0], $scope.FacilitiesCategory);
                    ////////
                    $scope.ShowBttnSave = false;
                }
                else {
                    $scope.FacilitiesCategory = new facilitiesCategoryModel();
                    $scope.ShowBttnSave = true;
                    ///////
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
    $scope.progressbar = ngProgressFactory.createInstance();
    $scope.progressbar.setColor("#3F92D6");
    $scope.progressbar.start();
    $scope.gridOptions.multiSelect = false;
    FacilitiesCategoryFactory.BaseObjFactory.GetData('facilitiesCategory/getAll').then(function (result) {
        $scope.gridOptions.data = result.data;
        $scope.progressbar.complete();
    });

    //#endregion
    //#region Method variable
    $scope.SaveData = function (data) {
        $scope.progressbar.start();
        FacilitiesCategoryFactory.BaseObjFactory.SaveData('facilitiesCategory/add', data).then(function (result) {
            if (angular.isDefined($scope.closeThisDialog)) {
                $scope.FacilitiesCategory = new facilitiesCategoryModel();
                $scope.FacilitiesCategory = result.data;
                $scope.FacilitiesCategory.Update = false;
                $scope.closeThisDialog($scope.FacilitiesCategory);
            }
            $scope.gridOptions.data.push(result.data);
            $scope.FacilitiesCategory = new facilitiesCategoryModel();
            $scope.progressbar.complete();
        });
    };
    $scope.UpdateData = function (data) {
        $scope.progressbar.start();
        FacilitiesCategoryFactory.BaseObjFactory.UpdateData('facilitiesCategory/edit', data).then(function (result) {
            angular.copy(result.data, $scope.mySelectedRows[0]);
            $scope.FacilitiesCategory = new facilitiesCategoryModel();
            $scope.progressbar.complete();
        });
    };
    $scope.DeleteData = function (data) {
        $scope.progressbar.start();
        FacilitiesCategoryFactory.BaseObjFactory.DeleteData('facilitiesCategory/delete', data).then(function (result) {
            angular.forEach($scope.gridOptions.data, function (item, index) {
                if (item.Id === $scope.FacilitiesCategory.Id)
                    $scope.gridOptions.data.splice(index, 1);
            });
            $scope.FacilitiesCategory = new facilitiesCategoryModel();
            $scope.progressbar.complete();
        });
    };
    //#endregion


}]);