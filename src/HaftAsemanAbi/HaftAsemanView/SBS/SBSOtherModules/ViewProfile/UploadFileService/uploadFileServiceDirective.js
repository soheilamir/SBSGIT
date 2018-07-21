
'use strict'
angular.module('uploadFileModule').directive("uploadfileService", [function () {
    return {
        replace: true,
        controller: "uploadFileServiceCtrl",
        templateUrl: "/HaftAsemanView/SBS/SBSOtherModules/ViewProfile/UploadFileService/uploadFileTmpl.html",
        link: function (scope, ele, attr) {
        },
    };
}]);