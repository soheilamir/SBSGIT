
'use strict'
angular.module('TagModule').controller('TagCtrl', ['$scope', '$rootScope', 'i18nService', '$interval', '$timeout', 'SbsTagModel', 'NewsBlogFactory', 'modalContentFactory', 'allContentInModal', function ($scope, $rootScope, i18nService, $interval, $timeout, SbsTagModel, NewsBlogFactory, modalContentFactory, allContentInModal) {
    $scope.SbsTag = new SbsTagModel();
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
          { name: 'Title', displayName: 'عنوان', enableColumnMenu: false, minWidth: 120, width: 180 },
        ],
        onRegisterApi: function (gridApi) {
            $scope.gridApi = gridApi;
            $scope.gridApi.core.on.columnVisibilityChanged($scope, function (changedColumn) {
                $scope.columnChanged = { name: changedColumn.colDef.name, visible: changedColumn.colDef.visible };
            });
            $scope.gridApi.selection.on.rowSelectionChanged($scope, function (row) {
                if (row.isSelected) {
                    $scope.mySelectedRows = $scope.gridApi.selection.getSelectedRows();
                    angular.copy($scope.mySelectedRows[0], $scope.SbsTag);
                    $scope.ShowBttnSave = false;
                }
                else {
                    $scope.ShowBttnSave = true;
                    $scope.SbsTag = new SbsTagModel();
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

    NewsBlogFactory.FactoryMethod.GetData("sbsTag/GetAllTagsData").then(function (result) {
        $scope.gridOptions.data = result.data;
    });

    $scope.SaveData = function () {
        NewsBlogFactory.FactoryMethod.SaveDataJson($scope.SbsTag, 'sbsTag/SaveData').then(function (result) {
            $timeout(function () {
                window.alert("Yes");
                $scope.SbsTag = new SbsTagModel();
                $scope.gridOptions.data.push(result.data);
            });
        });
    };
    $scope.UpdateData = function () {
        NewsBlogFactory.FactoryMethod.UpdateDataJson($scope.SbsTag, 'sbsTag/UpdateData').then(function (result) {
            $timeout(function () {
                window.alert("Update");
                angular.copy($scope.SbsTag, $scope.mySelectedRows[0]);
                $scope.SbsTag = new SbsTagModel();
                $scope.ShowBttnSave = true;
                $scope.gridApi.selection.clearSelectedRows();
            });
        });
    };
    $scope.DeleteData = function () {
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
        NewsBlogFactory.FactoryMethod.DeleteDataJson($scope.SbsTag, "sbsTag/DeleteData").then(function (result) {
            $timeout(function () {
                window.alert(result.data);
            });
            angular.forEach($scope.gridOptions.data, function (item, index) {
                if (item.Id === $scope.SbsTag.Id)
                    $scope.gridOptions.data.splice(index, 1);
            });
            $scope.SbsTag = new SbsTagModel();
            $scope.ShowBttnSave = true;
            $scope.gridApi.selection.clearSelectedRows();
        });
        modalContentFactory.modalContent.close("#msgmodal");
        modalContentFactory.modalContent.close("#innermodal");
    };
    //#endregion
}]);