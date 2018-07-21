
'use strict'
angular.module('multiUseModule').controller('RegisterUserCoCtrl', ['$scope', '$rootScope', 'allContentInModal', 'modalContentFactory', function ($scope, $rootScope, allContentInModal, modalContentFactory) {

    //#region Properties
    ////// get all regUser of Company in server
    $rootScope.Isasign = false;
    $scope.SelectedUser = null;
    $scope.acceptedLst = $scope.acceptedLst;
    $scope.unAcceptLst = $scope.unAcceptLst;
    //#endregion
    //#region Method
    $scope.MultiFnRegUser = function (userItem) {
        if ($scope.isModal)
            SelectedUser(userItem);
        else
            ShowInfoUserContent(userItem);
    }
    $rootScope.AsignUserReg = function () {
        angular.forEach($scope.acceptedUserList, function (user, index) {
            if (user.selected)
                $scope.SelectedUser = user;
        });
        $rootScope.$broadcast('userasign', { UserAsign: $scope.SelectedUser });
        modalContentFactory.modalContent.close("#innermodal");
    };
    //#endregion

    //#region private Method
    var SelectedUser = function (userItem) {
        angular.forEach($scope.acceptedUserList, function (user, index) {
            user.selected = false;
        });
        userItem.selected = true;
        $rootScope.Isasign = true;
    };
    var ShowInfoUserContent = function (userItem) {
    };
    //#endregion
}]);