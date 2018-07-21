
'use strict'
angular.module('WsPagesCatModule').controller('WsPagesCatCtrl', ['$scope', '$rootScope', 'i18nService', '$interval', '$timeout', 'WsPagesCatModel', 'BaseWebsitePagesFactory', 'modalContentFactory', 'allContentInModal', function ($scope, $rootScope, i18nService, $interval, $timeout, WsPagesCatModel, BaseWebsitePagesFactory, modalContentFactory, allContentInModal) {
    $scope.lstWebpageCat = [];
    $scope.lstWebPages = [];
    $scope.WsPagesCat = new WsPagesCatModel();
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
          { name: 'Title', displayName: 'نام دسته', enableColumnMenu: false, minWidth: 120, width: 180 },
          { name: 'WebsiteCategoryItem.Title', displayName: 'نام زیر دسته', enableColumnMenu: false, minWidth: 120, width: 180 },
          { name: 'WebPagesItem.PageName', displayName: 'عنوان صفحه', enableColumnMenu: false, minWidth: 120, width: 180 },
        ],
        onRegisterApi: function (gridApi) {
            $scope.gridApi = gridApi;
            $scope.gridApi.core.on.columnVisibilityChanged($scope, function (changedColumn) {
                $scope.columnChanged = { name: changedColumn.colDef.name, visible: changedColumn.colDef.visible };
            });
            $scope.gridApi.selection.on.rowSelectionChanged($scope, function (row) {
                if (row.isSelected) {
                    $scope.mySelectedRows = $scope.gridApi.selection.getSelectedRows();
                    angular.copy($scope.mySelectedRows[0], $scope.WsPagesCat);
                    $scope.ShowBttnSave = false;
                }
                else {
                    $scope.ShowBttnSave = true;
                    $scope.WsPagesCat = new WsPagesCatModel();
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
        $scope.lstWebPages = result.data;
        BaseWebsitePagesFactory.BWPFactory.GetWebpagesCatData("webpagesCat/GetWebpagesCatData").then(function (result) {
            $scope.gridOptions.data = result.data;
            $scope.lstWebpageCat = result.data;
        });
    });


    $scope.SaveData = function (model) {
        // model.WebsiteCategoryItem = null;
        BaseWebsitePagesFactory.BWPFactory.SaveDataJson(model, 'webpagesCat/SaveData').then(function (result) {
            $timeout(function () {
                window.alert("Yes");
                $scope.WsPagesCat = new WsPagesCatModel();
                $scope.gridOptions.data.push(result.data);
                $scope.lstWebpageCat.push(result.data);

            });
        });
    };
    $scope.UpdateData = function (model) {
        BaseWebsitePagesFactory.BWPFactory.UpdateDataJson(model, 'webpagesCat/UpdateData').then(function (result) {
            $timeout(function () {
                window.alert("Update");
                angular.copy(model, $scope.mySelectedRows[0]);
                $scope.WsPagesCat = new WsPagesCatModel();
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
        BaseWebsitePagesFactory.BWPFactory.DeleteDataJson($scope.WsPagesCat, "webpagesCat/DeleteData").then(function (result) {
            $timeout(function () {
                window.alert(result.data);
            });
            angular.forEach($scope.gridOptions.data, function (item, index) {
                if (item.Id === $scope.WsPagesCat.Id)
                    $scope.gridOptions.data.splice(index, 1);
            });
            $scope.WsPagesCat = new WsPagesCatModel();
            $scope.ShowBttnSave = true;
            $scope.gridApi.selection.clearSelectedRows();
        });
        modalContentFactory.modalContent.close("#msgmodal");
        modalContentFactory.modalContent.close("#innermodal");
    };
    //#endregion
}]);