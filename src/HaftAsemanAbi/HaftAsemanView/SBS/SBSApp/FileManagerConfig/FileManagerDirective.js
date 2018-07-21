
angular.module('FileManagerModule').directive('fileManagerContainer', [function () {
    return {
        controller: 'FileManagerCtrl',
        scope: {
            showAssign: '=',
            showCkAssign: '=',
        },
        replace: true,
        templateUrl: '/HaftAsemanView/SBS/SBSApp/FileManagerConfig/FileManagerTmpl.html',
        link: function (scope, ele, attr) {
        }
    }
}]).directive('dropTorget', [function () {
    return {
        link: function ($scope, ele, attr) {
            ele.bind('dragover', function (e) {
                e.stopPropagation();
                e.preventDefault();
                $scope.$apply(function () {
                    $scope.showUploader = true;
                });
            });
            ele.bind('dragleave', function (e) {
                e.stopPropagation();
                e.preventDefault();
                $scope.$apply(function () {
                    $scope.showUploader = false;
                });
            });
            ele.bind('drop', function (e) {
                e.stopPropagation();
                e.preventDefault();
                $scope.$apply(function () {
                    $scope.showUploader = false;
                    $scope.showResult = true;
                });
            });
        },
    };
}]);