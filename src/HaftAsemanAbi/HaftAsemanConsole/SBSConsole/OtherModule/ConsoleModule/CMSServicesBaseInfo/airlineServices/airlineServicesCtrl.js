
'use strict'
angular.module('airlineServicesModule').controller('airlineServicesCtrl', ['$scope', '$rootScope', 'i18nService', '$http', '$interval', '$q', 'ngProgressFactory', 'CMSServicesBaseInfoFactory', 'AirlineModelFactory', 'CountryModelFactory', function ($scope, $rootScope, i18nService, $http, $interval, $q, ngProgressFactory, CMSServicesBaseInfoFactory, AirlineModelFactory, CountryModelFactory) {
    //#region Global variable
    $scope.Country = new CountryModelFactory();
    $scope.Airline = new AirlineModelFactory();
    $scope.dataCountryS = [];
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
          { name: 'Name', displayName: 'نام ایرلاین', enableColumnMenu: false, minWidth: 120, width: 180 },
          { name: 'FlightStateCode', displayName: 'وضعیت پرواز', enableColumnMenu: false, minWidth: 90, width: 110 },
          { name: 'Type', displayName: 'نوع', enableColumnMenu: false, minWidth: 90, width: 110 },
          { name: 'IataCode', displayName: 'Iata Code', enableColumnMenu: false, minWidth: 90, width: 110 },
          { name: 'IacoCode', displayName: 'Iaco Code', enableColumnMenu: false, minWidth: 90, width: 110 },
        ],
        onRegisterApi: function (gridApi) {
            $scope.gridApi = gridApi;
            $scope.gridApi.core.on.columnVisibilityChanged($scope, function (changedColumn) {
                $scope.columnChanged = { name: changedColumn.colDef.name, visible: changedColumn.colDef.visible };
            });
            $scope.gridApi.selection.on.rowSelectionChanged($scope, function (row) {
                if (row.isSelected) {
                    $scope.mySelectedRows = $scope.gridApi.selection.getSelectedRows();
                    $scope.Airline = new AirlineModelFactory();
                    angular.copy($scope.mySelectedRows[0], $scope.Airline);
                    $scope.ShowBttnSave = false;
                }
                else {
                    $scope.ShowBttnSave = true;
                    $scope.Airline = new AirlineModelFactory();
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
    CMSServicesBaseInfoFactory.BaseInfoObj.GetData('airline/getAirlinesData').then(function (result) {
        $scope.gridOptions.data = result.data;
    });
    CMSServicesBaseInfoFactory.BaseInfoObj.GetData('GetCountriesByLangIso').then(function (result) {
        $scope.dataCountryS = result.data;
        $scope.progressbar.complete();
    });
    //#endregion
    $scope.SaveData = function () {
    };
    $scope.UpdateData = function () {
    };
    
}]);