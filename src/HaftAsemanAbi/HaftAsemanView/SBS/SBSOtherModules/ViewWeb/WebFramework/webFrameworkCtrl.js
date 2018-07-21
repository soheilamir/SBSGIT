
'use strict'
angular.module('webFrameworkModule').controller('webframeworkCtrl', ['$scope', '$rootScope', 'DomesticHotelBookingServiceModelFactory', 'ReqHotelBookingServiceModelFactory', 'DomesticHotelBookingServiceFactory', function ($scope, $rootScope, DomesticHotelBookingServiceModelFactory, ReqHotelBookingServiceModelFactory, DomesticHotelBookingServiceFactory) {

    //#region Global variable 
    $scope._Menu = {
        _Tm_c: '50px',
        _Rm_c: '-63px',
    }
    $scope.$on("documentClicked", _close);
    $scope.$on("escapePressed", _close);
    var hub = $.connection.onlineVisitorsHub;
    $scope.Usercount = 0;
    $scope.lastSelectedHeaderItem = null;
    $scope.locationInfo = $rootScope.baseData.locationInfo;
    $scope.currencyInfo = $rootScope.baseData.currencyInfo;
    var location = {
        selected: false,
    }
    var currency = {
        selected: false,
    }
    var feedback = {
        selected: false,
    }
    $scope.headerItemList = [location, currency, feedback];
    //#endregion
    //#region Event content
    function _close() {
        $scope.$apply(function () {
            angular.forEach($scope.headerItemList, function (item, index) {
                item.selected = false;
                $scope.lastSelectedHeaderItem = null;
            });
        });
    };
    $scope.ISActiveHeaderItem = function (itemContent, e) {
        if ($scope.lastSelectedHeaderItem == null) {
            $scope.lastSelectedHeaderItem = itemContent;
            itemContent.selected = true;
        }
        else {
            if (itemContent === $scope.lastSelectedHeaderItem) {
                itemContent.selected = false;
                $scope.lastSelectedHeaderItem = null;
            }
            else {
                $scope.lastSelectedHeaderItem.selected = false;
                itemContent.selected = true;
                $scope.lastSelectedHeaderItem = itemContent;
            }
        }
        e.stopPropagation();
    };
    //#endregion
    //#region signalr client
    hub.client.usersConnected = function (numUsers) { //this instanciate the usersConnected function receiving the numUsers parameter which is the number of users connected
        $scope.Usercount = numUsers; //show the number of users connected inside a div
        $scope.$apply();
    };
    $.connection.hub.start().done(function () {
    });
    //#endregion

}]);