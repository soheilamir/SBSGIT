
'use strict'
angular.module('WsPagesContextModule').controller('WsPagesContextCtrl', ['$scope', '$rootScope', 'i18nService', '$interval', '$timeout', 'WsPagesContextModel', 'BaseWebsitePagesFactory', 'modalContentFactory', 'allContentInModal', function ($scope, $rootScope, i18nService, $interval, $timeout, WsPagesContextModel, BaseWebsitePagesFactory, modalContentFactory, allContentInModal) {
    $scope.WsPagesContext = new WsPagesContextModel();
    $scope.lstWebPages = [];
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
          { name: 'WebPagesItem.PageName', displayName: 'نام صفحه', enableColumnMenu: false, minWidth: 120, width: 180 },
        ],
        onRegisterApi: function (gridApi) {
            $scope.gridApi = gridApi;
            $scope.gridApi.core.on.columnVisibilityChanged($scope, function (changedColumn) {
                $scope.columnChanged = { name: changedColumn.colDef.name, visible: changedColumn.colDef.visible };
            });
            $scope.gridApi.selection.on.rowSelectionChanged($scope, function (row) {
                if (row.isSelected) {
                    $scope.mySelectedRows = $scope.gridApi.selection.getSelectedRows();
                    angular.copy($scope.mySelectedRows[0], $scope.WsPagesContext);
                    $scope.ShowBttnSave = false;
                }
                else {
                    $scope.ShowBttnSave = true;
                    $scope.WsPagesContext = new WsPagesContextModel();
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
        BaseWebsitePagesFactory.BWPFactory.GetWebpagesContextData("webpagesContext/GetWebpagesContextData").then(function (result) {
            $scope.gridOptions.data = result.data;
        });
    });

    $scope.SaveData = function (model) {
        BaseWebsitePagesFactory.BWPFactory.SaveDataJson(model, 'webpagesContext/SaveData').then(function (result) {
            $timeout(function () {
                window.alert("Yes");
                $scope.WsPagesContext = new WsPagesContextModel();
                $scope.gridOptions.data.push(result.data);
                $rootScope.$broadcast('update');
            });
        });
    };
    $scope.UpdateData = function (model) {
        BaseWebsitePagesFactory.BWPFactory.UpdateDataJson(model, 'webpagesContext/UpdateData').then(function (result) {
            $timeout(function () {
                window.alert("Update");
                angular.copy(model, $scope.mySelectedRows[0]);
                $scope.WsPagesContext = new WsPagesContextModel();
                $scope.ShowBttnSave = true;
                $scope.gridApi.selection.clearSelectedRows();
                $rootScope.$broadcast('update');
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
        BaseWebsitePagesFactory.BWPFactory.DeleteDataJson($scope.WsPagesContext, "webpagesContext/DeleteData").then(function (result) {
            $timeout(function () {
                window.alert(result.data);
            });
            angular.forEach($scope.gridOptions.data, function (item, index) {
                if (item.Id === $scope.WsPagesContext.Id)
                    $scope.gridOptions.data.splice(index, 1);
            });
            $scope.WsPagesContext = new WsPagesContextModel();
            $scope.ShowBttnSave = true;
            $scope.gridApi.selection.clearSelectedRows();
        });
        modalContentFactory.modalContent.close("#msgmodal");
        modalContentFactory.modalContent.close("#innermodal");
    };
    //#endregion
}]);