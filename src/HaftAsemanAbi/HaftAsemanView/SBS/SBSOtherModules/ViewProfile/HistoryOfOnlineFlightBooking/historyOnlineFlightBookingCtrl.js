
'use strict'
angular.module('historyOnlineFlightBookingModule').controller('historyOnlineFlightBookingCtrl', ['$scope', '$rootScope', 'localStorageService', function ($scope, $rootScope, localStorageService) {
    //////////////////////////////////////////// اطلاعات زیر به صورت فیک است

    $scope.FlightInfo = localStorageService.get('SendDataTickets');
    $scope.AcceptOrder = function () {
        localStorageService.set('ticketsDataFlag', { ticketsData: true });
        window.alert("تایید خرید آنلاین انجام شد");
    }

    ///////////////////////////// End
}]);