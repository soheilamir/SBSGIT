
'use strict'
angular.module('multiUseModule').controller('checkoutTicketCtrl', ['$scope', '$rootScope', '$routeParams', 'ManageDomesticFlightReserveProcessFactory', 'FlightTicketDataWithOrderIdModelFactory', function ($scope, $rootScope, $routeParams, ManageDomesticFlightReserveProcessFactory, FlightTicketDataWithOrderIdModelFactory) {
    $scope.FlightTicketDataWithOrderId = new FlightTicketDataWithOrderIdModelFactory();
    ManageDomesticFlightReserveProcessFactory.DomesticFlightReserveProcessFactory.TicketDataWithOrderId($routeParams.refrenceId).then(function (result) {
        $scope.FlightTicketDataWithOrderId = result.data;
    });
}]);