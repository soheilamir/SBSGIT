
'use strict'
angular.module('FileManagerModule').factory('fileManagerModel', [function () {
    var fileManagerModel = function (fm) {
        var _fm = this;
        if (!fm) {
            _fm.folders = [];
            _fm.files = [];
            _fm.selectedFolder = {};
            _fm.clipboard = {};
            _fm.upFolder = {};
        }
        else
            _fm = fm;
    };
    return fileManagerModel;
}]);
angular.module('FileManagerModule').factory('fileFolderManager', ['$rootScope', '$http', '$timeout', function ($rootScope, $http, $timeout) {
    var folderMethod = {
        Create: function (folderName, fmItem) {
            var folder = {
                Name: folderName,
            };
            return $http({
                method: 'POST',
                url: "http://localhost:15609/fileManager/AddFolders",
                data: { folder: folder, folderItem: fmItem.selectedFolder },
                headers: { 'Content-Type': 'application/json' }
            }).success(function (data) {
                if (data.Name != null)
                    fmItem.folders.push(data);
                else
                    $timeout(function () {
                        window.alert("نام پوشه تکراری است.");
                    });
            });
        },
        GetFolderItems: function (selectedFolder) {
            return $http({
                method: 'POST',
                url: "http://localhost:15609/fileManager/GetFolderItems",
                data: JSON.stringify(selectedFolder),
                headers: { 'Content-Type': 'application/json' }
            });
        },
        DeleteFolder: function (selectedFolder) {
            return $http({
                method: 'POST',
                url: "http://localhost:15609/fileManager/DeleteFolder",
                data: JSON.stringify(selectedFolder),
                headers: { 'Content-Type': 'application/json' }
            });
        }

    };
    var fileMethod = {
        DeleteFiles: function (lstFiles) {
            return $http({
                method: 'Delete',
                url: "http://localhost:15609/fileManager/DeleteFile",
                data: JSON.stringify({ lstFiles: lstFiles }),
                headers: { 'Content-Type': 'application/json' }
            });
        }
    };
    return { folderMethod: folderMethod, fileMethod: fileMethod };
}]);