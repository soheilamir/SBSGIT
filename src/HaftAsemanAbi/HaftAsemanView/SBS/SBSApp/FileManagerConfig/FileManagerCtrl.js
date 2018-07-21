/// <reference path="D:\RRF Project\NetworkMagazin\New_2\networkMagazine\panelNM\Scripts/angular.js" />
'use strict'
angular.module('FileManagerModule').controller('FileManagerCtrl', ['modalContentFactory', 'allContentInModal', 'fileManagerModel', 'fileFolderManager', '$scope', '$rootScope', 'Upload', '$timeout', function (modalContentFactory, allContentInModal, fileManagerModel, fileFolderManager, $scope, $rootScope, Upload, $timeout) {
    //#region Global variable
    //$scope.modal = new modalContentFactory();
    $scope.showBttnDeleteFolder = true,
    $scope.showBttnDelete = false,
    $scope.showUploader = false;
    $scope.showResult = false;
    $scope.FMItems = new fileManagerModel();
    var rootFolder = {
        Id: 0
    }
    fileFolderManager.folderMethod.GetFolderItems(rootFolder).then(function (result) {
        $scope.FMItems = result.data;
    });
    //#endregion
    //#region Event
    $scope.$watch('files', function () {
        if ($scope.files && $scope.files.length) {
            for (var i = 0; i < $scope.files.length; i++) {
                $scope.errorMsg = null;
                (function (f) {
                    if (!f.$error)
                        $scope.upload(f, true);
                })($scope.files[i]);
            }

            $scope.$apply(function () {
                $scope.files = null;
            });
        }
    });

    $scope.upload = function (file, resumable) {
        uploadUsingUpload(file, resumable);
    };

    function uploadUsingUpload(file, resumable) {
        file.upload = Upload.upload({
            url: 'api/files/',
            headers: {
                'optional-header': 'header-value'
            },
            data: {
                file: file,
                selectedFolderId: $scope.FMItems.selectedFolder.Id
            }
        });
        file.upload.then(function (response) {
            $timeout(function () {
                angular.forEach(response.data.Photos, function (item, index) {
                    $scope.FMItems.files.push(item);
                });
            });
        }, function (response) {
            if (response.status > 0)
                $scope.errorMsg = response.status + ': ' + response.data;
        }, function (evt) {
            // Math.min is to fix IE which reports 200% sometimes
            file.progress = Math.min(100, parseInt(100 * evt.loaded / evt.total));
        });
    };

    //#region Create Folder
    $rootScope.CloseFrm = function () {
        modalContentFactory.modalContent.close("#innermodal");
    };
    $rootScope.AjxCreateFolder = function () {
        ///TODO ajax for create folder
        fileFolderManager.folderMethod.Create($rootScope.folderName, $scope.FMItems).then(function () {
            modalContentFactory.modalContent.close("#innermodal");
        });
    };
    //#endregion
    $scope.CreateFolder = function () {
        modalContentFactory.modalContent.open(allContentInModal.allContent.CreateInnerModal, allContentInModal.allContent.createfolder);
    };
    $scope.selectedFolder = function (fld) {
        if (fld.selected == false) {
            angular.forEach($scope.FMItems.folders, function (item, index) {
                item.selected = false;
            });
            fld.selected = true;
            angular.forEach($scope.FMItems.files, function (item, index) {
                item.selected = false;
            });
            angular.copy(fld, $scope.FMItems.selectedFolder);

            $scope.showBttnDelete = true;
            $scope.showBttnDeleteFolder = true;
        } else {
            fld.selected = false;
            $scope.showBttnDelete = false;
            $scope.showBttnDeleteFolder = false;
            $scope.FMItems.selectedFolder = {};
        }
    };
    $scope.GetFolderItems = function (selectedItem) {
        fileFolderManager.folderMethod.GetFolderItems(selectedItem).then(function (result) {
            if ($rootScope.SelectedFilesList.length > 0)
                angular.forEach(result.data.files, function (item, index) {
                    angular.forEach($rootScope.SelectedFilesList, function (itemSeleted, index) {
                        if (item.Id === itemSeleted.Id)
                            item.selected = true;
                    });
                });
            $scope.FMItems = result.data;
            angular.copy(selectedItem, $scope.FMItems.selectedFolder);
        });
    };
    $scope.DeleteFolder = function (selectedItem) {
        fileFolderManager.folderMethod.DeleteFolder(selectedItem).then(function (result) {
            if (result.data) {
                $scope.FMItems.folders.splice($scope.FMItems.folders.indexOf(selectedItem), 1);
                $timeout(function () {
                    window.alert("پوشه مورد نظر با موفقیت حذف گردید.");
                });
            }
            else {
                $timeout(function () {
                    window.alert("به علت وجود فایل یا پوشه امکان حذف وجود ندارد.");
                });
            }

        });
    };
    $scope.DeleteFiles = function (lstFiles) {
        fileFolderManager.fileMethod.DeleteFiles(GetSelectedFiles()).then(function (result) {
            if (result.data.result.Successful === true) {
                $timeout(function () {
                    window.alert(result.data.result.Message);
                });

                for (var i = 0; i < $scope.FMItems.files.length; i++) {
                    if ($scope.FMItems.files[i].selected === true) {
                        $scope.FMItems.files.splice(i, 1);
                        i--;
                    }
                }

            } else {
                $timeout(function () {
                    window.alert(result.data.result.Message);
                });
            }


        });
    };
    $scope.CheckedFile = function (selected) {
        if (selected === true) {
            angular.forEach($scope.FMItems.folders, function (item, index) {
                item.selected = false;
            });
            $scope.showBttnDelete = true;
            $scope.showBttnDeleteFolder = false;
            $scope.FMItems.selectedFolder = {};
        } else {
            var flagFile = false;
            var flagFolder = false;
            angular.forEach($scope.FMItems.files, function (item, index) {
                if (item.selected === true) {
                    flagFile = true;
                }
            });
            angular.forEach($scope.FMItems.folders, function (item, index) {
                if (item.selected === true) {
                    flagFolder = true;
                }
            });
            if (!flagFile && !flagFolder) {
                $scope.showBttnDelete = false;
                $scope.showBttnDeleteFolder = false;
            };
            if (!flagFile && flagFolder) {
                $scope.showBttnDelete = true;
                $scope.showBttnDeleteFolder = true;
            };
            if (flagFile && !flagFolder) {
                $scope.showBttnDelete = true;
                $scope.showBttnDeleteFolder = false;
            };
        }
    };
    var getUrlParam = function (paramName) {
        var reParam = new RegExp('(?:[\?&]|&)' + paramName + '=([^&]+)', 'i');
        var match = window.location.search.match(reParam);

        return (match && match.length > 1) ? match[1] : null;
    }
    var GetSelectedFiles = function () {
        var result = [];
        angular.forEach($scope.FMItems.files, function (item, index) {
            if (item.selected === true)
                result.push(item);
        });
        return result;
    };
    var ClearSelectedFile = function () {
        angular.forEach($scope.FMItems.files, function (item, index) {
            item.selected = false;
        });
    };
    $scope.AssignToCK = function () {
        var fileUrlT = "";
        $rootScope.baseDefaultData.AssignBttnIsMultiSelectConfig = false;
        if (!$rootScope.baseDefaultData.AssignBttnIsMultiSelectConfig && GetSelectedFiles().length > 1) {
            $timeout(function () {
                window.alert("شما تنها قادر به انتخاب یک فایل می باشید");
                ClearSelectedFile();
            });
        }
        else {
            fileUrlT = GetSelectedFiles()[0].FileUrl;
            //Get File Name
            var fileNameIndex = fileUrlT.lastIndexOf("/") + 1;
            var filename = fileUrlT.substr(fileNameIndex);
            //delete base url from link
            var url = fileUrlT.replace(/^.*\/\/[^\/]+/, '');
            var funcNum = getUrlParam('CKEditorFuncNum');
            var fileUrl = url;
            window.opener.CKEDITOR.tools.callFunction(funcNum, fileUrl);
            window.close();
        }
    };

    $scope.AssignData = function () {
        if ($rootScope.baseDefaultData.AssignBttnIsMultiSelectConfig) {
            $rootScope.$broadcast("fmSelectesFiles", { result: GetSelectedFiles() });
            modalContentFactory.modalContent.close("#basemodal");
        }
        else if (GetSelectedFiles().length > 1) {
            $timeout(function () {
                window.alert("شما تنها قادر به انتخاب یک فایل می باشید");
                ClearSelectedFile();
            });
        }
        else {
            $rootScope.$broadcast("fmSelectesFiles", { result: GetSelectedFiles()[0] });
            modalContentFactory.modalContent.close("#basemodal");
        }
    };
    //#endregion
}]);