
'use strict'
angular.module('WsPagesBannerModule').controller('WsPagesBannerCtrl', ['$scope', '$rootScope', 'i18nService', '$interval', '$timeout', 'WsPagesBannerModel', 'BaseWebsitePagesFactory', 'modalContentFactory', 'allContentInModal', function ($scope, $rootScope, i18nService, $interval, $timeout, WsPagesBannerModel, BaseWebsitePagesFactory, modalContentFactory, allContentInModal) {
    $scope.WsPagesBanner = new WsPagesBannerModel();
    $scope.ShowBttnSave = true;
    $scope.lstWebPages = [];
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
          { name: 'WebPagesItem.PageName', displayName: 'نام صفحه', enableColumnMenu: false, minWidth: 120, width: 180 },
          { name: 'Title', displayName: 'عنوان بنر', enableColumnMenu: false, minWidth: 120, width: 180 },
        ],
        onRegisterApi: function (gridApi) {
            $scope.gridApi = gridApi;
            $scope.gridApi.core.on.columnVisibilityChanged($scope, function (changedColumn) {
                $scope.columnChanged = { name: changedColumn.colDef.name, visible: changedColumn.colDef.visible };
            });
            $scope.gridApi.selection.on.rowSelectionChanged($scope, function (row) {
                if (row.isSelected) {
                    $scope.mySelectedRows = $scope.gridApi.selection.getSelectedRows();
                    angular.copy($scope.mySelectedRows[0], $scope.WsPagesBanner);
                    $scope.ShowBttnSave = false;
                }
                else {
                    $scope.ShowBttnSave = true;
                    $scope.WsPagesBanner = new WsPagesBannerModel();
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
    ///////// Set FilesItems
    $scope.$on("fmSelectesFiles", function (e, data) {
        angular.copy(data.result, $scope.WsPagesBanner.FilesItem);
    });

    //#region METHOD 

    $rootScope.CloseForm = function () {
        modalContentFactory.modalContent.close("#innermodal");
    };
    $rootScope.CloseMsg = function () {
        modalContentFactory.modalContent.close("#msgmodal");
    };

    BaseWebsitePagesFactory.BWPFactory.GetData("webpages/GetWebpagesData").then(function (result) {
        $scope.lstWebPages = result.data;
        BaseWebsitePagesFactory.BWPFactory.GetWebpagesBannerData("webpagesBanner/GetWebpagesBannerData").then(function (result) {
            $scope.gridOptions.data = result.data;
        });
    });
    $scope.SaveData = function (model) {
        BaseWebsitePagesFactory.BWPFactory.SaveDataJson(model, 'webpagesBanner/SaveData').then(function (result) {
            $timeout(function () {
                window.alert("Yes");
                $scope.WsPagesBanner = new WsPagesBannerModel();
                $scope.gridOptions.data.push(result.data);
            });
        });
    };
    $scope.UpdateData = function (model) {
        BaseWebsitePagesFactory.BWPFactory.UpdateDataJson(model, 'webpagesBanner/UpdateData').then(function (result) {
            $timeout(function () {
                window.alert("Update");
                angular.copy(model, $scope.mySelectedRows[0]);
                $scope.WsPagesBanner = new WsPagesBannerModel();
                $scope.ShowBttnSave = true;
                $scope.gridApi.selection.clearSelectedRows();
            });
        });
    };

    $scope.ShowFileManagerContent = function () {
        modalContentFactory.modalContent.open(allContentInModal.allContent.CreateModal, allContentInModal.allContent.createFileManager);
        $rootScope.baseData.AssignBttnIsMultiSelectConfig = false;
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
        BaseWebsitePagesFactory.BWPFactory.DeleteDataJson($scope.WsPagesBanner, "webpagesBanner/DeleteData").then(function (result) {
            $timeout(function () {
                window.alert(result.data);
            });
            angular.forEach($scope.gridOptions.data, function (item, index) {
                if (item.Id === $scope.WsPagesBanner.Id)
                    $scope.gridOptions.data.splice(index, 1);
            });
            $scope.WsPagesBanner = new WsPagesBannerModel();
            $scope.ShowBttnSave = true;
            $scope.gridApi.selection.clearSelectedRows();
        });
        modalContentFactory.modalContent.close("#msgmodal");
        modalContentFactory.modalContent.close("#innermodal");
    };
    //#endregion
}]);