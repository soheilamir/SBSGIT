
'use strict'
angular.module('WsPagesModule').controller('WsPagesCtrl', ['$scope', '$rootScope', 'i18nService', '$interval', '$timeout', 'WsPagesModel', 'BaseWebsitePagesFactory', 'modalContentFactory', 'allContentInModal', function ($scope, $rootScope, i18nService, $interval, $timeout, WsPagesModel, BaseWebsitePagesFactory, modalContentFactory, allContentInModal) {
    $scope.WsPages = new WsPagesModel();
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
          { name: 'PageName', displayName: 'نام صفحه', enableColumnMenu: false, minWidth: 120, width: 180 },
          { name: 'Title', displayName: 'عنوان', enableColumnMenu: false, minWidth: 120, width: 180 },
          { name: 'RoutUrl', displayName: 'RoutUrl', enableColumnMenu: false, minWidth: 120, width: 180 },
          { name: 'SourceUrl', displayName: 'SourceUrl', enableColumnMenu: false, minWidth: 120, width: 180 },
        ],
        onRegisterApi: function (gridApi) {
            $scope.gridApi = gridApi;
            $scope.gridApi.core.on.columnVisibilityChanged($scope, function (changedColumn) {
                $scope.columnChanged = { name: changedColumn.colDef.name, visible: changedColumn.colDef.visible };
            });
            $scope.gridApi.selection.on.rowSelectionChanged($scope, function (row) {
                if (row.isSelected) {
                    $scope.mySelectedRows = $scope.gridApi.selection.getSelectedRows();
                    angular.copy($scope.mySelectedRows[0], $scope.WsPages);
                    $scope.ShowBttnSave = false;
                }
                else {
                    $scope.ShowBttnSave = true;
                    $scope.WsPages = new WsPagesModel();
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

    //#region METHOD 

    $rootScope.CloseForm = function () {
        modalContentFactory.modalContent.close("#innermodal");
    };
    $rootScope.CloseMsg = function () {
        modalContentFactory.modalContent.close("#msgmodal");
    };

    BaseWebsitePagesFactory.BWPFactory.GetData("webpages/GetWebpagesData").then(function (result) {
        $scope.gridOptions.data = result.data;
    });

    $scope.SaveData = function (model) {
        BaseWebsitePagesFactory.BWPFactory.SaveDataJson(model, 'webpages/SaveData').then(function (result) {
            $timeout(function () {
                window.alert("Yes");
                $scope.WsPages = new WsPagesModel();
                $scope.gridOptions.data.push(result.data);
            });
        });
    };
    $scope.UpdateData = function (model) {
        BaseWebsitePagesFactory.BWPFactory.UpdateDataJson(model, 'webpages/UpdateData').then(function (result) {
            $timeout(function () {
                window.alert("Update");
                angular.copy(model, $scope.mySelectedRows[0]);
                $scope.WsPages = new WsPagesModel();
                $scope.ShowBttnSave = true;
                $scope.gridApi.selection.clearSelectedRows();
            });
        });
    };
    $scope.DeleteData = function (model) {
        $rootScope.fn = VerifyDeleted;
        $rootScope.Msg = {
            title: "هشدار",
            context: "آیا مایل به حذف می باشید؟",
            bttnText: "حذف اطلاعات"
        }
        modalContentFactory.modalContent.open(allContentInModal.allContent.CreateMsgModal, allContentInModal.allContent.createMsgContent);
    };
    $rootScope.YesBttn = function (fn) {
        fn();
    };
    var VerifyDeleted = function () {
        BaseWebsitePagesFactory.BWPFactory.DeleteDataJson($scope.WsPages, "webpages/DeleteData").then(function (result) {
            $timeout(function () {
                window.alert(result.data);
            });
            angular.forEach($scope.gridOptions.data, function (item, index) {
                if (item.Id === $scope.WsPages.Id)
                    $scope.gridOptions.data.splice(index, 1);
            });
            $scope.WsPages = new WsPagesModel();
            $scope.ShowBttnSave = true;
            $scope.gridApi.selection.clearSelectedRows();
        });
        modalContentFactory.modalContent.close("#msgmodal");
        modalContentFactory.modalContent.close("#innermodal");
    };
    //#endregion
}]);