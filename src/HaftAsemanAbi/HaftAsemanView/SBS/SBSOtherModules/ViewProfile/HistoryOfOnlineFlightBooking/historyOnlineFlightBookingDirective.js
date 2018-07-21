
'use strict'
angular.module('historyOnlineFlightBookingModule').directive('bookingOnlineHistoryServices', [function () {
    return {
        replace: true,
        controller: 'historyOnlineFlightBookingCtrl',
        templateUrl: "/HaftAsemanView/SBS/SBSOtherModules/ViewProfile/HistoryOfOnlineFlightBooking/historyOnlineFlightBookingTmpl.html",
    };
}]);