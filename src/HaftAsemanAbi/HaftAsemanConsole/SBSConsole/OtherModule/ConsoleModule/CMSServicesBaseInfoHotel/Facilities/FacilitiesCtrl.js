
'use strict'
angular.module('FacilitiesModule').controller('FacilitiesCtrl', ['$scope', '$rootScope', 'i18nService', '$http', '$interval', '$q', 'ngProgressFactory', 'facilitiesNameByLangModel', 'BaseInfoFactory', 'FacilitiesFactory', 'FacilitiesCategoryFactory', 'ngDialog', function ($scope, $rootScope, i18nService, $http, $interval, $q, ngProgressFactory, facilitiesNameByLangModel, BaseInfoFactory, FacilitiesFactory, FacilitiesCategoryFactory, ngDialog) {
    //#region Global variable
    $scope.Facilities = new facilitiesNameByLangModel();
    $scope.lstFacilitiesCats = [];
    $scope.facilitiesLst = [];
    $scope.lstLangs = [];
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
          { name: 'LanguageName', displayName: 'زبان', enableColumnMenu: false, minWidth: 120, width: 180 },
          { name: 'Name', displayName: 'نام امکانات', enableColumnMenu: false, minWidth: 120, width: 180 },
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
    FacilitiesCategoryFactory.BaseObjFactory.GetData('facilitiesCategory/getAll').then(function (result) {
        $scope.lstFacilitiesCats = result.data;
        BaseInfoFactory.LanguageFactory.GetData('languages/getAll').then(function (result) {
            $scope.lstLangs = result.data;
            $scope.progressbar.complete();
        });
    });

    //#endregion
    //#region Method
    $scope.ShowPageContent = function () {
        ngDialog.open({
            template: '/HaftAsemanConsole/SBSConsole/OtherModule/ConsoleModule/CMSServicesBaseInfoHotel/FacilitiesCategory/FacilitiesCategoryTmpl.html',
            controller: 'FacilitiesCategoryCtrl',
            className: 'ngdialog-theme-default',
            width: '80%',
            preCloseCallback: function (value) {
                if (value === "$closeButton")
                    return null;
                if (!value.Update) {
                    $scope.lstFacilitiesCats.push(value);
                    $scope.Facilities.FacilitiesItem = value;
                }
                else if (value.Update) {
                    angular.forEach($scope.lstFacilitiesCats, function (item, index) {
                        if (item.Id === value.Id) {
                            angular.copy(value, item);
                            $scope.Facilities.FacilitiesItem = value;
                        }
                    });
                }
            }
        });
    };
    $scope.AddFacilitiesByLang = function (model) {
        $scope.facilitiesLst.push(model);
        $scope.Facilities = new facilitiesNameByLangModel();
    };
    $scope.DeleteFacilitesItem = function (indexOfList) {
        $scope.facilitiesLst.splice(indexOfList, 1);
    };
    $scope.SaveData = function () {
    };
    $scope.UpdateData = function () {
    };
    $scope.DeleteData = function () {
    };
    //#endregion


}]);