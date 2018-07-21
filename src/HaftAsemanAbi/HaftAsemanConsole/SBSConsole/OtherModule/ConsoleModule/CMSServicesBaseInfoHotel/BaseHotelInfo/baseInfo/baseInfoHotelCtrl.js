
'use strict'
angular.module('BaseInfoHotelModule').controller('BaseInfoHotelCtrl', ['$scope', '$rootScope', 'i18nService', '$http', '$interval', '$q', 'ngProgressFactory', function ($scope, $rootScope, i18nService, $http, $interval, $q, ngProgressFactory) {
    //#region Global variable
    $scope.ShowBttnSave = true;
    $scope.ShowBttnOther = false;
    $scope.ShowBttnPre_1 = false;
    $scope.ShowBttnPre_2 = false;
    $scope.ShowBttnSec_1 = true;
    $scope.ShowBttnSec_2 = false;
    $scope.Sec_1 = true;
    $scope.Sec_2 = false;
    $scope.Sec_3 = false;
    //#endregion
    //#region Method
    $scope.SecConfig = function (sec_1, sec_2, sec_3) {
        if (sec_1) {
            $scope.ShowBttnPre_1 = false;
            $scope.ShowBttnPre_2 = false;
            $scope.ShowBttnSec_1 = true;
            $scope.ShowBttnSec_2 = false;
        }
        if (sec_2) {
            $scope.ShowBttnSec_1 = false;
            $scope.ShowBttnPre_1 = true;
            $scope.ShowBttnPre_2 = false;

            $scope.ShowBttnSec_2 = true;
        }
        if (sec_3) {
            $scope.ShowBttnPre_1 = false;
            $scope.ShowBttnPre_2 = true;
            $scope.ShowBttnSec_2 = false;
        }

        $scope.Sec_1 = sec_1;
        $scope.Sec_2 = sec_2;
        $scope.Sec_3 = sec_3;
    };
    $scope.SaveData = function () {
    };
    $scope.UpdateData = function () {
    };
    $scope.DeleteData = function () {
    };
    //#endregion


}]);