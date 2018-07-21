
'use strict'
angular.module('PublicPlaceModule').controller('PublicPlaceCtrl', ['$scope', '$rootScope', 'i18nService', '$http', '$interval', '$q', 'ngProgressFactory', 'publicPlaceNameByLangModel', 'PublicPlaceFactory', function ($scope, $rootScope, i18nService, $http, $interval, $q, ngProgressFactory, publicPlaceNameByLangModel, PublicPlaceFactory) {
    //#region Global variable
    $scope.publicPlace = new publicPlaceNameByLangModel();
    $scope.lstLangs = [];
    $scope.lstCountrys = [];
    $scope.lstStateProvinces = [];
    $scope.lstCitys = [];
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
          { name: 'CountryName', displayName: 'نام کشور', enableColumnMenu: false, minWidth: 120, width: 180 },
          { name: 'StateProvinceName', displayName: 'نام استان', enableColumnMenu: false, minWidth: 120, width: 180 },
          { name: 'CityName', displayName: 'نام شهر', enableColumnMenu: false, minWidth: 120, width: 180 },
          { name: 'LanguageName', displayName: 'زبان', enableColumnMenu: false, minWidth: 120, width: 180 },
          { name: 'Name', displayName: 'نام مکان', enableColumnMenu: false, minWidth: 120, width: 180 },
        ],
        onRegisterApi: function (gridApi) {
            $scope.gridApi = gridApi;
            $scope.gridApi.core.on.columnVisibilityChanged($scope, function (changedColumn) {
                $scope.columnChanged = { name: changedColumn.colDef.name, visible: changedColumn.colDef.visible };
            });
            $scope.gridApi.selection.on.rowSelectionChanged($scope, function (row) {
                if (row.isSelected) {
                    $scope.mySelectedRows = $scope.gridApi.selection.getSelectedRows();
                    ////////
                    $scope.ShowBttnSave = false;
                }
                else {
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

    //CMSServicesBaseInfoFactory.BaseInfoObj.GetData('airline/getAirlinesData').then(function (result) {
    //    $scope.gridOptions.data = result.data;
    //    $scope.progressbar.complete();
    //});

    //#endregion
    //#region Method variable
    $scope.SaveData = function () {
    };
    $scope.UpdateData = function () {
    };
    $scope.DeleteData = function () {
    };
    //#endregion


}]);