﻿
'use strict'
angular.module('airlineClassesServicesModule').directive('airclassGridContent', ['$rootScope', 'i18nService', '$interval', function ($rootScope, i18nService, $interval) {
    return {
        replace: true,
        scope: {
            showGrid: '=',
        },
        require: "^airlineClassesService",
        templateUrl: "/HaftAsemanConsole/SBSConsole/OtherModule/ConsoleModule/CMSServicesBaseInfo/AirlineClassesServices/gridContentTmpl.html",
        link: function (scope, ele, attr, ctrl) {
            //#region variable
            scope.langs = i18nService.getAllLangs();
            scope.lang = 'fa';
            scope.gridOptions = {
                enableSelectAll: true,
                enableFiltering: true,
                enableSorting: true,
                enableGridMenu: true,
                fastWatch: true,
                columnDefs: [
                  { name: 'seq', field: 'name', displayName: 'کد', enableColumnMenu: false, minWidth: 30, width: 35, enableFiltering: false, cellTemplate: '<div class="ui-grid-cell-contents">{{grid.renderContainers.body.visibleRowCache.indexOf(row)+1}}</div>' },
                  { name: 'AirlineItem.Name', displayName: 'نام ایرلاین', enableColumnMenu: false, minWidth: 120, width: 180 },
                  { name: 'FlightClassName', displayName: 'نام کلاس پروازی', enableColumnMenu: false, minWidth: 120, width: 180 },
                ],
                onRegisterApi: function (gridApi) {
                    scope.gridApi = gridApi;
                    scope.gridApi.core.on.columnVisibilityChanged(scope, function (changedColumn) {
                        scope.columnChanged = { name: changedColumn.colDef.name, visible: changedColumn.colDef.visible };
                    });
                    scope.gridApi.selection.on.rowSelectionChanged(scope, function (row) {
                        if (row.isSelected) {
                            scope.mySelectedRows = scope.gridApi.selection.getSelectedRows();
                        }
                        else {
                        }
                    });
                    scope.gridApi.selection.on.rowSelectionChangedBatch(scope, function (rows) {
                    });
                    // call resize every 500 ms for 5 s after modal finishes opening - usually only necessary on a bootstrap modal
                    $interval(function () {
                        scope.gridApi.core.handleWindowResize();
                    }, 1);
                },
            };
            scope.gridOptions.multiSelect = false;
            //#endregion
        },
    }

}])