
'use strict'
angular.module('uploadFileModule').directive("uploadfileService", [function () {
    return {
        replace: true,
        controller: "uploadFileServiceCtrl",
        templateUrl: "/HaftAsemanConsole/SBSConsole/OtherModule/uploadFile/uploadFileTmpl.html",
        link: function (scope, ele, attr) {
        },
    };
}]);